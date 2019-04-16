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
    public class SubdivisionController : GenericController<SubdivisionDTO>
    {
        public SubdivisionController(IGenericService<SubdivisionDTO> service) : base(service)
        {

        }
    }
}