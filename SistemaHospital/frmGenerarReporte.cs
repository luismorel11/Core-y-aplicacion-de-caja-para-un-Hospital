using CapaDatos;
using CapaModelo;
using ClosedXML.Excel;
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
    public partial class frmGenerarReporte : Form
    {
        public frmGenerarReporte()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void frmReporteMatricula_Load(object sender, EventArgs e)
        {
            cbosituacionmatricula.Items.Add(new ComboBoxItem() { Value = "", Text = "Todos" });
            cbosituacionmatricula.Items.Add(new ComboBoxItem() { Value = "Nuevo", Text = "Nuevo" });
            cbosituacionmatricula.Items.Add(new ComboBoxItem() { Value = "Antiguo", Text = "Antiguo" });
            cbosituacionmatricula.DisplayMember = "Text";
            cbosituacionmatricula.ValueMember = "Value";
            cbosituacionmatricula.SelectedIndex = 0;

            cboperiodo.Items.Add(new ComboBoxItem() { Value = 0, Text = "Todos" });
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
            cboperiodo.SelectedIndex = 0;

            List<Area> oListaArea = CD_Area.Listar();
            int idperiodo = Convert.ToInt32(((ComboBoxItem)cboperiodo.SelectedItem).Value);

            cbonivelacademico.Items.Add(new ComboBoxItem() { Value = 0, Text = "Todos" });
            if (oListaArea != null)
            {
                foreach (Area row in oListaArea.Where(x => x.Activo == true && x.oPeriodo.IdPeriodo == idperiodo))
                {
                    cbonivelacademico.Items.Add(new ComboBoxItem() { Value = row.IdArea, Text = row.DescripcionArea });
                }
            }
            cbonivelacademico.DisplayMember = "Text";
            cbonivelacademico.ValueMember = "Value";
            cbonivelacademico.SelectedIndex = 0;


            int idArea = Convert.ToInt32(((ComboBoxItem)cbonivelacademico.SelectedItem).Value);
            List<AreaDetalle> oListaAreadetalle = CD_AreaDetalle.Listar();
            cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Todos" });

            if (oListaAreadetalle != null)
            {
                oListaAreadetalle = oListaAreadetalle.Where(x => x.oArea.IdArea == idArea).ToList();


                if (oListaAreadetalle.Count > 0)
                {
                    foreach (AreaDetalle row in oListaAreadetalle.Where(x => x.Activo == true))
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


        private void cboperiodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbonivelacademico.Items.Clear();

            List<Area> oListaArea = CD_Area.Listar();
            int idperiodo = Convert.ToInt32(((ComboBoxItem)cboperiodo.SelectedItem).Value);

            cbonivelacademico.Items.Add(new ComboBoxItem() { Value =0, Text = "Todos" });
            if (oListaArea != null)
            {
                foreach (Area row in oListaArea.Where(x => x.Activo == true && x.oPeriodo.IdPeriodo == idperiodo))
                {
                    cbonivelacademico.Items.Add(new ComboBoxItem() { Value = row.IdArea, Text = row.DescripcionArea });
                }
            }
            cbonivelacademico.DisplayMember = "Text";
            cbonivelacademico.ValueMember = "Value";
            cbonivelacademico.SelectedIndex = 0;

            cbonivelacademico_SelectionChangeCommitted(cbonivelacademico,null);
        }

        private void cbonivelacademico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbogradoseccion.Items.Clear();

            int idArea = Convert.ToInt32(((ComboBoxItem)cbonivelacademico.SelectedItem).Value);
            List<AreaDetalle> oListaAreaDetalle = CD_AreaDetalle.Listar();
            cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Todos" });

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

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_{0}.xlsx", DateTime.Today.ToString("ddMMyyyy"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string informe = "Informe";
                        XLWorkbook wb = new XLWorkbook();
                        wb.Worksheets.Add(dt, informe);
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
            }
            else
            {
                MessageBox.Show("No existen datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            dt = CD_GenerarReporte.Reporte(
                txtcodigomatricula.Text,
                ((ComboBoxItem)cbosituacionmatricula.SelectedItem).Value.ToString(),
                txtcodigoalumno.Text,
                txtdocumentoidentidad.Text,
                txtnombres.Text,
                txtapellidos.Text,
                int.Parse(((ComboBoxItem)cboperiodo.SelectedItem).Value.ToString()) == 0 ? "" : ((ComboBoxItem)cboperiodo.SelectedItem).Text,
                int.Parse(((ComboBoxItem)cbonivelacademico.SelectedItem).Value.ToString()) == 0 ? "" : ((ComboBoxItem)cbonivelacademico.SelectedItem).Text,
                int.Parse(((ComboBoxItem)cbogradoseccion.SelectedItem).Value.ToString()) == 0 ? "" : ((ComboBoxItem)cbogradoseccion.SelectedItem).Text
                );

            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            dgvdata.DataSource = dt;
            btnexportar.Enabled = true;
        }

        private void cbosituacionmatricula_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
