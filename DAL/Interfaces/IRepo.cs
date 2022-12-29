using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<TClass, TId, TResult>
    {
        List<TClass> Get();

        TClass Get(TId id);

        TResult Add(TClass obj);

        bool Delete(TId id);

        TResult Update(TClass obj);
    }
}