using System.Collections.Generic;
using RentIdentity.Data.Entities;

namespace RentIdentity.DAL.RepositoryInterfaces
{
    public interface IRentalUnitRepository : IRepository<RentalUnit>
    {
        IEnumerable<RentalUnit> GetUnitsByAvailability(bool isAvailable);
        IEnumerable<RentalUnit> GetRentalUnitById(int id);
    }
}
