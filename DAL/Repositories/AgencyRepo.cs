using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class AgencyRepo : IAgencyRepo
    {
        private readonly WiseTripsContext _context;

        public AgencyRepo(WiseTripsContext context)
        {
            _context = context;
        }

        public Agency Add(Agency obj)
        {
            _context.Agencies.Add(obj);

            return _context.SaveChanges() > 0 ? obj : null;
        }

        public bool Delete(int id)
        {
            var agency = _context.Agencies.Find(id);
            _context.Agencies.Remove(agency);
            return _context.SaveChanges() > 0;
        }

        public List<Agency> Get()
        {
            return _context.Agencies.ToList();
        }

        public Agency Get(int id)
        {
            return _context.Agencies.Find(id);
        }

        public Agency Update(Agency obj)
        {
            var agency = Get(obj.Id);
            _context.Entry(agency).CurrentValues.SetValues(obj);
            
            return _context.SaveChanges() > 0 ? obj : null;
        }
    }
}
