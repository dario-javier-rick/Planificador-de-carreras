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
		    Alumno alumno = Alumno.ObtenerAlumno(nombreAlumno);		
            Cursada cursada = new Cursada();
			List<Materia> materias = cursada.ObtenerPosiblesMateriasACursar(alumno).ToList();

            CursadaViewModel model = new CursadaViewModel();
			model.Materias = materias;

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
