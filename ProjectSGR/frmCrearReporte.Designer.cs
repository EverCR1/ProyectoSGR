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
            this.components = new System.ComponentModel.Container();
            this.txtCantViajes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddViajes = new System.Windows.Forms.Button();
            this.panelViajes = new System.Windows.Forms.Panel();
            this.cBoxVehiculo = new System.Windows.Forms.ComboBox();
            this.bdSGRDataSet = new ProjectSGR.bdSGRDataSet();
            this.tbVehiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbVehiculoTableAdapter = new ProjectSGR.bdSGRDataSetTableAdapters.tbVehiculoTableAdapter();
            this.datePick = new System.Windows.Forms.DateTimePicker();
            this.nTurno = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPiloto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAyudante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCombustible = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtViaticos = new System.Windows.Forms.TextBox();
            this.panelViajes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSGRDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVehiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTurno)).BeginInit();
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
            this.panelViajes.Controls.Add(this.label8);
            this.panelViajes.Controls.Add(this.txtViaticos);
            this.panelViajes.Controls.Add(this.label7);
            this.panelViajes.Controls.Add(this.txtCombustible);
            this.panelViajes.Controls.Add(this.label6);
            this.panelViajes.Controls.Add(this.txtAyudante);
            this.panelViajes.Controls.Add(this.label5);
            this.panelViajes.Controls.Add(this.txtPiloto);
            this.panelViajes.Controls.Add(this.label4);
            this.panelViajes.Controls.Add(this.label3);
            this.panelViajes.Controls.Add(this.label2);
            this.panelViajes.Controls.Add(this.nTurno);
            this.panelViajes.Controls.Add(this.datePick);
            this.panelViajes.Controls.Add(this.cBoxVehiculo);
            this.panelViajes.Location = new System.Drawing.Point(24, 41);
            this.panelViajes.Name = "panelViajes";
            this.panelViajes.Size = new System.Drawing.Size(440, 329);
            this.panelViajes.TabIndex = 3;
            // 
            // cBoxVehiculo
            // 
            this.cBoxVehiculo.DataSource = this.bdSGRDataSet;
            this.cBoxVehiculo.DisplayMember = "tbVehiculo.nombre";
            this.cBoxVehiculo.FormattingEnabled = true;
            this.cBoxVehiculo.Location = new System.Drawing.Point(103, 3);
            this.cBoxVehiculo.Name = "cBoxVehiculo";
            this.cBoxVehiculo.Size = new System.Drawing.Size(147, 24);
            this.cBoxVehiculo.TabIndex = 4;
            // 
            // bdSGRDataSet
            // 
            this.bdSGRDataSet.DataSetName = "bdSGRDataSet";
            this.bdSGRDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbVehiculoBindingSource
            // 
            this.tbVehiculoBindingSource.DataMember = "tbVehiculo";
            this.tbVehiculoBindingSource.DataSource = this.bdSGRDataSet;
            // 
            // tbVehiculoTableAdapter
            // 
            this.tbVehiculoTableAdapter.ClearBeforeFill = true;
            // 
            // datePick
            // 
            this.datePick.Location = new System.Drawing.Point(103, 43);
            this.datePick.Name = "datePick";
            this.datePick.Size = new System.Drawing.Size(306, 22);
            this.datePick.TabIndex = 5;
            // 
            // nTurno
            // 
            this.nTurno.Location = new System.Drawing.Point(309, 3);
            this.nTurno.Name = "nTurno";
            this.nTurno.Size = new System.Drawing.Size(37, 22);
            this.nTurno.TabIndex = 6;
            this.nTurno.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vehículo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Turno:";
            // 
            // txtPiloto
            // 
            this.txtPiloto.Location = new System.Drawing.Point(103, 82);
            this.txtPiloto.Name = "txtPiloto";
            this.txtPiloto.Size = new System.Drawing.Size(100, 22);
            this.txtPiloto.TabIndex = 10;
            this.txtPiloto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPiloto_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Pago Piloto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pago Ayudante:";
            // 
            // txtAyudante
            // 
            this.txtAyudante.Location = new System.Drawing.Point(318, 82);
            this.txtAyudante.Name = "txtAyudante";
            this.txtAyudante.Size = new System.Drawing.Size(100, 22);
            this.txtAyudante.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Combustible:";
            // 
            // txtCombustible
            // 
            this.txtCombustible.Location = new System.Drawing.Point(103, 123);
            this.txtCombustible.Name = "txtCombustible";
            this.txtCombustible.Size = new System.Drawing.Size(100, 22);
            this.txtCombustible.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Viaticos:";
            // 
            // txtViaticos
            // 
            this.txtViaticos.Location = new System.Drawing.Point(318, 126);
            this.txtViaticos.Name = "txtViaticos";
            this.txtViaticos.Size = new System.Drawing.Size(100, 22);
            this.txtViaticos.TabIndex = 16;
            // 
            // frmCrearReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 668);
            this.Controls.Add(this.panelViajes);
            this.Controls.Add(this.btnAddViajes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantViajes);
            this.Name = "frmCrearReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creación de Reporte";
            this.Load += new System.EventHandler(this.frmCrearReporte_Load);
            this.panelViajes.ResumeLayout(false);
            this.panelViajes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSGRDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVehiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTurno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCantViajes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddViajes;
        private System.Windows.Forms.Panel panelViajes;
        private System.Windows.Forms.ComboBox cBoxVehiculo;
        private bdSGRDataSet bdSGRDataSet;
        private System.Windows.Forms.BindingSource tbVehiculoBindingSource;
        private bdSGRDataSetTableAdapters.tbVehiculoTableAdapter tbVehiculoTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nTurno;
        private System.Windows.Forms.DateTimePicker datePick;
        private System.Windows.Forms.TextBox txtPiloto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtViaticos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCombustible;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAyudante;
        private System.Windows.Forms.Label label5;
    }
}