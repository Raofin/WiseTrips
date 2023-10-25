namespace DAL.Interfaces
{
    public interface ICrudRepo<TClass, in TId, out TResult>
    {
        List<TClass> Get();

        TClass Get(TId id);

        TResult Add(TClass obj);

        bool Delete(TId id);

        TResult Update(TClass obj);
    }
}
