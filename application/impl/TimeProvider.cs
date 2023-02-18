using System.Globalization;
using e08.domain.model;
using e08.domain.unitofwork;

namespace e08.application.impl;

public class TimeProvider : ITimeProvider
{
    private IEnumerable<CityTime>? cityTimes;

    public TimeProvider(IUnitOfWork unitOfWork)
    {
        cityTimes = unitOfWork.CityTimeRepository.GetAll().Result;
    }

    public void PrintTime()
    {
        foreach (CityTime cityTime in cityTimes ?? Enumerable.Empty<CityTime>())
        {
            Console.WriteLine($"City: {cityTime.City}");
            System.Console.WriteLine($"Timezone: {cityTime.TimeZone}");
            System.Console.WriteLine($"Time: {DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.FFFzzz", CultureInfo.InvariantCulture)}\n");
        }
    }
}