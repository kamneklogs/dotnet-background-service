using System.Collections.ObjectModel;
using System.Globalization;
using TimeZoneConverter;

namespace e08.application.impl;

public class TimeProvider : ITimeProvider
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

    private Dictionary<string, TimeZoneInfo> _timeZones = new Dictionary<string, TimeZoneInfo>();

    private readonly string uuid = Guid.NewGuid().ToString();

    public TimeProvider()
    {
        foreach (string timeZone in cityXtimeZones)
        {
            string[] parts = timeZone.Split(';');
            string city = parts[0];
            string ianaTimeZone = parts[1];
            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(TZConvert.IanaToWindows(ianaTimeZone));
            _timeZones.Add(city, zone);
        }
    }

    public void PrintTime()
    {
        System.Console.WriteLine($"UUID: {uuid}");
/* 
        foreach (KeyValuePair<string, TimeZoneInfo> timeZone in _timeZones)
        {
            Console.WriteLine($"City: {timeZone.Key}");
            System.Console.WriteLine($"Timezone: {TZConvert.WindowsToIana(timeZone.Value.Id)}");
            System.Console.WriteLine($"Time: {DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.FFFzzz", CultureInfo.InvariantCulture)}\n");
        } */
    }
}