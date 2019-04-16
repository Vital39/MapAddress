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
    public class StreetController : GenericController<StreetDTO>
    {
        public StreetController(IGenericService<StreetDTO> service) : base(service)
        {

        }
    }
}