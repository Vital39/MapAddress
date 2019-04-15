using BLL.Models;
﻿using BLL.Interfaces;
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
        // GET: Address
        public ActionResult Index()
        {
            var model = addressService.GetAll();
            return View(model);
        }
        
        public AddressController(IGenericService<AddressDTO> service) : base(service)
        {

        }
    }
}