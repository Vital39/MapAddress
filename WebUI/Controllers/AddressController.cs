using BLL.Interfaces;
using BLL.Models;
using DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AddressController : GenericController<Address, AddressDTO>
    {
        public AddressController(IGenericService<Address, AddressDTO> service) : base(service)
        {

        }
    }
}