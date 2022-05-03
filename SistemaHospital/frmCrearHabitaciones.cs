using CapaDatos;
using CapaModelo;
using SistemaHospital.Reutilizable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHospital
{
    public partial class frmCrearHabitaciones : Form
    {
        public frmCrearHabitaciones()
        {
            InitializeComponent();
        }

        DataTable tabla = new DataTable();
        private void frmCrearHabitaciones_Load(object sender, EventArgs e)
        {
           
            txtidgradoseccion.Text = "0";
            cboestado.Items.Add(new ComboBoxItem() { Value = true, Text = "Activa" });
            cboestado.Items.Add(new ComboBoxItem() { Value = false, Text = "No Activa" });
            cboestado.DisplayMember = "Text";
            cboestado.ValueMember = "Value";
            cboestado.SelectedIndex = 0;

           

            CargarDatos();
        }

        private void CargarDatos()
        {

            List<Habitaciones> oListarHabitaciones = CD_Habitaciones.Listar();
            if (oListarHabitaciones == null)
                return;

            if (oListarHabitaciones.Count > 0)
            {
                tabla = new DataTable();
                tabla.Columns.Clear();
                tabla.Rows.Clear();
                cboFiltro.Items.Clear();

                lblTotalRegistros.Text = oListarHabitaciones.Count.ToString();

                tabla.Columns.Add("IdHabitaciones", typeof(int));
                tabla.Columns.Add("DescripcionHabitacion", typeof(string));
                tabla.Columns.Add("DescripcionCamas", typeof(string));
                tabla.Columns.Add("Estado", typeof(string));
                tabla.Columns.Add("Activa", typeof(bool));

                foreach (Habitaciones row in oListarHabitaciones)
                {
                    tabla.Rows.Add(row.IdHabitaciones, row.DescripcionHabitacion, row.DescripcionCamas,
                        row.Activo == true ? "Activa" : "No Activa", row.Activo);
                }

                dgvdata.DataSource = tabla;

                dgvdata.Columns["IdHabitaciones"].Visible = false;
                dgvdata.Columns["Activa"].Visible = false;

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

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            gbdatos.Enabled = true;

            btnnuevo.Visible = false;
            btnguardar.Visible = true;

            btnEditar.Visible = false;
            btncancelar.Visible = true;

            btneliminar.Visible = false;
            cboestado.Enabled = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            bool eseditar = Convert.ToInt32(txtidgradoseccion.Text) != 0 ? true : false;


            Habitaciones oHabitacion = new Habitaciones()
            {
                IdHabitaciones = Convert.ToInt32(txtidgradoseccion.Text),
                DescripcionHabitacion = txtdescripciongrado.Text,
                DescripcionCamas = txtdescripcionseccion.Text,
                Activo = Convert.ToBoolean(((ComboBoxItem)cboestado.SelectedItem).Value)
            };

            bool respuesta = false;

            string msgOk = "";
            string msgError = "";

            if (eseditar)
            {
                respuesta = CD_Habitaciones.Editar(oHabitacion);
                msgOk = "Se guardaron los cambios";
                msgError = "No se pudo guardar los cambios, ya existe un registro igual";

            }
            else
            {
                respuesta = CD_Habitaciones.Registrar(oHabitacion);
                msgOk = "Registro exitoso";
                msgError = "No se pudo registrar, ya existe un registro igual";
            }

            if (respuesta)
            {
                MessageBox.Show(msgOk, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reestablecer();
                CargarDatos();
            }
            else
            {
                MessageBox.Show(msgError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            gbdatos.Enabled = true;

            btnnuevo.Visible = false;
            btnguardar.Visible = true;

            btnEditar.Visible = false;
            btncancelar.Visible = true;

            btneliminar.Visible = false;
            cboestado.Enabled = true;

            if (dgvdata.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dgvdata.SelectedRows[0];
                int index = currentRow.Index;

                txtidgradoseccion.Text = dgvdata.Rows[index].Cells["IdHabitaciones"].Value.ToString();

                txtdescripciongrado.Text = dgvdata.Rows[index].Cells["DescripcionHabitacion"].Value.ToString();
                txtdescripcionseccion.Text = dgvdata.Rows[index].Cells["DescripcionCamas"].Value.ToString();

                foreach (ComboBoxItem item in cboestado.Items)
                {
                    if ((bool)item.Value == (bool)dgvdata.Rows[index].Cells["Activa"].Value)
                    {
                        int id = cboestado.Items.IndexOf(item);
                        cboestado.SelectedIndex = id;
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Selecciona un registro de la lista", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            gbdatos.Enabled = false;

            btnnuevo.Visible = true;
            btnguardar.Visible = false;

            btnEditar.Visible = true;
            btncancelar.Visible = false;

            btneliminar.Visible = true;
            Reestablecer();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvdata.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dgvdata.SelectedRows[0];
                int index = currentRow.Index;
                if (MessageBox.Show("¿Desea eliminar la habitacion  '" + 
                    dgvdata.Rows[index].Cells["DescripcionHabitacion"].Value.ToString() + "-"+
                    dgvdata.Rows[index].Cells["DescripcionCamas"].Value.ToString() +
                    "'?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdHabitaciones = Convert.ToInt32(dgvdata.Rows[index].Cells["IdHabitaciones"].Value.ToString());

                    bool respuesta = CD_Habitaciones.Eliminar(IdHabitaciones);
                    if (respuesta)
                    {
                        MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            else
            {
                MessageBox.Show("Selecciona un registro de la lista", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Reestablecer()
        {
            gbdatos.Enabled = false;

            btnnuevo.Visible = true;
            btnguardar.Visible = false;

            btnEditar.Visible = true;
            btncancelar.Visible = false;

            btneliminar.Visible = true;

            txtidgradoseccion.Text = "0";

            txtdescripciongrado.Text = "";
            txtdescripcionseccion.Text = "";

            cboestado.SelectedIndex = 0;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cboFiltro.SelectedItem.ToString();
            (dgvdata.DataSource as DataTable).DefaultView.RowFilter = string.Format("[" + columnaFiltro + "] like '%{0}%'", txtFilter.Text);
        }

        private void txtidgradoseccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
