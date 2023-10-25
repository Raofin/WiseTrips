using DAL.Entity;

namespace DAL.Interfaces;

public interface IUserRepo : ICrudRepo<User, int, bool>
{
}