using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TokenRepo : IRepo<Token, string, Token>
    {
        WiseTripsEntities db = new WiseTripsEntities();

        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }
       
        public bool Delete(string id)
        {
            var token = Get(id);
            db.Tokens.Remove(token);
            return db.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.AuthToken.Equals(id));
        }

        public Token Update(Token obj)
        {
            var token = Get(obj.AuthToken);
            db.Entry(token).CurrentValues.SetValues(obj);
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
