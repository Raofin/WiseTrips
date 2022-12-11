using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AgencyRepo : Repo, IRepo<Agency, int, Agency>
    {
        public Agency Add(Agency obj)
        {
            db.Agencies.Add(obj);
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
            var ext = db.Agencies.Find(id);
            db.Agencies.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Agency> Get()
        {
            return db.Agencies.ToList();
        }

        public Agency Get(int id)
        {
            return db.Agencies.Find(id);
        }

        public Agency Update(Agency obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
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
