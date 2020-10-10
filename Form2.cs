using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Text;

namespace BakeryBilling
{

    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }
        public class Items
        {
            public int id { get; set; }
            public string name { get; set; }
            public double qty { get; set; }
            public double mrp { get; set; }
            public double sprice { get; set; }
            public double tot_mrp { get; set; }
            public double tot_sprice { get; set; }
        }


        string billid = "0";
        List<Items> itemList = new List<Items>();
        OleDbConnection conn;
        OleDbCommand billCmd, productCmd;
        OleDbDataAdapter billAdapter, productAdapter;
        DataTable billTable, productTable;
        double total_mrp, total_sprice;
        private void update_totals()
        {
            total_mrp = 0;
            total_sprice = 0;
            foreach (Items item in itemList)
            {
                total_mrp += item.tot_mrp;
                total_sprice += item.tot_sprice;
            }
            lbl_totalmrp.Text = String.Format("{0:0.00}", total_mrp);
            lbl_ourtotal.Text = String.Format("{0:0.00}", total_sprice);
        }

        private void cmb_items_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_items.SelectedValue != null)
            {
                var id = cmb_items.SelectedValue;

                txt_id.Text = "0";
                txt_mrp.Text = "";
                txt_sprice.Text = "";
                txt_qty.Text = "";
                try
                {
                    string query = "SELECT ID,MRP,SPRICE FROM PRODUCTS WHERE ID=" + id;
                    productCmd = new OleDbCommand(query, conn);
                    productAdapter = new OleDbDataAdapter();
                    productAdapter.SelectCommand = productCmd;
                    DataTable localProductTable = new DataTable();
                    productAdapter.Fill(localProductTable);
                    if (localProductTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in localProductTable.Rows)
                        {
                            txt_id.Text = row["ID"].ToString();
                            txt_mrp.Text = row["MRP"].ToString();
                            txt_sprice.Text = row["Sprice"].ToString();
                        }

                    }
                    productAdapter.Dispose();
                    productCmd.Dispose();
                    localProductTable.Dispose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




        }
        private void clear_billing()
        {
            grdItems.DataSource = "";
            itemList.Clear();
            cmb_items.SelectedIndex = -1;
            txt_id.Text = "0";
            txt_mrp.Text = "";
            txt_sprice.Text = "";
            txt_qty.Text = "";


        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var index = grdItems.SelectedRows[0].Index;
                if (index >= 0)
                {
                    grdItems.DataSource = "";
                    itemList.RemoveAt(index);
                    grdItems.DataSource = itemList;
                    update_totals();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Selections Made");
            }




        }

        int listIndex = 0;
        int itemPerPage = 0;
        private void Bill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {



            int x = 10;
            int y = 10;
            Pen pen = new Pen(Brushes.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            int centerX = (int)(x + Math.Abs(285 * 0.5));

            Font H1 = new Font("Arial", 8, FontStyle.Bold);
            Font H2 = new Font("Arial", 8);
            Font H3 = new Font("Arial", 5, FontStyle.Bold);
            Font H4 = new Font("Arial", 5);
            Font th = new Font("Arial", 6);
            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;


            e.Graphics.DrawString("LEOS BAKERY & PROVISION STORE ", H1, Brushes.Black, new Point(x + 98, y), sf);
            y = y + 15;
            e.Graphics.DrawString("Thiruvamkulam Temple Road.\nMob 9744678214 ", H2, Brushes.Black, new Point(x + 98, y), sf);
            y = y + 40;
            e.Graphics.DrawString("Bill." + billid, H2, Brushes.Black, new Point(x, y));
            e.Graphics.DrawString("Date." + DateTime.Today.ToShortDateString(), H2, Brushes.Black, new Point(x + 110, y)); ;

            y = y + 30;
            e.Graphics.DrawString("S.No", H3, Brushes.Black, new Point(x, y));
            e.Graphics.DrawString("ITM", H3, Brushes.Black, new Point(x + 30, y));
            e.Graphics.DrawString("QTY", H3, Brushes.Black, new Point(x + 80, y));
            e.Graphics.DrawString("MRP", H3, Brushes.Black, new Point(x + 110, y));
            e.Graphics.DrawString("ORP", H3, Brushes.Black, new Point(x + 130, y));
            e.Graphics.DrawString("TOT.ORP", H3, Brushes.Black, new Point(x + 160, y));
            y = y + 10;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 5;
            //collect bill items
            billCmd = new OleDbCommand("SELECT * FROM BILLED_ITEMS WHERE BILL_ID=" + billid, conn);
            billAdapter = new OleDbDataAdapter();
            billTable = new DataTable();
            billAdapter.SelectCommand = billCmd;
            billAdapter.Fill(billTable);

            while (listIndex < billTable.Rows.Count)
            {
                DataRow row = billTable.Rows[listIndex];
                e.Graphics.DrawString((listIndex + 1).ToString(), H4, Brushes.Black, new Point(x, y));
                e.Graphics.DrawString(row["ITEM_NAME"].ToString(), H4, Brushes.Black, new Point(x + 30, y));
                e.Graphics.DrawString(row["BILL_QTY"].ToString(), H4, Brushes.Black, new Point(x + 80, y));
                e.Graphics.DrawString(((double)row["BILL_MRP"] / (double)row["BILL_QTY"]).ToString(), H4, Brushes.Black, new Point(x + 110, y));
                e.Graphics.DrawString(((double)row["BILL_SPRICE"] / (double)row["BILL_QTY"]).ToString(), H4, Brushes.Black, new Point(x + 130, y));
                e.Graphics.DrawString(row["BILL_SPRICE"].ToString(), H4, Brushes.Black, new Point(x + 160, y));
                y = y + 10;
                if (itemPerPage < 25)
                {
                    e.HasMorePages = false;
                    itemPerPage += 1;

                }
                else
                {
                    itemPerPage = 0;
                    listIndex += 1;
                    e.HasMorePages = true;
                    return;
                }
                listIndex += 1;


            }
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 10;
            e.Graphics.DrawString("Total MRP", H3, Brushes.Black, new Point(x, y));
            e.Graphics.DrawString(total_mrp.ToString(), H3, Brushes.Black, new Point(x + 40, y));
            e.Graphics.DrawString("Our Total Price", H3, Brushes.Black, new Point(x + 60, y));
            e.Graphics.DrawString(total_sprice.ToString(), H3, Brushes.Black, new Point(x + 115, y));

            y = y + 10;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 10;
            e.Graphics.DrawString("You save Rs." + (total_mrp - total_sprice).ToString() + " ,Thank you for shopping with us! ", th, Brushes.Black, new Point(x, y));
            y = y + 10;

            billCmd.Dispose();
            billAdapter.Dispose();


        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (itemList.Count > 0)
            {
                string date = dt_bill.Text;

                //Create a new bill entry

                try
                {
                    string query = "INSERT INTO BILLS(B_DATE,TOT_MRP,TOT_SPRICE) VALUES('" + date + "'," + total_mrp.ToString() + "," + total_sprice.ToString() + ")";
                    billCmd = new OleDbCommand(query, conn);
                    billAdapter = new OleDbDataAdapter();
                    billAdapter.InsertCommand = billCmd;
                    billAdapter.InsertCommand.ExecuteNonQuery();
                    billCmd.Dispose();
                    billAdapter.Dispose();


                    //Get the latest bill entry
                    query = "SELECT TOP 1 ID FROM BILLS ORDER BY ID DESC";
                    billCmd = new OleDbCommand(query, conn);
                    billAdapter = new OleDbDataAdapter();
                    billTable = new DataTable();
                    billAdapter.SelectCommand = billCmd;
                    billAdapter.Fill(billTable);

                    foreach (DataRow row in billTable.Rows)
                    {
                        billid = row["ID"].ToString();

                    }
                    billCmd.Dispose();
                    billAdapter.Dispose();
                    //billTable.Dispose();

                    //Add bill items to the bill items table

                    foreach (Items item in itemList)
                    {
                        query = "INSERT INTO BILLED_ITEMS(BILL_ID,ITEM_ID,ITEM_NAME,BILL_MRP,BILL_SPRICE,BILL_QTY) VALUES(" + billid + "," + item.id + ",'" + item.name + "'," + item.tot_mrp.ToString() + "," + item.tot_sprice.ToString() + "," + item.qty.ToString() + ")";
                        billCmd = new OleDbCommand(query, conn);
                        billAdapter = new OleDbDataAdapter();
                        billAdapter.InsertCommand = billCmd;
                        billAdapter.InsertCommand.ExecuteNonQuery();
                        billCmd.Dispose();
                        billAdapter.Dispose();



                    }
                    //update stocks
                    foreach (Items item in itemList)
                    {
                        query = "UPDATE PRODUCTS SET QTY=QTY-" + item.qty.ToString() + " WHERE ID=" + item.id + " AND P_NAME='" + item.name + "'";
                        productCmd = new OleDbCommand(query, conn);
                        productAdapter = new OleDbDataAdapter();
                        productAdapter.UpdateCommand = productCmd;
                        productAdapter.UpdateCommand.ExecuteNonQuery();
                        productAdapter.Dispose();
                        productCmd.Dispose();
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




                listIndex = 0;
                itemPerPage = 0;
                

                Bill.Print();

                refresh_product_combo();
            }
            else
            {
                MessageBox.Show("Noting to print");
            }



        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

            clear_billing();
            update_totals();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            clear_billing();
            update_totals();
            refresh_product_combo();
        }

        private void cmb_items_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmb_items_SelectionChangeCommitted(sender, e);
        }

        private void grdItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btn_delete_Click(sender, e);
            }
        }

        private void validate_number(object sender, KeyPressEventArgs e)
        {
            string txtsource = ((TextBox)sender).Name.ToString();

            if (txtsource == "txt_qty" || txtsource == "txt_mrp" || txtsource == "txt_sprice")
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == '.')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void frmBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_items_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_items.Text == "" || txt_mrp.Text == "" || txt_qty.Text == "" || txt_sprice.Text == "")
            {
                MessageBox.Show("Enter all Details");
                return;
            }
            grdItems.DataSource = "";
            var pid = txt_id.Text == "0" ? 0 : int.Parse(txt_id.Text);
            string pname = cmb_items.Text.ToUpper();
            double mrp = double.Parse(txt_mrp.Text);
            double sprice = double.Parse(txt_sprice.Text);
            double qty = double.Parse(txt_qty.Text);

            //QTY Validations
            string query = "SELECT QTY FROM PRODUCTS WHERE ID=" + pid + " AND P_NAME='" + pname + "'";

            try
            {
                productCmd = new OleDbCommand(query, conn);
                productAdapter = new OleDbDataAdapter();
                productTable = new DataTable();
                productAdapter.SelectCommand = productCmd;
                productAdapter.Fill(productTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (productTable.Rows.Count > 0)
            {
                int sqty = 0;
                foreach (DataRow row in productTable.Rows)
                {
                    sqty = int.Parse(row["QTY"].ToString());
                }

                if (qty > sqty)
                {
                    MessageBox.Show("You have entered a billing QTY which is Greater than The QTY in Stock BILL_QTY:" + qty.ToString() + "STOCK_QTY:" + sqty.ToString());
                    txt_id.Text = "0";
                    txt_mrp.Text = "";
                    txt_sprice.Text = "";
                    txt_qty.Text = "";
                    cmb_items.Focus();
                    return;

                }
            }
            productAdapter.Dispose();
            productCmd.Dispose();
            productTable.Dispose();

            itemList.Add(new Items() { id = pid, name = pname, qty = qty, mrp = mrp, sprice = sprice, tot_mrp = qty * mrp, tot_sprice = qty * sprice });
            grdItems.DataSource = itemList;
            update_totals();
            txt_id.Text = "0";
            txt_mrp.Text = "";
            txt_sprice.Text = "";
            txt_qty.Text = "";
            cmb_items.Focus();
        }




        private void frmBill_Load(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            conn = new OleDbConnection(connString);
            try
            {
                conn.Open();

                refresh_product_combo();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void refresh_product_combo()
        {
            dt_bill.Value = DateTime.Now;
            cmb_items.SelectedIndexChanged -= cmb_items_SelectedIndexChanged;
            try
            {
                productCmd = new OleDbCommand("SELECT ID,P_NAME FROM PRODUCTS WHERE QTY>0", conn);
                productAdapter = new OleDbDataAdapter();
                productAdapter.SelectCommand = productCmd;
                productTable = new DataTable();
                productAdapter.Fill(productTable);
                productCmd.Dispose();
                productAdapter.Dispose();
                cmb_items.DataSource = productTable;
                cmb_items.DisplayMember = "P_NAME";
                cmb_items.ValueMember = "ID";
                cmb_items.SelectedIndex = -1;
                cmb_items.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_items.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmb_items.SelectedIndexChanged += cmb_items_SelectedIndexChanged;
        }




    }

}