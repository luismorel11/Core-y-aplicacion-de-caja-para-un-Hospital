using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Paciente
    {

        public static List<Paciente> Listar()
        {
            List<Paciente> rptListaPaciente = new List<Paciente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarPacientes", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaPaciente.Add(new Paciente()
                        {
                            IdPaciente = Convert.ToInt32(dr["IdPaciente"].ToString()),
                            Codigo = dr["Codigo"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString()),
                            Sexo = dr["Sexo"].ToString(),
                           
                            Direccion = dr["Direccion"].ToString(),

                            Deuda = (float)Convert.ToDecimal(dr["Deuda"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaPaciente;

                }
                catch (Exception ex)
                {
                    rptListaPaciente = null;
                    return rptListaPaciente;
                }
            }
        }

        public static DataTable Reporte(string Nombres, string Apellidos, string Codigo, string DocumentoIdentidad)
        {
            List<Paciente> rptListPacientes = new List<Paciente>();
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlDataAdapter da = new SqlDataAdapter("usp_ReportePaciente", oConexion);
                da.SelectCommand.Parameters.AddWithValue("Nombres", Nombres);
                da.SelectCommand.Parameters.AddWithValue("Apellidos", Apellidos);
                da.SelectCommand.Parameters.AddWithValue("Codigo", Codigo);
                da.SelectCommand.Parameters.AddWithValue("DocumentoIdentidad", DocumentoIdentidad);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return dt;
                }
            }
        }


        public static bool Registrar(Paciente oPaciente)
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


        public static bool Editar(Paciente oPaciente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarPaciente", oConexion);
                    cmd.Parameters.AddWithValue("IdPaciente", oPaciente.IdPaciente);
                    cmd.Parameters.AddWithValue("Codigo", oPaciente.Codigo);
                    cmd.Parameters.AddWithValue("Nombres", oPaciente.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oPaciente.Apellidos);
                    cmd.Parameters.AddWithValue("DocumentoIdentidad", oPaciente.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oPaciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Sexo", oPaciente.Sexo);
                    cmd.Parameters.AddWithValue("Deuda", oPaciente.Deuda);
                    cmd.Parameters.AddWithValue("Direccion", oPaciente.Direccion);
                    cmd.Parameters.AddWithValue("Activo", oPaciente.Activo);
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

        public static bool Eliminar(int idpaciente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarPaciente", oConexion);
                    cmd.Parameters.AddWithValue("IdPaciente", idpaciente);
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
