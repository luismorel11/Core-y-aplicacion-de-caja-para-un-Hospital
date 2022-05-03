namespace SistemaHospital
{
    partial class frmGenerarReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnexportar = new System.Windows.Forms.Button();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtapellidos = new System.Windows.Forms.TextBox();
            this.txtnombres = new System.Windows.Forms.TextBox();
            this.txtdocumentoidentidad = new System.Windows.Forms.TextBox();
            this.txtcodigoalumno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcodigomatricula = new System.Windows.Forms.TextBox();
            this.cbosituacionmatricula = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbonivelacademico = new System.Windows.Forms.ComboBox();
            this.cbogradoseccion = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboperiodo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // btnexportar
            // 
            this.btnexportar.BackColor = System.Drawing.Color.Green;
            this.btnexportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportar.Enabled = false;
            this.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnexportar.ForeColor = System.Drawing.Color.White;
            this.btnexportar.Location = new System.Drawing.Point(781, 482);
            this.btnexportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(220, 28);
            this.btnexportar.TabIndex = 26;
            this.btnexportar.Text = "Exportar";
            this.btnexportar.UseVisualStyleBackColor = false;
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.AllowUserToDeleteRows = false;
            this.dgvdata.ColumnHeadersHeight = 29;
            this.dgvdata.Location = new System.Drawing.Point(16, 174);
            this.dgvdata.Margin = new System.Windows.Forms.Padding(4);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.RowHeadersWidth = 51;
            this.dgvdata.Size = new System.Drawing.Size(985, 302);
            this.dgvdata.TabIndex = 25;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(861, 138);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(140, 28);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtapellidos
            // 
            this.txtapellidos.Location = new System.Drawing.Point(648, 140);
            this.txtapellidos.Margin = new System.Windows.Forms.Padding(4);
            this.txtapellidos.Name = "txtapellidos";
            this.txtapellidos.Size = new System.Drawing.Size(187, 22);
            this.txtapellidos.TabIndex = 23;
            // 
            // txtnombres
            // 
            this.txtnombres.Location = new System.Drawing.Point(427, 140);
            this.txtnombres.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombres.Name = "txtnombres";
            this.txtnombres.Size = new System.Drawing.Size(192, 22);
            this.txtnombres.TabIndex = 22;
            // 
            // txtdocumentoidentidad
            // 
            this.txtdocumentoidentidad.Location = new System.Drawing.Point(200, 140);
            this.txtdocumentoidentidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtdocumentoidentidad.Name = "txtdocumentoidentidad";
            this.txtdocumentoidentidad.Size = new System.Drawing.Size(201, 22);
            this.txtdocumentoidentidad.TabIndex = 21;
            // 
            // txtcodigoalumno
            // 
            this.txtcodigoalumno.Location = new System.Drawing.Point(16, 140);
            this.txtcodigoalumno.Margin = new System.Windows.Forms.Padding(4);
            this.txtcodigoalumno.Name = "txtcodigoalumno";
            this.txtcodigoalumno.Size = new System.Drawing.Size(160, 22);
            this.txtcodigoalumno.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(644, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Apellidos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nombres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Documento de Identidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Código Paciente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Codigo Reporte:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Situación Reporte:";
            // 
            // txtcodigomatricula
            // 
            this.txtcodigomatricula.Location = new System.Drawing.Point(16, 31);
            this.txtcodigomatricula.Margin = new System.Windows.Forms.Padding(4);
            this.txtcodigomatricula.Name = "txtcodigomatricula";
            this.txtcodigomatricula.Size = new System.Drawing.Size(160, 22);
            this.txtcodigomatricula.TabIndex = 28;
            // 
            // cbosituacionmatricula
            // 
            this.cbosituacionmatricula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbosituacionmatricula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosituacionmatricula.FormattingEnabled = true;
            this.cbosituacionmatricula.Location = new System.Drawing.Point(200, 31);
            this.cbosituacionmatricula.Margin = new System.Windows.Forms.Padding(4);
            this.cbosituacionmatricula.Name = "cbosituacionmatricula";
            this.cbosituacionmatricula.Size = new System.Drawing.Size(201, 24);
            this.cbosituacionmatricula.TabIndex = 29;
            this.cbosituacionmatricula.SelectedIndexChanged += new System.EventHandler(this.cbosituacionmatricula_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 65);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Area:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(423, 65);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Habitacion:";
            // 
            // cbonivelacademico
            // 
            this.cbonivelacademico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbonivelacademico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbonivelacademico.FormattingEnabled = true;
            this.cbonivelacademico.Location = new System.Drawing.Point(200, 85);
            this.cbonivelacademico.Margin = new System.Windows.Forms.Padding(4);
            this.cbonivelacademico.Name = "cbonivelacademico";
            this.cbonivelacademico.Size = new System.Drawing.Size(201, 24);
            this.cbonivelacademico.TabIndex = 30;
            this.cbonivelacademico.SelectionChangeCommitted += new System.EventHandler(this.cbonivelacademico_SelectionChangeCommitted);
            // 
            // cbogradoseccion
            // 
            this.cbogradoseccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbogradoseccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbogradoseccion.FormattingEnabled = true;
            this.cbogradoseccion.Location = new System.Drawing.Point(427, 85);
            this.cbogradoseccion.Margin = new System.Windows.Forms.Padding(4);
            this.cbogradoseccion.Name = "cbogradoseccion";
            this.cbogradoseccion.Size = new System.Drawing.Size(192, 24);
            this.cbogradoseccion.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 65);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Periodo:";
            // 
            // cboperiodo
            // 
            this.cboperiodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboperiodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboperiodo.FormattingEnabled = true;
            this.cboperiodo.Location = new System.Drawing.Point(16, 85);
            this.cboperiodo.Margin = new System.Windows.Forms.Padding(4);
            this.cboperiodo.Name = "cboperiodo";
            this.cboperiodo.Size = new System.Drawing.Size(160, 24);
            this.cboperiodo.TabIndex = 31;
            this.cboperiodo.SelectedIndexChanged += new System.EventHandler(this.cboperiodo_SelectedIndexChanged);
            this.cboperiodo.SelectionChangeCommitted += new System.EventHandler(this.cboperiodo_SelectionChangeCommitted);
            // 
            // frmGenerarReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1011, 524);
            this.Controls.Add(this.cboperiodo);
            this.Controls.Add(this.cbogradoseccion);
            this.Controls.Add(this.cbonivelacademico);
            this.Controls.Add(this.cbosituacionmatricula);
            this.Controls.Add(this.txtcodigomatricula);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnexportar);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtapellidos);
            this.Controls.Add(this.txtnombres);
            this.Controls.Add(this.txtdocumentoidentidad);
            this.Controls.Add(this.txtcodigoalumno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmGenerarReporte";
            this.Text = "Generar Reporte";
            this.Load += new System.EventHandler(this.frmReporteMatricula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnexportar;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtapellidos;
        private System.Windows.Forms.TextBox txtnombres;
        private System.Windows.Forms.TextBox txtdocumentoidentidad;
        private System.Windows.Forms.TextBox txtcodigoalumno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcodigomatricula;
        private System.Windows.Forms.ComboBox cbosituacionmatricula;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbonivelacademico;
        private System.Windows.Forms.ComboBox cbogradoseccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboperiodo;
    }
}