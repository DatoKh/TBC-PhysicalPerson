using Common.Domain.Seedwork;
using TBC.Domain.Entities.CityAggregate;
using TBC.Domain.Entities.PersonAggregate;

namespace TBC.Domain.SeedWork
{
    public interface IUnitOfWork : IGenericUnitOfWork
    {
        ICityRepository CityRepository { get; }
        IPersonRepository PersonRepository { get; }
    }
}
