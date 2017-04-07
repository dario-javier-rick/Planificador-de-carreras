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
        public ActionResult Index(string nombre)
        {
            var model = new CursadaViewModel();
            model.Materias = (nombre == null) ? new List<Materia>() : MateriasRestantesHelper.GetMateriasPendientes(nombre);
            return View(model);
        }

        //[HttpPost]
        //public ActionResult GetMateriasPendientes(string nombre)
        //{
        //    var model = new CursadaViewModel
        //    {
        //        Materias = MateriasRestantesHelper.GetMateriasPendientes(nombre)
        //    };

        //    return View("Index", model);
        //}
    }
}
