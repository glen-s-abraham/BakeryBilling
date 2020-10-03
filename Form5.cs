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
        //string connString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\DB\\BAKERY.accdb";
        string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        //OleDbConnection conn;

        string query1;
        DataTable print;
        DateTime end_date=DateTime.Now;
        DateTime start_date;
        int flag = 0;
        public void grid_view(string query)
        {
            dateTimePicker1.Value = start_date;
            dateTimePicker2.Value = end_date;
            if(flag==1)
            {
                int id = 0;
                query = "SELECT ITEM_ID AS PRODUCT_ID,ITEM_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QTY,SUM(BILL_SPRICE) AS TOTAL_AMOUNT  FROM BILLED_ITEMS INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID WHERE B_DATE  >  #" + start_date + "#  AND B_DATE < #" + end_date + "# AND  ITEM_ID=" + id + "  GROUP BY ITEM_NAME,ITEM_ID";

            }

            //conn.Open();
            OleDbConnection conn = new OleDbConnection(connString);
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
            //other();
            total();

        }
        public void other ()
        {
            OleDbConnection conn = new OleDbConnection(connString);
            string q2 = "SELECT ITEM_ID,ITEM_NAME,SUM(BILL_QTY),SUM(BILL_SPRICE) FROM BILLED_ITEMS INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID  GROUP BY ITEM_NAME,ITEM_ID";
            //WHERE B_DATE  >  #" + start_date + "#  AND B_DATE < #" + end_date + "# AND  ITEM_ID=" + id +"
            OleDbCommand cm_other = new OleDbCommand(q2,conn);
            conn.Open();
            OleDbDataAdapter ad_other = new OleDbDataAdapter(cm_other);
            DataTable ds_other = new DataTable();
            ad_other.Fill(ds_other);
            print.Merge(ds_other);
            dataGridView1.DataSource = print;
            conn.Close();

        }
        public void report_backward(DateTime end_date)
        {
            if (comboBox1.SelectedIndex == 2)
            {

                button1.Visible = true;
                button2.Visible = true;

                //DateTime end_date = DateTime.Now;
                start_date = end_date.AddDays(-7);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";
                grid_view(query1);

            }
            if (comboBox1.SelectedIndex == 3)
            {
                button1.Visible = true;
                button2.Visible = true;
               // DateTime end_date = DateTime.Now;
                start_date = end_date.AddDays(-30);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";

                grid_view(query1);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                button1.Visible = true;
                button2.Visible = true;
                // DateTime end_date = DateTime.Now;
                start_date = end_date.AddDays(-1);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";
                grid_view(query1);
            }
        }

        public void report_forward(DateTime start_date)
        {
            if (comboBox1.SelectedIndex == 2)
            {

                button1.Visible = true;
                button2.Visible = true;

                //DateTime end_date = DateTime.Now;
                end_date = start_date.AddDays(7);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";
                grid_view(query1);

            }
            if (comboBox1.SelectedIndex == 3)
            {
                button1.Visible = true;
                button2.Visible = true;
                // DateTime end_date = DateTime.Now;
                end_date = start_date.AddDays(30);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";
                grid_view(query1);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                button1.Visible = true;
                button2.Visible = true;
                // DateTime end_date = DateTime.Now;
                end_date = start_date.AddDays(1);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";
                grid_view(query1);
            }
        }

        public void total()
        {
            int sum = 0;
            double mrp = 0.0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (flag == 1)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    mrp += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                }
                if (flag==0)
                {

                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    mrp += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);

                }
            }
            textBox1.Text = sum.ToString();
            textBox2.Text = mrp.ToString();
        }

        int listIndex = 0;
        int itemPerPage = 0;
       
           

        


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


            if (comboBox1.SelectedIndex==4)
            {
                groupBox1.Enabled = true;
                groupBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = true;
                
            }

            if (comboBox1.SelectedIndex == 2)
            {

                button1.Visible = true;
                button2.Visible = true;

                end_date = DateTime.Now;
                start_date = end_date.AddDays(-7);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";
                grid_view(query1);

            }
            if (comboBox1.SelectedIndex == 3)
            {
                button1.Visible = true;
                button2.Visible = true;
                 end_date = DateTime.Now;
                start_date = end_date.AddDays(-30);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";
                grid_view(query1);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                button1.Visible = true;
                button2.Visible = true;
                 end_date = DateTime.Now;
                start_date = end_date.AddDays(-1);
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID ";
                grid_view(query1);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
             start_date=end_date;

            report_forward(start_date);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("SELECT ");
            comboBox1.Items.Add("DAY");
            comboBox1.Items.Add("WEEKLY");
            comboBox1.Items.Add("MONTHLY");
            comboBox1.Items.Add("PERIOD");
            comboBox2.Items.Add("ON STOCK");
            comboBox2.Items.Add("OFF STOCK");
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            groupBox1.Visible = true;
            groupBox1.Enabled = false;
            button4.Visible = false;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {

            listIndex = 0;
            itemPerPage = 0;
            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = printDocument1;
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
                query1 = "SELECT PRODUCTS.ID AS PRODUCT_ID,P_NAME AS PRODUCT_NAME,SUM(BILL_QTY) AS SOLD_QUANTITY,SUM(QTY) AS ON_STOCK,SUM(SPRICE) AS SRP FROM ((PRODUCTS INNER JOIN BILLED_ITEMS ON PRODUCTS.ID=BILLED_ITEMS.ITEM_ID) INNER JOIN BILLS ON BILLED_ITEMS.BILL_ID=BILLS.ID)WHERE B_DATE >  #" + start_date + "#  AND B_DATE < #" + end_date + "# GROUP BY PRODUCTS.P_NAME,PRODUCTS.ID  ";
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

            report_backward( end_date);

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         
        }

        private void printDocument1_PrintPage_2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString(comboBox2.Text.ToString()+"  "+ comboBox1.Text.ToString() +" REPORT", H2, Brushes.Black, new Point(x, y));
            e.Graphics.DrawString( "DATE :" + DateTime.Now, H2, Brushes.Black, new Point(x+400, y));
            y = y + 30;
            e.Graphics.DrawString(start_date.ToString() +"- "+ end_date.ToString(), H2, Brushes.Black, new Point(x + 30, y));
            y = y + 50;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 10;
            e.Graphics.DrawString("SI No.", H2, Brushes.Black, new Point(x-10, y));
            e.Graphics.DrawString("ITEM ID", H2, Brushes.Black, new Point(x+70, y));
            e.Graphics.DrawString("ITEM NAME", H2, Brushes.Black, new Point(x + 190, y));
            e.Graphics.DrawString("SOLD QTY", H2, Brushes.Black, new Point(x + 390, y));
            e.Graphics.DrawString("ON STOCK", H2, Brushes.Black, new Point(x + 550, y));
            e.Graphics.DrawString("SRP", H2, Brushes.Black, new Point(x + 700, y));

            y = y + 30;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 20;
            if (flag == 0)
            {


                for (int i = 0; i < print.Rows.Count; i++)
                {
                    x = 30;
                    for (int j = 0; j < print.Columns.Count; j++)
                    {

                        //object o = print.Rows[i].ItemArray[j];
                        if (j == 0)
                        {
                            e.Graphics.DrawString((i + 1).ToString() + "              " + print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x, y));
                            //MessageBox.Show(y.ToString());
                        }
                        else if (j != 4)
                        {
                            //MessageBox.Show(x.ToString());
                            e.Graphics.DrawString(print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x, y));


                        }
                        else
                        {
                            e.Graphics.DrawString(print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x - 80, y));

                            //e.Graphics.DrawString( print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x + 420, y));
                            //e.Graphics.DrawString(print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x+550, y));
                            //e.Graphics.DrawString(print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x+700, y));

                        }

                        x = x + 200;
                    }

                    if (i < 25)
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

                    y = y + 30;
                    x = 30;

                }
            }
            else if (flag==1)
            {
                for (int i = 0; i < print.Rows.Count; i++)
                {
                    x = 30;
                    for (int j = 0; j < print.Columns.Count; j++)
                    {

                        //object o = print.Rows[i].ItemArray[j];
                        if (j == 0)
                        {
                            e.Graphics.DrawString((i + 1).ToString() + "              " + print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x, y));
                            //MessageBox.Show(y.ToString());
                        }
                        else if (j ==3)
                        {
                            
                            e.Graphics.DrawString("0", H3, Brushes.Black, new Point(x , y));
                            e.Graphics.DrawString(print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x+110, y));


                        }
                        else
                        {
                            e.Graphics.DrawString(print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x , y));

                            //e.Graphics.DrawString( print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x + 420, y));
                            //e.Graphics.DrawString(print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x+550, y));
                            //e.Graphics.DrawString(print.Rows[i].ItemArray[j].ToString(), H3, Brushes.Black, new Point(x+700, y));

                        }

                        x = x + 200;
                    }

                    if (i < 25)
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

                    y = y + 30;
                    x = 30;

                }
            }
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 20;
            e.Graphics.DrawString("Total Quantity", H2, Brushes.Black, new Point(x, y));
            e.Graphics.DrawString(textBox1.Text.ToString(), H2, Brushes.Black, new Point(x + 120, y));
            e.Graphics.DrawString(" Total Amount", H2, Brushes.Black, new Point(x + 200, y));
            e.Graphics.DrawString(textBox2.Text.ToString(), H2, Brushes.Black, new Point(x + 350, y));
            y = y + 30;
            e.Graphics.DrawLine(pen, new Point(0, y), new Point(1000, y));
            y = y + 20;
           // e.Graphics.DrawString("You save Rs." + (total_mrp - total_sprice).ToString() + " ,Thank you for shopping with us!", H2, Brushes.Black, new Point(x + 150, y));

            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource="";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            if (comboBox2.SelectedIndex==0)
            { 
                flag = 0;
            }
            else
            {
                flag = 1;
            }

        }
    }
}
