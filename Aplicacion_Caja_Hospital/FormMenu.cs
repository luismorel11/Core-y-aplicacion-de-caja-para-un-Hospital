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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLoginClientes loginClientes = new FormLoginClientes();
            loginClientes.MdiParent = this.MdiParent;
            loginClientes.StartPosition = FormStartPosition.Manual;
            this.Close();
            loginClientes.Show();
        }

        private void buttonCierre_Click(object sender, EventArgs e)
        {
           FormCierre cierre = new FormCierre();
            cierre.MdiParent = this.MdiParent;
            cierre.StartPosition = FormStartPosition.Manual;
            this.Close();
            cierre.Show();

            
        }

        private void entradaFT_Click(object sender, EventArgs e)
        {
            FormEntrada entrada = new FormEntrada();
            entrada.MdiParent = this.MdiParent;
            entrada.StartPosition = FormStartPosition.Manual;
            this.Close();
            entrada.Show();
        }

        private void salidaFT_Click(object sender, EventArgs e)
        {
            FormSalida salida = new FormSalida();
            salida.MdiParent = this.MdiParent;
            salida.StartPosition = FormStartPosition.Manual;
            this.Close();
            salida.Show();
        }
    }
}
