using e08.infrastructure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<CountryTimeService>();
    })
    .Build();

host.Run();
