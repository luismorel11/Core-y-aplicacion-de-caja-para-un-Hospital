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
    public partial class FrmPagarProcedimiento : Form
    {
        public FrmPagarProcedimiento()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\padre_billini_0.jpg");
            this.BackgroundImage = img;
        }

        private void FrmPagarProcedimiento_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SN.PacientesSoapClient soapClient = new SN.PacientesSoapClient();
            soapClient.PagarCuenta(textBox1.Text, textBox2.Text, textBox3.Text, 1);
            MessageBox.Show("Procedimiento Pagado Correctamente", "mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
