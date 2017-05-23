using System.Linq;
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
            bool noExiste = true;
            //Carrera c = new Carrera{Nombre = "Pepe"};
            Carrera c = CarreraBLL.CrearCarrera("Pepe");

            //DataManager dm = DataManager.Instance;
            DataManager dm = DataManager.Instance(BLL.Constantes.Constantes.DataManagerPath);

            noExiste = !dm.ObtenerCarrerasEnApp().Exists(x => x.Equals(c));

            Assert.IsTrue(noExiste);
        }


        [Test]
        public void ExisteCarrera()
        {
            /*            bool Existe = true;
                        Carrera c = new Carrera{Nombre = "Pepe"};

                        //DataManager dm = DataManager.Instance;
                        DataManager dm = DataManager.Instance(BLL.Constantes.Constantes.DataManagerPath);

                        dm.RegistrarCarrera(c);

                        Existe = dm.ObtenerCarrerasEnApp().Exists(x => x.Equals(c));

                        Assert.IsTrue(Existe);
            */
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


        /// <summary>
        /// User Story: 3.2
        /// Test Case: Se intenta actualizar los horarios de materias de un plan de estudios
        /// </summary>
        [Test]
        public void ActualizarHorariosMaterias()
        {

        }


        /// <summary>
        /// User Story: 3.3
        /// Test Case: Se intenta mostrar un plan de estudios vacío
        /// </summary>
        [Test]
        public void MostrarPlanEstudioVacío()
        {

        }


        /// <summary>
        /// User Story: 3.3
        /// Test Case: Se intenta mostrar un plan de estudios con datos
        /// </summary>
        [Test]
        public void MostrarPlanEstudio()
        {

        }

        /// <summary>
        /// User Story: 3.4
        /// Test Case: Se intenta mostrar los planes de estudio de un alumno
        /// </summary>
        [Test]
        public void MostrarPlanEstudioAlumno()
        {
            Alumno alumno = dm.ObtenerAlumnosEnApp().FirstOrDefault();
            Assert.IsTrue(alumno.PlanDeEstudio.Any());
        }

        /// <summary>
        /// User Story: 3.5
        /// Test Case: Se intenta mostrar las materias por cada plan de estudios
        /// </summary>
        [Test]
        public void MostrarMateriasPlanDeEstudios()
        {
            PlanDeEstudio plan = dm.ObtenerPlanesdeEstudioEnApp().FirstOrDefault();
            Assert.IsTrue(plan.Materia.Any());
        }

    }
}
