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
        class Items
        {
            public int id { get; set; }
            public string name { get; set; }
            public double qty { get; set; }
            public double mrp { get; set; }
            public double sprice { get; set; }
            public double tot_mrp { get; set; }
            public double tot_sprice { get; set; }
        }
        List<Items> itemList = new List<Items>();
        OleDbConnection conn;
        OleDbCommand billCmd,productCmd;
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
            lbl_totalmrp.Text = String.Format("{0:0.00}",total_mrp); 
            lbl_ourtotal.Text = String.Format("{0:0.00}", total_sprice);
        }

        private void cmb_items_SelectionChangeCommitted(object sender, EventArgs e)
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
                if (localProductTable.Rows.Count>0)
                {
                    foreach(DataRow row in localProductTable.Rows)
                    {
                        txt_id.Text= row["ID"].ToString();
                        txt_mrp.Text = row["MRP"].ToString();
                        txt_sprice.Text = row["Sprice"].ToString();
                    }
                    
                }
                productAdapter.Dispose();
                productCmd.Dispose();
                localProductTable.Dispose();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch(Exception ex)
            {
                MessageBox.Show("No Selections Made");
            }
            



        }

        int listIndex = 0;
        int itemPerPage = 0;
        private void Bill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            int paperWidth = 1122;
            int x = 30;
            int y = 10;
            Pen pen = new Pen(Brushes.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            
            int centerX = (int)(x + Math.Abs(paperWidth * 0.5));
            
            Font H1 = new Font("Arial", 28);
            Font H2 = new Font("Arial", 16);
            Font H3 = new Font("Arial", 12);
            e.Graphics.DrawString("Bakery Name",H1,Brushes.Black,new Point(x+280,y));
            y = y + 50;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 10;
            e.Graphics.DrawString("Item", H2, Brushes.Black, new Point(x, y));
            e.Graphics.DrawString("QTY", H2, Brushes.Black, new Point(x+100, y));
            e.Graphics.DrawString("MRP", H2, Brushes.Black, new Point(x + 200, y));
            e.Graphics.DrawString("OurPrice", H2, Brushes.Black, new Point(x + 300, y));
            e.Graphics.DrawString("Tot MRP", H2, Brushes.Black, new Point(x + 450, y));
            e.Graphics.DrawString("Tot Our Price", H2, Brushes.Black, new Point(x + 620, y));
            y = y + 30;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 20;
            while(listIndex<itemList.Count)
            {
               
                e.Graphics.DrawString(itemList[listIndex].name, H3, Brushes.Black, new Point(x, y));
                e.Graphics.DrawString(itemList[listIndex].qty.ToString(), H3, Brushes.Black, new Point(x + 110, y));
                e.Graphics.DrawString(itemList[listIndex].mrp.ToString(), H3, Brushes.Black, new Point(x + 210, y));
                e.Graphics.DrawString(itemList[listIndex].sprice.ToString(), H3, Brushes.Black, new Point(x + 340, y));
                e.Graphics.DrawString(itemList[listIndex].tot_mrp.ToString(), H3, Brushes.Black, new Point(x + 480, y));
                e.Graphics.DrawString(itemList[listIndex].tot_sprice.ToString(), H3, Brushes.Black, new Point(x + 650, y));
                y = y + 30;
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
            y = y + 20;
            e.Graphics.DrawString("Total MRP", H2, Brushes.Black, new Point(x, y));
            e.Graphics.DrawString(total_mrp.ToString(), H2, Brushes.Black, new Point(x+120, y));
            e.Graphics.DrawString("Our Total Price", H2, Brushes.Black, new Point(x+200, y));
            e.Graphics.DrawString(total_sprice.ToString(), H2, Brushes.Black, new Point(x + 350, y));
            y = y + 30;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 20;
            e.Graphics.DrawString("You save Rs."+(total_mrp-total_sprice).ToString()+" ,Thank you for shopping with us!", H2, Brushes.Black, new Point(x+150, y));
            

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            
            string date = dt_bill.Text;
            string billid="0";
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
                
                foreach(DataRow row in billTable.Rows)
                {
                    billid = row["ID"].ToString();
                }
                billCmd.Dispose();
                billAdapter.Dispose();
                billTable.Dispose();

                //Add bill items to the bill items table
               
                foreach(Items item in itemList)
                {
                    query = "INSERT INTO BILLED_ITEMS(BILL_ID,ITEM_NAME,BILL_MRP,BILL_SPRICE,BILL_QTY) VALUES(" + billid + ",'" + item.name + "'," + item.tot_mrp.ToString() + "," + item.tot_sprice.ToString() + "," + item.qty.ToString() + ")";
                    billCmd = new OleDbCommand(query, conn);
                    billAdapter = new OleDbDataAdapter();
                    billAdapter.InsertCommand = billCmd;
                    billAdapter.InsertCommand.ExecuteNonQuery();
                    billCmd.Dispose();
                    billAdapter.Dispose();
                    
            

                }
                //update stocks
                foreach(Items item in itemList)
                {
                    query = "UPDATE PRODUCTS SET QTY=QTY-"+item.qty.ToString()+" WHERE ID="+item.id+" AND P_NAME='"+item.name+"'";
                    productCmd = new OleDbCommand(query, conn);
                    productAdapter = new OleDbDataAdapter();
                    productAdapter.UpdateCommand = productCmd;
                    productAdapter.UpdateCommand.ExecuteNonQuery();
                    productAdapter.Dispose();
                    productCmd.Dispose();
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


            
            listIndex = 0;
            itemPerPage = 0;
            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = Bill;
            printPreview.Show();

            //Bill.Print();
            
            refresh_product_combo();
            
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

            clear_billing();
            update_totals();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh_product_combo();
        }

        private void cmb_items_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_items.Text == "" || txt_mrp.Text == "" || txt_qty.Text == "" || txt_sprice.Text == ""){
                MessageBox.Show("Enter all Details");
                return;
            }
            grdItems.DataSource = "";
            var pid = txt_id.Text == "0" ? 0 : int.Parse(txt_id.Text);
            string pname = cmb_items.Text.ToUpper();
            double mrp = double.Parse(txt_mrp.Text);
            double sprice = double.Parse(txt_sprice.Text);
            double qty = double.Parse(txt_qty.Text);
            itemList.Add(new Items() { id = pid, name = pname, qty = qty, mrp=mrp,sprice=sprice,tot_mrp = qty*mrp, tot_sprice = qty*sprice });
            grdItems.DataSource = itemList;
            update_totals();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void refresh_product_combo()
        {
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
