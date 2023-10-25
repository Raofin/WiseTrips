using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepo : IUserRepo, IAuthRepo
    {
        private readonly WiseTripsContext _context;

        public UserRepo(WiseTripsContext context)
        {
            _context = context;
        }

        public bool Add(User obj)
        {
            _context.Users.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            return _context.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var ext = Get(obj.Id);
            _context.Entry(ext).CurrentValues.SetValues(obj);
            return _context.SaveChanges() > 0;
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u =>
                    u.Username.Equals(username) &&
                    u.Password.Equals(password)
            );
            return user;
        }

        public bool Logout(string token)
        {
            var authToken = _context.Tokens.FirstOrDefault(t => t.AuthToken.Equals(token));

            if (authToken == null) 
                return false;
            
            authToken.ExpiredOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public User GetUser(string token)
        {
            return (from u in _context.Users
                    where u.Id == (from t in _context.Tokens 
                        where t.AuthToken == token && t.ExpiredOn > DateTime.Now 
                        select t.UserId).FirstOrDefault() 
                            select u).FirstOrDefault();
        }
    }
}
