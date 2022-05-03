using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace CapaDatos
{

    public class CD_DetalleDoctorProcedimiento
    {
        public static List<Doctor> DetalleDoctorProcedimiento()
        {
            List<Doctor> oListarDoctorProcedimiento = new List<Doctor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_DetalleDoctorProcedimiento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("Doctores") != null)
                            {
                                oListarDoctorProcedimiento = (from Doctor in doc.Element("Doctores").Elements("Doctor")
                                                      select new Doctor()
                                                      {
                                                          IdDoctor = int.Parse(Doctor.Element("IdDoctor").Value),
                                                          Nombres = Doctor.Element("Nombres").Value,
                                                          Apellidos = Doctor.Element("Apellidos").Value,
                                                          oListaArea = Doctor.Element("Areas") != null ?
                                                            (from Area in Doctor.Element("Areas").Elements("Area")
                                                             select new Area()
                                                             {
                                                                 IdArea = int.Parse(Area.Element("IdArea").Value),
                                                                 DescripcionArea = Area.Element("DescripcionArea").Value,
                                                                 oListaHabitaciones = Area.Element("Habitaciones_camas") != null ?
                                                                 (from Habitaciones in Area.Element("Habitaciones_camas").Elements("Habitaciones")
                                                                  select new Habitaciones()
                                                                  {
                                                                      IdHabitaciones = int.Parse(Habitaciones.Element("IdHabitaciones").Value),
                                                                      DescripcionHabitacion = Habitaciones.Element("DescripcionHabitacion").Value,
                                                                      DescripcionCamas = Habitaciones.Element("DescripcionCamas").Value,
                                                                      oListaProcedimiento = Habitaciones.Element("Procedimiento") != null ?
                                                                      (from Procedimiento in Habitaciones.Element("Procedimiento").Elements("Procedimiento")
                                                                       select new Procedimiento()
                                                                       {
                                                                           IdProcedimiento = int.Parse(Procedimiento.Element("IdProcedimiento").Value),
                                                                           Descripcion = Procedimiento.Element("Descripcion").Value,
                                                                       }).ToList() : new List<Procedimiento>()
                                                                  }).ToList() : new List<Habitaciones>()
                                                             }
                                                            ).ToList() : new List<Area>()
                                                      }


                                    ).ToList();
                            }
                            else
                            {
                                oListarDoctorProcedimiento = new List<Doctor>();
                            }
                        }

                        dr.Close();

                    }

                    return oListarDoctorProcedimiento;
                }
                catch (Exception ex)
                {
                    oListarDoctorProcedimiento = new List<Doctor>();
                    return oListarDoctorProcedimiento;
                }
            }
        }


        public static bool Registrar(DoctorProcedimiento oDoctorProcedimiento, string Descripcion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarCurricula", oConexion);
                    cmd.Parameters.AddWithValue("Idarea", oDoctorProcedimiento.oNivelDetalleProcedimiento.oArea.IdArea);
                    cmd.Parameters.AddWithValue("Idhabitaciones", oDoctorProcedimiento.oNivelDetalleProcedimiento.oHabitaciones.IdHabitaciones);
                    cmd.Parameters.AddWithValue("Idprocedimiento", oDoctorProcedimiento.oNivelDetalleProcedimiento.oProcedimiento.IdProcedimiento);
                    cmd.Parameters.AddWithValue("Iddoctor", oDoctorProcedimiento.oDoctor.IdDoctor);
                    cmd.Parameters.AddWithValue("Descripcion", Descripcion);
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
