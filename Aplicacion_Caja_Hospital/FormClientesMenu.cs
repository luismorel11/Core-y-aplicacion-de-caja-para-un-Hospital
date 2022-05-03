using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Caja_Hospital
{
    public partial class FormClientesMenu : Form
    {
        public FormClientesMenu()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.MdiParent = this.MdiParent;
            menu.StartPosition = FormStartPosition.Manual;
            this.Close();
            menu.Show();
        }

        private void buttonDeposito_Click(object sender, EventArgs e)
        {
            FormDeposito deposito = new FormDeposito();
            deposito.MdiParent = this.MdiParent;
            deposito.StartPosition = FormStartPosition.Manual;
            this.Close();
            deposito.Show();
        }

        private void buttonRetirada_Click(object sender, EventArgs e)
        {
            FormRetiro retiro = new FormRetiro();
            retiro.MdiParent = this.MdiParent;
            retiro.StartPosition = FormStartPosition.Manual;
            this.Close();
            retiro.Show();
        }

        private void FormClientesMenu_Load(object sender, EventArgs e)
        {

        }

        private void buttonPrestamo_Click(object sender, EventArgs e)
        {
            FrmPagarProcedimiento pagarprocedimiento = new FrmPagarProcedimiento();
            pagarprocedimiento.MdiParent = this.MdiParent;
            pagarprocedimiento.StartPosition = FormStartPosition.Manual;
            this.Close();
            pagarprocedimiento.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmagregarProcedimiento agregarprocedimiento = new frmagregarProcedimiento();
            agregarprocedimiento.MdiParent = this.MdiParent;
            agregarprocedimiento.StartPosition = FormStartPosition.Manual;
            this.Close();
            agregarprocedimiento.Show();

        }
    }
}
