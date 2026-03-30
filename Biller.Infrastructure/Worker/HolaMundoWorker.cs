using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Biller.Infrastructure.Worker;

public class HolaMundoWorker : BackgroundService
{
    private readonly ILogger<HolaMundoWorker> _logger;
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(3);

    public HolaMundoWorker(ILogger<HolaMundoWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Hola mundo - {Time}", DateTimeOffset.UtcNow);
            await Task.Delay(_interval, stoppingToken);
        }
    }
}
