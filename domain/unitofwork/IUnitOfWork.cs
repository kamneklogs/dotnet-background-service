using e08.domain.model;
using e08.domain.repository;

namespace e08.domain.unitofwork;

public interface IUnitOfWork : IDisposable
{
    IRepository<CityTime> CityTimeRepository { get; }
    Task<bool> Complete();
}