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
        string strSQL;
        OleDbConnection conn;
        // var connString = ConfigurationManager.ConnectionStrings["Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|BAKERY.accdb"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            flag = 1;
            add.BackColor = Color.FromArgb(229, 32, 88);
            update.BackColor = Color.FromArgb(151, 196, 232);
            delete.BackColor = Color.FromArgb(151, 196, 232);
            ok.Enabled = true;
            reset.Enabled = true;
            pname.Enabled = true;
            qty.Enabled = true;
            cprice.Enabled = true;
            sprice.Enabled = true;
            mrp.Enabled = true;
            expdate.Enabled = true;

        }

        private void update_Click(object sender, EventArgs e)
        {
            flag = 2;
            add.BackColor = Color.FromArgb(151, 196, 232);
            update.BackColor = Color.FromArgb(229, 32, 88);
            delete.BackColor = Color.FromArgb(151, 196, 232);
            ok.Enabled = true;
            reset.Enabled = true;
            pname.Enabled = true;
            qty.Enabled = true;
            cprice.Enabled = true;
            sprice.Enabled = true;
            mrp.Enabled = true;
            expdate.Enabled = true;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            flag = 3;
            update.BackColor = Color.FromArgb(151, 196, 232);
            add.BackColor = Color.FromArgb(151, 196, 232);
            delete.BackColor = Color.FromArgb(229, 32, 88);
            ok.Enabled = true;
            reset.Enabled = true;
            pname.Enabled = true;
            qty.Enabled = false;
            cprice.Enabled = false;
            sprice.Enabled = false;
            mrp.Enabled = false;
            expdate.Enabled = false;
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


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();

              
                
                
                if (flag == 1)
                {
                    string query = "INSERT INTO PRODUCTS(P_NAME,CUR_EXP_DATE,MRP,SPRICE,CPRICE,QTY)VALUES('" + pname.Text + "','" + DateTime.Parse(expdate.Text) + "','" + Double.Parse(mrp.Text) + "','" + Double.Parse(sprice.Text)+"','" + Double.Parse(cprice.Text) + "','" + Double.Parse(qty.Text) + "')";
                    OleDbCommand command =new OleDbCommand(query, conn);
                    command.ExecuteReader();

                    conn.Close();
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
