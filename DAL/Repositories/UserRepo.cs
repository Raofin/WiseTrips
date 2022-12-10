using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepo : IRepo<User, int, bool>,IAuth
    {
       // WiseTripsEntities db = new WiseTripsEntities();      //old
        WiseTripsEntities db;
        internal UserRepo()
        {
            db = new WiseTripsEntities();
        }



        public bool Add(User obj)      //bool ,User
        {
            db.Users.Add(obj);
         return db.SaveChanges() >0;       //save changes means it return numeric value(1,2,3..)
        }

        public bool Delete(int id)
        {
            var ext = db.Users.Find(id);
            db.Users.Remove(ext);
          return db.SaveChanges()>0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public User Authenticate(string username, string password)
        {
            var user = db.Users.FirstOrDefault(
                u =>
                    u.Username.Equals(username) &&
                    u.Password.Equals(password)
            );
            return user;
        }
    }
}
