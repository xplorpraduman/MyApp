namespace MyApp.Service
{
    public class WorkerService(ILogger<WorkerService> _logger, WorkerState _workerState) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _workerState.IsRunning = true;

            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(3000, cancellationToken);
            }
            _workerState.IsRunning = false;
        }
    }
}
