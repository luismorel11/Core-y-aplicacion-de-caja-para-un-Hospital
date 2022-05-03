using log4net;
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
    
    public partial class FormSalida : Form
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        public FormSalida()
        {
            InitializeComponent();
            labelError.Hide(); //oculta la advertencia de tipo de dato incorrecto hasta que se ingrese un tipo de dato incorrecto
        }

        private void labelAdmin_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Logger.Info("Salida");
            //volver al menu
            FormMenu menu = new FormMenu();
            menu.MdiParent = this.MdiParent;
            menu.StartPosition = FormStartPosition.Manual;
            this.Close();
            menu.Show();
        }

        private void FormSalida_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(textBox1.Text, out value))
            {
                //prepara la conexion a base de datos
                SqlConnection conexion = new SqlConnection();
                SqlCommand command = null;
                conexion.ConnectionString = ConfigurationManager.ConnectionStrings["Aplicacion_Caja_Hospital.Properties.Settings.DBCAJAConnectionString"].ConnectionString;
                conexion.Open();
                command = new SqlCommand();

                //inserta los valores en el cuadre
                command.CommandText = "ppCuadre";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Administrador", "admin");
                command.Parameters.AddWithValue("Entrada", 0);
                command.Parameters.AddWithValue("Salida", -decimal.Parse(textBox1.Text));
                command.Parameters.AddWithValue("Deposito", 0);
                command.Parameters.AddWithValue("Retiro", 0);
                command.Parameters.AddWithValue("PagoPrestamo", 0);
                command.Connection = conexion;
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                //inserta los valores en el historial
                command.CommandText = "ppHistorial";
                command.Parameters.AddWithValue("Administrador", "admin");
                command.Parameters.AddWithValue("Entrada", 0);
                command.Parameters.AddWithValue("Salida", -decimal.Parse(textBox1.Text));
                command.Parameters.AddWithValue("Cliente", 0);
                command.Parameters.AddWithValue("Deposito", 0);
                command.Parameters.AddWithValue("Retiro", 0);
                command.Parameters.AddWithValue("PagoPrestamo", 0);
                command.ExecuteNonQuery();

                //cerrar y volver al menu
                FormMenu menu = new FormMenu();
                menu.MdiParent = this.MdiParent;
                menu.StartPosition = FormStartPosition.Manual;
                this.Close();
                menu.Show();
            }
            else
            {
                labelError.Show(); //muestra un label diciendo que el tipo de dato es incorrecto
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
