using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planificador.BLL
{
    public class Finder
    {
        /*
        protected static List<T> ObtenerObjetos<T>(ref object objeto) where T : Models.Correlativa
        {
            List<T> dtoList = new List<T>();
            OracleDataReader reader = null;
            try
            {
                Id.Connection.Open();
                reader = Id.ExecuteReader();
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
                /*              else
                                {
                                    // Whenver there's no data, we return null. 
                                    dtoList = null;
                                } //COMMENT 11/12/2013
            }
            catch (Exception e)
            {
                UnitOfWork oUw = new UnitOfWork();
                LogDTO _log = new LogDTO();

                _log.sLog = " Error al ejecutar insert: " + Id.CommandText;
                _log.sIdWebApp = "VOP13";
                _log.sInsertusu = "VOP13";
                _log.dInsertfec = DateTime.Now;
                oUw.Add((IEntity)_log);

                LogDTO _log2 = new LogDTO();
                String parameters = "";
                int count = Id.Parameters.Count;

                for (int i = 0; i <= count - 1; i++)
                {
                    parameters += Id.Parameters[i].ParameterName + " " + Id.Parameters[i].Value;
                }

                _log2.sLog = "Parametros: " + parameters;
                _log2.sIdWebApp = "VOP13";
                _log2.sInsertusu = "VOP13";
                _log2.dInsertfec = DateTime.Now;
                oUw.Add((IEntity)_log2);


                LogDTO _log3 = new LogDTO();
                _log3.sLog = " error: " + e.Message;
                _log3.sIdWebApp = "VOP13";
                _log3.sInsertusu = "VOP13";
                _log3.dInsertfec = DateTime.Now;
                oUw.Add((IEntity)_log3);

                oUw.Committ();
                throw new Exception("Error en el Select", e);
            }
            finally
            {
                Id.Connection.Close();
                Id.Connection.Dispose();
            }
            return dtoList;
        }

    */
    }
}