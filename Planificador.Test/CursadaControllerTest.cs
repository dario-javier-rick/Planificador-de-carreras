﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Planificador.Controllers;
using Planificador.Models;
using System.Web.Mvc;
using Planificador.Models.ViewModels;
using Planificador.Logic;
using Planificador.Data.PlanesDeEstudio;
using System;

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
            var diccionario = b.DiccionarioCriticidad;

            Dictionary<Materia, int> ff = new Dictionary<Materia, int>();
            Materia ip = new Materia {  Nombre = "Introduccion a la Programacion" }; ff.Add(ip, 0);

            ff.Add(new Materia { Nombre = "Introduccion a la Matematica" }, 0);
            ff.Add(new Materia { Nombre = "Programacion 1", Correlativas = { ip } }, 1);
            ff.Add(new Materia { Nombre = "Logica y teoria de numeros" }, 1);
            ff.Add(new Materia { Nombre = "Programacion 2" }, 2);
            ff.Add(new Materia { Nombre = "Matematica Discreta" }, 2);
            ff.Add(new Materia { Nombre = "Programacion 3" }, 3);

            CollectionAssert.AreEqual(ff,diccionario);
            //foreach (var element in diccionario)
            //{
                /* Parecido al Any (Ojo no es lo mismo.). */
             //   Materia q = (from matf in ff
               //              where matf.Key == element.Key
                 //            select matf.Key).FirstOrDefault();

                //if (ff.Any(matf => matf.Key == element.Key))
                //{
                    //if (element)

                //}
            //}
        }
        

        [Test]
        public void CaminoCritico_LicenciaturaEconomia()
        {
            //Consulto al controlador
            IPlanEstudio a = new PlanEstudiosLicenciaturaEconomia();
            /* Se comenta porque el teesteo va para el plan de estudio licenciatura. */
            //IPlanEstudio a = new PlanEstudiosLicenciaturaSistemas();
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
