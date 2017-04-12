using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planificador.Controllers;
using Planificador.Models;
using System.Web.Mvc;
using Planificador.Models.ViewModels;
using Planificador.Logic;


namespace PlanificadorTest
{
    [TestFixture]
    public class CursadaControllerTest
    {
        private CursadaController Controller { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Controller = new CursadaController();
        }

        [Test]
        public void Index_ListaVacia()
        {
			//Consulto al controlador
			ViewResult result = this.Controller.Index(null) as ViewResult;

            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel) result.ViewData.Model;

			//Valido resultado de ViewModel
            Assert.IsTrue(!model.Materias.Any());
        }

        [Test]
        public void Index_Alumno_LicenciaturaInformatica()
        {
            //Consulto al controlador
            ViewResult result = this.Controller.Index("Dario") as ViewResult;

            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel) result.ViewData.Model;

            //Valido resultado de ViewModel
            IEnumerable<Materia> listaMateriasLicenciaturaInformatica = MateriasPorCarrera.ListarMateriasLicenciaturaSistemas();
            CollectionAssert.AreEqual(listaMateriasLicenciaturaInformatica.ToList(), model.Materias.ToList());
        }

        [Test]
        public void Index_Alumno_LicenciaturaEconomia()
        {
            //Consulto al controlador
            const string Alumno = "Adam";
            ViewResult result = this.Controller.Index(Alumno) as ViewResult;

            //Controlador retorna ViewModel
            CursadaViewModel model = (CursadaViewModel) result.ViewData.Model;

            //Valido resultado de ViewModel
            IEnumerable<Materia> listaMateriasLicenciaturaEconomia = MateriasPorCarrera.ListarMateriasLicenciaturaEconomia();
            CollectionAssert.AreEqual(listaMateriasLicenciaturaEconomia.ToList(), model.Materias.ToList());
        }


    }
}
