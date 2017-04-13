using System.Collections.Generic;
using System.Data.Entity;
using RentIdentity.Data;
using RentIdentity.Data.Entities;
using RentIdentity.DAL.RepositoryInterfaces;
using System;
using System.Linq;

namespace RentIdentity.DAL.Repositories
{
    public class RentalUnitRepository : Repository<RentalUnit>, IRentalUnitRepository
    {
        public RentalUnitRepository(RentIdentityDb context) :base(context){}
        public RentIdentityDb RentIdentityDb => Context as RentIdentityDb;

        public IEnumerable<RentalUnit> GetRentalUnitById(int id)
        {
            return RentIdentityDb.RentalUnits.Where(r => r.Id == id).ToList();
        }

        public IEnumerable<RentalUnit> GetUnitsByAvailability(bool isAvailable)
        {
            return RentIdentityDb.RentalUnits.Where(r => r.IsAvailable == isAvailable).ToList();
        }
    }
}
