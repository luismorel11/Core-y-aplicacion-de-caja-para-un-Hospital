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
    public class CD_DoctorProcedimiento
    {
        public static List<DoctorProcedimiento> Listar()
        {
            List<DoctorProcedimiento> rptListaDoctorProcedimiento = new List<DoctorProcedimiento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarDoctorProcedimiento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaDoctorProcedimiento.Add(new DoctorProcedimiento()
                        {
                            IdDoctorProcedimiento = Convert.ToInt32(dr["IdDoctorProcedimiento"].ToString()),
                            oNivelDetalleProcedimiento = new NivelDetalleProcedimiento()
                            {
                                oArea = new Area()
                                {
                                    IdArea = Convert.ToInt32(dr["IdArea"].ToString()),
                                    DescripcionArea = dr["DescripcionArea"].ToString()
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
                                    Descripcion = dr["DescripcionCurso"].ToString()
                                }

                            },
                            oDoctor = new Doctor()
                            {
                                IdDoctor = Convert.ToInt32(dr["IdDoctor"].ToString()),
                                Codigo = dr["CodigoDoctor"].ToString(),
                                Nombres = dr["NombreDoctor"].ToString(),
                                Apellidos = dr["ApellidoDoctor"].ToString()
                            },
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaDoctorProcedimiento;

                }
                catch (Exception ex)
                {
                    rptListaDoctorProcedimiento = null;
                    return rptListaDoctorProcedimiento;
                }
            }
        }


        public static bool Registrar(DoctorProcedimiento oDoctorProcedimiento)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarDoctorProcedimiento", oConexion);
                    cmd.Parameters.AddWithValue("IdArea", oDoctorProcedimiento.oNivelDetalleProcedimiento.oArea.IdArea);
                    cmd.Parameters.AddWithValue("Idhabitacion", oDoctorProcedimiento.oNivelDetalleProcedimiento.oHabitaciones.IdHabitaciones);
                    cmd.Parameters.AddWithValue("IdProcedimiento", oDoctorProcedimiento.oNivelDetalleProcedimiento.oProcedimiento.IdProcedimiento);
                    cmd.Parameters.AddWithValue("IdDoctor", oDoctorProcedimiento.oDoctor.IdDoctor);
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

        public static bool Eliminar(int idDoctorProcedimiento)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarDoctorProcedimiento", oConexion);
                    cmd.Parameters.AddWithValue("IdDoctorProcedimiento", idDoctorProcedimiento);
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
