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
using System.Xml.Linq;

namespace SistemaHospital
{
    public partial class frmCrearVacantes : Form
    {
        public frmCrearVacantes()
        {
            InitializeComponent();
        }

        DataTable tabla = new DataTable();
        private void frmCrearVacantes_Load(object sender, EventArgs e)
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
        }

        private void cargardatos()
        {
            if (cbonivel.Items.Count < 1 && cboperiodo.Items.Count < 1)
                return;


            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            if (idnivel == 0)
            {
                MessageBox.Show("Debe seleccionar un Area", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tabla = new DataTable();
            tabla.Columns.Clear();
            tabla.Rows.Clear();
            dgvdata.DataSource = tabla;

            List<AreaDetalle> oListaAreaDetalle = CD_AreaDetalle.Listar();

            if (oListaAreaDetalle != null)
            {
                oListaAreaDetalle = oListaAreaDetalle.Where(x => x.oArea.IdArea == idnivel).ToList();

            }


            if (oListaAreaDetalle.Count > 0)
            {
                tabla = new DataTable();
                tabla.Columns.Clear();
                tabla.Rows.Clear();

                tabla.Columns.Add("IdAreaDetalle", typeof(int)).ReadOnly = true;
                tabla.Columns.Add("IdArea", typeof(int)).ReadOnly = true;
                tabla.Columns.Add("Descripcion Area", typeof(string)).ReadOnly = true;
                tabla.Columns.Add("Descripcion Horario", typeof(string)).ReadOnly = true;

                tabla.Columns.Add("IdHabitaciones", typeof(string)).ReadOnly = true;
                tabla.Columns.Add("Descripcion Habitacion", typeof(string)).ReadOnly = true;
                tabla.Columns.Add("Descripcion Camas", typeof(string)).ReadOnly = true;

                tabla.Columns.Add("Total Vacantes", typeof(string));

                
                //.DefaultCellStyle.ForeColor = Color.Gray;

                //tabla.Columns.Add("Estado", typeof(string));
                tabla.Columns.Add("Activo", typeof(bool));

                foreach (AreaDetalle row in oListaAreaDetalle)
                {
                    tabla.Rows.Add(row.IdAreaDetalle,
                        row.oArea.IdArea,
                        row.oArea.DescripcionArea,
                        row.oArea.DescripcionHorario,
                        row.oHabitaciones.IdHabitaciones,
                        row.oHabitaciones.DescripcionHabitacion,
                        row.oHabitaciones.DescripcionCamas,
                        row.TotalVacantes,
                        //row.Activo == true ? "Activo" : "No Activo", 
                        row.Activo);
                }

                dgvdata.DataSource = tabla;

                dgvdata.Columns["IdAreaDetalle"].Visible = false;
                dgvdata.Columns["IdArea"].Visible = false;
                dgvdata.Columns["IdHabitaciones"].Visible = false;
                dgvdata.Columns["Activo"].Visible = false;
                dgvdata.Columns["Total Vacantes"].DefaultCellStyle.BackColor = Color.LightYellow;

            }

            btnGuardar.Enabled = true;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            XElement DETALLE = new XElement("DETALLE");

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                DETALLE.Add(new XElement("DATA",
                    new XElement("IdAreaDetalle", row.Cells["IdAreaDetalle"].Value),
                    new XElement("TotalVacantes", row.Cells["Total Vacantes"].Value)
                    ));
            }


            bool resultado = CD_AreaDetalle.RegistrarVacantes(DETALLE.ToString());

            if (resultado)
            {
                MessageBox.Show("Se guardaron los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false;
                tabla = new DataTable();
                tabla.Columns.Clear();
                tabla.Rows.Clear();
                dgvdata.DataSource = tabla;
                cbonivel.SelectedIndex = 0;
            }
            else
                MessageBox.Show("No se guardaron los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
