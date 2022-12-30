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

            return db.SaveChanges() > 0 ? obj : null;
        }

        public bool Delete(int id)
        {
            var agency = db.Agencies.Find(id);
            db.Agencies.Remove(agency);
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
            var agency = Get(obj.Id);
            db.Entry(agency).CurrentValues.SetValues(obj);
            
            return db.SaveChanges() > 0 ? obj : null;
        }
    }
}
