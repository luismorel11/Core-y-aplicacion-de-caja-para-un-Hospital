using CapaDatos;
using CapaModelo;
using SistemaHospital.Reutilizable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHospital
{
    public partial class frmCrearPaciente : Form
    {
        public frmCrearPaciente()
        {
            InitializeComponent();
        }
        DataTable tabla = new DataTable();
        private void frmCrearAlumnos_Load(object sender, EventArgs e)
        {
            txtidalumno.Text = "0";
            cbosexo.Items.Add(new ComboBoxItem() { Value = "Masculino", Text = "Masculino" });
            cbosexo.Items.Add(new ComboBoxItem() { Value = "Femenino", Text = "Femenino" });
            cbosexo.DisplayMember = "Text";
            cbosexo.ValueMember = "Value";
            cbosexo.SelectedIndex = 0;

            cboestado.Items.Add(new ComboBoxItem() { Value = true, Text = "Activo" });
            cboestado.Items.Add(new ComboBoxItem() { Value = false, Text = "No Activo" });
            cboestado.DisplayMember = "Text";
            cboestado.ValueMember = "Value";
            cboestado.SelectedIndex = 0;

            string consulta = "select *from Paciente";
            SqlDataAdapter dataApater = new SqlDataAdapter(consulta, Conexion.CN);
            DataTable dt = new DataTable();
            dataApater.Fill(dt);

            dgvdata.DataSource = dt;

            CargarDatos();
        }

        private void CargarDatos()
        {

            List<Paciente> oListaAlumno = CD_Paciente.Listar();
            if (oListaAlumno == null)
                return;

            if (oListaAlumno.Count > 0)
            {
                tabla = new DataTable();
                tabla.Columns.Clear();
                tabla.Rows.Clear();
                cboFiltro.Items.Clear();

                lblTotalRegistros.Text = oListaAlumno.Count.ToString();

                tabla.Columns.Add("IdAlumno", typeof(int));
                tabla.Columns.Add("Codigo", typeof(string));
                tabla.Columns.Add("Nombres", typeof(string));
                tabla.Columns.Add("Apellidos", typeof(string));
                tabla.Columns.Add("Documento Identidad", typeof(string));
                tabla.Columns.Add("Fecha Nacimiento", typeof(string));
                tabla.Columns.Add("Sexo", typeof(string));
                tabla.Columns.Add("Ciudad", typeof(string));
                tabla.Columns.Add("Direccion", typeof(string));
                tabla.Columns.Add("Estado", typeof(string));
                tabla.Columns.Add("Activo", typeof(bool));

                foreach (Paciente row in oListaAlumno)
                {
                    tabla.Rows.Add(row.IdPaciente, row.Codigo, row.Nombres, row.Apellidos, row.DocumentoIdentidad, row.FechaNacimiento.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                        row.Sexo, row.Deuda, row.Direccion, row.Activo == true ? "Activo" : "No Activo", row.Activo);
                }

                dgvdata.DataSource = tabla;

                dgvdata.Columns["IdAlumno"].Visible = false;
                dgvdata.Columns["Activo"].Visible = false;

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

        private void btnEditar_Click(object sender, EventArgs e)
        {


            if (dgvdata.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dgvdata.SelectedRows[0];
                int index = currentRow.Index;


                txtidalumno.Text = dgvdata.Rows[index].Cells["IdPaciente"].Value.ToString();
                txtcodigo.Text = dgvdata.Rows[index].Cells["Codigo"].Value.ToString();
                txtnombres.Text = dgvdata.Rows[index].Cells["Nombres"].Value.ToString();
                txtapellidos.Text = dgvdata.Rows[index].Cells["Apellidos"].Value.ToString();
                txtdocumentoidentidad.Text = dgvdata.Rows[index].Cells["DocumentoIdentidad"].Value.ToString();
                txtfechanacimiento.Value = Convert.ToDateTime(dgvdata.Rows[index].Cells["FechaNacimiento"].Value.ToString());

                foreach (ComboBoxItem item in cbosexo.Items)
                {
                    if ((string)item.Value == dgvdata.Rows[index].Cells["Sexo"].Value.ToString())
                    {
                        int id = cbosexo.Items.IndexOf(item);
                        cbosexo.SelectedIndex = id;
                        break;
                    }
                }


                txtciudad.Text = dgvdata.Rows[index].Cells["Deuda"].Value.ToString();
                txtdireccion.Text = dgvdata.Rows[index].Cells["Direccion"].Value.ToString();

                foreach (ComboBoxItem item in cboestado.Items)
                {
                    if ((bool)item.Value == (bool)dgvdata.Rows[index].Cells["Activo"].Value)
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
                return;
            }

            gbdatos.Enabled = true;

            btnnuevo.Visible = false;
            btnguardar.Visible = true;

            btnEditar.Visible = false;
            btncancelar.Visible = true;

            btneliminar.Visible = false;
            cboestado.Enabled = true;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            bool eseditar = Convert.ToInt32(txtidalumno.Text) != 0 ? true : false;

            Paciente oAlumno = new Paciente()
            {
                IdPaciente = Convert.ToInt32(txtidalumno.Text),
                Codigo = txtcodigo.Text,
                Nombres = txtnombres.Text,
                Apellidos = txtapellidos.Text,
                DocumentoIdentidad = txtdocumentoidentidad.Text,
                FechaNacimiento = txtfechanacimiento.Value,
                Sexo = ((ComboBoxItem)cbosexo.SelectedItem).Value.ToString(),
                Deuda = (float)Convert.ToDecimal( txtciudad.Text),
                Direccion = txtdireccion.Text,
                Activo = Convert.ToBoolean(((ComboBoxItem)cboestado.SelectedItem).Value)
            };

            bool respuesta = false;

            string msgOk = "";
            string msgError = "";

            if (eseditar)
            {
                respuesta = CD_Paciente.Editar(oAlumno);
                msgOk = "Se guardaron los cambios";
                msgError = "No se pudo guardar los cambios";

            }
            else
            {
                respuesta = CD_Paciente.Registrar(oAlumno);
                msgOk = "Registro exitoso";
                msgError = "No se pudo registrar";
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

        private void Reestablecer()
        {
            gbdatos.Enabled = false;

            btnnuevo.Visible = true;
            btnguardar.Visible = false;

            btnEditar.Visible = true;
            btncancelar.Visible = false;

            btneliminar.Visible = true;

            txtidalumno.Text = "0";
            txtcodigo.Text = "";
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtdocumentoidentidad.Text = "";
            txtfechanacimiento.Value = DateTime.Now.Date;
            cbosexo.SelectedIndex = 0;
            txtciudad.Text = "";
            txtdireccion.Text = "";
            cboestado.SelectedIndex = 0;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cboFiltro.SelectedItem.ToString();
            (dgvdata.DataSource as DataTable).DefaultView.RowFilter = string.Format("[" + columnaFiltro + "] like '%{0}%'", txtFilter.Text);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvdata.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dgvdata.SelectedRows[0];
                int index = currentRow.Index;
                if (MessageBox.Show("¿Desea eliminar el alumno con codigo " + dgvdata.Rows[index].Cells["Codigo"].Value.ToString() + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idalumno = Convert.ToInt32(dgvdata.Rows[index].Cells["IdAlumno"].Value.ToString());

                    bool respuesta = CD_Paciente.Eliminar(idalumno);
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

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void gbdatos_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalRegistros_Click(object sender, EventArgs e)
        {

        }
    }
}
