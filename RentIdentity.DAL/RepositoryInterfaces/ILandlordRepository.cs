using System.Collections.Generic;
using RentIdentity.Data.Entities;

namespace RentIdentity.DAL.RepositoryInterfaces
{
    public interface ILandlordRepository : IRepository<Landlord>
    {
        IEnumerable<Landlord> GetLandlordsById(int id);
    }
}
