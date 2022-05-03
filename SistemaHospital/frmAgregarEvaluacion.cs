using CapaDatos;
using CapaModelo;
using SistemaHospital;
using SistemaHospital.Reutilizable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SistemaHospital
{
    public partial class frmAgregarEvaluacion : Form
    {
        public frmAgregarEvaluacion()
        {
            InitializeComponent();
        }
        List<Doctor> oListaDocenteCurso = new List<Doctor>();
        List<Doctor> oListaDocenteCursoTemp = new List<Doctor>();

        List<Area> oListaNivel = new List<Area>();
        List<Habitaciones> oListaGradoSeccion = new List<Habitaciones>();
        List<Procedimiento> oListaCurso = new List<Procedimiento>();
        DataTable tabla = new DataTable();

        private void frmAgregarCalificacion_Load(object sender, EventArgs e)
        {
            List<Periodo> oListaPeriodo = CD_Periodo.Listar();


            if (oListaPeriodo != null)
            {
                if (oListaPeriodo.Count > 0)
                {
                    foreach (Periodo row in oListaPeriodo.Where(x => x.Activo == true))
                    {
                        cboperiodo.Items.Add(new ComboBoxItem() { Value = row.IdPeriodo, Text = row.Descripcion });
                    }
                    cboperiodo.DisplayMember = "Text";
                    cboperiodo.ValueMember = "Value";
                    cboperiodo.SelectedIndex = 0;
                }
            }


            oListaDocenteCurso = CD_DetalleDoctorProcedimiento.DetalleDoctorProcedimiento();

            if (oListaDocenteCurso.Count > 0)
            {
                foreach (Doctor item in oListaDocenteCurso)
                {
                    cbodocente.Items.Add(new ComboBoxItem() { Value = item.IdDoctor, Text = item.Nombres + " " + item.Apellidos });
                }
                cbodocente.DisplayMember = "Text";
                cbodocente.ValueMember = "Value";
                cbodocente.SelectedIndex = 0;

                if (Configuracion.oUsuario.DescripcionReferencia == "DOCENTE")
                {
                    foreach (ComboBoxItem item in cbodocente.Items)
                    {
                        if ((int)item.Value == Configuracion.oUsuario.IdReferencia)
                        {
                            int id = cbodocente.Items.IndexOf(item);
                            cbodocente.SelectedIndex = id;
                            break;
                        }
                    }
                    cbodocente.Enabled = false;
                }

                cbodocente.SelectedIndex = 0;

                oListaDocenteCursoTemp = oListaDocenteCurso.Where(x => x.IdDoctor == int.Parse(((ComboBoxItem)cbodocente.SelectedItem).Value.ToString())).ToList();


                //LISTAR NIVEL ACADEMICO
                cbonivel.Items.Add(new ComboBoxItem() { Value = 0, Text = "Selecciona" });
                oListaNivel = (from lista in oListaDocenteCursoTemp from temp in lista.oListaArea select temp).ToList();
                if (oListaNivel.Count > 0)
                {
                    foreach (Area item in oListaNivel)
                    {
                        cbonivel.Items.Add(new ComboBoxItem() { Value = item.IdArea, Text = item.DescripcionArea });
                    }
                }
                cbonivel.DisplayMember = "Text";
                cbonivel.ValueMember = "Value";
                cbonivel.SelectedIndex = 0;

                //LISTAR GRADOSECCION
                cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Selecciona" });
                oListaGradoSeccion = (from lista in oListaNivel
                                      where lista.IdArea == int.Parse(((ComboBoxItem)cbonivel.SelectedItem).Value.ToString())
                                      from temp in lista.oListaHabitaciones
                                      select temp).ToList();
                if (oListaGradoSeccion.Count > 0)
                {
                    foreach (Habitaciones item in oListaGradoSeccion)
                    {
                        cbogradoseccion.Items.Add(new ComboBoxItem() { Value = item.IdHabitaciones, Text = item.DescripcionHabitacion + " - " + item.DescripcionCamas });
                    }
                }
                cbogradoseccion.DisplayMember = "Text";
                cbogradoseccion.ValueMember = "Value";
                cbogradoseccion.SelectedIndex = 0;

                //LISTAR CURSO
                cbocurso.Items.Add(new ComboBoxItem() { Value = 0, Text = "Selecciona" });
                oListaCurso = (from lista in oListaGradoSeccion
                               where lista.IdHabitaciones == int.Parse(((ComboBoxItem)cbogradoseccion.SelectedItem).Value.ToString())
                               from temp in lista.oListaProcedimiento
                               select temp).ToList();
                if (oListaCurso.Count > 0)
                {
                    foreach (Procedimiento item in oListaCurso)
                    {
                        cbocurso.Items.Add(new ComboBoxItem() { Value = item.IdProcedimiento, Text = item.Descripcion });
                    }
                }
                cbocurso.DisplayMember = "Text";
                cbocurso.ValueMember = "Value";
                cbocurso.SelectedIndex = 0;
            }

        }

        private void cbonivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbogradoseccion.Items.Clear();

            //LISTAR GRADOSECCION
            cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Selecciona" });
            oListaGradoSeccion = (from lista in oListaNivel
                                  where lista.IdArea == int.Parse(((ComboBoxItem)cbonivel.SelectedItem).Value.ToString())
                                  from temp in lista.oListaHabitaciones
                                  select temp).ToList();
            if (oListaGradoSeccion.Count > 0)
            {
                foreach (Habitaciones item in oListaGradoSeccion)
                {
                    cbogradoseccion.Items.Add(new ComboBoxItem() { Value = item.IdHabitaciones, Text = item.DescripcionHabitacion + " - " + item.DescripcionCamas });
                }
            }
            cbogradoseccion.DisplayMember = "Text";
            cbogradoseccion.ValueMember = "Value";
            cbogradoseccion.SelectedIndex = 0;

            cbogradoseccion_SelectionChangeCommitted(cbogradoseccion, null);
        }

        private void cbogradoseccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbocurso.Items.Clear();

            //LISTAR CURSO
            cbocurso.Items.Add(new ComboBoxItem() { Value = 0, Text = "Selecciona" });
            oListaCurso = (from lista in oListaGradoSeccion
                           where lista.IdHabitaciones == int.Parse(((ComboBoxItem)cbogradoseccion.SelectedItem).Value.ToString())
                           from temp in lista.oListaProcedimiento
                           select temp).ToList();
            if (oListaCurso.Count > 0)
            {
                foreach (Procedimiento item in oListaCurso)
                {
                    cbocurso.Items.Add(new ComboBoxItem() { Value = item.IdProcedimiento, Text = item.Descripcion });
                }
            }
            cbocurso.DisplayMember = "Text";
            cbocurso.ValueMember = "Value";
            cbocurso.SelectedIndex = 0;

            cboalumno.Items.Add(new ComboBoxItem() { Value = 0, Text = "Selecciona" });
            cboalumno.DisplayMember = "Text";
            cboalumno.ValueMember = "Value";
            cboalumno.SelectedIndex = 0;
        }

        private void cbodocente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbonivel.Items.Clear();
            oListaDocenteCursoTemp = oListaDocenteCurso.Where(x => x.IdDoctor == int.Parse(((ComboBoxItem)cbodocente.SelectedItem).Value.ToString())).ToList();


            //LISTAR NIVEL ACADEMICO
            cbonivel.Items.Add(new ComboBoxItem() { Value = 0, Text = "Selecciona" });
            oListaNivel = (from lista in oListaDocenteCursoTemp from temp in lista.oListaArea select temp).ToList();
            if (oListaNivel.Count > 0)
            {
                foreach (Area item in oListaNivel)
                {
                    cbonivel.Items.Add(new ComboBoxItem() { Value = item.IdArea, Text = item.DescripcionArea });
                }
            }
            cbonivel.DisplayMember = "Text";
            cbonivel.ValueMember = "Value";
            cbonivel.SelectedIndex = 0;

            cbonivel_SelectionChangeCommitted(cbonivel, null);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            cboalumno.Items.Clear();

            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            int idgradoseccion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);
            int idcurso = Convert.ToInt32(((ComboBoxItem)cbocurso.SelectedItem).Value);
            int iddocente = Convert.ToInt32(((ComboBoxItem)cbodocente.SelectedItem).Value);

            if (cbonivel.Items.Count < 1 || cbogradoseccion.Items.Count < 1 || cbocurso.Items.Count < 1 || cbodocente.Items.Count < 1)
            {
                MessageBox.Show("Faltan algunos datos para agregar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (idnivel == 0 || idgradoseccion == 0 || idcurso == 0 || iddocente == 0)
            {
                MessageBox.Show("Seleccione todos los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<GenerarReporte> oListaMatricula = CD_GenerarReporte.Listar();

            oListaMatricula = oListaMatricula.Where(x => x.oAreaDetalle.oArea.IdArea == idnivel && x.oAreaDetalle.oHabitaciones.IdHabitaciones == idgradoseccion).ToList();

            //LISTAR ALUMNOS POR NIVEL Y GRADO
            cboalumno.Items.Add(new ComboBoxItem() { Value = 0, Text = "Selecciona" });
            if (oListaMatricula.Count > 0)
            {
                foreach (GenerarReporte item in oListaMatricula) { cboalumno.Items.Add(new ComboBoxItem() { Value = item.oPaciente.IdPaciente , Text = item.oPaciente.Nombres + " " + item.oPaciente.Apellidos }); }
            }
            cboalumno.DisplayMember = "Text";
            cboalumno.ValueMember = "Value";
            cboalumno.SelectedIndex = 0;

            

        }

        private void btnvernotas_Click(object sender, EventArgs e)
        {


            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            int idgradoseccion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);
            int idcurso = Convert.ToInt32(((ComboBoxItem)cbocurso.SelectedItem).Value);
            int iddocente = Convert.ToInt32(((ComboBoxItem)cbodocente.SelectedItem).Value);
            int idalumno = Convert.ToInt32(((ComboBoxItem)cboalumno.SelectedItem).Value);

            if (cbonivel.Items.Count < 1 || cbogradoseccion.Items.Count < 1 || cbocurso.Items.Count < 1 || cbodocente.Items.Count < 1 || idalumno < 1)
            {
                MessageBox.Show("Faltan algunos datos para agregar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (idnivel == 0 || idgradoseccion == 0 || idcurso == 0 || iddocente == 0 || idalumno == 0)
            {
                MessageBox.Show("Seleccione todos los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //LISTAMOS CURRICULA
            List<Curricula> oListaCurricula = CD_Currricula.Listar(idnivel, idgradoseccion, idcurso, iddocente);
            List<EvaluarPaciente> oListaCalificacion = CD_EvaluarPaciente.Listar(idnivel, idgradoseccion, idcurso, idalumno);

            List<EvaluarPaciente> oListaCalificacionTemp = new List<EvaluarPaciente>();


            foreach(Curricula cu in oListaCurricula)
            {
                bool encontrado = false;
                foreach(EvaluarPaciente ca in oListaCalificacion)
                {
                    if(cu.IdCurricula == ca.oCurricula.IdCurricula)
                    {
                        encontrado = true;
                        oListaCalificacionTemp.Add(new EvaluarPaciente()
                        {
                            oCurricula = new Curricula()
                            {
                                IdCurricula = ca.oCurricula.IdCurricula,
                                Descripcion = ca.oCurricula.Descripcion,
                            },
                            Analiticas = ca.Analiticas
                        });
                        break;
                    }
                }
                if (!encontrado)
                {
                    oListaCalificacionTemp.Add(new EvaluarPaciente()
                    {
                        oCurricula = new Curricula()
                        {
                            IdCurricula = cu.IdCurricula,
                            Descripcion = cu.Descripcion,
                        },
                        Analiticas = ""
                    });
                }

            }

            if (oListaCalificacionTemp.Count > 0)
            {
                tabla = new DataTable();
                tabla.Columns.Clear();
                tabla.Rows.Clear();

                dgvdata.DataSource = null;
                dgvdata.Columns.Clear();
                dgvdata.Rows.Clear();

                tabla.Columns.Add("IdCurricula", typeof(int)).ReadOnly = true;
                tabla.Columns.Add("Descripcion", typeof(string)).ReadOnly = true;
                tabla.Columns.Add("Nota", typeof(string));

                foreach (EvaluarPaciente row in oListaCalificacionTemp)
                {
                    tabla.Rows.Add(row.oCurricula.IdCurricula, row.oCurricula.Descripcion,row.Analiticas);
                };

                dgvdata.DataSource = tabla;

                dgvdata.Columns["IdCurricula"].Visible = false;
            }
            btnguardarcambios.Enabled = true;
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            XElement DETALLE = new XElement("DETALLE");
            int idalumno = Convert.ToInt32(((ComboBoxItem)cboalumno.SelectedItem).Value);
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                DETALLE.Add(new XElement("DATA",
                    new XElement("IdCurricula", row.Cells["IdCurricula"].Value),
                    new XElement("IdPaciente", idalumno),
                    new XElement("Analiticas", row.Cells["Nota"].Value)
                    ));
            }


            bool resultado = CD_EvaluarPaciente.Registrar(DETALLE.ToString());

            if (resultado)
            {
                MessageBox.Show("Se guardaron los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnguardarcambios.Enabled = false;
                tabla = new DataTable();
                tabla.Columns.Clear();
                tabla.Rows.Clear();
                dgvdata.DataSource = tabla;
                cboalumno.SelectedIndex = 0;
            }
            else
                MessageBox.Show("No se guardaron los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
