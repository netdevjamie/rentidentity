using RentIdentity.Data;
using RentIdentity.DAL.Repositories;
using RentIdentity.DAL.RepositoryInterfaces;

namespace RentIdentity.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentIdentityDb _context;

        public ILandlordRepository Landlords { get; private set; }
        public IRentalUnitRepository RentalUnits { get; private set; }

        public UnitOfWork(RentIdentityDb context)
        {
            _context = context;
            RentalUnits = new RentalUnitRepository(_context);
            Landlords = new LandlordRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
