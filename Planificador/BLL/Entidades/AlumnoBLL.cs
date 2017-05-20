using System;
using System.Collections.Generic;
using System.Linq;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class AlumnoBLL
    {
        public static Alumno ObtenerAlumno(string nombreAlumno)
        {
            DataManager dm = DataManager.Instance(Constantes.Constantes.DataManagerPath);
            //return dm.ObtenerAlumnoEnApp();
            throw new NotImplementedException();
        }

        public static Alumno GenerateFromDataLine(string fromDataLine)
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

        public static string ToDataLine(Alumno alumno)
        {
            return "[Alumno]," + alumno.Id + "," + alumno.Dni + "," + alumno.Nombre;
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