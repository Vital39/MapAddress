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
        IGenericService<AddressDTO> addressService;
        IGenericService<StreetDTO> streetService;
        IGenericService<SubdivisionDTO> subdivisionService;

        public MapController(IGenericService<AddressDTO> addressService, IGenericService<StreetDTO> streetService, IGenericService<SubdivisionDTO> subdivisionService)
        {
            this.addressService = addressService;
            this.streetService = streetService;
            this.subdivisionService = subdivisionService;
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
            var streets = streetService.FindBy(x => x.StreetName.Contains(requestStr)).ToList();
            //var addresses = streets.Join(streets, ) (s => s.StreetId == addressService.FindBy(x=>x.StreetId))

            List<string> strs = new List<string>(); /*= addressService.Ge;*/
            
            foreach (var street in streets)
            {
                strs.AddRange(addressService.FindBy(x => x.StreetId == street.StreetId).Select(x=> street.StreetName+" "+x.House));
            }

            return Json(strs, JsonRequestBehavior.AllowGet);
        }
    }
}