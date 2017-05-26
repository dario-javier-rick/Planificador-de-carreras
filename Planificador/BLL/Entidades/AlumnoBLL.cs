using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class AlumnoBLL : IDataReader<Alumno>, IDisposable
    {
		DataManager dm = DataManager.Instance(Constantes.Constantes.DataManagerPath);

		public string ToDataLine(Alumno alumno)
		{
			return "[Alumno]," + alumno.Id + "," + alumno.Dni + "," + alumno.Nombre;
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

		public static Alumno ObtenerAlumno(string nombreAlumno)
		{
            return null;//dm.ObtenerAlumnosEnApp(); //.FirstOrDefault(a => a.Nombre == nombreAlumno);
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

        public void Close()
        {
            throw new NotImplementedException();
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public object GetValue(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
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