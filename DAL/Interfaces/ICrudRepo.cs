namespace DAL.Interfaces
{
    public interface ICrudRepo<TClass, in TId, TResult>
    {
        Task<List<TClass>> GetAsync();

        Task<TClass> GetAsync(TId id);

        Task<TResult> AddAsync(TClass obj);

        Task<bool> DeleteAsync(TId id);

        Task<TResult> UpdateAsync(TClass obj);
    }
}
