
namespace Aplicacion_Caja_Hospital
{
    partial class FormCierre
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tblCuadreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CajaDS = new Aplicacion_Caja_Hospital.CajaDBDataSet();
            this.tblCuadreTableAdapter = new Aplicacion_Caja_Hospital.CajaDBDataSetTableAdapters.tblCuadreTableAdapter();
            this.buttonTerminar = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.CajaDBDataSet = new Aplicacion_Caja_Hospital.CajaDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.tblCuadreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CajaDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CajaDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tblCuadreBindingSource
            // 
            this.tblCuadreBindingSource.DataMember = "tblCuadre";
            this.tblCuadreBindingSource.DataSource = this.CajaDS;
            // 
            // CajaDS
            // 
            this.CajaDS.DataSetName = "CajaDS";
            this.CajaDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblCuadreTableAdapter
            // 
            this.tblCuadreTableAdapter.ClearBeforeFill = true;
            // 
            // buttonTerminar
            // 
            this.buttonTerminar.Location = new System.Drawing.Point(1059, 462);
            this.buttonTerminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTerminar.Name = "buttonTerminar";
            this.buttonTerminar.Size = new System.Drawing.Size(243, 78);
            this.buttonTerminar.TabIndex = 1;
            this.buttonTerminar.Text = "Terminar día";
            this.buttonTerminar.UseVisualStyleBackColor = true;
            this.buttonTerminar.Click += new System.EventHandler(this.buttonTerminar_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(1059, 389);
            this.buttonVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(243, 65);
            this.buttonVolver.TabIndex = 2;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // CajaDBDataSet
            // 
            this.CajaDBDataSet.DataSetName = "CajaDBDataSet";
            this.CajaDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "tblCuadre";
            reportDataSource1.Value = this.tblCuadreBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Aplicacion_Caja_Hospital.ReportCierre.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(16, 15);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1034, 524);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // FormCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1317, 554);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonTerminar);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCierre";
            this.Text = "FormCierre";
            this.Load += new System.EventHandler(this.FormCierre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblCuadreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CajaDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CajaDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tblCuadreBindingSource;
        private CajaDBDataSet CajaDS;
        private CajaDBDataSetTableAdapters.tblCuadreTableAdapter tblCuadreTableAdapter;
        private System.Windows.Forms.Button buttonTerminar;
        private System.Windows.Forms.Button buttonVolver;
        private CajaDBDataSet CajaDBDataSet;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}