using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{

    public class CD_GenerarReporte
    {
        public static List<GenerarReporte> Listar()
        {

            List<GenerarReporte> rptListaGenerarReporte = new List<GenerarReporte>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerGenerarReporte", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaGenerarReporte.Add(new GenerarReporte()
                        {
                            IdReporte = Convert.ToInt32(dr["IdReporte"].ToString()),
                            oAreaDetalle = new AreaDetalle()
                            {
                                oArea = new Area() { IdArea = Convert.ToInt32(dr["IdArea"].ToString()) },
                                oHabitaciones = new Habitaciones() { IdHabitaciones = Convert.ToInt32(dr["IdHabitaciones"].ToString()) }
                            },
                            oPaciente = new Paciente()
                            {
                                IdPaciente = Convert.ToInt32(dr["IdPaciente"].ToString()),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString()
                            }
                        });
                    }
                    dr.Close();

                    return rptListaGenerarReporte;

                }
                catch (Exception ex)
                {
                    rptListaGenerarReporte = new List<GenerarReporte>();
                    return rptListaGenerarReporte;
                }
            }
        }

        public static DataTable Reporte(string codigoReporte, string situacionReporte, string codigoPaciente, string DocumentoIdentidad,
            string Nombres, string Apellidos, string periodo, string Area, string Habitaciones)
        {
            List<Paciente> rptListaPaciente = new List<Paciente>();
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlDataAdapter da = new SqlDataAdapter("usp_ReporteRegistroReporte", oConexion);
                da.SelectCommand.Parameters.AddWithValue("CodigoReporte", codigoReporte);
                da.SelectCommand.Parameters.AddWithValue("SituacionReporte", situacionReporte);
                da.SelectCommand.Parameters.AddWithValue("CodigoPaciente", codigoPaciente);
                da.SelectCommand.Parameters.AddWithValue("DocumentoIdentidad", DocumentoIdentidad);
                da.SelectCommand.Parameters.AddWithValue("Nombres", Nombres);
                da.SelectCommand.Parameters.AddWithValue("Apellidos", Apellidos);
                da.SelectCommand.Parameters.AddWithValue("Periodo", periodo);
                da.SelectCommand.Parameters.AddWithValue("Area", Area);
                da.SelectCommand.Parameters.AddWithValue("Habitacion", Habitaciones);
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

        public static int Registrar(string xml)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarGenerarReporte", oConexion);
                    cmd.Parameters.Add("xml", SqlDbType.Xml).Value = xml;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }
    }
}
