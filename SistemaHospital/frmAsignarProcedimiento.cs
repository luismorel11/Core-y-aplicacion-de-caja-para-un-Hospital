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
    public partial class frmAsignarProcedimiento : Form
    {
        public frmAsignarProcedimiento()
        {
            InitializeComponent();
        }

        private void frmAsignarProcedimiento_Load(object sender, EventArgs e)
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
                cbogradoseccion.Items.Add(new ComboBoxItem() { Value = 0, Text = "Seleccione Habitaciones" });

                if (oListaAreaDetalle != null)
                {
                    oListaAreaDetalle = oListaAreaDetalle.Where(x => x.oArea.IdArea == idArea).ToList();


                    if(oListaAreaDetalle.Count > 0)
                    {
                        foreach (AreaDetalle row in oListaAreaDetalle.Where(x => x.Activo == true))
                        {
                            cbogradoseccion.Items.Add(new ComboBoxItem() { Value = row.oHabitaciones.IdHabitaciones,
                                Text = row.oHabitaciones.DescripcionHabitacion + " - " + row.oHabitaciones.DescripcionCamas });
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
            lbasignados.Items.Clear();
            lbporasignar.Items.Clear();

            if (cbonivel.Items.Count < 1 || cboperiodo.Items.Count < 1 || cbogradoseccion.Items.Count < 1)
                return;


            int idArea = Convert.ToInt32(((ComboBoxItem)cbonivel.SelectedItem).Value);
            if (idArea == 0)
            {
                MessageBox.Show("Debe seleccionar un area", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int IdHabitacion = Convert.ToInt32(((ComboBoxItem)cbogradoseccion.SelectedItem).Value);
            if (IdHabitacion == 0)
            {
                MessageBox.Show("Debe seleccionar un Habitacion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //OBTENEMOS DATA

            List<Procedimiento> oListaProcedimientoPorAsignar = new List<Procedimiento>();
            List<Procedimiento> oListaProcedimientoAsignados = new List<Procedimiento>();

            List<Procedimiento> oListaProcedimiento = CD_Procedimiento.Listar();
            List<NivelDetalleProcedimiento> oListaAreaDetalleProcedimiento = CD_NivelDetalleProcedimiento.Listar();

            //FILTRAMOS SEGUN NUESTRO PARAMETROS DE FILTRO
            if (oListaAreaDetalleProcedimiento != null)
            {
                oListaAreaDetalleProcedimiento = oListaAreaDetalleProcedimiento.Where(x => 
                x.oArea.IdArea == idArea &&
                x.oHabitaciones.IdHabitaciones == IdHabitacion).ToList();

            }

            //OBTENEMOS LOS POR ASIGNAR Y LOS ASIGNADOS
            if(oListaProcedimiento != null && oListaAreaDetalleProcedimiento != null)
            {
                oListaProcedimientoAsignados = (from a in oListaProcedimiento
                                               join b in oListaAreaDetalleProcedimiento on a.IdProcedimiento equals b.oProcedimiento.IdProcedimiento
                                               select a).ToList();

                foreach (Procedimiento a in oListaProcedimiento)
                {
                    bool encontrado = false;
                    foreach (Procedimiento b in oListaProcedimientoAsignados)
                    {
                        if (a.IdProcedimiento == b.IdProcedimiento)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (!encontrado)
                        oListaProcedimientoPorAsignar.Add(a);
                }
            }


            //PINTAMOS LOS POR ASIGNAR EN EL LISTBOX
            if (oListaProcedimientoPorAsignar.Count > 0)
            {
                foreach (Procedimiento row in oListaProcedimientoPorAsignar.Where(x => x.Activo == true))
                {
                    lbporasignar.Items.Add(new ComboBoxItem() { Value = row.IdProcedimiento, Text = row.Descripcion });
                }
                lbporasignar.DisplayMember = "Text";
                lbporasignar.ValueMember = "Value";

            }

            //PINTAMOS LOS ASIGNADOS EN EL LISTBOX
            if (oListaProcedimientoAsignados.Count > 0)
            {
                foreach (Procedimiento row in oListaProcedimientoAsignados.Where(x => x.Activo == true))
                {
                    lbasignados.Items.Add(new ComboBoxItem() { Value = row.IdProcedimiento, Text = row.Descripcion });
                }
                lbasignados.DisplayMember = "Text";
                lbasignados.ValueMember = "Value";
            }
            btnGuardar.Enabled = true;
        }



        private void cbonivel_SelectionChangeCommitted(object sender, EventArgs e)
        {

            cbogradoseccion.Items.Clear();

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {

            List<ComboBoxItem> ListOptions = new List<ComboBoxItem>();

            foreach (ComboBoxItem option in lbporasignar.SelectedItems)
            {
                lbasignados.Items.Add(option);
                ListOptions.Add(option);
            }

            foreach (ComboBoxItem option in ListOptions)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            XElement XML = new XElement("DETALLE");

            XML.Add(new XElement("Area",
                new XElement("IdArea", ((ComboBoxItem)cbonivel.SelectedItem).Value)
              ));

            XML.Add(new XElement("Habitaciones",
                new XElement("Idhabitacion", ((ComboBoxItem)cbogradoseccion.SelectedItem).Value)
              ));

            XElement CURSOS = new XElement("Procedimiento");

            foreach (ComboBoxItem option in lbasignados.Items)
            {
                CURSOS.Add(new XElement("DATA",
                    new XElement("IdCurso", option.Value)
                    ));
            }

            XML.Add(CURSOS);


            bool resultado = CD_NivelDetalleProcedimiento.Asignar(XML.ToString());

            if (resultado)
            {
                MessageBox.Show("Se guardaron los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false;
                lbasignados.Items.Clear();
                lbporasignar.Items.Clear();
                cbonivel.SelectedIndex = 0;
                cbonivel_SelectionChangeCommitted(cbonivel, new EventArgs());
                cbogradoseccion.SelectedIndex = 0;
            }
            else
                MessageBox.Show("No se guardaron los cambios, Algunos cursos ya cuentan con un horario asignado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void lbasignados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
