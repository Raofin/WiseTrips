using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TripRepo : ITripRepo
    {
        private readonly WiseTripsContext _context;

        public TripRepo(WiseTripsContext context)
        {
            _context = context;
        }

        public List<Trip> Get()
        {
            return _context.Trips.ToList();
        }

        public Trip Get(int id)
        {
            return _context.Trips.Find(id);
        }

        public bool Add(Trip obj)
        {
            _context.Trips.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Trip obj)
        {
            var ext = Get(obj.Id);
            _context.Entry(ext).CurrentValues.SetValues(obj);
            return _context.SaveChanges() > 0;
        }
    }
}
