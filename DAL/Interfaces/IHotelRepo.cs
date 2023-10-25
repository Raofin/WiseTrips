using DAL.Entity;

namespace DAL.Interfaces;

public interface IHotelRepo : ICrudRepo<Hotel, int, bool>
{
}