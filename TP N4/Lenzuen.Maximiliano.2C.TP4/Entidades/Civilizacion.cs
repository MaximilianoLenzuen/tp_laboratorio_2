using Archivos;
using Excepctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Civilizacion
    {
        private List<Unidad> unidades;

        private List<Edificio> edificios;

        private int stockMadera;

        private int stockComida;

        private int stockOro;

        private int stockPiedra;

        private int limitePoblacion;

        private int poblacionActual;

        private static Civilizacion singleton;

        public static Civilizacion GetCivilizacion(int madera, int comida, int oro , int piedra)
        {
            if (singleton == null)
            {
                singleton =  new Civilizacion(madera,comida,oro,piedra);
            }
            return singleton;

        }

        #region Constructores

        public Civilizacion()
        {
            this.unidades = new List<Unidad>();
            this.edificios = new List<Edificio>();
        }

        private Civilizacion(int madera, int comida, int oro, int piedra) : this()
        {
            this.stockMadera = madera;
            this.stockComida = comida;
            this.stockOro = oro;
            this.stockPiedra = piedra;
            this.limitePoblacion = 15;
            this.poblacionActual = 0;
        }
        #endregion

        #region Properties
        public List<Unidad> Unidades
        {
            get { return this.unidades; }
        }

        public List<Edificio> Edificios
        {
            get { return this.edificios; }
        }

        public int PoblacionActual
        {
            get { return this.poblacionActual; }
            set { this.poblacionActual = value; }
        }
        public int StockMadera
        {
            get { return this.stockMadera; }
            set { this.stockMadera = value; }
        }

        public int StockComida
        {
            get { return this.stockComida; }
            set { this.stockComida = value; }
        }

        public int StockOro
        {
            get { return this.stockOro; }
            set { this.stockOro = value; }
        }

        public int StockPiedra
        {
            get { return this.stockPiedra; }
            set { this.stockPiedra = value; }
        }

        public int LimitePoblacion
        {
            get { return this.limitePoblacion; }
            set { this.limitePoblacion = value; }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Restará los recursos gastados a la civilizacion por la unidad
        /// </summary>
        /// <param name="civ"></param>
        /// <param name="unidad"></param>
        /// <returns></returns>
        public static Civilizacion operator -(Civilizacion civ, Unidad unidad)
        {
            civ.StockComida -= unidad.CostoComida;
            civ.StockMadera -= unidad.CostoMadera;
            civ.StockOro -= unidad.CostoOro;
            civ.StockPiedra -= unidad.CostoPiedra;
            civ.PoblacionActual += unidad.EspacioPoblacion;
            return civ;
        }
        /// <summary>
        /// Restará los recursos gastados a la civilizacion por el edificio
        /// </summary>
        /// <param name="civ"></param>
        /// <param name="edificio"></param>
        /// <returns></returns>
        public static Civilizacion operator -(Civilizacion civ, Edificio edificio)
        {
            civ.StockComida -= edificio.CostoComida;
            civ.StockMadera -= edificio.CostoMadera;
            civ.StockOro -= edificio.CostoOro;
            civ.StockPiedra -= edificio.CostoPiedra;
            return civ;
        }
        
        /// <summary>
        /// Agregará a la unidad a la base de datos UnidadesVendidas
        /// </summary>
        /// <param name="civ"></param>
        /// <param name="unidad"></param>
        /// <returns></returns>
        
        public static Civilizacion operator +(Civilizacion civ, Unidad unidad)
        {
            AccesoDataBase database = new AccesoDataBase();
            if (civ.ValidarRecursos(unidad,civ))
            {
                if (civ.PoblacionActual < civ.LimitePoblacion)
                {
                    database.EjecutarVenta<Unidad>(unidad);
                    civ.Unidades.Add(unidad);
                    civ -= unidad;
                }
                else
                {
                    throw new AlcanzadoLimitePoblacion();
                }
            }
            else
            {
                throw new FaltanRecursos();
            }
            return civ;
        }
        /// <summary>
        /// Agregará al edificio a la base de datos UnidadesVendidas
        /// </summary>
        /// <param name="civ"></param>
        /// <param name="edificio"></param>
        /// <returns></returns>
        public static Civilizacion operator +(Civilizacion civ, Edificio edificio)
        {
            AccesoDataBase database = new AccesoDataBase();
            if (civ.ValidarRecursos(edificio,civ))
            {
                database.EjecutarVenta<Edificio>(edificio);
                civ.Edificios.Add(edificio);
                civ -= edificio;
            }
            else
            {
                throw new FaltanRecursos();
            }
            return civ;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Validará que se posean la cantidad de recursos necesarios para realizar la compra 
        /// </summary>
        /// <param name="unidad"></param>
        /// <param name="civ"></param>
        /// <returns></returns>
        private bool ValidarRecursos(EntidadMilitar unidad, Civilizacion civ)
        {
            if (unidad.CostoComida <= civ.StockComida &&
                        unidad.CostoMadera <= civ.StockMadera &&
                        unidad.CostoOro <= civ.StockOro && unidad.CostoPiedra <= civ.StockPiedra)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Guardará los datos de la civilizacion en un archivo xml ubicado en el escritorio
        /// </summary>
        /// <param name="civ"></param>
        /// <returns></returns>
        public static bool Guardar(Civilizacion civ)
        {
            Xml<Civilizacion> xml = new Xml<Civilizacion>();
            return xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Civilizacion.xml", civ);
        }

        /// <summary>
        /// Leerá desde el archivo generado previamente en el escritorio
        /// </summary>
        /// <returns></returns>
        public static Civilizacion Leer()
        {
            Xml<Civilizacion> xml = new Xml<Civilizacion>();
            xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Civilizacion.xml", out Civilizacion universidad);
            return universidad;
        }

        /// <summary>
        /// Guardara la civilizacion en una carpeta localizada en el escritorio
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool GuardarTexto(Civilizacion civ)
        {
            Texto texto = new Texto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Civilizacion.txt";
            return texto.Guardar(ruta, civ.ToString());
        }

        /// <summary>
        /// Leerá la civilizacion en un archivo localizado en el escritorio
        /// </summary>
        /// <returns></returns>
        public static string LeerTexto()
        {
            Texto texto = new Texto();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Civilizacion.txt";

            if (!(texto.Leer(path, out string retorno)))
            {
                retorno = null;
            }
            return retorno;
        }
        /// <summary>
        /// Mostrará todos los datos
        /// </summary>
        /// <returns></returns>
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Unidades vendidas");
            foreach (Unidad unidad in this.Unidades)
            {
                sb.AppendLine(unidad.ToString());
            }
            sb.AppendLine("Edificios vendidos");

            foreach (Edificio edificio in this.Edificios)
            {
                sb.AppendLine(edificio.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
     
