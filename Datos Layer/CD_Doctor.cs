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
    public class CD_Doctor
    {
        public static List<Doctor> Listar()
        {
            List<Doctor> rptListaDoctor = new List<Doctor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarDoctor", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaDoctor.Add(new Doctor()
                        {
                            IdDoctor = Convert.ToInt32(dr["IdDoctor"].ToString()),
                            Codigo = dr["Codigo"].ToString(),
                            DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString()),
                            Sexo = dr["Sexo"].ToString(),
                            GradoEstudio = dr["GradoEstudio"].ToString(),
                            Ciudad = dr["Ciudad"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Email = dr["Email"].ToString(),
                            NumeroTelefono = dr["NumeroTelefono"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaDoctor;

                }
                catch (Exception ex)
                {
                    rptListaDoctor = null;
                    return rptListaDoctor;
                }
            }
        }


        public static bool Registrar(Doctor oDoctor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarDoctor", oConexion);
                    cmd.Parameters.AddWithValue("DocumentoIdentidad", oDoctor.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("Nombres", oDoctor.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oDoctor.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oDoctor.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Sexo", oDoctor.Sexo);
                    cmd.Parameters.AddWithValue("GradoEstudio", oDoctor.GradoEstudio);
                    cmd.Parameters.AddWithValue("Ciudad", oDoctor.Ciudad);
                    cmd.Parameters.AddWithValue("Direccion", oDoctor.Direccion);
                    cmd.Parameters.AddWithValue("Email", oDoctor.Email);
                    cmd.Parameters.AddWithValue("NumeroTelefono", oDoctor.NumeroTelefono);
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


        public static bool Editar(Doctor oDoctor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarDoctor", oConexion);
                    cmd.Parameters.AddWithValue("IdDoctor", oDoctor.IdDoctor);
                    cmd.Parameters.AddWithValue("DocumentoIdentidad", oDoctor.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("Nombres", oDoctor.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oDoctor.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oDoctor.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Sexo", oDoctor.Sexo);
                    cmd.Parameters.AddWithValue("GradoEstudio", oDoctor.GradoEstudio);
                    cmd.Parameters.AddWithValue("Ciudad", oDoctor.Ciudad);
                    cmd.Parameters.AddWithValue("Direccion", oDoctor.Direccion);
                    cmd.Parameters.AddWithValue("Email", oDoctor.Email);
                    cmd.Parameters.AddWithValue("NumeroTelefono", oDoctor.NumeroTelefono);
                    cmd.Parameters.AddWithValue("Activo", oDoctor.Activo);
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

        public static bool Eliminar(int idDoctor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarDoctor", oConexion);
                    cmd.Parameters.AddWithValue("IdDoctor", idDoctor);
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
