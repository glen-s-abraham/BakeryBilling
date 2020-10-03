namespace BakeryBilling
{
    partial class Form3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mrp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pname = new System.Windows.Forms.ComboBox();
            this.cprice = new System.Windows.Forms.TextBox();
            this.sprice = new System.Windows.Forms.TextBox();
            this.qty = new System.Windows.Forms.TextBox();
            this.expdate = new System.Windows.Forms.DateTimePicker();
            this.reset = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.product_grid = new System.Windows.Forms.DataGridView();
            this.purchase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.product_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(546, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "CPrice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(530, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Exp Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(12, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "SPrice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.Location = new System.Drawing.Point(296, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "MRP";
            // 
            // mrp
            // 
            this.mrp.Location = new System.Drawing.Point(345, 21);
            this.mrp.Name = "mrp";
            this.mrp.Size = new System.Drawing.Size(158, 20);
            this.mrp.TabIndex = 2;
            this.mrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mrp_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(275, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quantity";
            // 
            // pname
            // 
            this.pname.FormattingEnabled = true;
            this.pname.Location = new System.Drawing.Point(68, 23);
            this.pname.Name = "pname";
            this.pname.Size = new System.Drawing.Size(158, 21);
            this.pname.TabIndex = 1;
            this.pname.SelectedIndexChanged += new System.EventHandler(this.pname_SelectedIndexChanged);
            this.pname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pname_KeyPress);
            // 
            // cprice
            // 
            this.cprice.Location = new System.Drawing.Point(609, 21);
            this.cprice.Name = "cprice";
            this.cprice.Size = new System.Drawing.Size(158, 20);
            this.cprice.TabIndex = 3;
            this.cprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cprice_KeyPress);
            // 
            // sprice
            // 
            this.sprice.Location = new System.Drawing.Point(68, 63);
            this.sprice.Name = "sprice";
            this.sprice.Size = new System.Drawing.Size(158, 20);
            this.sprice.TabIndex = 4;
            this.sprice.TextChanged += new System.EventHandler(this.sprice_TextChanged);
            this.sprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sprice_KeyPress);
            // 
            // qty
            // 
            this.qty.Location = new System.Drawing.Point(345, 62);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(158, 20);
            this.qty.TabIndex = 5;
            this.qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qty_KeyPress);
            // 
            // expdate
            // 
            this.expdate.Location = new System.Drawing.Point(609, 61);
            this.expdate.Name = "expdate";
            this.expdate.Size = new System.Drawing.Size(158, 20);
            this.expdate.TabIndex = 6;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.reset.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.reset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reset.Location = new System.Drawing.Point(419, 99);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(84, 34);
            this.reset.TabIndex = 8;
            this.reset.Text = "RESET";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.ok.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ok.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ok.Location = new System.Drawing.Point(329, 99);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(84, 34);
            this.ok.TabIndex = 7;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.add.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.add.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add.Location = new System.Drawing.Point(188, 147);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(84, 33);
            this.add.TabIndex = 21;
            this.add.Text = "ADD";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.delete.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.delete.Location = new System.Drawing.Point(530, 147);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(84, 33);
            this.delete.TabIndex = 22;
            this.delete.Text = "DELETE";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.update.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.update.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.update.Location = new System.Drawing.Point(293, 147);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(84, 33);
            this.update.TabIndex = 23;
            this.update.Text = "UPDATE";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // product_grid
            // 
            this.product_grid.AllowUserToAddRows = false;
            this.product_grid.AllowUserToDeleteRows = false;
            this.product_grid.AllowUserToResizeColumns = false;
            this.product_grid.AllowUserToResizeRows = false;
            this.product_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.product_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.product_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.product_grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.product_grid.Location = new System.Drawing.Point(27, 192);
            this.product_grid.Name = "product_grid";
            this.product_grid.ReadOnly = true;
            this.product_grid.ShowEditingIcon = false;
            this.product_grid.Size = new System.Drawing.Size(752, 150);
            this.product_grid.TabIndex = 24;
            // 
            // purchase
            // 
            this.purchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.purchase.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.purchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.purchase.Location = new System.Drawing.Point(402, 147);
            this.purchase.Name = "purchase";
            this.purchase.Size = new System.Drawing.Size(108, 33);
            this.purchase.TabIndex = 25;
            this.purchase.Text = "PURCHASE";
            this.purchase.UseVisualStyleBackColor = false;
            this.purchase.Click += new System.EventHandler(this.purchase_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 354);
            this.ControlBox = false;
            this.Controls.Add(this.purchase);
            this.Controls.Add(this.product_grid);
            this.Controls.Add(this.update);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.expdate);
            this.Controls.Add(this.qty);
            this.Controls.Add(this.sprice);
            this.Controls.Add(this.cprice);
            this.Controls.Add(this.pname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mrp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1075, 578);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.product_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mrp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pname;
        private System.Windows.Forms.TextBox cprice;
        private System.Windows.Forms.TextBox sprice;
        private System.Windows.Forms.TextBox qty;
        private System.Windows.Forms.DateTimePicker expdate;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.DataGridView product_grid;
        private System.Windows.Forms.Button purchase;
    }
}