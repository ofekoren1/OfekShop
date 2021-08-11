using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;


namespace OfekShop1
{
    public partial class frmMaimMenu : Form
    {
        public frmMaimMenu()
        {
            InitializeComponent();
        }

        private void btnCostumer_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            this.Hide();
            frm.Show();

        }

        private void btnWaiters_Click(object sender, EventArgs e)
        {
            frmWaiters frm = new frmWaiters();
            this.Hide();
            frm.Show();

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Ordes frm = new Ordes();
            this.Hide();
            frm.Show();

        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            frmSalary frm = new frmSalary();
            this.Hide();
            frm.Show();

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Hide();
            frm.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
