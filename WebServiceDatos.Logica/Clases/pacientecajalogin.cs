using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebServiceDatos.Logica.Clases
{
    public class pacientecajalogin
    {

        string stConexion;
        SqlCommand sqlCommand = null;
        SqlConnection sqlConnection = null;
        SqlParameter sqlParameter = null;
        SqlDataAdapter sqlDataAdapter = null;

        public pacientecajalogin()
        {
            Conexion conexionWeb = new Conexion();
            stConexion = conexionWeb.getconexion();
        }



        public bool stPacientelogin(string Nombre, string DocumentoIdentidad,int idpaciente)
        {
            bool respuesta =true;
            try
            {

                sqlConnection = new SqlConnection(stConexion);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("usp_loginPaciente", sqlConnection);
                

                sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                sqlCommand.Parameters.AddWithValue("@DocumentoIdentidad", DocumentoIdentidad);
                sqlCommand.Parameters.AddWithValue("@idPaciente", idpaciente);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.ExecuteNonQuery();



                //return sqlParameter.Value.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { sqlConnection.Close(); }

            return respuesta;
        }
    }
}
