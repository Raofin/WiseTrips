using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class RoleRepo : IRoleRepo
    {
        private readonly WiseTripsContext _context;

        public RoleRepo(WiseTripsContext context)
        {
            _context = context;
        }

        public List<Role> Get()
        {
            return _context.Roles.ToList();
        }

        public Role Get(int id)
        {
            return _context.Roles.Find(id);
        }

        public bool Add(Role obj)
        {
            _context.Roles.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Role obj)
        {
            var ext = Get(obj.Id);
            _context.Entry(ext).CurrentValues.SetValues(obj);
            return _context.SaveChanges() > 0;
        }
    }
}
