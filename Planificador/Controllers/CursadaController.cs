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
        /// <summary>
        /// Controlador HTTP
        /// </summary>
        /// <param name="nombreAlumno"></param>
        /// <returns></returns>
        public ActionResult Index(string nombreAlumno)
        {
            CursadaViewModel model = new CursadaViewModel();

            Cursada cursada = new Cursada();
            
            model.Materias = (nombreAlumno == null) ? new List<Materia>() : cursada.obtenerPosiblesMateriasACursar(new Alumno()).ToList(); //TODO
            return View(model);
        }


        /// <summary>
        /// Controlador abstracto
        /// </summary>
        /// <param name="nombreAlumno"></param>
        private void IndexAbs(string nombreAlumno)
        {
            //Controlador HTTP debe consultar a este método para abstraer el comportamiento web de la lógica de controlador
        }

    }
}
