using BLL.Models;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AddressController : Controller
    {
        IGenericService<AddressDTO> addressService;

        public AddressController(IGenericService<AddressDTO> addressService)
        {
            this.addressService = addressService;
        }

        // GET: Address
        public ActionResult Index()
        {
            var model = addressService.GetAll();
            return View(model);
        }
    }
}