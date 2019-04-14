using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenericService<DTO> where DTO : class, new() 
    {
        IEnumerable<DTO> GetAll();
        IEnumerable<DTO> FindBy(Expression<Func<DTO, bool>> predicate);
        DTO Get(int id);
        DTO Add(DTO obj);
        DTO Update(DTO obj);
        DTO Delete(int id);
    }
}
