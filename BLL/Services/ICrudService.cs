using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICrudService<TDto>
    {
        TDto Add(TDto data);
        List<TDto> Get();
        TDto Get(int id);
        void Update(TDto data);
        bool Delete(int id);
    }

}
