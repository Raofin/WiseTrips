using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PackageRepo : Repo, IRepo<Package, int, Package>
    {
        public Package Add(Package obj)
        {
            db.Packages.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            var ext = db.Packages.Find(id);
            db.Packages.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Package> Get()
        {
            return db.Packages.ToList();
        }

        public Package Get(int id)
        {
            return db.Packages.Find(id);
        }

        public Package Update(Package obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            else
            {
                return null;
            }

        }
    }
}