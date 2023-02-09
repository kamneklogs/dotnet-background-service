using e08.application;
using e08.application.impl;
using e08.infrastructure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<TimeService>();

        services.AddSingleton<ITimeProvider, TimeProvider>(); // Same instance for all consumers
        // services.AddTransient<ITimeProvider, TimeProvider>(); // New instance for each consumer
        // services.AddScoped<ITimeProvider, TimeProvider>(); // New instance for each scope, an exception is thrown, search for more info with Pedro
    })
    .Build();

host.Run();