﻿using DAL.EF;
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
            return db.SaveChanges() > 0 ? obj : null;
        }

        public bool Delete(int id)
        {
            var package = db.Packages.Find(id);
            db.Packages.Remove(package);
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
            var package = Get(obj.Id);
            db.Entry(package).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }
    }
}