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
    public partial class frmRegistrarGenerarReporte : Form
    {
        public frmRegistrarGenerarReporte()
        {
            InitializeComponent();
        }

        static int idperiodo = 0;

        private void frmCrearMatricula_Load(object sender, EventArgs e)
        {
            idperiodo = 0;
            List<Periodo> oListaPeriodo = CD_Periodo.Listar();

            if (oListaPeriodo != null)
            {
               lblperiodo.Text = oListaPeriodo.FirstOrDefault(x => x.Activo == true).Descripcion.ToString();
               idperiodo = int.Parse(oListaPeriodo.FirstOrDefault(x => x.Activo == true).IdPeriodo.ToString());
            }

            List<Area> oListaNivel = CD_Area.Listar();
            cbonivelacademico.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione" });
            if (oListaNivel != null)
            {
                foreach (Area row in oListaNivel.Where(x => x.Activo == true && x.oPeriodo.IdPeriodo == idperiodo))
                {
                    cbonivelacademico.Items.Add(new ComboBoxItem() { Value = row.IdArea, Text = row.DescripcionArea });
                }
                
            }
            cbonivelacademico.DisplayMember = "Text";
            cbonivelacademico.ValueMember = "Value";
            cbonivelacademico.SelectedIndex = 0;

            
            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivelacademico.SelectedItem).Value);
            List<AreaDetalle> oListaNivelDetalle = CD_AreaDetalle.Listar();
            cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione" });

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

        private void btnbuscar_Click(object sender, EventArgs e)
        {

            if(cbonivelacademico.SelectedIndex == 0 || cbogradoseccion.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccion no correcta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<AreaDetalle> oListaNivelDetalle = CD_AreaDetalle.Listar();
            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivelacademico.SelectedItem).Value);
            int idgradoseccion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);

            txtvacantes.Text = oListaNivelDetalle.FirstOrDefault(x => x.oArea.IdArea == idnivel && x.oHabitaciones.IdHabitaciones == idgradoseccion).VacantesDisponibles.ToString();

        }

        private void cbonivelacademico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbogradoseccion.Items.Clear();

            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivelacademico.SelectedItem).Value);
            List<AreaDetalle> oListaNivelDetalle = CD_AreaDetalle.Listar();
            cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione" });

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
            txtvacantes.Text = "";
        }

        private void btncontinuar_Click(object sender, EventArgs e)
        {
            if (txtvacantes.Text.Trim() == "")
            {
                MessageBox.Show("No existe vacantes", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int vacantes = int.Parse(txtvacantes.Text);

            if(vacantes > 0)
            {
                frmRegistrarMatricula frm = new frmRegistrarMatricula();
                frm.Pidperiodo = idperiodo;
                frm.PidArea = Convert.ToInt32(((ComboBoxItem)cbonivelacademico.SelectedItem).Value);
                frm.PidHabitacion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);
                frm.PdescripcionArea = ((ComboBoxItem)cbonivelacademico.SelectedItem).Text.ToString();
                frm.PdescripcionHabitacion = ((ComboBoxItem)cbogradoseccion.SelectedItem).Text.ToString();
                frm.MdiParent = this.ParentForm;
                frm.Show();
                this.Hide();
                frm.FormClosing += Frm_Closing;
            }
        }

        private void Frm_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        private void cbogradoseccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtvacantes.Text = "";
        }

        private void lblperiodo_Click(object sender, EventArgs e)
        {

        }
    }
}
