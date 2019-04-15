using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class GenericController<DOMAIN,DTO> : Controller where DOMAIN : class, new() where DTO : class, new()
    {
        protected IGenericService<DTO> service;

        public GenericController(IGenericService<DTO> service)
        {
            this.service = service;
        }

        public virtual ActionResult Index()
        {
            var model = service.GetAll();
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult Edit(int id = 1)
        {
            var model = (id == 0)
                ?
                new DTO()
                :
                service.Get(id);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Edit(DTO obj)
        {
            if (ModelState.IsValid)
            {
                service.Add(obj);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public virtual ActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return Json("OK");
            }
            catch (Exception exc)
            {
                return Json("ERROR");
            }
        }
    }
}