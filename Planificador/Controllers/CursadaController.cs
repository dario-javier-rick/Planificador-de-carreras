using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planificador.Models;
using Planificador.ViewModels;
using Planificador.BLL;

using AlumnoBLL = Planificador.BLL.Entidades.AlumnoBLL;

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
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            CursadaViewModel viewModel = new CursadaViewModel {Materias = alumno?.Libreta?.MateriasAprobadas?.ToList()};
            return View(viewModel);
        }


        /// <summary>
        /// Controlador generico.
		/// Controlador HTTP debe consultar a este método para abstraer el comportamiento web 
        /// </summary>
        /// <param name="alumno"></param>
		private CursadaViewModel Index(AlumnoBLL alumno)
        {
            Cursada cursada = new Cursada();
            List<Materia> materias = null; //cursada.ObtenerPosiblesMateriasACursar(alumno).ToList(); //TODO

            CursadaViewModel model = new CursadaViewModel { Materias = materias };

            return model;
        }


        public JsonResult ObtenerDatosAlumno(string nombreAlumno)
        {
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                return Json(alumno);
            }
            return Json(new { });
        }


        public JsonResult ObtenerPlanesDeEstudio(string nombreAlumno)
        {
            List<PlanDeEstudio> listaPlanes = null; // AlumnoBLL.ObtenerAlumno(nombreAlumno)?.PlanesDeEstudios.ToList(); //TODO
            object jsonResult = null; //from p in listaPlanes
                             //join c in Data.Carreras.ListaCarreras
                             //   on p.CarreraIdCarrera equals c.IdCarrera
                             //select new { p.Id, c.Nombre }; //TODO

            if (listaPlanes != null)
            {
                return Json(jsonResult);
            }
            return Json(new { });
        }

        public JsonResult ObtenerHistorial(string nombreAlumno)
        {
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                return Json(alumno.Libreta);
            }
            return Json(new { });
        }

        public JsonResult ObtenerMateriasPendientes(string nombreAlumno)
        {
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                Cursada cursada = new Cursada();
                List<Materia> materias = CursadaBLL.ObtenerPosiblesMateriasACursar(alumno).ToList();

                return Json(materias);
            }

            return Json(new { });
        }

        public JsonResult ObtenerCaminoCritico(string nombreAlumno)
        {
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                CursadaBLL cursada = new CursadaBLL();
                List<Materia> materias = null; //cursada.ObtenerPosiblesMateriasACursar(alumno).ToList(); //TODO
                cursada.CalcularPesoEnCaminoCritico(materias);
                Dictionary<Materia, int> diccionario = cursada.CaminoCritico.DiccionarioCriticidad;

                return Json(diccionario);
            }

            return Json(new { });
        }

    }
}