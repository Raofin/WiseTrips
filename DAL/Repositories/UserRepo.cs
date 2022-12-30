using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepo : IRepo<User, int, bool>, IAuth
    {
        WiseTripsEntities db;

        internal UserRepo()
        {
            db = new WiseTripsEntities();
        }

        public bool Add(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            return db.SaveChanges() > 0;
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
            var user = db.Users.FirstOrDefault(u =>
                    u.Username.Equals(username) &&
                    u.Password.Equals(password)
            );
            return user;
        }

        public bool Logout(string token)
        {
            var authToken = db.Tokens.FirstOrDefault(t => t.AuthToken.Equals(token));

            if (authToken == null) 
                return false;
            
            authToken.ExpiredOn = DateTime.Now;
            db.SaveChanges();
            return true;
        }

        public User GetUser(string token)
        {
            return (from u in db.Users
                    where u.Id == (from t in db.Tokens 
                        where t.AuthToken == token && t.ExpiredOn > DateTime.Now 
                        select t.UserId).FirstOrDefault() 
                            select u).FirstOrDefault();
        }
    }
}
