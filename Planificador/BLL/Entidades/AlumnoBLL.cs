using System;
using System.Collections.Generic;
using System.Linq;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class AlumnoBLL : IDataReader<Alumno>
    {
        //Lazy initialization. Instancio el objeto únicamente cuando lo necesito.
        private static readonly Lazy<AlumnoBLL> Instancia = new Lazy<AlumnoBLL>(() => new AlumnoBLL());
        public List<Alumno> ListaObj { get; }


        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public static AlumnoBLL Instance => Instancia.Value;


        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        private AlumnoBLL()
        {
            ListaObj = new List<Alumno>();
        }

        public string ToDataLine(Alumno alumno)
		{
			return "["+ nameof(alumno) + "]," + alumno.Id + "," + alumno.Dni + "," + alumno.Nombre;
		}

        public Alumno GenerateFromDataLine(string fromDataLine)
        {
            string[] alumnoArray = fromDataLine.Split(',');
            Alumno alumno = new Alumno
            {
                Id = Convert.ToInt32(alumnoArray[1]),
                Dni = alumnoArray[2],
                Nombre = alumnoArray[3]
            };

            return alumno;
        }


        //Otros métodos.
        public static Alumno ObtenerAlumno(string nombreAlumno)
		{
			return Instance.ListaObj.FirstOrDefault(a => a.Nombre == nombreAlumno);
		}

        public static List<Materia> ListarMateriasAprobadas(Alumno alumno)
        {
            return alumno.Libreta.MateriasAprobadas.ToList();
        }

        public static IEnumerable<Materia> ObtenerMateriasQuePuedoCursar(IEnumerable<Materia> materiasAprobadas, IEnumerable<Materia> materiasDeCarrera)
        {
            var enumerable = materiasAprobadas as Materia[] ?? materiasAprobadas.ToArray();
            List<Materia> materiasSinAprobar = materiasDeCarrera.Except(enumerable).ToList();

            //De las sin aprobar, saco las que requieren correlativas que no tengo aprobadas
            List<Materia> materiasQuePudenSerCursadas = PlanDeEstudioBLL.ObtenerMateriasQueNoRequierenCorrelativas(materiasSinAprobar, enumerable);

            //TODO: Sacar if
            if (!materiasQuePudenSerCursadas.Any())
            {
                return Enumerable.Empty<Materia>();
            }

            return materiasQuePudenSerCursadas;
        }

        public static implicit operator Lazy<object>(AlumnoBLL v)
        {
            throw new NotImplementedException();
        }



        /*
        private static List<Materia> ObtenerMateriasSinAprobar(List<Materia> materiasAprobadas, List<Materia> materiasDeCarrera)
        {
            List<Materia> listaDeMateriasSinAprobar = new List<Materia>();
            foreach (Materia materiaDelAlumnoAprobada in materiasAprobadas)
            {
                Materia materiaAprobada = materiasDeCarrera.FirstOrDefault(x => x.Equals(materiaDelAlumnoAprobada));
                if (materiaAprobada != null)
                {
                    foreach (var materiaDeCarrera in materiasDeCarrera)
                    {
                        if (materiaDeCarrera.Correlativas.Contains(materiaAprobada))
                        {
                            materiaDeCarrera.Correlativas.Remove(materiaDeCarrera);
                            listaDeMateriasSinAprobar.Add(materiaDeCarrera);
                        }
                    }
                }
            }
            return listaDeMateriasSinAprobar;
        }
        */

    }
}