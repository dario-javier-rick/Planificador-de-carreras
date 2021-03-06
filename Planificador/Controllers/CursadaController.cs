﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Planificador.Models;
using Planificador.ViewModels;
using Planificador.BLL;
using Planificador.BLL.Strategies;

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
            CursadaViewModel cvm = new CursadaViewModel();;
            return cvm;
        }

        public JsonResult ObtenerDatosAlumno(string nombreAlumno)
        {
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                AlumnoViewModel avm = new AlumnoViewModel
                {
                    Nombre = alumno.Nombre,
                    Apellido = alumno.Apellido,
                    Dni = alumno.Dni
                };
                return Json(avm);
            }
            return Json(new { });
        }


        public JsonResult ObtenerPlanesDeEstudio(string nombreAlumno)
        {
            FacadePlanificador fc = new FacadePlanificador();

            Alumno alumno = fc.ObtenerAlumnos().FirstOrDefault(a => a.Nombre == nombreAlumno);
        
            var jsonResult = from p in fc.ObtenerPlanesDeEstudio()
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
            if (alumno.Libreta != null && alumno.Libreta.MateriaAprobada.Any())
            {
                var jsonResult = from m in alumno.Libreta.MateriaAprobada
                                 select new {m.Id, m.Materia.Nombre};

                return Json(jsonResult);
            }
            return Json(new { });
        }

        public JsonResult ObtenerMateriasPendientes(string nombreAlumno)
        {
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                List<Materia> materias = AlumnoBLL.ListarMateriasSinAprobar(alumno);

                return Json(materias);
            }

            return Json(new { });
        }

        public JsonResult ObtenerCaminoCritico(string nombreAlumno)
        {
            Alumno alumno = AlumnoBLL.ObtenerAlumno(nombreAlumno);
            if (alumno != null)
            {
                CaminoCritico camino = new CaminoCritico(alumno);
                camino.ConfigurarEstrategia(new EstrategiaGeneral());
                camino.Calcular();

                return Json(camino);
            }

            return Json(new { });
        }

    }
}