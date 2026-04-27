namespace MyApp.Singleton
{
    public sealed class LoggerSingleton
    {
        private static readonly Lazy<LoggerSingleton> _instance = new(() => new LoggerSingleton());
     
        private LoggerSingleton() { }
        
        public static LoggerSingleton Instance => _instance.Value;
        
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}