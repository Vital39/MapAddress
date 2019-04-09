using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MainRepository<T> : GenericRepository<T> where T : class, new()
    {
        public MainRepository(DbContext context) : base(context)
        {

        }
    }
}
