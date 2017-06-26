using System;
using System.Collections.Generic;
using System.Linq;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class LibretaBLL : IDataReader<Libreta>
    {
        private static LibretaBLL _instancia;
        public List<Libreta> ListaObj { get; }

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public static LibretaBLL Instance()
        {
            return _instancia ?? (_instancia = new LibretaBLL());
        }

        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        private LibretaBLL()
        {
            ListaObj = new List<Libreta>();
        }

        public string ToDataLine(Libreta obj)
        {
            throw new NotImplementedException();
        }

        public Libreta GenerateFromDataLine(string dataLine)
        {
            string[] datos = dataLine.Split(',');

            Alumno alumno = AlumnoBLL.ObtenerAlumno(int.Parse(datos[1]));
            Libreta libreta = LibretaBLL.ObtenerLibreta(alumno.Id);
            Materia materia = MateriaBLL.ObtenerMateria(int.Parse(datos[2]));
            Double nota = double.Parse(datos[3]);
            DateTime fechaAprobacion = DateTime.Parse(datos[4]);

            if (libreta == null)
            {
                libreta = new Libreta
                {
                    Id = int.Parse(datos[1]),
                    Alumno = alumno,
                    MateriaAprobada = new List<MateriaAprobada>()
                };

                _instancia.ListaObj.Add(libreta);
            }
            
            MateriaAprobada aprobada = new MateriaAprobada
            {
                Materia = materia,
                LibretaId = libreta.Id,
                Nota = nota,
                FechaAprobacion = fechaAprobacion
            };
            libreta.MateriaAprobada.Add(aprobada);
            

            return libreta;
        }

        public static Libreta ObtenerLibreta(int idAlumno)
        {
            return _instancia.ListaObj.FirstOrDefault(l => l.Alumno.Id == idAlumno);
        }
    }
}
