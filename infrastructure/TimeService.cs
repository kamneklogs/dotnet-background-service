using e08.application;

namespace e08.infrastructure;

public class TimeService : BackgroundService
{

    private readonly ITimeProvider _timeProvider;

    public TimeService(ITimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _timeProvider.PrintTime();

            await Task.Delay(1000 * 30, stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        System.Console.WriteLine("Background service completed");

        await base.StopAsync(stoppingToken);
    }
}
