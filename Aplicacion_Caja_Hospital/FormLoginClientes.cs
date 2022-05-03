using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Caja_Hospital
{
    public partial class FormLoginClientes : Form
    {
        public FormLoginClientes()
        {
            InitializeComponent();
            labelError.Hide();
        }

        private void FormLoginClientes_Load(object sender, EventArgs e)
        {

        }

        private void buttonLoginClient_Click(object sender, EventArgs e)
        {

            SN.PacientesSoapClient soapClient = new SN.PacientesSoapClient();
            
            
            bool Idpaciente = soapClient.pacientecaja(textBox1.Text, textBox2.Text, Convert.ToInt32( textBox3.Text));

            if (Idpaciente = true )
            {
                FormClientesMenu clientesMenu = new FormClientesMenu();
                clientesMenu.MdiParent = this.MdiParent;
                clientesMenu.StartPosition = FormStartPosition.Manual;
                this.Close();
                clientesMenu.Show();
            }
            else
            {
                labelError.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.MdiParent = this.MdiParent;
            menu.StartPosition = FormStartPosition.Manual;
            this.Close();
            menu.Show();
        }
    }
}
