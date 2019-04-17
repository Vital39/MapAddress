using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class MapController : Controller
    {
        AddressModel addressModel;

        public MapController(IGenericService<AddressDTO> addressService, IGenericService<StreetDTO> streetService, IGenericService<SubdivisionDTO> subdivisionService)
        {
            addressModel = new AddressModel(addressService, streetService, subdivisionService);
         
        }



        // GET: Map
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Map()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAddress(string requestStr)
        {
            var res= addressModel.GetAddresses(requestStr);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

    }
}