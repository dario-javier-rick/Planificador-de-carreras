using System;
using System.Collections.Generic;
using Planificador.BLL.Entidades;
using Planificador.Models;

namespace Planificador.BLL
{
    public class DataManager
    {

        private static DataManager instancia;

        //private static readonly Lazy<DataManager> instancia = new Lazy<DataManager>(() => new DataManager());
        private string path { get; set; }

        private List<Correlativa> correlativas { get; set; }
        private List<PlanDeEstudio> planes { get; set; }
        private List<Alumno> alumnos { get; set; }
        private List<Carrera> carreras { get; set; }
        private List<Cursada> cursadas { get; set; }
        private List<Materia> materias { get; set; }
        private List<Profesor> profesores { get; set; }
        private List<Libreta> libretas { get; set; }


        /* Nicolás Fernández, 12/05/2017, Contructor que va a correr todos los metodos privados para generar datos en memoria. */
        /*private DataManager()
        {
            /* Invento datos de mentira. */
        /*    CrearCarreras();
        }
        public static DataManager Instance
        {
            get
            {
                return instancia.Value;
            }
        }*/

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataManager Instance(string path)
        {
            if (instancia == null)
            {
                instancia = new DataManager(path);
            }
            return instancia;
        }

        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        /// <param name="path"></param>
        private DataManager(string path)
        {
            alumnos = new List<Alumno>();
            carreras = new List<Carrera>();
            planes = new List<PlanDeEstudio>();
            materias = new List<Materia>();

            //path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName).FullName;
            this.path = path;

            //CargarDatos(path + @"\Planificador\Data\Data.txt");
            //CargarDatos(path + @"\Planificador\Data\NewData.txt");
            //GuardarDatosEn(path + @"\Planificador\Data\Data.txt");
            //EliminarDatosDe(path + @"\Planificador\Data\NewData.txt");

            CargarDatos(path + @"\Data.txt");
            //CargarDatos(path + @"\NewData.txt");

            //GuardarDatosEn(path + @"\Data.txt");
            //EliminarDatosDe(path + @"\NewData.txt");
        }

        /* Nicolás Fernández, 18/05/2017, Carga datos desde el archivo. */
        public void CargarDatos(string fromData)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(fromData);

            string line = "";


            int i = 1;
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("[Alumno]"))
                {
                    alumnos.Add(AlumnoBLL.GenerateFromDataLine(line));
                }

                if (line.Contains("[Carrera]"))
                {
                    carreras.Add(CarreraBLL.GenerateFromDataLine(line));
                }
                i++;
            }

            file.Close();
        }

        /* Nicolás Fernández, 18/05/2017, Genera nuevamente los datos Iniciales. */
        public void ResetDatos()
        {
            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\hola\Desktop\Nicolas\Test.txt");
            /*System.IO.StreamWriter file = new System.IO.StreamWriter(path + @"\Planificador\Data\Data.txt");
            file.WriteLine("Hola mundo");
            file.WriteLine(path + @"\Planificador\Data\Data.txt");
            CrearCarreras();
            foreach(Carrera c in carreras)
            {
                file.WriteLine("[Carrera]," + c.CodCarrera + "," + c.NombreCarrera);
            }
            CrearPlanes();
            file.Close();
            CargarDatos(path + @"\Planificador\Data\Data.txt");*/
            System.IO.StreamWriter file = new System.IO.StreamWriter(path + @"\Planificador\Data\NewData.txt");
            file.Close();
        }

        private void GuardarDatosEn(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            //file.WriteLine("HOla");
            foreach (Alumno a in alumnos)
            {
                file.WriteLine("a");
                file.WriteLine(AlumnoBLL.ToDataLine(a));
            }
            foreach (Carrera c in carreras)
            {
                file.WriteLine("c");
                file.WriteLine(CarreraBLL.ToDataLine(c));
            }

            file.Close();
        }

        private void EliminarDatosDe(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            file.WriteLine("");
            file.Close();
        }

        /** Generación de datos. **/
        /* Nicolas Fernandez, 19/05/2017, Agregar Carrera */
        public void RegistrarCarrera(Carrera carrera)
        {
            if (carrera.CodigoCarrera == 0)
            {
                string dataCarrera = "[Carrera],";
                int cod = AsignarCodCarrera();
                carreras.Add(new Carrera{CodigoCarrera = cod, Nombre = carrera.Nombre});
                dataCarrera += cod + "," + carrera.Nombre;
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + @"\Planificador\Data\NewData.txt", true);
                file.WriteLine(dataCarrera);
                file.Close();
            }
            else
            {
                carreras.Add(carrera);
            }
        }

        /* Nicolás Fernández, 12/05/2017, Creación de metodo interno para generar datos de testeo. */
        private void CrearCarreras()
        {
            new Carrera { Nombre = "Tecnicatura Superior en Sistemas" };
            new Carrera { Nombre = "Licenciatura en Sistemas" };
            new Carrera { Nombre = "Ingenieria Industrial" };
            new Carrera { Nombre = "Licenciatura en Economia" };
        }

        /* Nicolás Fernández, 17/05/2017, Con el siguiente metodo se generan los planes de estudio iniciales. */
        public void CrearPlanes()
        {
            //PlanDeEstudio planTecSistemas = new PlanDeEstudio(carreras.Find(x => x.NombreCarrera.Equals("Tecnicatura Superior en Sistemas")));

            /*
            PlanDeEstudio planLicSistemas = new PlanDeEstudio(carreras.Find(x => x.NombreCarrera.Equals("Licenciatura en Sistemas")));
            Materia intProg = new Materia("Introducción a la Programación");
            planLicSistemas.AgregarMateria(intProg);
            Materia intMat = new Materia("Introducción a la Matemática");
            planLicSistemas.AgregarMateria(intMat);
            Materia talLec = new Materia("Taller de Lectoescritura");
            planLicSistemas.AgregarMateria(talLec);
            Materia progr1 = new Materia("Programación I");
            planLicSistemas.AgregarMateriaConCorrelativa(progr1, intProg);
            Materia loTeNu = new Materia("Lógica y Teoría de Números");
            planLicSistemas.AgregarMateriaConCorrelativa(loTeNu, intMat);
            Materia orgCo1 = new Materia("Organización del Computador");
            planLicSistemas.AgregarMateriaConCorrelativa(orgCo1, intProg);
            Materia progr2 = new Materia("Programación II");
            planLicSistemas.AgregarMateriaConCorrelativa(progr2, progr1);
            Materia algLin = new Materia("Álgebra Lineal");
            planLicSistemas.AgregarMateriaConCorrelativa(algLin, intMat);
            Materia sisOpR = new Materia("Sistemas Operativos y Redes I");
            planLicSistemas.AgregarMateriaConCorrelativa(sisOpR, orgCo1);
            Materia progr3 = new Materia("Programación III");
            planLicSistemas.AgregarMateriaConCorrelativa(progr3, progr2);
            Materia calCom = new Materia("Cálculo para Computación");
            planLicSistemas.AgregarMateriaConCorrelativa(calCom, intMat);
            planLicSistemas.AgregarMateriaConCorrelativa(calCom, algLin);
            Materia prbSoc = new Materia("Problemas Socioeconómicos Contemporáneos");
            planLicSistemas.AgregarMateria(prbSoc);
            Materia basDat = new Materia("Bases de Datos I");
            planLicSistemas.AgregarMateriaConCorrelativa(basDat, loTeNu);
            planLicSistemas.AgregarMateriaConCorrelativa(basDat, progr2);
            planLicSistemas.AgregarMateriaConCorrelativa(basDat, orgCo1);
            Materia matDis = new Materia("Matemática Discreta");
            planLicSistemas.AgregarMateriaConCorrelativa(matDis, loTeNu);
            planLicSistemas.AgregarMateriaConCorrelativa(matDis, calCom);
            planLicSistemas.AgregarMateriaConCorrelativa(matDis, algLin);
            Materia esVeSo = new Materia("Especificación y Verificación de Software");
            
            PlanDeEstudio planIngIndustrial = new PlanDeEstudio(carreras.Find(x => x.NombreCarrera.Equals("Ingenieria Industrial")));
            PlanDeEstudio planLicEconomia = new PlanDeEstudio(carreras.Find(x => x.NombreCarrera.Equals("Licenciatura en Economia")));
    */
        }

        /* Nicolas Fernandez, 2/05/2017, Obtiene una carrera en particular. */
        public Carrera ObtenerCarrera(Carrera carrera)
        {
            foreach (Carrera c in this.carreras)
            {
                if (CarreraBLL.Mismas(carrera, c))
                    return c;
            }

            return null;
        }

        /** Obtencion de datos. **/
        public List<Carrera> ObtenerCarrerasEnApp()
        {
            return carreras;
        }

        public List<PlanDeEstudio> ObtenerPlanesdeEstudioEnApp()
        {
            return planes;
        }

        /* Nicolás Fernández, 17/05/2017, Devuelve listado de materias en el sistema. */
        public List<Materia> ObtenerMateriasEnApp()
        {
            return materias;
        }

        internal bool ExisteCarrera(Carrera carrera)
        {
            return carreras.Exists(x => x.Nombre.Equals(carrera.Nombre));
        }

        /* Nicolás Fernández, 17/05/2017, Retorna el resultado de la busqueda una materia. */
        public bool ExisteMateria(string NombreMateria)
        {
            bool existe = false;

            foreach (Materia mt in materias)
            {
                if (mt.Nombre.Equals(NombreMateria))
                {
                    existe = true;
                }
            }

            return existe;
        }

        /* Nicolás Fernández, 17/05/2017, Devuelve una materia particular */
        public Materia ObtenerMateria(string nombreMateria)
        {
            foreach (Materia mt in materias)
            {
                if (mt.Nombre.Equals(nombreMateria))
                    return mt;
            }

            return new Materia(); //("", "");
        }

        public void CrearUnNuevoPlanDeEstudio(PlanDeEstudio Plan)
        {
            planes.Add(Plan);
        }

        /** Nicolás Fernández, 18/05/2017, Otros metodos. **/
        /* Nicolás Fernández, 18/05/2017, Metodo para saber si la carrera exite. */
        public int CodigoDeCarrera(Carrera carrera)
        {
            if (carreras.Exists(x => x.Nombre.Equals(carrera.Nombre)))
            {
                return carreras.Find(x => x.Nombre.Equals(carrera.Nombre)).CodigoCarrera;
            }

            return 0;
        }

        /* Nicolás Fernández, 18/05/2017, Adignacion de código a carrera. */
        public int AsignarCodCarrera()
        {
            return carreras.Count + 1;
        }


    }
}