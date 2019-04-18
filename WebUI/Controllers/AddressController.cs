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
        private VmAddressPaging pagingVm;
        public AddressController(IGenericService<AddressDTO> service) : base(service)
        {
            pagingVm = new VmAddressPaging(service);
        }

        public ActionResult VmAddressPaging(int currentPage = 1)
        {
            pagingVm.CurrentPageProp = currentPage;
            return PartialView(pagingVm);
        }
    }
}