using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Area
    {

        public static List<Area> Listar()
        {
            List<Area> rptListarArea = new List<Area>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarAreas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListarArea.Add(new Area()
                        {
                            IdArea = Convert.ToInt32(dr["IdArea"].ToString()),
                            oPeriodo = new Periodo()
                            {
                                IdPeriodo = Convert.ToInt32(dr["IdPeriodo"].ToString()),
                                Descripcion = dr["DescripcionPeriodo"].ToString(),
                            },
                            DescripcionArea = dr["DescripcionArea"].ToString(),
                            DescripcionHorario = dr["DescripcionHorario"].ToString(),
                            HoraInicio = Convert.ToDateTime(dr["HoraInicio"].ToString()),
                            HoraFin = Convert.ToDateTime(dr["HoraFin"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListarArea;

                }
                catch (Exception ex)
                {
                    rptListarArea = null;
                    return rptListarArea;
                }
            }
        }


        public static bool Registrar(Area oArea)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarArea", oConexion);
                    cmd.Parameters.AddWithValue("IdPeriodo", oArea.oPeriodo.IdPeriodo);
                    cmd.Parameters.AddWithValue("DescripcionArea", oArea.DescripcionArea);
                    cmd.Parameters.AddWithValue("DescripcionHorario", oArea.DescripcionHorario);
                    cmd.Parameters.AddWithValue("HoraInicio", oArea.HoraInicio);
                    cmd.Parameters.AddWithValue("HoraFin", oArea.HoraFin);
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


        public static bool Editar(Area oArea)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarArea", oConexion);
                    cmd.Parameters.AddWithValue("IdArea", oArea.IdArea);
                    cmd.Parameters.AddWithValue("IdPeriodo", oArea.oPeriodo.IdPeriodo);
                    cmd.Parameters.AddWithValue("DescripcionArea", oArea.DescripcionArea);
                    cmd.Parameters.AddWithValue("DescripcionHorario", oArea.DescripcionHorario);
                    cmd.Parameters.AddWithValue("HoraInicio", oArea.HoraInicio);
                    cmd.Parameters.AddWithValue("HoraFin", oArea.HoraFin);
                    cmd.Parameters.AddWithValue("Activo", oArea.Activo);
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

        public static bool Eliminar(int idArea)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarArea", oConexion);
                    cmd.Parameters.AddWithValue("IdArea", idArea);
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
