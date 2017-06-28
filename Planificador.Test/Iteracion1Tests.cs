using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using Planificador.BLL;
using Planificador.BLL.Constantes;
using Planificador.Controllers;
using Planificador.Models;
using Planificador.ViewModels;
using Planificador.BLL.Entidades;

namespace Planificador.Test
{
    class Iteracion1Tests
    {
        private FacadePlanificador _fc;
        private CursadaController Controller { get; set; }

        [SetUp]
        public void Setup()
        {
            _fc = new FacadePlanificador();
            DataManager dm = new DataManager(AppDomain.CurrentDomain.BaseDirectory + @"Data/" + Constantes.NombreArchivo);
            dm.CargarDatos();

            Controller = new CursadaController();
        }

        [Test]
        public void Index_ListaVacia()
        {
            //Consulto al controlador
            ViewResult result = Controller.Index(null) as ViewResult;
            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel)result.ViewData.Model;
            //Valido resultado de ViewModel
            Assert.IsTrue(!model.Materias?.Any());   
        }

        [Test]
        public void Index_Alumno_TecnicaturaInformatica()
        {
            //Consulto al controlador
            const string alumno = "Dario";
            ViewResult result = Controller.Index(alumno) as ViewResult;

            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel)result.ViewData.Model;

            List<PlanDeEstudio> todosLosPlanes = _fc.ObtenerPlanesDeEstudio();
            PlanDeEstudio tecnicaturaInformatica = CarreraBLL.ObtenerCarrera("Tecnicatura Sistemas").PlanDeEstudios.FirstOrDefault();

            //Valido resultado de ViewModel
            IEnumerable<Materia> listaMateriasTecnicaturaInformatica = CarreraBLL.ObtenerCarrera("Tecnicatura Sistemas").PlanDeEstudios.FirstOrDefault().Materia;
            CollectionAssert.AreEqual(listaMateriasTecnicaturaInformatica.ToList(), model.Materias.ToList());
        }

        [Test]
        public void Index_Alumno_LicenciaturaInformatica()
        {
            //Consulto al controlador
            const string alumno = "Dario";
            ViewResult result = Controller.Index(alumno) as ViewResult;
            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel)result.ViewData.Model;

            List<PlanDeEstudio> todosLosPlanes = _fc.ObtenerPlanesDeEstudio();
            PlanDeEstudio licenciaturaInformatica = todosLosPlanes.Where(p => p.Id == 0).FirstOrDefault(); //TODO: Ver Id

            //Valido resultado de ViewModel
            //IEnumerable<Materia> listaMateriasLicenciaturaInformatica = licenciaturaInformatica.Materia;//PlanEstudiosLicenciaturaSistemas.GetListaMaterias();
            //CollectionAssert.AreEqual(listaMateriasLicenciaturaInformatica.ToList(), model.Materias.ToList());
        }

        [Test]
        public void Index_Alumno_LicenciaturaEconomia()
        {
            /*comentado
            //Consulto al controlador
            const string alumno = "Adam";
            ViewResult result = Controller.Index(alumno) as ViewResult;
            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel)result.ViewData.Model;
            //Valido resultado de ViewModel
            IEnumerable<Materia> listaMateriasLicenciaturaEconomia = PlanEstudiosLicenciaturaEconomia.GetListaMaterias();
            CollectionAssert.AreEqual(listaMateriasLicenciaturaEconomia.ToList(), model.Materias.ToList());
            */
        }


        [Test]
        public void CaminoMinimo_LicenciaturaEconomia()
        {
            /*comentado
            //Consulto al controlador
            IPlanEstudio a = new PlanEstudiosLicenciaturaEconomia();
            /* Se comenta porque el teesteo va para el plan de estudio licenciatura. */
            //IPlanEstudio a = new PlanEstudiosLicenciaturaSistemas();
            /*comentado
            var b = new CaminoCritico();
            var g = b.GetCaminoCritico(a.GetPlanEstudio());
            */
        }

        [Test]
        public void CaminoMinimo_LicenciaturaInformatica()
        {
            //Consulto al controlador
            Controller.ObtenerCaminoCritico("Dario Rick");

            /*Comentado
            //Consulto al controlador
            IPlanEstudio a = new PlanEstudiosLicenciaturaSistemas();
            var b = new CaminoCritico();
            var g = b.GetCaminoCritico(a.GetPlanEstudio());
            */
        }
    }
}
