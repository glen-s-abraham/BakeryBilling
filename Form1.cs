using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryBilling
{
    public partial class frmMain : Form
    {
        Form obj = null;
        public frmMain()
        {
            InitializeComponent();
        }
        private void render_form(Form frm)
        {
            if (obj != null)
            {
                obj.Close();
                obj.Dispose();
            }
            obj = frm;
            obj.TopLevel = false;
            obj.AutoScroll = true;
            obj.FormBorderStyle = FormBorderStyle.None;
            frmpanel.Controls.Add(obj);
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            render_form(new Form3());
            lblfrmname.Text = "Products";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            render_form(new frmBill());
            lblfrmname.Text = "Bill";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            render_form(new Form5());
            lblfrmname.Text = "Reprort";
        }

        private void frmpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
