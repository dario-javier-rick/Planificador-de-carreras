﻿using System;
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
			Cursada cursada = new Cursada(); //Facade object
			IEnumerable<Materia> materias = cursada.ObtenerPosiblesMateriasACursar(alumno);

		    CursadaViewModel model = new CursadaViewModel {Materias = materias};

		    return model;
		}


        /*
        private ActionResult GenerarCaminoMinimo()
        {
            throw new NotImplementedException();
        }
        */

    }
}
