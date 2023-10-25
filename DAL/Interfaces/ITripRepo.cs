using DAL.Entity;

namespace DAL.Interfaces;

public interface ITripRepo : ICrudRepo<Trip, int, bool>
{
}