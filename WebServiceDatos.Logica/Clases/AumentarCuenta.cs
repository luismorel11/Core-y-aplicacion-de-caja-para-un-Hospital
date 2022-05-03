using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WebServiceDatos.Logica.Clases

{
    public class AumentarCuenta
    {

        string stConexion;
        SqlCommand sqlCommand = null;
        SqlConnection sqlConnection = null;
        SqlParameter sqlParameter = null;
        SqlDataAdapter sqlDataAdapter = null;

        public AumentarCuenta()
        {
            Conexion conexionWeb = new Conexion();
            stConexion = conexionWeb.getconexion();
        }



        public bool stAumentarCuenta(string Nombres, string DocumentoIdentidad, string DescripcionProcedimiento,float aumentar)
        {
            bool respuesta = true;
            try
            {

                sqlConnection = new SqlConnection(stConexion);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("usp_AumentarProPa", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Nombre", Nombres);
                sqlCommand.Parameters.AddWithValue("@DocumentoIdentidad", DocumentoIdentidad);
                sqlCommand.Parameters.AddWithValue("@DescripcionProcedimiento", DescripcionProcedimiento);
                sqlCommand.Parameters.AddWithValue("@aumetar", aumentar);
                sqlCommand.ExecuteNonQuery();




                //return sqlParameter.Value.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { sqlConnection.Close(); }

            return respuesta;
        }

    }
}
