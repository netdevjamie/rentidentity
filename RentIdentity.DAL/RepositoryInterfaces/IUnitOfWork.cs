using System;

namespace RentIdentity.DAL.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRentalUnitRepository RentalUnits { get; }
        ILandlordRepository Landlords { get; }


        int Complete();
    }
}
