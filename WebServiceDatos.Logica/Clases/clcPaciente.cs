using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaModelo;

namespace WebServiceDatos.Logica.Clases
{
    public class clcPaciente
    {
        string stConexion;
        SqlCommand sqlCommand = null;
        SqlConnection sqlConnection = null;
        SqlParameter sqlParameter = null;
        SqlDataAdapter sqlDataAdapter = null;

        public clcPaciente()
        {
            Conexion conexionWeb = new Conexion();
            stConexion = conexionWeb.getconexion();
        }


        
        public bool stInsertarPaciente(string Nombres, string Apellidos, String DocumentoIdentidad, DateTime Fechanacimiento, string sexo, string deuda, string direccion)
        {
            bool respuesta = true;
            try
            {

                sqlConnection = new SqlConnection(stConexion);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("usp_RegistrarPaciente", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Nombres", Nombres);
                sqlCommand.Parameters.AddWithValue("@Apellidos", Apellidos);
                sqlCommand.Parameters.AddWithValue("@DocumentoIdentidad", DocumentoIdentidad);
                sqlCommand.Parameters.AddWithValue("@FechaNacimiento", Fechanacimiento);
                sqlCommand.Parameters.AddWithValue("@Sexo", sexo);
                sqlCommand.Parameters.AddWithValue("@Deuda", deuda);
                sqlCommand.Parameters.AddWithValue("@Direccion", direccion);

               

                sqlCommand.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                sqlCommand.ExecuteNonQuery();
                respuesta = Convert.ToBoolean(sqlCommand.Parameters["Resultado"].Value);

                //return sqlParameter.Value.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { sqlConnection.Close(); }

            return respuesta;
        }
        


    }
}
