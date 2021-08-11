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
    public partial class frmSalary : Form
    {
        public frmSalary()
        {
            InitializeComponent();
        }

        private DataSet ds, ds1, ds2, ds3, ds4;
        private DataTable dt, dt1, dt2, dt3, dt4;
        private int inc = 0;
        private int maxRow, maxRow1, maxRow4;
        private int edit;
        int x;
        private System.Data.OleDb.OleDbDataAdapter da, da1, da2, da3, da4;
        System.Data.OleDb.OleDbConnection con, con1, con2, con3, con4;

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMaimMenu frm = new frmMaimMenu();
            this.Hide();
            frm.Show();
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
            if (con1 != null)
            {
                con1.Close();
                con1.Dispose();
            }
            if (con2 != null)
            {
                con2.Close();
                con2.Dispose();
            }
            if (con3 != null)
            {
                con3.Close();
                con3.Dispose();
            }
            if (con4 != null)
            {
                con4.Close();
                con4.Dispose();
            }
            this.Close();
        }

        private void frmSalary_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectToWaiter();
                ConnectToSalary();
                updateFields();
                lockForm();
            }
            catch (System.Exception)
            {
                MessageBox.Show("התקשרות למסד נתונים נכשלה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lockForm()
        {
            txtMonth.ReadOnly = true;
            cmbNumWaiter.Enabled = false;
            txtSalary.ReadOnly = true;
          
            txtSumSale.ReadOnly = true;
            txtYear.ReadOnly = true;
            btnAdd.Enabled = true;
            btnBack.Enabled = true;
            btnBitol.Enabled = false;
            btnDelete.Enabled = true;
            btnMainMenu.Enabled = true;
            btnNext.Enabled = true;
            btnSave.Enabled = false;
        
            btnUpDatde.Enabled = true;
            btnMainMenu.Enabled = true;
            Gbox.Visible = true;
            btnHisov.Enabled = false;
        }

        private void UnLockForm()
        {
            txtMonth.ReadOnly = false;
            cmbNumWaiter.Enabled = true;
            txtSalary.ReadOnly = true;
           
            txtSumSale.ReadOnly = true;
            txtYear.ReadOnly = false;
            btnAdd.Enabled = false;
            btnBack.Enabled = false;
            btnBitol.Enabled = true;
            btnDelete.Enabled = false;
            btnMainMenu.Enabled = false;
            btnNext.Enabled = false;
            btnSave.Enabled = true;
           
            btnUpDatde.Enabled = false;
            btnMainMenu.Enabled = false;
            btnHisov.Enabled = true;
            Gbox.Visible = false;
        }
        private void ConnectToSalary()
        {
            con = new OleDbConnection();
            con.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con.Open();
            string sql = "SELECT * FROM Salary";
            da = new OleDbDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds, "Salary");
            dt = ds.Tables["Salary"];
            maxRow = ds.Tables["Salary"].Rows.Count;
        }

        private void ConnectToWaiter()
        {
            con1 = new OleDbConnection();
            con1.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con1.Open();
            string sql = "SELECT * FROM Waiters";
            da1 = new OleDbDataAdapter(sql, con1);
            ds1 = new DataSet();
            da1.Fill(ds1, "Waiters");
            dt1 = ds1.Tables["Waiters"];
            maxRow1 = ds1.Tables["Waiters"].Rows.Count;
            cmbNumWaiter.Items.Clear();
            for (int i = 0; i < maxRow1; i++)
            {
                cmbNumWaiter.Items.Add(dt1.Rows[i][0] + "/" + dt1.Rows[i][1]);
            }
        }
        private void ConnectToOrders()
        {
            string str = cmbNumWaiter.Text.ToString();
            string[] str1 = str.Split('/');

            con2 = new OleDbConnection();
            con2.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con2.Open();
            string sql = "SELECT NumWaiter, Month([DateOrder]), Year([DateOrder]), Sum(Orders.SumOrder) FROM Orders GROUP BY NumWaiter, Month([DateOrder]), Year([DateOrder]) HAVING NumWaiter='" + str1[0] + "'" + "AND Month([DateOrder])='" + txtMonth.Text + "'" + "AND Year([DateOrder])='" + txtYear.Text + "'";          
            da2 = new OleDbDataAdapter(sql, con2);
            ds2 = new DataSet();
            da2.Fill(ds2, "Orders");
            dt2 = ds2.Tables["Orders"];
            string ezer = dt2.Rows[0][3].ToString();
            txtSumSale.Text = ezer;
            ConnectToWaiter1();
            int y = int.Parse(dt2.Rows[0][3].ToString());
            txtSalary.Text = (x * y/100).ToString();
            MessageBox.Show("המשכורת חושבה בהצלחה");

        }

        private void ConnectToWaiter1()
        {

            string st = cmbNumWaiter.Text.ToString();
            string[] str = st.Split('/');
            con3 = new OleDbConnection();
            con3.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con3.Open();
            string sql = "SELECT Waiters.NumWaiter, Waiters.PrecentW FROM Waiters WHERE Waiters.NumWaiter='" + str[0] + "'";

            da3 = new OleDbDataAdapter(sql, con3);
            ds3 = new DataSet();
            da3.Fill(ds3, "Waiters");
            dt3 = ds3.Tables["Waiters"];
            x = int.Parse(dt3.Rows[0][1].ToString());
        }

        private void ConnectToSalaryDoh()
        {
            con4 = new OleDbConnection();
            con4.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con4.Open();
            string sql = "SELECT Salary.NumWaiter, Waiters.NWaiter, Salary.SumSale, Salary.SalaryW FROM Waiters INNER JOIN Salary ON Waiters.NumWaiter = Salary.NumWaiter WHERE Salary.YearWaiter='" + txtYear1.Text + "'" + "AND Salary.MonthWaiter='" + cmbMonth.Text + "'";
            da4 = new OleDbDataAdapter(sql, con4);
            ds4 = new DataSet();
            da4.Fill(ds4, "Salary");
            dt4 = ds4.Tables["Salary"];
            maxRow4 = ds4.Tables["Salary"].Rows.Count;

        }

        public void updateFields()
        {

            cmbNumWaiter.Text = dt.Rows[inc][0].ToString();
            txtMonth.Text = dt.Rows[inc][1].ToString();
            txtYear.Text = dt.Rows[inc][2].ToString();
            txtSumSale.Text = dt.Rows[inc][3].ToString();
            txtSalary.Text = dt.Rows[inc][4].ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (inc < maxRow - 1)
                inc++;
            else inc = 0;
            updateFields();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc > 0)
                inc--;
            else inc = maxRow - 1;
            updateFields();
        }

        private void btnUpDatde_Click(object sender, EventArgs e)
        {
            edit = 1;
            UnLockForm();
        }

        private void btnBitol_Click(object sender, EventArgs e)
        {
            lockForm();
            updateFields();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnLockForm();
            edit = 0;
            txtMonth.Clear();
            cmbNumWaiter.Text = " ";
            txtSalary.Clear();
            txtSumSale.Clear();
            txtYear.Clear();
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput())
                {
                    System.Data.OleDb.OleDbCommandBuilder cb;
                    cb = new System.Data.OleDb.OleDbCommandBuilder(da);
                    DataRow dr;
                    if (edit == 0)
                        dr = ds.Tables["Salary"].NewRow();
                    else dr = ds.Tables["Salary"].Rows[inc];

                    string str = cmbNumWaiter.Text.ToString();
                    string[] str1 = str.Split('/');

                    dr[0] = str[0];
                    dr[1] = txtMonth.Text.ToString();
                    dr[2] = txtYear.Text.ToString();
                    dr[3] = txtSumSale.Text.ToString();
                    dr[4] = txtSalary.Text.ToString();

                    string message = "המשכורת עודכן בהצלחה";

                    if (edit == 0)
                    {
                        ds.Tables["Salary"].Rows.Add(dr);
                        maxRow++;
                        inc = maxRow - 1;
                        message = "המשכורת התווספה בהצלחה";
                    }

                    da.Update(ds, "Salary");
                    MessageBox.Show(message, "משכורות", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lockForm();
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("אין אפשרות להוסיף את המשכורת.ייתכן והמשכורת כבר קיימת      .", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool checkInput()
        {
            return true;
       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (maxRow != 0)
            {
                DialogResult dir = MessageBox.Show("האם אתה בטוח שברצונך למחוק משכורת זו?", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dir == DialogResult.Yes)
                {
                    int OrderID = int.Parse(cmbNumWaiter.Text);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    int row = inc;
                    cb = new OleDbCommandBuilder(da);
                    ds.Tables["Salary"].Rows[row].Delete();
                    maxRow--;
                    inc = 0;
                    MessageBox.Show("נמחקו פרטי המשכורת");
                    da.Update(ds, "Salary");
                    if (maxRow == 0)
                    {
                        MessageBox.Show("אין עוד משכורות", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateFields();
                    }
                    else
                        updateFields();

                    MessageBox.Show("בוצע בהצלחה", "המשכורת נמחקה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnHisov_Click(object sender, EventArgs e)
        {
            ConnectToOrders();
            btnSave.Enabled = true;
        }

        private void DohMascorot_Click(object sender, EventArgs e)
        {
            ConnectToSalaryDoh();
            StreamWriter file = File.CreateText("דוח משכורות" + cmbMonth.Text + "_" + txtYear1.Text + ".txt");
            DataTable ct1 = ds4.Tables["Salary"];
            file.WriteLine("דוח משכורות" + cmbMonth.Text + "_" + txtYear1.Text);
            if ((maxRow4 != 0))
            {
                foreach (DataRow dr in ct1.Rows)
                {
                    file.WriteLine(" ");
                    file.WriteLine("מספר מלצר  " + dr[0]);
                    file.WriteLine("שם מלצר  " + dr[1]);
                    file.WriteLine("סכום המכירות לאותו חודש:  " + dr[2]);
                    file.WriteLine("משכורת:  " + dr[3]);
                    file.WriteLine(" ");
                }
                file.Close();
                MessageBox.Show("הופק דוח בהצלחה", "בוצע בהצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        



    }
}
