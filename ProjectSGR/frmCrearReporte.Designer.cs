namespace ProjectSGR
{
    partial class frmCrearReporte
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
            this.txtCantViajes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddViajes = new System.Windows.Forms.Button();
            this.panelViajes = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtCantViajes
            // 
            this.txtCantViajes.Location = new System.Drawing.Point(161, 12);
            this.txtCantViajes.Name = "txtCantViajes";
            this.txtCantViajes.Size = new System.Drawing.Size(100, 22);
            this.txtCantViajes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad de Viajes";
            // 
            // btnAddViajes
            // 
            this.btnAddViajes.Location = new System.Drawing.Point(283, 12);
            this.btnAddViajes.Name = "btnAddViajes";
            this.btnAddViajes.Size = new System.Drawing.Size(75, 23);
            this.btnAddViajes.TabIndex = 2;
            this.btnAddViajes.Text = "Añadir";
            this.btnAddViajes.UseVisualStyleBackColor = true;
            this.btnAddViajes.Click += new System.EventHandler(this.btnAddViajes_Click);
            // 
            // panelViajes
            // 
            this.panelViajes.Location = new System.Drawing.Point(24, 41);
            this.panelViajes.Name = "panelViajes";
            this.panelViajes.Size = new System.Drawing.Size(440, 329);
            this.panelViajes.TabIndex = 3;
            // 
            // frmCrearReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 577);
            this.Controls.Add(this.panelViajes);
            this.Controls.Add(this.btnAddViajes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantViajes);
            this.Name = "frmCrearReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creación de Reporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCantViajes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddViajes;
        private System.Windows.Forms.Panel panelViajes;
    }
}