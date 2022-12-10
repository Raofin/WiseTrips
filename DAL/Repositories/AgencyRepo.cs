using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AgencyRepo : IRepo<Agency, int, bool>, IAuth
    {
        WiseTripsEntities db=new WiseTripsEntities();
        public bool Add(Agency obj)
        {
            db.Agencies.Add(obj);
            return db.SaveChanges() > 0;


        }


        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
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

        public bool Update(Agency obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;

        }
    }
}
