using DAL.Entity;

namespace DAL.Interfaces;

public interface IRoleRepo : ICrudRepo<Role, int, bool>
{
}