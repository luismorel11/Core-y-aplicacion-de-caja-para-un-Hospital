
namespace Aplicacion_Caja_Hospital
{
    partial class FormClientesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientesMenu));
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonRetirada = new System.Windows.Forms.Button();
            this.buttonPrestamo = new System.Windows.Forms.Button();
            this.buttonDeposito = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.SystemColors.Info;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.labelTitle.Location = new System.Drawing.Point(319, 95);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(415, 54);
            this.labelTitle.TabIndex = 18;
            this.labelTitle.Text = "MENU CLIENTES";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCancelar.Location = new System.Drawing.Point(812, 501);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(252, 49);
            this.buttonCancelar.TabIndex = 17;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonRetirada
            // 
            this.buttonRetirada.BackColor = System.Drawing.SystemColors.Info;
            this.buttonRetirada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRetirada.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRetirada.Location = new System.Drawing.Point(219, 359);
            this.buttonRetirada.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRetirada.Name = "buttonRetirada";
            this.buttonRetirada.Size = new System.Drawing.Size(252, 68);
            this.buttonRetirada.TabIndex = 16;
            this.buttonRetirada.Text = "Retirar";
            this.buttonRetirada.UseVisualStyleBackColor = false;
            this.buttonRetirada.Click += new System.EventHandler(this.buttonRetirada_Click);
            // 
            // buttonPrestamo
            // 
            this.buttonPrestamo.BackColor = System.Drawing.SystemColors.Info;
            this.buttonPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrestamo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPrestamo.Location = new System.Drawing.Point(597, 247);
            this.buttonPrestamo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrestamo.Name = "buttonPrestamo";
            this.buttonPrestamo.Size = new System.Drawing.Size(252, 68);
            this.buttonPrestamo.TabIndex = 15;
            this.buttonPrestamo.Text = "Pagar Procedimiento";
            this.buttonPrestamo.UseVisualStyleBackColor = false;
            this.buttonPrestamo.Click += new System.EventHandler(this.buttonPrestamo_Click);
            // 
            // buttonDeposito
            // 
            this.buttonDeposito.BackColor = System.Drawing.SystemColors.Info;
            this.buttonDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeposito.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDeposito.Location = new System.Drawing.Point(219, 247);
            this.buttonDeposito.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeposito.Name = "buttonDeposito";
            this.buttonDeposito.Size = new System.Drawing.Size(252, 68);
            this.buttonDeposito.TabIndex = 14;
            this.buttonDeposito.Text = "Deposito";
            this.buttonDeposito.UseVisualStyleBackColor = false;
            this.buttonDeposito.Click += new System.EventHandler(this.buttonDeposito_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(597, 359);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 68);
            this.button1.TabIndex = 19;
            this.button1.Text = "Agregar Procedimiento";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormClientesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonRetirada);
            this.Controls.Add(this.buttonPrestamo);
            this.Controls.Add(this.buttonDeposito);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormClientesMenu";
            this.Text = "FormClientesMenu";
            this.Load += new System.EventHandler(this.FormClientesMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonRetirada;
        private System.Windows.Forms.Button buttonPrestamo;
        private System.Windows.Forms.Button buttonDeposito;
        private System.Windows.Forms.Button button1;
    }
}