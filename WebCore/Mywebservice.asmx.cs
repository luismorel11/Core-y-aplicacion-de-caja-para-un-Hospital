using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;

namespace WebCore
{
    /// <summary>
    /// Summary description for Mywebservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Mywebservice : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]

        public int suma(int i, int a)
        {
            return i + a;
        }

        [WebMethod]
        public bool CrearPaciente(Paciente oPaciente)
        {

            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarPaciente", oConexion);
                    cmd.Parameters.AddWithValue("Nombres", oPaciente.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oPaciente.Apellidos);
                    cmd.Parameters.AddWithValue("DocumentoIdentidad", oPaciente.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oPaciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Sexo", oPaciente.Sexo);
                    cmd.Parameters.AddWithValue("Deuda", oPaciente.Deuda);
                    cmd.Parameters.AddWithValue("Direccion", oPaciente.Direccion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;
           






        }


    }
}
