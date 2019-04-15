using BLL.Models;
using DAL.DbLayer;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubdivisionService : MainService<Subdivision, SubdivisionDTO> 
    {
        public SubdivisionService(IGenericRepository<Subdivision> repository) : base(repository)
        {
        }
    }
}
