using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceDatos.Logica.Clases;
using System.Data;
using System.Data.SqlClient;
using WebServiceDatos.Logica;
using Conexion = WebServiceDatos.Logica.Conexion;

namespace WebCore.Ws.Servicios
{
    /// <summary>
    /// Summary description for Pacientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Pacientes : System.Web.Services.WebService
    {

        [WebMethod]
        public bool InsertarPacientes(string Nombres, string Apellidos, String DocumentoIdentidad, DateTime Fechanacimiento, string sexo, string deuda, string direccion)
        {
            try
            {
                clcPaciente clcPaciente = new clcPaciente();
                return clcPaciente.stInsertarPaciente(Nombres,Apellidos,DocumentoIdentidad,Fechanacimiento,sexo,deuda,direccion);

            }catch(Exception ex) { throw ex; }
        }

        [WebMethod]

        public bool pacientecaja(string Nombre, string DocumentoIdentidad,int idpaciente)
        {
            //int respuesta = 0;
            try
            {
                pacientecajalogin pacientecajalogin = new pacientecajalogin();
                return pacientecajalogin.stPacientelogin(Nombre, DocumentoIdentidad,idpaciente);

            }
            catch (Exception ex) { throw ex; }
        }




        [WebMethod]

        public int loginPacientecaja(string Paciente, string DocumentoIdentidad)
        {
            int respuesta = 0;
            try
            {
                string stConexion;
                Conexion conexionWeb = new Conexion();
                stConexion = conexionWeb.getconexion();


                SqlConnection oConexion = new SqlConnection(stConexion);
                SqlCommand cmd = new SqlCommand("usp_loginPacienteCaja", oConexion);
                cmd.Parameters.AddWithValue("@Nombre", Paciente);
                cmd.Parameters.AddWithValue("@DocumentoIdentidad", DocumentoIdentidad);
                cmd.Parameters.Add("@idPaciente", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();

                cmd.ExecuteNonQuery();
                respuesta = Convert.ToInt32(cmd.Parameters["@idPaciente"].Value);

            }
            catch (Exception ex)
            {
                respuesta = 0;
            }
            return respuesta;
        }




       

        [WebMethod]

        public bool RegistrarPaciente(Paciente pacientes)
        {
            bool respuesta = true;
            try
            {
                CD_Paciente.Registrar(pacientes);

            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }





        [WebMethod]
        public bool AumentarCuenta(string Nombres, string DocumentoIdentidad, string DescripcionProcedimiento, float aumentar)
        {

            try
            {
                AumentarCuenta clcPaciente = new AumentarCuenta();
                return clcPaciente.stAumentarCuenta(Nombres,DocumentoIdentidad,DescripcionProcedimiento,aumentar);

            }
            catch (Exception ex) { throw ex; }

        }
        [WebMethod]

        public bool PagarCuenta(string Nombres, string DocumentoIdentidad, string DescripcionProcedimiento, float pagar)
        {

            try
            {
                PagarDeuda clcPaciente = new PagarDeuda();
                return clcPaciente.stpagarCuenta(Nombres, DocumentoIdentidad, DescripcionProcedimiento, pagar);

            }
            catch (Exception ex) { throw ex; }

        }



    }
}
