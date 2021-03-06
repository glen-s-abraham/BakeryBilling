﻿namespace BakeryBilling
{
    partial class frmBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_items = new System.Windows.Forms.ComboBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.txt_mrp = new System.Windows.Forms.TextBox();
            this.txt_sprice = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.grdItems = new System.Windows.Forms.DataGridView();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_totalmrp = new System.Windows.Forms.Label();
            this.lbl_ourtotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Bill = new System.Drawing.Printing.PrintDocument();
            this.PrintView = new System.Windows.Forms.PrintDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.dt_bill = new System.Windows.Forms.DateTimePicker();
            this.btn_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(405, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(550, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "MRP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(705, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "SPrice";
            // 
            // cmb_items
            // 
            this.cmb_items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_items.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmb_items.FormattingEnabled = true;
            this.cmb_items.Location = new System.Drawing.Point(243, 30);
            this.cmb_items.Name = "cmb_items";
            this.cmb_items.Size = new System.Drawing.Size(156, 35);
            this.cmb_items.TabIndex = 1;
            this.cmb_items.SelectedIndexChanged += new System.EventHandler(this.cmb_items_SelectedIndexChanged);
            this.cmb_items.SelectionChangeCommitted += new System.EventHandler(this.cmb_items_SelectionChangeCommitted);
            this.cmb_items.TextChanged += new System.EventHandler(this.cmb_items_TextChanged);
            // 
            // txt_qty
            // 
            this.txt_qty.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txt_qty.Location = new System.Drawing.Point(442, 29);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(100, 35);
            this.txt_qty.TabIndex = 2;
            this.txt_qty.TextChanged += new System.EventHandler(this.txt_qty_TextChanged);
            this.txt_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validate_number);
            // 
            // txt_mrp
            // 
            this.txt_mrp.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txt_mrp.Location = new System.Drawing.Point(599, 30);
            this.txt_mrp.Name = "txt_mrp";
            this.txt_mrp.Size = new System.Drawing.Size(100, 35);
            this.txt_mrp.TabIndex = 3;
            this.txt_mrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validate_number);
            // 
            // txt_sprice
            // 
            this.txt_sprice.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txt_sprice.Location = new System.Drawing.Point(767, 30);
            this.txt_sprice.Name = "txt_sprice";
            this.txt_sprice.Size = new System.Drawing.Size(100, 35);
            this.txt_sprice.TabIndex = 4;
            this.txt_sprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validate_number);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(32)))), ((int)(((byte)(88)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(881, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(962, 31);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 35);
            this.btn_delete.TabIndex = 6;
            this.btn_delete.Text = "DEL";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Location = new System.Drawing.Point(758, 484);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 35);
            this.btn_print.TabIndex = 7;
            this.btn_print.Text = "&PRINT";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // grdItems
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdItems.Location = new System.Drawing.Point(27, 89);
            this.grdItems.MultiSelect = false;
            this.grdItems.Name = "grdItems";
            this.grdItems.ReadOnly = true;
            this.grdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItems.Size = new System.Drawing.Size(1010, 383);
            this.grdItems.TabIndex = 10;
            this.grdItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdItems_KeyDown);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(27, 64);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(34, 20);
            this.txt_id.TabIndex = 12;
            this.txt_id.Text = "0";
            this.txt_id.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(948, 484);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(89, 35);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "&CANCEL";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 492);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 27);
            this.label5.TabIndex = 14;
            this.label5.Text = "Total MRP";
            // 
            // lbl_totalmrp
            // 
            this.lbl_totalmrp.AutoSize = true;
            this.lbl_totalmrp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.lbl_totalmrp.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbl_totalmrp.Location = new System.Drawing.Point(153, 489);
            this.lbl_totalmrp.Name = "lbl_totalmrp";
            this.lbl_totalmrp.Size = new System.Drawing.Size(31, 32);
            this.lbl_totalmrp.TabIndex = 15;
            this.lbl_totalmrp.Text = "0";
            // 
            // lbl_ourtotal
            // 
            this.lbl_ourtotal.AutoSize = true;
            this.lbl_ourtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(32)))), ((int)(((byte)(88)))));
            this.lbl_ourtotal.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbl_ourtotal.Location = new System.Drawing.Point(452, 491);
            this.lbl_ourtotal.Name = "lbl_ourtotal";
            this.lbl_ourtotal.Size = new System.Drawing.Size(31, 32);
            this.lbl_ourtotal.TabIndex = 17;
            this.lbl_ourtotal.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(325, 494);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 27);
            this.label7.TabIndex = 16;
            this.label7.Text = "Our Price";
            // 
            // Bill
            // 
            this.Bill.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.Bill_PrintPage);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "Date";
            // 
            // dt_bill
            // 
            this.dt_bill.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.dt_bill.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_bill.Location = new System.Drawing.Point(67, 31);
            this.dt_bill.Name = "dt_bill";
            this.dt_bill.Size = new System.Drawing.Size(127, 35);
            this.dt_bill.TabIndex = 11;
            this.dt_bill.Value = new System.DateTime(2020, 9, 24, 0, 0, 0, 0);
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btn_refresh.ForeColor = System.Drawing.Color.White;
            this.btn_refresh.Location = new System.Drawing.Point(839, 484);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(103, 35);
            this.btn_refresh.TabIndex = 8;
            this.btn_refresh.Text = "&REFRESH";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1059, 539);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.dt_bill);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_ourtotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_totalmrp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_sprice);
            this.Controls.Add(this.txt_mrp);
            this.Controls.Add(this.txt_qty);
            this.Controls.Add(this.cmb_items);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBill";
            this.Text = "Bill";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBill_FormClosed);
            this.Load += new System.EventHandler(this.frmBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_items;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.TextBox txt_mrp;
        private System.Windows.Forms.TextBox txt_sprice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DataGridView grdItems;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_totalmrp;
        private System.Windows.Forms.Label lbl_ourtotal;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Printing.PrintDocument Bill;
        private System.Windows.Forms.PrintDialog PrintView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_bill;
        private System.Windows.Forms.Button btn_refresh;
    }
}