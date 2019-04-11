﻿using BLL.Interfaces;
using BLL.Models;
using DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class SubdivisionController : GenericController<Subdivision, SubdivisionDTO>
    {
        public SubdivisionController(IGenericService<Subdivision, SubdivisionDTO> service) : base(service)
        {

        }
    }
}