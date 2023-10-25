using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TokenRepo : IToken
    {
        private readonly WiseTripsContext _context;

        public TokenRepo(WiseTripsContext context)
        {
            _context = context;
        }

        public Token Add(Token obj)
        {
            _context.Tokens.Add(obj);
            return _context.SaveChanges() > 0 ? obj : null;
        }
       
        public bool Delete(string id)
        {
            var token = Get(id);
            _context.Tokens.Remove(token);
            return _context.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            return _context.Tokens.FirstOrDefault(t => t.AuthToken.Equals(id));
        }

        public Token Update(Token obj)
        {
            var token = Get(obj.AuthToken);
            _context.Entry(token).CurrentValues.SetValues(obj);
            return _context.SaveChanges() > 0 ? obj : null;
        }
    }
}
