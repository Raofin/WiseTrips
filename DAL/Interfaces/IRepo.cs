using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<TClass, TId, TResult>       //done
    {
        List<TClass> Get();

        TClass Get(TId id);

        TResult Add(TClass obj);

        //bool 
            //void Delete(TId id);
        bool Delete(TId id);
        TResult Update(TClass obj);
       // void Update(Coupon data);
    }
}