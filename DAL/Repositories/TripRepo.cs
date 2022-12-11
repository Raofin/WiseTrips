using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TripRepo : Repo, IRepo<Trip, int, bool>
    {
        public List<Trip> Get()
        {
            return db.Trips.ToList();
        }

        public Trip Get(int id)
        {
            return db.Trips.Find(id);
        }

        public bool Add(Trip obj)
        {
            db.Trips.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Trip obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
