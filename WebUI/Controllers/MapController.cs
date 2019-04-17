using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class MapController : GenericController<AddressDTO>
    {
        VmAddressModel addressModel;
      

        public MapController(IGenericService<AddressDTO> service) : base(service)
        {
            addressModel = new VmAddressModel(service);
        }

        public ActionResult Map()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAddress(string requestStr)
        {
            var all = service.GetAll();///////////////
            var res= addressModel.GetAddresses(requestStr);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

    }
}