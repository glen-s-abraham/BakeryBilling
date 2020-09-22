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
        OleDbConnection conn;
        OleDbCommand billCmd,productCmd;
        OleDbDataAdapter billAdapter, productAdapter;

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

        private void cmb_items_TextChanged(object sender, EventArgs e)
        {
           
        }

        DataTable billTable, productTable;


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
