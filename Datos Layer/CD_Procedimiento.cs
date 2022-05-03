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
    public class CD_Procedimiento
    {

        public static List<Procedimiento> Listar()
        {
            List<Procedimiento> rptListaProcedimiento = new List<Procedimiento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarProcedimientos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaProcedimiento.Add(new Procedimiento()
                        {
                            IdProcedimiento = Convert.ToInt32(dr["IdProcedimiento"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                           // Costo = (float)Convert.ToDecimal(dr["Costo"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaProcedimiento;

                }
                catch (Exception ex)
                {
                    rptListaProcedimiento = null;
                    return rptListaProcedimiento;
                }
            }
        }


        public static bool Registrar(Procedimiento oProcedimiento)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarProcedimiento", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oProcedimiento.Descripcion);
                    cmd.Parameters.AddWithValue("Costo", oProcedimiento.Costo);
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


        public static bool Editar(Procedimiento oProcedimiento)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarProcedimiento", oConexion);
                    cmd.Parameters.AddWithValue("IdProcedimiento", oProcedimiento.IdProcedimiento);
                    cmd.Parameters.AddWithValue("Descripcion", oProcedimiento.Descripcion);
                    cmd.Parameters.AddWithValue("Costo", oProcedimiento.Costo);
                    cmd.Parameters.AddWithValue("Activo", oProcedimiento.Activo);
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

        public static bool Eliminar(int idProcedimiento)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarProcedimiento", oConexion);
                    cmd.Parameters.AddWithValue("IdProcedimiento", idProcedimiento);
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
