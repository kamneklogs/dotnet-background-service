using e08.domain.model;
using e08.domain.repository;
using e08.domain.repository.impl;
using e08.domain.unitofwork;
using Microsoft.EntityFrameworkCore;

namespace e07.domain.unitofwork;

public class UnitOfWork : IUnitOfWork
{

    private readonly DbContext _context;

    private IRepository<CityTime> _cityTimeRepository;
    public IRepository<CityTime> CityTimeRepository => _cityTimeRepository;


    public UnitOfWork(DbContext context)
    {
        _context = context;
        _cityTimeRepository = new Repository<CityTime>(context);
    }

    public async Task<bool> Complete() => await _context.SaveChangesAsync() > 0;

    public void Dispose() => _context.Dispose();
}