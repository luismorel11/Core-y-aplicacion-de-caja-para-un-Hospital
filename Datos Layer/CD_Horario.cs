using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Horario
    {

        public static List<Horario> Listar()
        {
            List<Horario> rptListaHorario = new List<Horario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarHorario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaHorario.Add(new Horario()
                        {
                            IdHorario = Convert.ToInt32(dr["IdHorario"].ToString()),
                            oNivelDetalleProcedimiento = new NivelDetalleProcedimiento()
                            {
                                oProcedimiento = new Procedimiento()
                                {
                                    IdProcedimiento = Convert.ToInt32(dr["IdProcedimiento"].ToString()),
                                    Descripcion = dr["NombreProcedimiento"].ToString()

                                },
                                oArea = new Area()
                                {
                                    IdArea = Convert.ToInt32(dr["IdArea"].ToString())
                                },
                                oHabitaciones = new Habitaciones()
                                {
                                    IdHabitaciones = Convert.ToInt32(dr["IdHabitaciones"].ToString())
                                }
                            },
                            DiaSemana = dr["DiaSemana"].ToString(),
                            HoraInicio = Convert.ToDateTime(dr["HoraInicio"].ToString()),
                            HoraFin = Convert.ToDateTime(dr["HoraFin"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaHorario;

                }
                catch (Exception ex)
                {
                    rptListaHorario = null;
                    return rptListaHorario;
                }
            }
        }

        public static bool Registrar(Horario oHorario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("usp_RegistrarHorario", oConexion);
                    cmd.Parameters.AddWithValue("IdArea", oHorario.oNivelDetalleProcedimiento.oArea.IdArea);
                    cmd.Parameters.AddWithValue("IdHabitaciones", oHorario.oNivelDetalleProcedimiento.oHabitaciones.IdHabitaciones);
                    cmd.Parameters.AddWithValue("IdProcedimiento", oHorario.oNivelDetalleProcedimiento.oProcedimiento.IdProcedimiento);
                    cmd.Parameters.AddWithValue("DiaSemana", oHorario.DiaSemana);
                    cmd.Parameters.AddWithValue("HoraInicio", oHorario.HoraInicio);
                    cmd.Parameters.AddWithValue("HoraFin", oHorario.HoraFin);
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

        public static bool Eliminar(int idHorario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarHorario", oConexion);
                    cmd.Parameters.AddWithValue("IdHorario", idHorario);
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
