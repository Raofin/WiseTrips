using DAL.Entity;

namespace DAL.Interfaces;

public interface IToken : ICrudRepo<Token, string, Token>
{
}