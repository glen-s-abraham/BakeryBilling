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
    public partial class Form3 : Form
    {
        int flag = 0;
        
        OleDbConnection conn;
        OleDbDataAdapter productadapter;
        OleDbCommand cmd;
        DataTable producttable;
        public Form3()
        {
            InitializeComponent();
        }

        private void pname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT CUR_EXP_DATE,MRP,SPRICE,CPRICE,QTY FROM PRODUCTS WHERE P_NAME = '" + pname.Text + "'";
                cmd = new OleDbCommand(query, conn);
                productadapter = new OleDbDataAdapter();
                productadapter.SelectCommand = cmd;
                productadapter.SelectCommand.ExecuteNonQuery();
                OleDbDataReader productreader = cmd.ExecuteReader();

                while(productreader.Read())
                {
                    
                    mrp.Text = productreader["MRP"].ToString();
                    cprice.Text = productreader["CPRICE"].ToString();
                    sprice.Text = productreader["SPRICE"].ToString();
                    expdate.Text = productreader["CUR_EXP_DATE"].ToString();
                    qty.Text = productreader["QTY"].ToString();

                }




            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            flag = 1;
            add.BackColor = Color.FromArgb(229, 32, 88);
            update.BackColor = Color.FromArgb(151, 196, 232);
            delete.BackColor = Color.FromArgb(151, 196, 232);
            purchase.BackColor = Color.FromArgb(151, 196, 232);
            state_manage();
            

        }

        private void update_Click(object sender, EventArgs e)
        {
            flag = 2;
            add.BackColor = Color.FromArgb(151, 196, 232);
            update.BackColor = Color.FromArgb(229, 32, 88);
            delete.BackColor = Color.FromArgb(151, 196, 232);
            purchase.BackColor = Color.FromArgb(151, 196, 232);
            state_manage();
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            flag = 3;
            update.BackColor = Color.FromArgb(151, 196, 232);
            add.BackColor = Color.FromArgb(151, 196, 232);
            delete.BackColor = Color.FromArgb(229, 32, 88);
            purchase.BackColor = Color.FromArgb(151, 196, 232);              
            qty.Enabled = false;
            cprice.Enabled = false;
            sprice.Enabled = false;
            mrp.Enabled = false;
            expdate.Enabled = false;
        }
        private void purchase_Click(object sender, EventArgs e)
        {
            flag = 4;
            add.BackColor = Color.FromArgb(151, 196, 232);
            update.BackColor = Color.FromArgb(151, 196, 232);
            delete.BackColor = Color.FromArgb(151, 196, 232);
            purchase.BackColor = Color.FromArgb(229, 32, 88);
            state_manage1();
            qty.Enabled = true;           
            expdate.Enabled = true;

        }
        private void state_manage()
        {
            ok.Enabled = true;
            reset.Enabled = true;
            pname.Enabled = true;
            qty.Enabled = true;
            cprice.Enabled = true;
            sprice.Enabled = true;
            mrp.Enabled = true;
            expdate.Enabled = true;
        }
        private void state_manage1()
        {
            ok.Enabled = true;
            reset.Enabled = true;
            pname.Enabled = true;
            cprice.Enabled = false;
            sprice.Enabled = false;
            mrp.Enabled = false;
            
        }
        private void refresh()
        {
            pname.Text = "";
            cprice.Text = "";
            mrp.Text = "";
            sprice.Text = "";
            expdate.Text = "";
            qty.Text = "";
        }
        private void grid_view()
        {
            try
            { DataSet productset = new DataSet();
                string query = "SELECT * FROM PRODUCTS ORDER BY(ID) DESC";
                cmd = new OleDbCommand(query, conn);
                productadapter = new OleDbDataAdapter();
                productadapter.SelectCommand = cmd;
                productadapter.SelectCommand.ExecuteNonQuery();
                producttable = new DataTable();
                productadapter.Fill(productset);
                producttable = new DataTable();
                producttable.Columns.Add("Sl.No", typeof(int));
                producttable.Columns.Add("Product", typeof(string));
                producttable.Columns.Add("MRP", typeof(double));
                producttable.Columns.Add("SRP", typeof(int));
                producttable.Columns.Add("CRP", typeof(int));
                producttable.Columns.Add("Quantity", typeof(int));
                producttable.Columns.Add("Expiry", typeof(DateTime));
                int i = 1;

                foreach(DataTable table in productset.Tables )
                {
                    foreach(DataRow dr in table.Rows)
                    {
                        producttable.Rows.Add(i, dr["P_NAME"], dr["QTY"], dr["MRP"], dr["SPRICE"], dr["CPRICE"], dr["CUR_EXP_DATE"]);
                        i++;
                    }
                }
                product_grid.DataSource = producttable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void validate_prices(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void pname_combo() //product name to combo box 
        {
            try
            {
                string query = "SELECT ID,P_NAME FROM PRODUCTS ORDER BY(ID) DESC";
                cmd = new OleDbCommand(query, conn);
                productadapter = new OleDbDataAdapter();
                productadapter.SelectCommand = cmd;
                productadapter.SelectCommand.ExecuteNonQuery();
                DataSet products = new DataSet();
                productadapter.Fill(products);
                pname.DataSource = products.Tables[0];
                pname.ValueMember = "ID";
                pname.DisplayMember = "P_NAME";
                pname.AutoCompleteSource = AutoCompleteSource.ListItems;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cmd.Dispose();
            productadapter.Dispose();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            ok.Enabled = false;
            reset.Enabled = false;
            pname.Enabled = false;
            qty.Enabled = false;
            cprice.Enabled = false;
            sprice.Enabled = false;
            mrp.Enabled = false;
            expdate.Enabled = false;
            
            var connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            conn = new OleDbConnection(connString);
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            pname_combo();
            grid_view();
        }

        private void ok_Click(object sender, EventArgs e)
        { int alert = 1;
            DialogResult result;
            try {
                string query;
               productadapter = new OleDbDataAdapter();



                if (flag == 1)
                {
                    if (pname.Text != "" && mrp.Text != "" && cprice.Text != "" && sprice.Text != "" && qty.Text != "" && expdate.Text != "")
                    {
                        result = MessageBox.Show("Are you sure want to add ?", "", MessageBoxButtons.YesNo);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            query = "SELECT * FROM PRODUCTS WHERE P_NAME ='" + pname.Text + "'";
                            cmd = new OleDbCommand(query, conn);
                            productadapter.SelectCommand = cmd;
                            productadapter.SelectCommand.ExecuteNonQuery();
                            OleDbDataReader productreader = cmd.ExecuteReader();

                            while (productreader.Read())
                            {
                                if (productreader.HasRows == true)
                                {
                                    alert = 0;
                                }
                            }
                            if (alert == 1)
                            {


                                query = "INSERT INTO PRODUCTS(P_NAME,CUR_EXP_DATE,OLD_EXP_DATE,MRP,SPRICE,CPRICE,QTY)VALUES('" + pname.Text.ToUpper() + "','" + DateTime.Parse(expdate.Text) + "','" + DateTime.Parse(expdate.Text) + "','" + Double.Parse(mrp.Text) + "','" + Double.Parse(sprice.Text) + "','" + Double.Parse(cprice.Text) + "','" + Double.Parse(qty.Text) + "')";
                                cmd = new OleDbCommand(query, conn);
                               
                                productadapter.InsertCommand = cmd;
                                productadapter.InsertCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("ITEM ALREADY EXISTS");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("FILL PRODUCT DATA.");
                    }

                                                         
                }
                else if(flag == 2)
                {
                    if (pname.Text != "" && mrp.Text != "" && cprice.Text != "" && sprice.Text != "" && qty.Text != "" && expdate.Text != "")
                    {
                        result = MessageBox.Show("Are you sure want to update ?", "", MessageBoxButtons.YesNo);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            query = "UPDATE PRODUCTS SET OLD_EXP_DATE = CUR_EXP_DATE WHERE P_NAME = '" + pname.Text + "'";
                            cmd = new OleDbCommand(query, conn);
                            productadapter.UpdateCommand = cmd;
                            productadapter.UpdateCommand.ExecuteNonQuery();
                            query = "UPDATE PRODUCTS SET CUR_EXP_DATE = '" + DateTime.Parse(expdate.Text) + "',MRP = '" + Double.Parse(mrp.Text) + "',SPRICE ='" + sprice.Text + "',CPRICE ='" + Double.Parse(cprice.Text) + "',QTY= '" + Double.Parse(qty.Text) + "'  WHERE P_NAME = '" + pname.Text + "'";
                            cmd = new OleDbCommand(query, conn);
                            productadapter.UpdateCommand = cmd;
                            productadapter.UpdateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("FILL PRODUCT DATA.");
                    }

                }
                else if(flag ==3)
                {
                    if (pname.Text != "" && mrp.Text != "" && cprice.Text != "" && sprice.Text != "" && qty.Text != "" && expdate.Text != "")
                    {
                        result = MessageBox.Show("Are you sure want to delete ?", "", MessageBoxButtons.YesNo);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            query = "DELETE FROM PRODUCTS WHERE P_NAME = '" + pname.Text + "'";
                            cmd = new OleDbCommand(query, conn);
                            productadapter.DeleteCommand = cmd;
                            productadapter.DeleteCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVALID DATA.");
                    }



                }
                else if(flag == 4)
                {
                    if (pname.Text != "" && mrp.Text != "" && cprice.Text != "" && sprice.Text != "" && qty.Text != "" && expdate.Text != "")
                    {
                        result = MessageBox.Show("Confirm Purchase ?", "", MessageBoxButtons.YesNo);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            query = "UPDATE PRODUCTS SET OLD_EXP_DATE = CUR_EXP_DATE WHERE P_NAME = '" + pname.Text + "'";
                            cmd = new OleDbCommand(query, conn);
                            productadapter.UpdateCommand = cmd;
                            productadapter.UpdateCommand.ExecuteNonQuery();
                            query = "UPDATE PRODUCTS SET CUR_EXP_DATE = '" + DateTime.Parse(expdate.Text) + "',QTY=QTY + '" + Double.Parse(qty.Text) + "'  WHERE P_NAME = '" + pname.Text + "'";
                            cmd = new OleDbCommand(query, conn);
                            productadapter.UpdateCommand = cmd;
                            productadapter.UpdateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("FILL PRODUCT DATA.");
                    }

                }
                refresh();
                pname_combo();
                grid_view();
                cmd.Dispose();
                productadapter.Dispose();
            }

            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || char.IsDigit(e.KeyChar) || (e.KeyChar == '_'));
        }

        private void mrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate_prices(sender, e);
        }

        private void cprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate_prices(sender, e);
        }

        private void sprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void sprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate_prices(sender, e);
        }

        private void qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }
    }
}
