﻿using NUnit.Framework;
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
            //Here the mock for the service provider call
            var result = this.Controller.Index() as ViewResult;
            var model = (CursadaViewModel)result.ViewData.Model;

            Assert.IsTrue(model.Materias.Equals(DbContext.GetListaDeMaterias()));

        }
    }
}