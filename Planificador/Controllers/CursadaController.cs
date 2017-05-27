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
            FacadePlanificador fc = new FacadePlanificador();
            Alumno alumno = fc.ObtenerAlumnos().FirstOrDefault(a => a.Nombre == nombreAlumno);
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
            CursadaViewModel cvm = new CursadaViewModel();

            cvm.Materias = alumno != null ? alumno?.Libreta?.MateriasAprobadas?.ToList() : new List<Materia>();

            return cvm;
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
            FacadePlanificador fc = new FacadePlanificador();

            Alumno alumno = fc.ObtenerAlumnos().FirstOrDefault(a => a.Nombre == nombreAlumno);

            object jsonResult = from p in fc.ObtenerPlanesDeEstudio()
                                join c in fc.ObtenerCarreras()
                                    on p.Id equals c.CodigoCarrera
                                join a in alumno?.PlanDeEstudio
                                    on p.Id equals a.Id
                                select new { p.Id, c.Nombre };

            if (alumno?.PlanDeEstudio != null)
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
                List<Materia> materias = null;//CursadaBLL.ObtenerPosiblesMateriasACursar(alumno).ToList();

                return Json(materias);
            }

            return Json(new { });
        }

        public JsonResult ObtenerCaminoCritico(string nombreAlumno)
        {
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                FacadePlanificador cursada = new FacadePlanificador();
                List<Materia> materias = null; //cursada.ObtenerPosiblesMateriasACursar(alumno).ToList(); //TODO
                cursada.CalcularPesoEnCaminoCritico(materias);
                Dictionary<Materia, int> diccionario = null;//cursada.CaminoCritico.DiccionarioCriticidad;

                return Json(diccionario);
            }

            return Json(new { });
        }

    }
}