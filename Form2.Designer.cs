namespace BakeryBilling
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_items = new System.Windows.Forms.ComboBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.txt_mrp = new System.Windows.Forms.TextBox();
            this.txt_sprice = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grdItems = new System.Windows.Forms.DataGridView();
            this.txt_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(245, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(393, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "MRP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(559, 29);
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
            this.cmb_items.Location = new System.Drawing.Point(77, 23);
            this.cmb_items.Name = "cmb_items";
            this.cmb_items.Size = new System.Drawing.Size(156, 35);
            this.cmb_items.TabIndex = 4;
            this.cmb_items.SelectionChangeCommitted += new System.EventHandler(this.cmb_items_SelectionChangeCommitted);
            this.cmb_items.TextChanged += new System.EventHandler(this.cmb_items_TextChanged);
            // 
            // txt_qty
            // 
            this.txt_qty.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txt_qty.Location = new System.Drawing.Point(282, 23);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(100, 35);
            this.txt_qty.TabIndex = 5;
            // 
            // txt_mrp
            // 
            this.txt_mrp.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txt_mrp.Location = new System.Drawing.Point(442, 22);
            this.txt_mrp.Name = "txt_mrp";
            this.txt_mrp.Size = new System.Drawing.Size(100, 35);
            this.txt_mrp.TabIndex = 6;
            // 
            // txt_sprice
            // 
            this.txt_sprice.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txt_sprice.Location = new System.Drawing.Point(621, 22);
            this.txt_sprice.Name = "txt_sprice";
            this.txt_sprice.Size = new System.Drawing.Size(100, 35);
            this.txt_sprice.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(32)))), ((int)(((byte)(88)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(786, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(867, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 9;
            this.button2.Text = "DEL";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(948, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 35);
            this.button3.TabIndex = 10;
            this.button3.Text = "PRINT";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // grdItems
            // 
            this.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItems.Location = new System.Drawing.Point(37, 89);
            this.grdItems.MultiSelect = false;
            this.grdItems.Name = "grdItems";
            this.grdItems.Size = new System.Drawing.Size(986, 416);
            this.grdItems.TabIndex = 11;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(37, 64);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(34, 20);
            this.txt_id.TabIndex = 12;
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1059, 539);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView grdItems;
        private System.Windows.Forms.TextBox txt_id;
    }
}