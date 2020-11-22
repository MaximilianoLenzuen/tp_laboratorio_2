using Excepctions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AccesoDataBase  
    {
        private SqlConnection sqlConnection;
        private string connectionString;

        public AccesoDataBase()
        {
            this.connectionString = "Server=.;Database=EntidadesDB;Trusted_Connection=True;";
            this.sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Recibirá una unidad o edificio que guardará en una base de datos
        /// </summary>
        /// <param name="entidad"></param>
        public void EjecutarVenta<TEntidad>(TEntidad entidad) where TEntidad : EntidadMilitar
        {
            try
            {
                string command = "INSERT INTO UnidadesVendidas(nombre, tipo) " +
                "VALUES (@nombre,@tipo)";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("nombre", entidad.Nombre);
                sqlCommand.Parameters.AddWithValue("tipo", entidad.GetType().ToString());
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (this.sqlConnection.State == System.Data.ConnectionState.Open)
                    this.sqlConnection.Close();
            }

        }

        /// <summary>
        /// Verificará si existe en la base de datos el nombre ingresa, y en caso de ser así, de qué tipo es la entidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public string BuscarTipoPorNombre(string nombre)
        {
            try
            {
                string command = "SELECT Tipo FROM EntidadesMilitares where Nombre='" + nombre + "'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    string tipo = (string)reader["Tipo"];
                    return tipo;
                }
                else
                {
                    throw new NoExisteEnDB();
                }
            }
            finally
            {
                if (this.sqlConnection.State == System.Data.ConnectionState.Open)
                    this.sqlConnection.Close();
            }
        }

        /// <summary>
        /// Ya habiendo verificado antes que exista en la base de datos y al ser unica la entidad encontrada, la leerá y me devolverá la informacion
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Unidad BuscarUnidad(string nombre)
        {
            try
            {
                string command = "SELECT * FROM EntidadesMilitares where Nombre='" + nombre + "'";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                string nombreUnidad = (string)reader["Nombre"];
                int comida = (int)reader["Comida"];
                int madera = (int)reader["Madera"];
                int oro = (int)reader["Oro"];
                int piedra = (int)reader["Piedra"];
                Unidad unidad = new Unidad(nombreUnidad, madera, comida, oro, piedra);
                return unidad;
            }
            finally
            {
                if (this.sqlConnection.State == System.Data.ConnectionState.Open)
                    this.sqlConnection.Close();
            }
        }

        public Edificio BuscarEdificio(string nombre)
        {
            try
            {
                string command = "SELECT * FROM EntidadesMilitares where Nombre='" + nombre + "'";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                string nombreUnidad = (string)reader["Nombre"];
                int comida = (int)reader["Comida"];
                int madera = (int)reader["Madera"];
                int oro = (int)reader["Oro"];
                int piedra = (int)reader["Piedra"];
                Edificio edificio = new Edificio(nombreUnidad, madera, comida, oro, piedra);
                return edificio;
            }
            finally
            {
                if (this.sqlConnection.State == System.Data.ConnectionState.Open)
                    this.sqlConnection.Close();
            }

        }

    }
}
