using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Caja_Hospital
{
    public partial class FormLogin : Form
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        public FormLogin()
        {
            InitializeComponent();
            string sucursal = ConfigurationManager.AppSettings["Sucursal"]; ; 
            labelSucursal.Text = sucursal; 
            labelError.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Hospital" & textBox2.Text == "admin1234")
            {
                Logger.Info("Login");
                FormMenu menu = new FormMenu();
                menu.MdiParent = this.MdiParent;
                menu.StartPosition = FormStartPosition.Manual;
                this.Close();
                menu.Show(); 
            }
            else
            {
                labelError.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2;
                textBox1.Top = (this.ClientSize.Height - textBox1.Height) / 2;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        
        private void labelSucursal_Click(object sender, EventArgs e)
        {
    
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
