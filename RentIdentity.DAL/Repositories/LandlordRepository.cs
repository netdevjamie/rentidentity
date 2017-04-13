using System.Collections.Generic;
using System.Data.Entity;
using RentIdentity.Data;
using RentIdentity.Data.Entities;
using RentIdentity.DAL.RepositoryInterfaces;
using System.Linq;

namespace RentIdentity.DAL.Repositories
{
    public class LandlordRepository : Repository<Landlord>, ILandlordRepository
    {
        public LandlordRepository(RentIdentityDb context) :base(context){}
       // public RentIdentityDb RentIdentityDb => Context as RentIdentityDb;

        public IEnumerable<Landlord> GetLandlordsById(int id)
        {
            return RentIdentityDb.Landlords.Where(r => r.Id == id).ToList();
        }

        public RentIdentityDb RentIdentityDb
        {
            get { return Context as RentIdentityDb; }
        }
    }
}
