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

        private void btn_cancel_Click(object sender, EventArgs e)
        {

            clear_billing();
            update_totals();
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
                productCmd = new OleDbCommand("SELECT ID,P_NAME FROM PRODUCTS",conn);
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
