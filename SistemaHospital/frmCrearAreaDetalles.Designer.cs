﻿namespace SistemaHospital
{
    partial class frmCrearAreaDetalles
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
            this.lbporasignar = new System.Windows.Forms.ListBox();
            this.lbasignados = new System.Windows.Forms.ListBox();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btnquitar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboperiodo = new System.Windows.Forms.ComboBox();
            this.cbonivel = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbporasignar
            // 
            this.lbporasignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbporasignar.FormattingEnabled = true;
            this.lbporasignar.ItemHeight = 16;
            this.lbporasignar.Location = new System.Drawing.Point(24, 101);
            this.lbporasignar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbporasignar.Name = "lbporasignar";
            this.lbporasignar.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbporasignar.Size = new System.Drawing.Size(219, 244);
            this.lbporasignar.TabIndex = 0;
            // 
            // lbasignados
            // 
            this.lbasignados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbasignados.FormattingEnabled = true;
            this.lbasignados.ItemHeight = 16;
            this.lbasignados.Location = new System.Drawing.Point(433, 97);
            this.lbasignados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbasignados.Name = "lbasignados";
            this.lbasignados.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbasignados.Size = new System.Drawing.Size(219, 244);
            this.lbasignados.TabIndex = 1;
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.Orange;
            this.btnagregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnagregar.Location = new System.Drawing.Point(288, 164);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(100, 28);
            this.btnagregar.TabIndex = 2;
            this.btnagregar.Text = ">>";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btnquitar
            // 
            this.btnquitar.BackColor = System.Drawing.Color.Orange;
            this.btnquitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnquitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnquitar.Location = new System.Drawing.Point(288, 199);
            this.btnquitar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnquitar.Name = "btnquitar";
            this.btnquitar.Size = new System.Drawing.Size(100, 28);
            this.btnquitar.TabIndex = 2;
            this.btnquitar.Text = "<<";
            this.btnquitar.UseVisualStyleBackColor = false;
            this.btnquitar.Click += new System.EventHandler(this.btnquitar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Periodo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Area:";
            // 
            // cboperiodo
            // 
            this.cboperiodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboperiodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboperiodo.FormattingEnabled = true;
            this.cboperiodo.Location = new System.Drawing.Point(24, 37);
            this.cboperiodo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboperiodo.Name = "cboperiodo";
            this.cboperiodo.Size = new System.Drawing.Size(240, 24);
            this.cboperiodo.TabIndex = 5;
            // 
            // cbonivel
            // 
            this.cbonivel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbonivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbonivel.FormattingEnabled = true;
            this.cbonivel.Location = new System.Drawing.Point(291, 37);
            this.cbonivel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbonivel.Name = "cbonivel";
            this.cbonivel.Size = new System.Drawing.Size(253, 24);
            this.cbonivel.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(553, 34);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(20, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Habitaciones pendientes de Asignar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(433, 350);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(220, 28);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(429, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Habitaciones Asignadas";
            // 
            // frmCrearAreaDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(679, 391);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbonivel);
            this.Controls.Add(this.cboperiodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnquitar);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.lbasignados);
            this.Controls.Add(this.lbporasignar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmCrearAreaDetalles";
            this.Text = "Asignar Habitaciones en Areas";
            this.Load += new System.EventHandler(this.frmCrearNivelDetalle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbporasignar;
        private System.Windows.Forms.ListBox lbasignados;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btnquitar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboperiodo;
        private System.Windows.Forms.ComboBox cbonivel;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
    }
}