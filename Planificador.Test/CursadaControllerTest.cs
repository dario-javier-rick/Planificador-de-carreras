using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Planificador.Controllers;
using Planificador.Models;
using System.Web.Mvc;
using Planificador.Models.ViewModels;
using Planificador.Logic;
using Planificador.Data.PlanesDeEstudio;


namespace PlanificadorTest
{
    [TestFixture]
    public class CursadaControllerTest
    {
        private CursadaController Controller { get; set; }

        [SetUp]
        public void Setup()
        {
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
            Assert.IsTrue(!model.Materias.Any());
        }

        [Test]
        public void Index_Alumno_LicenciaturaInformatica()
        {
            //Consulto al controlador
            const string alumno = "Dario";
            ViewResult result = Controller.Index(alumno) as ViewResult;

            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel)result.ViewData.Model;

            //Valido resultado de ViewModel
            IEnumerable<Materia> listaMateriasLicenciaturaInformatica = PlanEstudiosLicenciaturaSistemas.GetListaMaterias();
            CollectionAssert.AreEqual(listaMateriasLicenciaturaInformatica.ToList(), model.Materias.ToList());
        }

        [Test]
        public void Index_Alumno_LicenciaturaEconomia()
        {
            //Consulto al controlador
            const string alumno = "Adam";
            ViewResult result = Controller.Index(alumno) as ViewResult;

            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel)result.ViewData.Model;

            //Valido resultado de ViewModel
            IEnumerable<Materia> listaMateriasLicenciaturaEconomia = PlanEstudiosLicenciaturaEconomia.GetListaMaterias();
            CollectionAssert.AreEqual(listaMateriasLicenciaturaEconomia.ToList(), model.Materias.ToList());
        }

        [Test]
        public void CaminoCritico()
        {
            //Consulto al controlador
            IPlanEstudio a = new PlanEstudiosLicenciaturaSistemas();
            var b = new CaminoCritico();
            var g = b.GetCaminoCritico(a.GetPlanEstudio());
        }

        [Test]
        public void CaminoCritico_LicenciaturaEconomia()
        {
            //Consulto al controlador
            IPlanEstudio a = new PlanEstudiosLicenciaturaSistemas();
            var b = new CaminoCritico();
            var g = b.GetCaminoCritico(a.GetPlanEstudio());
        }

        [Test]
        public void CaminoCritico_LicenciaturaInformatica()
        {
            //Consulto al controlador
            IPlanEstudio a = new PlanEstudiosLicenciaturaSistemas();
            var b = new CaminoCritico();
            var g = b.GetCaminoCritico(a.GetPlanEstudio());
        }

    }
}
