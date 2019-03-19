namespace Tarea5
{
    partial class _5
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
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.dtp5 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNoFactura = new System.Windows.Forms.ComboBox();
            this.dtgFac = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPagosR = new System.Windows.Forms.Label();
            this.lblMontoPagos = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFac)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(127, 30);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(121, 21);
            this.cbCliente.TabIndex = 0;
            // 
            // dtp5
            // 
            this.dtp5.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp5.Location = new System.Drawing.Point(416, 31);
            this.dtp5.Name = "dtp5";
            this.dtp5.Size = new System.Drawing.Size(148, 20);
            this.dtp5.TabIndex = 1;
            this.dtp5.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Compras desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "No. de factura";
            // 
            // cboNoFactura
            // 
            this.cboNoFactura.FormattingEnabled = true;
            this.cboNoFactura.Location = new System.Drawing.Point(127, 95);
            this.cboNoFactura.Name = "cboNoFactura";
            this.cboNoFactura.Size = new System.Drawing.Size(121, 21);
            this.cboNoFactura.TabIndex = 5;
            this.cboNoFactura.SelectedIndexChanged += new System.EventHandler(this.cboNoFactura_SelectedIndexChanged);
            // 
            // dtgFac
            // 
            this.dtgFac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFac.Location = new System.Drawing.Point(56, 138);
            this.dtgFac.Name = "dtgFac";
            this.dtgFac.Size = new System.Drawing.Size(354, 184);
            this.dtgFac.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "TOTAL:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(354, 334);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "No. de Pagos Realizados";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(494, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Monto Total Pagos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(497, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Saldo Actual";
            // 
            // lblPagosR
            // 
            this.lblPagosR.AutoSize = true;
            this.lblPagosR.Location = new System.Drawing.Point(676, 138);
            this.lblPagosR.Name = "lblPagosR";
            this.lblPagosR.Size = new System.Drawing.Size(0, 13);
            this.lblPagosR.TabIndex = 12;
            // 
            // lblMontoPagos
            // 
            this.lblMontoPagos.AutoSize = true;
            this.lblMontoPagos.Location = new System.Drawing.Point(679, 168);
            this.lblMontoPagos.Name = "lblMontoPagos";
            this.lblMontoPagos.Size = new System.Drawing.Size(0, 13);
            this.lblMontoPagos.TabIndex = 13;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(682, 199);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(0, 13);
            this.lblSaldo.TabIndex = 14;
            // 
            // _5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.lblMontoPagos);
            this.Controls.Add(this.lblPagosR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtgFac);
            this.Controls.Add(this.cboNoFactura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp5);
            this.Controls.Add(this.cbCliente);
            this.Name = "_5";
            this.Text = "_5";
            this.Load += new System.EventHandler(this._5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.DateTimePicker dtp5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNoFactura;
        private System.Windows.Forms.DataGridView dtgFac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPagosR;
        private System.Windows.Forms.Label lblMontoPagos;
        private System.Windows.Forms.Label lblSaldo;
    }
}