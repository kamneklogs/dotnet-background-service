using e07.domain.unitofwork;
using e08.application;
using e08.application.impl;
using e08.domain.repository;
using e08.domain.repository.impl;
using e08.domain.unitofwork;
using e08.infrastructure;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<TimeService>();

        services.AddSingleton<ITimeProvider, TimeProvider>();

        services.AddSingleton<DbContext, CountryTimeDBContext>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
    })
    .Build();

host.Run();