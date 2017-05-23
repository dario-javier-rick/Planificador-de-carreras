using NUnit.Framework;
using Planificador.BLL;
using Planificador.BLL.Entidades;
using Planificador.Models;

namespace Planificador.Test
{
    class Iteracion2Tests
    {
        private DataManager dm { get; set; }

        [SetUp]
        public void Setup()
        {
            DataManager dm = DataManager.Instance(BLL.Constantes.Constantes.DataManagerPath);
        }

        //User Story 3.1


        /// <summary>
        /// User Story: 3.1
        /// Test Case: Se intenta probar un constructor vacío.
        /// </summary>
        [Test]
        public void ConstructoVacio()
        {
            //Carrera c = new Carrera("A");

            //GeneradorPlanEstudio gpe = new GeneradorPlanEstudio();

            //gpe.CrearPlanEstudio();
        }

        /** Nicolás Fernández, 18/05/2017, User Hitory := Constructor Plan de estudio. **/
        /* 1. Controlar si la carrera existe. */
        [Test]
        public void NoExisteCarrera()
        {
            //bool noExiste = true;
            //Carrera c = new Carrera{Nombre = "Pepe"};
            /* Nicolas Fernandez, 2/05/2017, Se crea la carrera con la clase CarreraBLL. */
            Carrera c = CarreraBLL.CrearCarrera("Pepe");

            //DataManager dm = DataManager.Instance;
            DataManager dm = DataManager.Instance(BLL.Constantes.Constantes.DataManagerPath);

            Carrera c1 = dm.ObtenerCarrera(c);

            //noExiste = !dm.ObtenerCarrerasEnApp().Exists(x => x.Equals(c));

            //Assert.IsTrue(noExiste);
            Assert.IsNull(c1);
        }


        [Test]
        public void ExisteCarrera()
        {
            //bool Existe = true;
            Carrera c = CarreraBLL.CrearCarrera("Pepe");

            //DataManager dm = DataManager.Instance;
            DataManager dm = DataManager.Instance(BLL.Constantes.Constantes.DataManagerPath);

            dm.RegistrarCarrera(c);

            //Existe = dm.ObtenerCarrerasEnApp().Exists(x => x.Equals(c));
            //Assert.IsTrue(Existe);
        }

        /*[Test]
        public void ExisteCarrera()
        {
            bool existe = false;
            Carrera c = new Carrera("Pepe");
            GeneradorPlanEstudio gpe = new GeneradorPlanEstudio();
            gpe.CrearPlanEstudio(c, new PlanDeEstudio(c));
            DataManager dm = new DataManager();
            existe = dm.ObtenerCarrerasEnApp().Exists(x => x.NombreCarrera.Equals(c.NombreCarrera));
            Assert.IsTrue(existe);
        }*/

    }
}
