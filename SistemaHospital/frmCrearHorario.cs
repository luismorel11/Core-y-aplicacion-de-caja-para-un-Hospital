﻿using CapaDatos;
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
    public partial class frmCrearHorario : Form
    {
        public frmCrearHorario()
        {
            InitializeComponent();
        }

        DataTable tabla = new DataTable();
        private void frmCrearHorario_Load(object sender, EventArgs e)
        {

            List<Periodo> oListaPeriodo = CD_Periodo.Listar();
            if (oListaPeriodo != null)
            {
                foreach (Periodo row in oListaPeriodo.Where(x => x.Activo == true))
                {
                    cboperiodo.Items.Add(new ComboBoxItem() { Value = row.IdPeriodo, Text = row.Descripcion });
                }
                cboperiodo.DisplayMember = "Text";
                cboperiodo.ValueMember = "Value";


            }

            if (cboperiodo.Items.Count > 0)
            {
                cboperiodo.SelectedIndex = 0;

                List<Area> oListaNivel = CD_Area.Listar();
                int idperiodo = Convert.ToInt32(((ComboBoxItem)cboperiodo.SelectedItem).Value);
                cbonivel.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Area" });

                if (oListaNivel != null)
                {
                    foreach (Area row in oListaNivel.Where(x => x.Activo == true && x.oPeriodo.IdPeriodo == idperiodo))
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
                int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
                List<AreaDetalle> oListaNivelDetalle = CD_AreaDetalle.Listar();
                cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Habitacion" });

                if (oListaNivelDetalle != null)
                {
                    oListaNivelDetalle = oListaNivelDetalle.Where(x => x.oArea.IdArea == idnivel).ToList();


                    if (oListaNivelDetalle.Count > 0)
                    {
                        foreach (AreaDetalle row in oListaNivelDetalle.Where(x => x.Activo == true))
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

            cbodiasemana.Items.Add(new ComboBoxItem() { Value = "Lunes", Text = "Lunes" });
            cbodiasemana.Items.Add(new ComboBoxItem() { Value = "Martes", Text = "Martes" });
            cbodiasemana.Items.Add(new ComboBoxItem() { Value = "Miercoles", Text = "Miercoles" });
            cbodiasemana.Items.Add(new ComboBoxItem() { Value = "Jueves", Text = "Jueves" });
            cbodiasemana.Items.Add(new ComboBoxItem() { Value = "Viernes", Text = "Viernes" });
            cbodiasemana.Items.Add(new ComboBoxItem() { Value = "Sabado", Text = "Sabado" });
            cbodiasemana.Items.Add(new ComboBoxItem() { Value = "Domingo", Text = "Domingo" });
            cbodiasemana.DisplayMember = "Text";
            cbodiasemana.ValueMember = "Value";
            cbodiasemana.SelectedIndex = 0;

            txthorainicio.Value = DateTime.Now.Date;
            txthorafin.Value = DateTime.Now.Date;

        }

        private void CargarDatos()
        {
            cbocurso.Items.Clear();
            cbodiasemana.SelectedIndex = 0;
            txthorainicio.Value = DateTime.Now.Date;
            txthorafin.Value = DateTime.Now.Date;

            if (cbonivel.Items.Count < 1 || cboperiodo.Items.Count < 1 || cbogradoseccion.Items.Count < 1)
                return;


            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            if (idnivel == 0)
            {
                MessageBox.Show("Debe seleccionar un area", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            List<NivelDetalleProcedimiento> oListaNivelDetalleCurso = CD_NivelDetalleProcedimiento.Listar();

            //FILTRAMOS SEGUN NUESTRO PARAMETROS DE FILTRO
            if (oListaNivelDetalleCurso != null)
            {
                oListaNivelDetalleCurso = oListaNivelDetalleCurso.Where(x =>
                x.oArea.IdArea == idnivel &&
                x.oHabitaciones.IdHabitaciones == idgradoseccion).ToList();

            }

            //OBTENEMOS LOS POR ASIGNAR Y LOS ASIGNADOS
            if (oListaCurso != null && oListaNivelDetalleCurso != null)
            {
                oListaCursosAsignados = (from a in oListaCurso
                                         join b in oListaNivelDetalleCurso on a.IdProcedimiento equals b.oProcedimiento.IdProcedimiento
                                         select a).ToList();

             
            }

            //PINTAMOS LOS ASIGNADOS EN EL LISTBOX
            cbocurso.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Procedimiento"});
            if (oListaCursosAsignados.Count > 0)
            {
                foreach (Procedimiento row in oListaCursosAsignados.Where(x => x.Activo == true))
                {
                    cbocurso.Items.Add(new ComboBoxItem() { Value = row.IdProcedimiento, Text = row.Descripcion });
                }

                lblmin.Text = "(Min. " + oListaNivelDetalleCurso[0].oArea.HoraInicio.ToString("H:mm:ss") + ")";
                lblmax.Text = "(Max. " +  oListaNivelDetalleCurso[0].oArea.HoraFin.ToString("H:mm:ss") + ")";

                    /*
             row.HoraInicio.ToString("H:mm:ss"),
                        row.HoraFin.ToString("H:mm:ss"),        
             */
            }
            cbocurso.DisplayMember = "Text";
            cbocurso.ValueMember = "Value";
            cbocurso.SelectedIndex = 0;
            //btnGuardar.Enabled = true;



            //MOSTRAMOS TODOS LOS HORARIOS POR NIVEL Y GRADOSECCION
            List<Horario> oListaHorario = CD_Horario.Listar();
            if(oListaHorario != null)
            {
                tabla = new DataTable();
                tabla.Columns.Clear();
                tabla.Rows.Clear();
                cboFiltro.Items.Clear();
                dgvdata.DataSource = null;
                dgvdata.Columns.Clear();
                dgvdata.Rows.Clear();


                tabla.Columns.Add("IdHorario", typeof(int));
                tabla.Columns.Add("IdProcedimiento", typeof(int));
                tabla.Columns.Add("Dia Semana", typeof(string));
                tabla.Columns.Add("Nombre Procedimiento", typeof(string));
                tabla.Columns.Add("Hora Inicio", typeof(string));
                tabla.Columns.Add("Hora Fin", typeof(string));
                tabla.Columns.Add("Activo", typeof(bool));

                foreach (Horario row in oListaHorario.Where(x => x.oNivelDetalleProcedimiento.oArea.IdArea == idnivel && x.oNivelDetalleProcedimiento.oHabitaciones.IdHabitaciones == idgradoseccion))
                {
                    tabla.Rows.Add(
                        row.IdHorario,
                        row.oNivelDetalleProcedimiento.oProcedimiento.IdProcedimiento,
                        row.DiaSemana,
                        row.oNivelDetalleProcedimiento.oProcedimiento.Descripcion,
                        row.HoraInicio.ToString("H:mm:ss"),
                        row.HoraFin.ToString("H:mm:ss"), row.Activo);
                }
                dgvdata.DataSource = tabla;

                dgvdata.Columns["IdHorario"].Visible = false;
                dgvdata.Columns["idProcedimiento"].Visible = false;
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
                    if (cl.Visible == true)
                    {
                        cboFiltro.Items.Add(cl.HeaderText);
                    }
                }
                cboFiltro.SelectedIndex = 0;
            }


        }

        private void cbonivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbogradoseccion.Items.Clear();

            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            List<AreaDetalle> oListaNivelDetalle = CD_AreaDetalle.Listar();
            cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Habitaciones" });

            if (oListaNivelDetalle != null)
            {
                oListaNivelDetalle = oListaNivelDetalle.Where(x => x.oArea.IdArea == idnivel).ToList();


                if (oListaNivelDetalle.Count > 0)
                {
                    foreach (AreaDetalle row in oListaNivelDetalle.Where(x => x.Activo == true))
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cboperiodo.Items.Count < 1 || cbonivel.Items.Count < 1 || cbogradoseccion.Items.Count < 1)
            {
                MessageBox.Show("No hay datos de busqueda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cbonivel.SelectedIndex ==  0 || cbogradoseccion.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar todos los datos de busqueda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            CargarDatos();
        }

        private void btnasignar_Click(object sender, EventArgs e)
        {
            if(cbocurso.Items.Count < 1)
            {
                MessageBox.Show("Debe realizar la busqueda primero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            int idgradoseccion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);
            int idcurso = Convert.ToInt32(((ComboBoxItem)cbocurso.SelectedItem).Value);

            if(idcurso == 0)
            {
                MessageBox.Show("Seleccione un curso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool encontrado = false;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if(Convert.ToInt32(row.Cells["IdProcedimiento"].Value) == idcurso &&
                   Convert.ToString(row.Cells["Dia Semana"].Value) == ((ComboBoxItem)cbodiasemana.SelectedItem).Value.ToString())
                {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                MessageBox.Show("Ya se encuentra registrado el curso y dia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            Horario oHorario = new Horario()
            {
                oNivelDetalleProcedimiento = new NivelDetalleProcedimiento(){
                    oArea = new Area() { IdArea = idnivel},
                    oHabitaciones = new Habitaciones() { IdHabitaciones = idgradoseccion},
                    oProcedimiento = new Procedimiento() { IdProcedimiento = idcurso}
                },
                DiaSemana = ((ComboBoxItem)cbodiasemana.SelectedItem).Value.ToString(),
                HoraInicio = txthorainicio.Value,
                HoraFin = txthorafin.Value
            };

            bool resultado = CD_Horario.Registrar(oHorario);

            if (resultado) {
                MessageBox.Show("Registro correcto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                Restablecer();
            }
            else
            {
                MessageBox.Show("No se pudo registrar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void Restablecer()
        {
            //cboperiodo.SelectedIndex = 0;
            //cbonivel.SelectedIndex = 0;
            //cbogradoseccion.SelectedIndex = 0;

            //cbocurso.Items.Clear();
            cbocurso.SelectedIndex = 0;
            cbodiasemana.SelectedIndex = 0;
            txthorainicio.Value = DateTime.Now.Date;
            txthorafin.Value = DateTime.Now.Date;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cboFiltro.SelectedItem.ToString();
            (dgvdata.DataSource as DataTable).DefaultView.RowFilter = string.Format("[" + columnaFiltro + "] like '%{0}%'", txtFilter.Text);
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
                        int idhorario = int.Parse(dgvdata.Rows[index].Cells["IdHorario"].Value.ToString());
                        bool Respuesta = CD_Horario.Eliminar(idhorario);

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

        private void cbocurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
