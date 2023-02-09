using System.Collections.ObjectModel;
using System.Globalization;
using TimeZoneConverter;

namespace e08.infrastructure;

public class CountryTimeService : BackgroundService
{

    private Dictionary<string, TimeZoneInfo> _timeZones = new Dictionary<string, TimeZoneInfo>();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ReadOnlyCollection<string> cityXtimeZones =
        new ReadOnlyCollection<string>(new List<string>
        {
            "Bogota;America/Bogota",
            "Chicago;America/Chicago",
            "Argentina;America/Argentina/Buenos_Aires",
            "Detroit;America/Detroit",
            "London;Europe/London"
        });

        foreach (string timeZone in cityXtimeZones)
        {
            string[] parts = timeZone.Split(';');
            string city = parts[0];
            string ianaTimeZone = parts[1];
            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(TZConvert.IanaToWindows(ianaTimeZone));
            _timeZones.Add(city, zone);
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (KeyValuePair<string, TimeZoneInfo> timeZone in _timeZones)
            {
                Console.WriteLine($"City: {timeZone.Key}");
                System.Console.WriteLine($"Timezone: {TZConvert.WindowsToIana(timeZone.Value.Id)}");
                System.Console.WriteLine($"Time: {DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.FFFzzz", CultureInfo.InvariantCulture)}\n");
            }

            await Task.Delay(1000 * 30, stoppingToken);
        }
    }
}
