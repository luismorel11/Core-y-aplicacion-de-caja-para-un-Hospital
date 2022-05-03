using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
  

    public class CD_AreaDetalle
    {
        public static List<AreaDetalle> Listar()
        {
            List<AreaDetalle> rptListaAreaDetalle = new List<AreaDetalle>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarAreadetalle", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaAreaDetalle.Add(new AreaDetalle()
                        {
                            IdAreaDetalle = Convert.ToInt32(dr["IdAreaDetalle"].ToString()),
                            oArea = new Area()
                            {
                                IdArea = Convert.ToInt32(dr["IdArea"].ToString()),
                                DescripcionArea = dr["DescripcionArea"].ToString(),
                                DescripcionHorario = dr["DescripcionHorario"].ToString()
                            },
                            oHabitaciones = new Habitaciones()
                            {
                                IdHabitaciones = Convert.ToInt32(dr["IdHabitaciones"].ToString()),
                                DescripcionHabitacion = dr["DescripcionHabitacion"].ToString(),
                                DescripcionCamas = dr["DescripcionCamas"].ToString()
                            },
                            TotalVacantes = Convert.ToInt32(dr["TotalVacantes"].ToString()),
                            VacantesDisponibles = Convert.ToInt32(dr["VacantesDisponibles"].ToString()),
                            VacantesOcupadas = Convert.ToInt32(dr["VacantesOcupadas"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaAreaDetalle;

                }
                catch (Exception ex)
                {
                    rptListaAreaDetalle = null;
                    return rptListaAreaDetalle;
                }
            }
        }


        public static bool Registrar(string xml)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarAreaDetalle", oConexion);
                    cmd.Parameters.Add("xml", SqlDbType.Xml).Value = xml;
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

        public static bool RegistrarVacantes(string xml)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVacantes", oConexion);
                    cmd.Parameters.Add("xml", SqlDbType.Xml).Value = xml;
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
