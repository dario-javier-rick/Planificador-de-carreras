using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planificador.Models;
using Planificador.Models.ViewModels;
using Planificador.Logic;

namespace Planificador.Controllers
{
    public class CursadaController : Controller
    {
        public ActionResult Index()
        {
            var model = new CursadaViewModel
            {
                Materias = DbContext.GetListaDeMaterias()
            };

            return View(model);
        }
    }
}
