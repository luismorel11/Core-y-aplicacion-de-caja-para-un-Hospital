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
    public partial class frmCrearAreaDetalles : Form
    {
        public frmCrearAreaDetalles()
        {
            InitializeComponent();
        }

        private void frmCrearNivelDetalle_Load(object sender, EventArgs e)
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

        private void CargarDatos()
        {
            lbasignados.Items.Clear();
            lbporasignar.Items.Clear();

            if (cbonivel.Items.Count < 1 && cboperiodo.Items.Count < 1)
                return;


            int idnivel = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            if(idnivel == 0)
            {
                MessageBox.Show("Debe seleccionar un Area", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //OBTENEMOS DATA

            List<Habitaciones> oListaGradoSeccionPorAsignar = new List<Habitaciones>();
            List<Habitaciones> oListaGradoSeccionAsignados = new List<Habitaciones>();

            List<Habitaciones> oListaGradoSeccion = CD_Habitaciones.Listar();
            List<AreaDetalle> oListaNivelDetalle = CD_AreaDetalle.Listar();

            //FILTRAMOS SEGUN NUESTRO PARAMETROS DE FILTRO
            if(oListaNivelDetalle != null)
            {
                oListaNivelDetalle = oListaNivelDetalle.Where(x => x.oArea.IdArea == idnivel).ToList();

            }

            //OBTENEMOS LOS POR ASIGNAR Y LOS ASIGNADOS
            if (oListaGradoSeccion != null && oListaNivelDetalle != null)
            {
                oListaGradoSeccionAsignados = (from a in oListaNivelDetalle
                                               join b in oListaGradoSeccion on a.oHabitaciones.IdHabitaciones equals b.IdHabitaciones
                                               select b).ToList();

                foreach(Habitaciones a in oListaGradoSeccion)
                {
                    bool encontrado = false;
                    foreach(Habitaciones b in oListaGradoSeccionAsignados)
                    {
                        if(a.IdHabitaciones == b.IdHabitaciones)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if(!encontrado)
                    oListaGradoSeccionPorAsignar.Add(a);
                }
            }

            //PINTAMOS LOS POR ASIGNAR EN EL LISTBOX
            if (oListaGradoSeccionPorAsignar.Count > 0)
            {
                foreach (Habitaciones row in oListaGradoSeccionPorAsignar.Where(x => x.Activo == true))
                {
                    lbporasignar.Items.Add(new ComboBoxItem() { Value = row.IdHabitaciones, Text = row.DescripcionHabitacion + " - " + row.DescripcionCamas });
                }
                lbporasignar.DisplayMember = "Text";
                lbporasignar.ValueMember = "Value";

            }

            //PINTAMOS LOS ASIGNADOS EN EL LISTBOX
            if (oListaGradoSeccionAsignados.Count > 0)
            {
                foreach (Habitaciones row in oListaGradoSeccionAsignados.Where(x => x.Activo == true))
                {
                    lbasignados.Items.Add(new ComboBoxItem() { Value = row.IdHabitaciones, Text = row.DescripcionHabitacion + " - " + row.DescripcionCamas });
                }
                lbasignados.DisplayMember = "Text";
                lbasignados.ValueMember = "Value";
            }


            btnGuardar.Enabled = true;
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            List<ComboBoxItem> ListOptions = new List<ComboBoxItem>();

            foreach(ComboBoxItem option in lbporasignar.SelectedItems)
            {
                lbasignados.Items.Add(option);
                ListOptions.Add(option);
            }
            
            foreach(ComboBoxItem option in ListOptions)
            {
                lbporasignar.Items.Remove(option);
                
            }
            lbasignados.DisplayMember = "Text";
            lbasignados.ValueMember = "Value";
        }

        private void btnquitar_Click(object sender, EventArgs e)
        {
            List<ComboBoxItem> ListOptions = new List<ComboBoxItem>();

            foreach (ComboBoxItem option in lbasignados.SelectedItems)
            {
                lbporasignar.Items.Add(option);
                ListOptions.Add(option);
            }

            foreach (ComboBoxItem option in ListOptions)
            {
                lbasignados.Items.Remove(option);

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            XElement XML = new XElement("DETALLE",
              new XElement("DATA",
              new XElement("IdArea", ((ComboBoxItem)cbonivel.SelectedItem).Value)
              ));

            XElement Habitacion = new XElement("Habitaciones");
            
            foreach (ComboBoxItem option in lbasignados.Items)
            {
                Habitacion.Add(new XElement("DATA",
                    new XElement("IdHabitacion", option.Value)
                    ));
            }

            XML.Add(Habitacion);

            bool resultado = CD_AreaDetalle.Registrar(XML.ToString());

            if (resultado)
            {
                MessageBox.Show("Se guardaron los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false;
                lbasignados.Items.Clear();
                lbporasignar.Items.Clear();
                cbonivel.SelectedIndex = 0;
            }
            else
                MessageBox.Show("No se guardaron los cambios, algunas areas ya cuentas con procedimientos asignados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }
    }
}
