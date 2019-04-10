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
    public class AddressService : MainService<Address, AddressDTO>
    {
        public AddressService(IGenericRepository<Address> repository) : base(repository)
        {
            
        }
    }
}
