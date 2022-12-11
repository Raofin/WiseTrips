using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class HotelRepo : Repo, IRepo<Hotel, int, bool>
    {
        public List<Hotel> Get()
        {
            return db.Hotels.ToList();
        }

        public Hotel Get(int id)
        {
            return db.Hotels.Find(id);
        }

        public bool Add(Hotel obj)
        {
            db.Hotels.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Hotel obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
