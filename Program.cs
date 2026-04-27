using MyApp.Repository;
using MediatR;
using MyApp.Factory;
using MyApp.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation;
using MyApp.Queries.Models;
using MyApp.Validators;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using MyApp.Interface;
using MyApp.CustomMiddleware;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{ 
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please JWT token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    
options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<DelegateService>();
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
builder.Services.AddScoped<IPaymentService, UpiPaymentService>();  
builder.Services.AddScoped<StaticWeatherService>();
builder.Services.AddScoped<RandomWeatherService>();
builder.Services.AddScoped<UpiPaymentService>();
builder.Services.AddSingleton<CreditCardPaymentService>();

builder.Services.AddSingleton<WorkerState>();
builder.Services.AddScoped<Printer>();
builder.Services.AddHostedService<WorkerService>();
builder.Services.AddScoped<IValidator<Employee>, EmployeeValidator>();

//builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddScoped<IWeatherServiceFactory, WeatherServiceFactory>();
builder.Services.AddMemoryCache();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        }
    );
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Fastest;
});


builder.Services.AddAuthorization();

builder.Services.AddDistributedMemoryCache();  //In-memory fake distributed cache. for local testing 

//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = "localhost:6379";
//    options.InstanceName = "MyApp";
//});

//builder.Services.AddDistributedSqlServerCache(); // SQL caching 


// Rate Limiting Middleware
builder.Services.AddRateLimiter(options =>
{
    //options.AddTokenBucketLimiter("token", opt =>
    //options.AddConcurrencyLimiter("concurrency", opt =>
    //options.AddSlidingWindowLimiter("sliding", opt =>
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 5;
        opt.Window = TimeSpan.FromSeconds(20);
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
       // opt.QueueLimit = 2;
    });

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

        await context.HttpContext.Response.WriteAsync("Too many requests. Please try again later.");
    };

});

var app = builder.Build();


// Minimal API endpoint
app.MapGet("/greetings", (string name, IPaymentService ser) =>
{
    return  $"Hello {name} from Minimal API";
}).WithTags("MinimalAPIs");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCompression();
app.UseMiddleware<GlobalExceptionMiddleware>();
//app.UseExceptionHandler("/error"); 
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();

//app.UseMiddleware<SimpleMiddleware>();

app.MapControllers();

app.Run();
