using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planificador.BLL
{
    public class Finder
    {
        /*
        protected static List<T> ObtenerObjetos<T>(ref T objeto) where T : ModelBase
        {
            List<T> dtoList = new List<T>();

            try
            {
                if (reader.HasRows)
                {
                    // Get a parser for this DTO type and populate
                    // the ordinals.
                    DTOParser parser = DTOParserFactory.GetParser(typeof(T));
                    parser.PopulateOrdinals(reader);
                    // Use the parser to build our list of DTOs.
                    while (reader.Read())
                    {
                        T dto = null;
                        dto = (T)parser.PopulateDTO(reader);
                        dtoList.Add(dto);
                    }
                    reader.Close();
                }
                else
                {
                    dtoList = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error en el Finder", e);
            }
            finally
            {
                //Id.Connection.Close();
                //Id.Connection.Dispose();
            }
            return dtoList;
        }

    */
    }
}