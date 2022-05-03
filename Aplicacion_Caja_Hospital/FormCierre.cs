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
using Microsoft.Reporting.WinForms;

namespace Aplicacion_Caja_Hospital
{
    public partial class FormCierre : Form
    {
        public FormCierre()
        {
            InitializeComponent();
        }

        private void FormCierre_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'CajaDS.tblCuadre' table. You can move, or remove it, as needed.
            this.tblCuadreTableAdapter.Fill(this.CajaDS.tblCuadre);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.Refresh();

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void buttonTerminar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand command = null;
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["Aplicacion_Caja_Hospital.Properties.Settings.DBCAJAConnectionString"].ConnectionString;
            conexion.Open();
            command = new SqlCommand();

            command.CommandText = "ppTotalDia";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("Total", 1);
            command.Parameters.AddWithValue("Fecha", DateTime.Now);
            command.Connection = conexion;
            command.ExecuteNonQuery();
            command.Parameters.Clear();

            //command.CommandText = "ppTerminarDia";
            //command.Connection = conexion;
            //command.ExecuteNonQuery();

            Application.Exit();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.MdiParent = this.MdiParent;
            menu.StartPosition = FormStartPosition.Manual;
            this.Close();
            menu.Show();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.tblCuadreTableAdapter.Fill(this.CajaDS.tblCuadre);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.Refresh();
        }
    }
}
