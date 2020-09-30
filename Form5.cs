using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Configuration;

namespace BakeryBilling
{
    public partial class Form5 : Form
    {
        string connString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\DB\\BAKERY.accdb";
        OleDbConnection conn;
        string query1;
        DataTable print;
        DateTime end_date = DateTime.Now;
        DateTime start_date;
        public void grid_view(string query)
        {
            
            OleDbConnection conn = new OleDbConnection(connString);
            //conn.Open();
            OleDbCommand grid_cmd = new OleDbCommand(query, conn);
            conn.Open();
            OleDbDataAdapter grid_adapter = new OleDbDataAdapter(grid_cmd);
            DataTable ds = new DataTable();
            print = new DataTable();
           // conn.Open();
            grid_adapter.Fill(ds);
            grid_adapter.Fill(print);
            
            dataGridView1.DataSource = ds;
            conn.Close();
            total();

        }

        public void report_backward(DateTime start_date,DateTime end_date)
        {
            if (comboBox1.SelectedIndex == 1)
            {

                button1.Visible = true;
                button2.Visible = true;

                //DateTime end_date = DateTime.Now;
                start_date = end_date.AddDays(-7);
                query1 = "select item_name AS ITEM_NAMES , B_DATE AS BILL_DATE , SUM(BILL_QTY) AS QUANTITY FROM BILLS INNER JOIN BILLED_ITEMS ON BILLS.ID=BILLED_ITEMS.BILL_ID WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY ITEM_NAME,B_DATE ";
                grid_view(query1);

            }
            if (comboBox1.SelectedIndex == 2)
            {
                button1.Visible = true;
                button2.Visible = true;
               // DateTime end_date = DateTime.Now;
                start_date = end_date.AddDays(-30);
                query1 = "select item_name AS ITEM_NAMES , B_DATE AS BILL_DATE , SUM(BILL_QTY) AS QUANTITY FROM BILLS INNER JOIN BILLED_ITEMS ON BILLS.ID=BILLED_ITEMS.BILL_ID WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY ITEM_NAME,B_DATE ";

                grid_view(query1);
            }
        }

        public void report_forward(DateTime start_date, DateTime end_date)
        {
            if (comboBox1.SelectedIndex == 1)
            {

                button1.Visible = true;
                button2.Visible = true;

                //DateTime end_date = DateTime.Now;
                end_date = start_date.AddDays(7);
                query1 = "select item_name AS ITEM_NAMES , B_DATE AS BILL_DATE , SUM(BILL_QTY) AS QUANTITY FROM BILLS INNER JOIN BILLED_ITEMS ON BILLS.ID=BILLED_ITEMS.BILL_ID WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY ITEM_NAME,B_DATE ";
                grid_view(query1);

            }
            if (comboBox1.SelectedIndex == 2)
            {
                button1.Visible = true;
                button2.Visible = true;
                // DateTime end_date = DateTime.Now;
                end_date = start_date.AddDays(30);
                query1 = "select item_name AS ITEM_NAMES , B_DATE AS BILL_DATE , SUM(BILL_QTY) AS QUANTITY FROM BILLS INNER JOIN BILLED_ITEMS ON BILLS.ID=BILLED_ITEMS.BILL_ID WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY ITEM_NAME,B_DATE ";

                grid_view(query1);
            }
        }

        public void total()
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            textBox1.Text = sum.ToString();
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
            e.Graphics.DrawString("Bakery Name", H1, Brushes.Black, new Point(x + 280, y));
            y = y + 50;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 10;
            e.Graphics.DrawString("Item", H2, Brushes.Black, new Point(x, y));
            e.Graphics.DrawString("QTY", H2, Brushes.Black, new Point(x + 100, y));
            e.Graphics.DrawString("MRP", H2, Brushes.Black, new Point(x + 200, y));
            e.Graphics.DrawString("OurPrice", H2, Brushes.Black, new Point(x + 300, y));
            e.Graphics.DrawString("Tot MRP", H2, Brushes.Black, new Point(x + 450, y));
            e.Graphics.DrawString("Tot Our Price", H2, Brushes.Black, new Point(x + 620, y));
            y = y + 30;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 20;
            foreach(DataRow rs in print.Rows )
            {

                e.Graphics.DrawString(rs[listIndex].ToString(), H3, Brushes.Black, new Point(x, y));
                e.Graphics.DrawString(rs[listIndex].ToString(), H3, Brushes.Black, new Point(x + 110, y));
                e.Graphics.DrawString(rs[listIndex].ToString(), H3, Brushes.Black, new Point(x + 210, y));
                e.Graphics.DrawString(rs[listIndex].ToString(), H3, Brushes.Black, new Point(x + 340, y));
                e.Graphics.DrawString(rs[listIndex].ToString(), H3, Brushes.Black, new Point(x + 480, y));
                e.Graphics.DrawString(rs[listIndex].ToString(), H3, Brushes.Black, new Point(x + 650, y));
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
           

        }


        public Form5()
        {
            InitializeComponent();
           
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime end_date = DateTime.Now;


            if (comboBox1.SelectedIndex==3)
            {
                groupBox1.Enabled = true;
                groupBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                
            }

            if (comboBox1.SelectedIndex == 1)
            {

                button1.Visible = true;
                button2.Visible = true;

               // DateTime end_date = DateTime.Now;
                start_date = end_date.AddDays(-7);
                query1 = "select item_name AS ITEM_NAMES , B_DATE AS BILL_DATE , SUM(BILL_QTY) AS QUANTITY FROM BILLS INNER JOIN BILLED_ITEMS ON BILLS.ID=BILLED_ITEMS.BILL_ID WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY ITEM_NAME,B_DATE ";
                grid_view(query1);

            }
            if (comboBox1.SelectedIndex == 2)
            {
                button1.Visible = true;
                button2.Visible = true;
               // DateTime end_date = DateTime.Now;
                start_date = end_date.AddDays(-30);
                query1 = "select item_name AS ITEM_NAMES , B_DATE AS BILL_DATE , SUM(BILL_QTY) AS QUANTITY FROM BILLS INNER JOIN BILLED_ITEMS ON BILLS.ID=BILLED_ITEMS.BILL_ID WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY ITEM_NAME,B_DATE ";

                grid_view(query1);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
             start_date=end_date;

            report_forward(start_date, end_date);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("SELECT ");
            comboBox1.Items.Add("WEEKLY");
            comboBox1.Items.Add("MONTHLY");
            comboBox1.Items.Add("PERIOD");
            comboBox1.SelectedIndex = 0;
            groupBox1.Visible = false;
            groupBox1.Enabled = false;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            
            printPreview.Show();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)

            {

                

            }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime end_date = dateTimePicker2.Value;
            DateTime start_date = dateTimePicker1.Value;
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                query1 = "select item_name AS ITEM_NAMES , B_DATE AS BILL_DATE , SUM(BILL_QTY) AS QUANTITY FROM BILLS INNER JOIN BILLED_ITEMS ON BILLS.ID=BILLED_ITEMS.BILL_ID WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY ITEM_NAME,B_DATE ";
                grid_view(query1);
            }
            else
            {
                MessageBox.Show("invalid Date");
            }
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
               

        }

        private void button1_Click(object sender, EventArgs e)
        {
            end_date = start_date;

            report_backward(start_date, end_date);

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         
        }
    }
}
