using CapaDatos;
using CapaModelo;
using SistemaHospital.Reutilizable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHospital
{
    public partial class frmAgregarProcPaciente : Form
    {
        public frmAgregarProcPaciente()
        {
            InitializeComponent();
        }

        private void frmAgregarProcPaciente_Load(object sender, EventArgs e)
        {
           
            
               

            SqlConnection connection = new SqlConnection(Conexion.CN);
            connection.Open();
            

             string consulta = "select *from Procedimiento";
                    SqlDataAdapter dataApater = new SqlDataAdapter(consulta, Conexion.CN);
                    DataTable dt = new DataTable();
                    dataApater.Fill(dt);

                    dataGridView1.DataSource = dt;

                

                   

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Conexion.CN);
           
            connection.Open();
            SqlCommand command = new SqlCommand("usp_AsignarProPa", connection);
            

            command.Parameters.AddWithValue("@IdPaciente", textBox1.Text);
            command.Parameters.AddWithValue("@DocumentoIdentidad", textBox2.Text);
            command.Parameters.AddWithValue("@IdProcedimiento", textBox3.Text);
            command.Parameters.AddWithValue("@aumetar", textBox4.Text);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            MessageBox.Show("Procedimiento Asignado Correctamente", "mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
