using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{

    public class CD_Habitaciones
    {
        public static List<Habitaciones> Listar()
        {
            List<Habitaciones> rptListaHabitaciones = new List<Habitaciones>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarHabitaciones", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaHabitaciones.Add(new Habitaciones()
                        {
                            IdHabitaciones = Convert.ToInt32(dr["IdHabitaciones"].ToString()),
                            DescripcionHabitacion = dr["DescripcionHabitacion"].ToString(),
                            DescripcionCamas = dr["DescripcionCamas"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activa"])

                        });
                    }
                    dr.Close();

                    return rptListaHabitaciones;

                }
                catch (Exception ex)
                {
                    rptListaHabitaciones = null;
                    return rptListaHabitaciones;
                }
            }
        }


        public static bool Registrar(Habitaciones oHabitaciones)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarHabitaciones", oConexion);
                    cmd.Parameters.AddWithValue("DescripcionHabitaciones", oHabitaciones.DescripcionHabitacion);
                    cmd.Parameters.AddWithValue("DescripcionCamas", oHabitaciones.DescripcionCamas);
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


        public static bool Editar(Habitaciones ohabitaciones)
        {

            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarHabitaciones", oConexion);
                    cmd.Parameters.AddWithValue("idhabitaciones", ohabitaciones.IdHabitaciones);
                    cmd.Parameters.AddWithValue("DescripcionHabitaciones", ohabitaciones.DescripcionHabitacion);
                    cmd.Parameters.AddWithValue("DescripcionCamas", ohabitaciones.DescripcionCamas);
                    cmd.Parameters.AddWithValue("Activa", ohabitaciones.Activo);
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

        public static bool Eliminar(int idHabitaciones)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarHabitacion", oConexion);
                    cmd.Parameters.AddWithValue("idHabitaciones", idHabitaciones);
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
