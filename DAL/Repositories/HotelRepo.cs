using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class HotelRepo : IHotelRepo
    {
        private readonly WiseTripsContext _context;

        public HotelRepo(WiseTripsContext context)
        {
            _context = context;
        }

        public List<Hotel> Get()
        {
            return _context.Hotels.ToList();
        }

        public Hotel Get(int id)
        {
            return _context.Hotels.Find(id);
        }

        public bool Add(Hotel obj)
        {
            _context.Hotels.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Hotel obj)
        {
            var ext = Get(obj.Id);
            _context.Entry(ext).CurrentValues.SetValues(obj);
            return _context.SaveChanges() > 0;
        }
    }
}
