using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PackageRepo : IPackageRepo
    {
        private readonly WiseTripsContext _context;

        public PackageRepo(WiseTripsContext context)
        {
            _context = context;
        }

        public Package Add(Package obj)
        {
            _context.Packages.Add(obj);
            return _context.SaveChanges() > 0 ? obj : null;
        }

        public bool Delete(int id)
        {
            var package = _context.Packages.Find(id);
            _context.Packages.Remove(package);
            return _context.SaveChanges() > 0;
        }

        public List<Package> Get()
        {
            return _context.Packages.ToList();
        }

        public Package Get(int id)
        {
            return _context.Packages.Find(id);
        }

        public Package Update(Package obj)
        {
            var package = Get(obj.Id);
            _context.Entry(package).CurrentValues.SetValues(obj);
            return _context.SaveChanges() > 0 ? obj : null;
        }
    }
}