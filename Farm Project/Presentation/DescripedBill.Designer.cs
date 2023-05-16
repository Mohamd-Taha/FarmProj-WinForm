namespace Farm_Project.Presentation
{
    partial class DescripedBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescripedBill));
            this.billProductsDGV = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new Guna.UI.WinForms.GunaLineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDiscount = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtPiad = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtTrader = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtDate = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtTotal = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtPayement = new Guna.UI.WinForms.GunaLineTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.billProductsDGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // billProductsDGV
            // 
            this.billProductsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.billProductsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.billProductsDGV.Location = new System.Drawing.Point(570, 36);
            this.billProductsDGV.Name = "billProductsDGV";
            this.billProductsDGV.ReadOnly = true;
            this.billProductsDGV.RowTemplate.Height = 24;
            this.billProductsDGV.Size = new System.Drawing.Size(766, 684);
            this.billProductsDGV.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 32);
            this.label8.TabIndex = 24;
            this.label8.Text = "Bill Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Trader";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Payement Type";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.Enabled = false;
            this.txtId.FocusedLineColor = System.Drawing.Color.LightGreen;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtId.LineColor = System.Drawing.Color.LightGreen;
            this.txtId.Location = new System.Drawing.Point(133, 14);
            this.txtId.Name = "txtId";
            this.txtId.PasswordChar = '\0';
            this.txtId.SelectedText = "";
            this.txtId.Size = new System.Drawing.Size(116, 34);
            this.txtId.TabIndex = 16;
            this.txtId.TextChanged += new System.EventHandler(this.gunaLineTextBox3_TextChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(266, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Paid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(266, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Discount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Total";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDiscount);
            this.panel2.Controls.Add(this.txtPiad);
            this.panel2.Controls.Add(this.txtTrader);
            this.panel2.Controls.Add(this.txtDate);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.txtPayement);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtId);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Enabled = false;
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 306);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.White;
            this.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiscount.Enabled = false;
            this.txtDiscount.FocusedLineColor = System.Drawing.Color.LightGreen;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiscount.LineColor = System.Drawing.Color.LightGreen;
            this.txtDiscount.Location = new System.Drawing.Point(412, 169);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.Size = new System.Drawing.Size(116, 34);
            this.txtDiscount.TabIndex = 28;
            this.txtDiscount.TextChanged += new System.EventHandler(this.gunaLineTextBox7_TextChanged);
            // 
            // txtPiad
            // 
            this.txtPiad.BackColor = System.Drawing.Color.White;
            this.txtPiad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPiad.Enabled = false;
            this.txtPiad.FocusedLineColor = System.Drawing.Color.LightGreen;
            this.txtPiad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPiad.LineColor = System.Drawing.Color.LightGreen;
            this.txtPiad.Location = new System.Drawing.Point(412, 87);
            this.txtPiad.Name = "txtPiad";
            this.txtPiad.PasswordChar = '\0';
            this.txtPiad.SelectedText = "";
            this.txtPiad.Size = new System.Drawing.Size(116, 34);
            this.txtPiad.TabIndex = 27;
            // 
            // txtTrader
            // 
            this.txtTrader.BackColor = System.Drawing.Color.White;
            this.txtTrader.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTrader.Enabled = false;
            this.txtTrader.FocusedLineColor = System.Drawing.Color.LightGreen;
            this.txtTrader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTrader.LineColor = System.Drawing.Color.LightGreen;
            this.txtTrader.Location = new System.Drawing.Point(133, 76);
            this.txtTrader.Name = "txtTrader";
            this.txtTrader.PasswordChar = '\0';
            this.txtTrader.SelectedText = "";
            this.txtTrader.Size = new System.Drawing.Size(116, 34);
            this.txtTrader.TabIndex = 26;
            this.txtTrader.TextChanged += new System.EventHandler(this.gunaLineTextBox5_TextChanged);
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDate.Enabled = false;
            this.txtDate.FocusedLineColor = System.Drawing.Color.LightGreen;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDate.LineColor = System.Drawing.Color.LightGreen;
            this.txtDate.Location = new System.Drawing.Point(133, 156);
            this.txtDate.Name = "txtDate";
            this.txtDate.PasswordChar = '\0';
            this.txtDate.SelectedText = "";
            this.txtDate.Size = new System.Drawing.Size(116, 34);
            this.txtDate.TabIndex = 25;
            this.txtDate.TextChanged += new System.EventHandler(this.gunaLineTextBox4_TextChanged_1);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotal.Enabled = false;
            this.txtTotal.FocusedLineColor = System.Drawing.Color.LightGreen;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotal.LineColor = System.Drawing.Color.LightGreen;
            this.txtTotal.Location = new System.Drawing.Point(133, 234);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.PasswordChar = '\0';
            this.txtTotal.SelectedText = "";
            this.txtTotal.Size = new System.Drawing.Size(116, 34);
            this.txtTotal.TabIndex = 24;
            this.txtTotal.TextChanged += new System.EventHandler(this.gunaLineTextBox2_TextChanged_1);
            // 
            // txtPayement
            // 
            this.txtPayement.BackColor = System.Drawing.Color.White;
            this.txtPayement.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPayement.Enabled = false;
            this.txtPayement.FocusedLineColor = System.Drawing.Color.LightGreen;
            this.txtPayement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPayement.LineColor = System.Drawing.Color.LightGreen;
            this.txtPayement.Location = new System.Drawing.Point(412, 14);
            this.txtPayement.Name = "txtPayement";
            this.txtPayement.PasswordChar = '\0';
            this.txtPayement.SelectedText = "";
            this.txtPayement.Size = new System.Drawing.Size(116, 34);
            this.txtPayement.TabIndex = 23;
            this.txtPayement.TextChanged += new System.EventHandler(this.gunaLineTextBox1_TextChanged_1);
            // 
            // DescripedBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.billProductsDGV);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DescripedBill";
            this.Text = "DescripedBill";
            ((System.ComponentModel.ISupportInitialize)(this.billProductsDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView billProductsDGV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaLineTextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaLineTextBox txtDiscount;
        private Guna.UI.WinForms.GunaLineTextBox txtPiad;
        private Guna.UI.WinForms.GunaLineTextBox txtTrader;
        private Guna.UI.WinForms.GunaLineTextBox txtDate;
        private Guna.UI.WinForms.GunaLineTextBox txtTotal;
        private Guna.UI.WinForms.GunaLineTextBox txtPayement;
    }
}