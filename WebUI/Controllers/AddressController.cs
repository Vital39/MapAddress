using BLL.Models;
﻿using BLL.Interfaces;
using DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AddressController : GenericController<AddressDTO>
    {
        public AddressController(IGenericService<AddressDTO> service) : base(service)
        {

        }

        public ActionResult VmAddressPaging(int currentPage = 1)
        {
            VmAddressPaging model = new VmAddressPaging(service, currentPage);
            return View(model);
        }
    }
}