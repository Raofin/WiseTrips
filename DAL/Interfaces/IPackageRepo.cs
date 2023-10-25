using DAL.Entity;

namespace DAL.Interfaces;

public interface IPackageRepo : ICrudRepo<Package, int, Package>
{
}