using System.Collections.Generic;
using System.Linq;
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
            CursadaViewModel viewModel = Index(alumno);
            return View(viewModel);
        }


        /// <summary>
        /// Controlador generico.
		/// Controlador HTTP debe consultar a este método para abstraer el comportamiento web 
        /// </summary>
        /// <param name="alumno"></param>
		private CursadaViewModel Index(Alumno alumno)
        {
            Cursada cursada = new Cursada();
            List<Materia> materias = cursada.ObtenerPosiblesMateriasACursar(alumno).ToList();

            CursadaViewModel model = new CursadaViewModel { Materias = materias };

            return model;
        }


        public JsonResult ObtenerDatosAlumno(string nombreAlumno)
        {
            Alumno alumno = Alumno.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                return Json(alumno);
            }
            return Json(new { });
        }


        public JsonResult ObtenerPlanesDeEstudio(string nombreAlumno)
        {
            Alumno alumno = Alumno.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                return Json(alumno.PlanesDeEstudios);
            }
            return Json(new { });
        }

        public JsonResult ObtenerHistorial(string nombreAlumno)
        {
            Alumno alumno = Alumno.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                return Json(alumno.HistorialAcademico);
            }
            return Json(new { });
        }

        public JsonResult ObtenerMateriasPendientes(string nombreAlumno)
        {
            Alumno alumno = Alumno.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                Cursada cursada = new Cursada();
                List<Materia> materias = cursada.ObtenerPosiblesMateriasACursar(alumno).ToList();

                return Json(materias);
            }

            return Json(new { });
        }

        public JsonResult ObtenerCaminoCritico(string nombreAlumno)
        {
            Alumno alumno = Alumno.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                Cursada cursada = new Cursada();
                List<Materia> materias = cursada.ObtenerPosiblesMateriasACursar(alumno).ToList();
                cursada.CalcularPesoEnCaminoCritico(materias);
                Dictionary<Materia,int> diccionario = cursada.CaminoCritico.DiccionarioCriticidad;

                return Json(diccionario);
            }

            return Json(new { });
        }


    }
}
