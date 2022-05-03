using CapaDatos;
using CapaModelo;
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

namespace SistemaHospital
{
    public partial class frmAsignarDoctor : Form
    {
        public frmAsignarDoctor()
        {
            InitializeComponent();
        }
        DataTable tabla = new DataTable();
        private void frmAsignarDocente_Load(object sender, EventArgs e)
        {
            List<Periodo> oListaPeriodo = CD_Periodo.Listar();
            List<Doctor> oListaDoctor = CD_Doctor.Listar();

            if (oListaPeriodo != null)
            {
                foreach (Periodo row in oListaPeriodo.Where(x => x.Activo == true))
                {
                    cboperiodo.Items.Add(new ComboBoxItem() { Value = row.IdPeriodo, Text = row.Descripcion });
                }
                cboperiodo.DisplayMember = "Text";
                cboperiodo.ValueMember = "Value";


            }

            cbodocente.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Doctor" });
            if (oListaDoctor != null)
            {
                foreach (Doctor row in oListaDoctor.Where(x => x.Activo == true))
                {
                    cbodocente.Items.Add(new ComboBoxItem() { Value = row.IdDoctor, Text = row.Nombres + " " + row.Apellidos });
                }
                cbodocente.DisplayMember = "Text";
                cbodocente.ValueMember = "Value";
                cbodocente.SelectedIndex = 0;
            }


            if (cboperiodo.Items.Count > 0)
            {
                cboperiodo.SelectedIndex = 0;

                List<Area> oListaArea = CD_Area.Listar();
                int idperiodo = Convert.ToInt32(((ComboBoxItem)cboperiodo.SelectedItem).Value);
                cbonivel.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Area" });

                if (oListaArea != null)
                {
                    foreach (Area row in oListaArea.Where(x => x.Activo == true && x.oPeriodo.IdPeriodo == idperiodo))
                    {
                        cbonivel.Items.Add(new ComboBoxItem() { Value = row.IdArea, Text = row.DescripcionArea });
                    }
                    cbonivel.DisplayMember = "Text";
                    cbonivel.ValueMember = "Value";
                    cbonivel.SelectedIndex = 0;

                }
            }

            if (cbonivel.Items.Count > 0)
            {
                cbonivel.SelectedIndex = 0;
                int idArea = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
                List<AreaDetalle> oListaAreaDetalle = CD_AreaDetalle.Listar();
                cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Habitacion" });

                if (oListaAreaDetalle != null)
                {
                    oListaAreaDetalle = oListaAreaDetalle.Where(x => x.oArea.IdArea == idArea).ToList();


                    if (oListaAreaDetalle.Count > 0)
                    {
                        foreach (AreaDetalle row in oListaAreaDetalle.Where(x => x.Activo == true))
                        {
                            cbogradoseccion.Items.Add(new ComboBoxItem()
                            {
                                Value = row.oHabitaciones.IdHabitaciones,
                                Text = row.oHabitaciones.DescripcionHabitacion + " - " + row.oHabitaciones.DescripcionCamas
                            });
                        }

                    }

                }

                cbogradoseccion.DisplayMember = "Text";
                cbogradoseccion.ValueMember = "Value";
                cbogradoseccion.SelectedIndex = 0;
            }




        }

        private void CargarDatos()
        {
            cbocurso.Items.Clear();

            //cbodocente.SelectedIndex = 0;

            if (cbonivel.Items.Count < 1 || cboperiodo.Items.Count < 1 || cbogradoseccion.Items.Count < 1)
                return;


            int idArea = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            if (idArea == 0)
            {
                MessageBox.Show("Debe seleccionar un Area", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idgradoseccion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);
            if (idgradoseccion == 0)
            {
                MessageBox.Show("Debe seleccionar un habitacion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //OBTENEMOS DATA
            List<Procedimiento> oListaCursosPorAsignar = new List<Procedimiento>();
            List<Procedimiento> oListaCursosAsignados = new List<Procedimiento>();

            List<Procedimiento> oListaCurso = CD_Procedimiento.Listar();
            List<NivelDetalleProcedimiento> oListaAreaDetalleCurso = CD_NivelDetalleProcedimiento.Listar();

            //FILTRAMOS SEGUN NUESTRO PARAMETROS DE FILTRO
            if (oListaAreaDetalleCurso != null)
            {
                oListaAreaDetalleCurso = oListaAreaDetalleCurso.Where(x =>
                x.oArea.IdArea == idArea &&
                x.oHabitaciones.IdHabitaciones == idgradoseccion).ToList();

            }

            //OBTENEMOS LOS POR ASIGNAR Y LOS ASIGNADOS
            if (oListaCurso != null && oListaAreaDetalleCurso != null)
            {
                oListaCursosAsignados = (from a in oListaCurso
                                         join b in oListaAreaDetalleCurso on a.IdProcedimiento equals b.oProcedimiento.IdProcedimiento
                                         select a).ToList();


            }

            //PINTAMOS LOS ASIGNADOS EN EL COMBOBOX
            cbocurso.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione procedimiento" });
            if (oListaCursosAsignados.Count > 0)
            {
                foreach (Procedimiento row in oListaCursosAsignados.Where(x => x.Activo == true))
                {
                    cbocurso.Items.Add(new ComboBoxItem() { Value = row.IdProcedimiento, Text = row.Descripcion });
                }

            }
            cbocurso.DisplayMember = "Text";
            cbocurso.ValueMember = "Value";
            cbocurso.SelectedIndex = 0;
            //btnGuardar.Enabled = true;

            CargarAsignado();


        }

        private void CargarAsignado()
        {
            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            int idgradoseccion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);
            //MOSTRAMOS TODOS LOS CURSOS ASIGNADOS POR NIVEL Y GRADOSECCION
            List<DoctorProcedimiento> oListaDoctorCurso = CD_DoctorProcedimiento.Listar();
            if (oListaDoctorCurso != null)
            {

                tabla = new DataTable();
                tabla.Columns.Clear();
                tabla.Rows.Clear();
                cboFiltro.Items.Clear();
                dgvdata.DataSource = null;
                dgvdata.Columns.Clear();
                dgvdata.Rows.Clear();


                tabla.Columns.Add("IdDoctorProcedimiento", typeof(int));
                tabla.Columns.Add("IdDoctor", typeof(int));
                tabla.Columns.Add("IdProcedimiento", typeof(int));
                tabla.Columns.Add("CodigoDoctor", typeof(string));
                tabla.Columns.Add("Doctor", typeof(string));
                tabla.Columns.Add("Area", typeof(string));
                tabla.Columns.Add("Habitaciones", typeof(string));
                tabla.Columns.Add("IdHabitaciones", typeof(string));
                tabla.Columns.Add("Activo", typeof(bool));

                foreach (DoctorProcedimiento row in oListaDoctorCurso.Where(x => x.oNivelDetalleProcedimiento.oArea.IdArea == idnivel && x.oNivelDetalleProcedimiento.oHabitaciones.IdHabitaciones == idgradoseccion))
                {
                    tabla.Rows.Add(
                        row.IdDoctorProcedimiento,
                        row.oDoctor.IdDoctor,
                        row.oNivelDetalleProcedimiento.oProcedimiento.IdProcedimiento,
                        row.oDoctor.Codigo,
                        row.oDoctor.Nombres + " " + row.oDoctor.Apellidos,
                        row.oNivelDetalleProcedimiento.oArea.DescripcionArea,
                        row.oNivelDetalleProcedimiento.oHabitaciones.DescripcionHabitacion + " " + row.oNivelDetalleProcedimiento.oHabitaciones.DescripcionCamas,
                        row.oNivelDetalleProcedimiento.oProcedimiento.Descripcion,
                        row.Activo);
                }

                dgvdata.DataSource = tabla;

                dgvdata.Columns["IdDoctorProcedimiento"].Visible = false;
                dgvdata.Columns["IdDoctor"].Visible = false;
                dgvdata.Columns["IdProcedimiento"].Visible = false;
                dgvdata.Columns["Activo"].Visible = false;

                //AGREGAR BOTON ELIMINAR
                DataGridViewButtonColumn BotonElimar = new DataGridViewButtonColumn();

                BotonElimar.HeaderText = "Eliminar";
                BotonElimar.Width = 50;
                BotonElimar.Text = "Eliminar";
                BotonElimar.Name = "btnEliminar";
                BotonElimar.FlatStyle = FlatStyle.Flat;
                BotonElimar.UseColumnTextForButtonValue = true;
                BotonElimar.CellTemplate.Style.BackColor = Color.Red;
                BotonElimar.CellTemplate.Style.ForeColor = Color.White;
                BotonElimar.CellTemplate.Style.SelectionBackColor = Color.Red;
                BotonElimar.CellTemplate.Style.SelectionForeColor = Color.White;

                //AGREGAMOS LOS BOTONES
                dgvdata.Columns.Add(BotonElimar);


                foreach (DataGridViewColumn cl in dgvdata.Columns)
                {
                    if (cl.Visible == true && cl.Name != "btnEliminar")
                    {
                        cboFiltro.Items.Add(cl.HeaderText);
                    }
                }
                cboFiltro.SelectedIndex = 0;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboperiodo.Items.Count < 1 || cbonivel.Items.Count < 1 || cbogradoseccion.Items.Count < 1)
            {
                MessageBox.Show("No hay datos de busqueda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cbonivel.SelectedIndex == 0 || cbogradoseccion.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar todos los datos de busqueda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            CargarDatos();
        }

        private void cbonivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbogradoseccion.Items.Clear();

            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            List<AreaDetalle> oListaAreaDetalle = CD_AreaDetalle.Listar();
            cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Habitacion" });

            if (oListaAreaDetalle != null)
            {
                oListaAreaDetalle = oListaAreaDetalle.Where(x => x.oArea.IdArea == idnivel).ToList();


                if (oListaAreaDetalle.Count > 0)
                {
                    foreach (AreaDetalle row in oListaAreaDetalle.Where(x => x.Activo == true))
                    {
                        cbogradoseccion.Items.Add(new ComboBoxItem()
                        {
                            Value = row.oHabitaciones.IdHabitaciones,
                            Text = row.oHabitaciones.DescripcionHabitacion + " - " + row.oHabitaciones.DescripcionCamas
                        });
                    }

                }

            }

            cbogradoseccion.DisplayMember = "Text";
            cbogradoseccion.ValueMember = "Value";
            cbogradoseccion.SelectedIndex = 0;
        }

        private void btnasignar_Click(object sender, EventArgs e)
        {
            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            int idgradoseccion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);


            if (cbodocente.Items.Count < 1 && cbocurso.Items.Count < 1)
            {
                MessageBox.Show("No existen datos para asignar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cbodocente.SelectedIndex == 0 || cbocurso.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione datos para asignar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idcurso = Convert.ToInt32(((ComboBoxItem)cbocurso.SelectedItem).Value);
            int iddocente = Convert.ToInt32(((ComboBoxItem)cbodocente.SelectedItem).Value);

            bool encontrado = false;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (Convert.ToInt32(row.Cells["IdProcedimiento"].Value) == idcurso)
                {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                MessageBox.Show("Ya se encuentra registrado el curso a un docente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            DoctorProcedimiento oDocenteCurso = new DoctorProcedimiento()
            {
                oNivelDetalleProcedimiento = new NivelDetalleProcedimiento()
                {
                    oArea = new Area() { IdArea = idnivel },
                    oHabitaciones = new Habitaciones() { IdHabitaciones = idgradoseccion },
                    oProcedimiento = new Procedimiento() { IdProcedimiento = idcurso }
                },
                oDoctor = new Doctor() { IdDoctor = iddocente }
            };

            bool respuesta = CD_DoctorProcedimiento.Registrar(oDocenteCurso);
            if (respuesta)
            {
                MessageBox.Show("Asignado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAsignado();
            }
            else
            {
                MessageBox.Show("No se pudo asignar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {

                    if (MessageBox.Show("¿Desea eliminar el registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int iddocentecurso = int.Parse(dgvdata.Rows[index].Cells["IdDocenteCurso"].Value.ToString());
                        bool Respuesta = CD_DoctorProcedimiento.Eliminar(iddocentecurso);

                        if (Respuesta)
                        {
                            dgvdata.Rows.RemoveAt(index);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar, revise su configuracion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }



                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cboFiltro.SelectedItem.ToString();
            (dgvdata.DataSource as DataTable).DefaultView.RowFilter = string.Format("[" + columnaFiltro + "] like '%{0}%'", txtFilter.Text);
        }
    }

}
