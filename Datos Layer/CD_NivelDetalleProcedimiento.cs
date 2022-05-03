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
   
    public class CD_NivelDetalleProcedimiento
    {

        public static List<NivelDetalleProcedimiento> Listar()
        {
            List<NivelDetalleProcedimiento> rptListaNivelDetalleProcedimiento = new List<NivelDetalleProcedimiento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarProcedimientoAsignado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaNivelDetalleProcedimiento.Add(new NivelDetalleProcedimiento()
                        {
                            IdNivelDetalleProcedimiento = Convert.ToInt32(dr["IdNivelDetalleProcedimiento"].ToString()),
                            oAreaDetalle = new AreaDetalle() { IdAreaDetalle = Convert.ToInt32(dr["idareadetalle"].ToString()) },
                            oArea = new Area()
                            {
                                IdArea = Convert.ToInt32(dr["IdArea"].ToString()),
                                DescripcionArea = dr["DescripcionArea"].ToString(),
                                DescripcionHorario = dr["DescripcionHorario"].ToString(),
                                HoraInicio = Convert.ToDateTime(dr["HoraInicio"].ToString()),
                                HoraFin = Convert.ToDateTime(dr["HoraFin"].ToString())
                            },
                            oHabitaciones = new Habitaciones()
                            {
                                IdHabitaciones = Convert.ToInt32(dr["IdHabitaciones"].ToString()),
                                DescripcionHabitacion = dr["DescripcionHabitacion"].ToString(),
                                DescripcionCamas = dr["DescripcionCamas"].ToString()
                            },
                            oProcedimiento = new Procedimiento()
                            {
                                IdProcedimiento = Convert.ToInt32(dr["IdProcedimiento"].ToString()),
                                Descripcion = dr["Descripcion"].ToString(),
                                //Costo=(float)Convert.ToDecimal( dr["Costo"].ToString()),
                                Activo = Convert.ToBoolean(dr["ProcedimientosActivo"]),
                            }

                        });
                    }
                    dr.Close();

                    return rptListaNivelDetalleProcedimiento;

                }
                catch (Exception ex)
                {
                    rptListaNivelDetalleProcedimiento = null;
                    return rptListaNivelDetalleProcedimiento;
                }
            }
        }

        public static bool Asignar(string xml)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_AsginarProcedimiento", oConexion);
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

