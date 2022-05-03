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

    public class CD_EvaluarPaciente
    {
        public static List<EvaluarPaciente> Listar(int IdArea, int IdHabitaciones, int IdProcedimiento, int IdPaciente)
        {

            List<EvaluarPaciente> rptListaEvaluarPaciente = new List<EvaluarPaciente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {

                SqlCommand cmd = new SqlCommand("usp_EvaluarPaciente", oConexion);
                cmd.Parameters.AddWithValue("Idarea", IdArea);
                cmd.Parameters.AddWithValue("IdHabitacion", IdHabitaciones);
                cmd.Parameters.AddWithValue("IdProcedimiento", IdProcedimiento);
                cmd.Parameters.AddWithValue("IdPaciente", IdPaciente);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaEvaluarPaciente.Add(new EvaluarPaciente()
                        {   Analiticas =Convert.ToString( dr["Analiticas"].ToString()),
                            oCurricula = new Curricula()
                            {
                                IdCurricula = Convert.ToInt32(dr["IdCurricula"].ToString()),
                                Descripcion = dr["Descripcion"].ToString(),
                                oDoctorProcedimiento = new DoctorProcedimiento()
                                {
                                    oNivelDetalleProcedimiento = new NivelDetalleProcedimiento()
                                    {
                                        oProcedimiento = new Procedimiento() { IdProcedimiento = Convert.ToInt32(dr["IdProcedimiento"].ToString()) },
                                        oHabitaciones = new Habitaciones() { IdHabitaciones = Convert.ToInt32(dr["IdHabitacion"].ToString()) },
                                        oArea = new Area() { IdArea = Convert.ToInt32(dr["IdArea"].ToString()) }
                                    }
                                }
                            },
                            oPaciente = new Paciente() { IdPaciente = Convert.ToInt32(dr["IdPaciente"].ToString()) },

                        });
                    }
                    dr.Close();

                    return rptListaEvaluarPaciente;

                }
                catch (Exception ex)
                {
                    rptListaEvaluarPaciente = new List<EvaluarPaciente>();
                    return rptListaEvaluarPaciente;
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
                    SqlCommand cmd = new SqlCommand("usp_RegistrarEvaluarPaciente", oConexion);
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