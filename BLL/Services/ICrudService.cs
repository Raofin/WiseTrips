namespace BLL.Services;

public interface ICrudService<TDto>
{
    Task<bool> AddAsync(TDto data);
    Task<List<TDto>> GetAsync();
    Task<TDto> GetAsync(int id);
    Task UpdateAsync(TDto data);
    Task<bool> DeleteAsync(int id);
}