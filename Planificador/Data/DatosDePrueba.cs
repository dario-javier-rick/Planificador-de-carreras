using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.Logic
{

    /// <summary>
    /// Clase accesoria para cargar alumnos. En caso de pasarnos a una DB, se eliminará
    /// </summary>
    public static class Alumnos
    {
        public static Carrera LicenciaturaSistemas = new Carrera { IdCarrera = 1, Nombre = "Licenciatura en Sistemas" };
        public static Carrera LicenciaturaEconomia = new Carrera { IdCarrera = 2, Nombre = "Licenciatura en Economía" };

        public static PlanDeEstudios PlanDeEstudiosSistemas = new PlanDeEstudios
        {
            Materias = MateriasPorCarrera.ListarMateriasLicenciaturaSistemas()
        };
        public static PlanDeEstudios PlanDeEstudiosEconomia = new PlanDeEstudios
        {
            Materias = MateriasPorCarrera.ListarMateriasLicenciaturaEconomia()
        };

        public static List<Alumno> ListaAlumnos = new List<Alumno> {

            new Alumno
            {
                IdAlumno = 1,
                Nombre = "Dario",
                Apellido = "Rick",
                Dni = "37170404",
                PlanesDeEstudios = new List<PlanDeEstudios> { PlanDeEstudiosSistemas }
            },

            new Alumno
            {
                IdAlumno = 2,
                Nombre = "Nicolas",
                Apellido = "Fernandez",
                PlanesDeEstudios = new List<PlanDeEstudios> { PlanDeEstudiosSistemas }
            },

            new Alumno
            {
                IdAlumno = 3,
                Nombre = "NicolasV",
                Apellido = "Videla Rivero",
                PlanesDeEstudios = new List<PlanDeEstudios> { PlanDeEstudiosSistemas, PlanDeEstudiosEconomia }
            },

            new Alumno
            {
                IdAlumno = 4,
                Nombre = "Adam",
                Apellido = "Smith",
                PlanesDeEstudios = new List<PlanDeEstudios> { PlanDeEstudiosEconomia }
            },

                        new Alumno
            {
                IdAlumno = 5,
                Nombre = "Prueba",
                Apellido = "Test",
                Dni = "34123123",
                PlanesDeEstudios = new List<PlanDeEstudios> { }
            },

        };

    }

    /// <summary>
    /// Clase accesoria para cargar las listas de materias por carrera. En caso de pasarnos a una DB, se eliminará.
    /// </summary>
    public static class MateriasPorCarrera
    {
        public static ICollection<Materia> ListarMateriasLicenciaturaEconomia()
        {
            ICollection<Materia> listaMaterias = new List<Materia>();

            Materia ie = new Materia
            {
                IdMateria = 1,
                Nombre = "Introduccion a la Economía"
            };
            listaMaterias.Add(ie);

            Materia ec = new Materia
            {
                IdMateria = 2,
                Nombre = "Economia Clasica"
            };
            listaMaterias.Add(ec);

            Materia ek = new Materia
            {
                IdMateria = 1,
                Nombre = "Economia Keynesiana"
            };
            listaMaterias.Add(ek);

            return listaMaterias;
        }


        public static ICollection<Materia> ListarMateriasLicenciaturaSistemas()
        {
            ICollection<Materia> listaMaterias = new List<Materia>();

            Materia ip = new Materia
            {
                IdMateria = 1,
                Nombre = "Introduccion a la Programacion"
            };
            listaMaterias.Add(ip);

            Materia p1 = new Materia
            {
                IdMateria = 2,
                Nombre = "Programacion 1",
                Correlativas = new List<Materia> { ip }
            };
            listaMaterias.Add(p1);

            Materia p2 = new Materia
            {
                IdMateria = 3,
                Nombre = "Programacion 2",
                Correlativas = new List<Materia> { p1 }
            };
            listaMaterias.Add(p2);

            Materia p3 = new Materia
            {
                IdMateria = 4,
                Nombre = "Programacion 3",
                Correlativas = new List<Materia> { p2 }
            };
            listaMaterias.Add(p3);

            Materia im = new Materia
            {
                IdMateria = 5,
                Nombre = "Introduccion a la Matematica",
            };
            listaMaterias.Add(im);


            Materia lg = new Materia
            {
                IdMateria = 6,
                Nombre = "Logica y teoria de numeros",
                Correlativas = new List<Materia> { im }
            };
            listaMaterias.Add(lg);


            Materia md = new Materia
            {
                IdMateria = 7,
                Nombre = "Matematica Discreta",
                Correlativas = new List<Materia> { lg }
            };
            listaMaterias.Add(md);

            return listaMaterias;

        }

    }
}