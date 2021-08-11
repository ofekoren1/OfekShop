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
    public partial class Ordes : Form
    {
        private DataSet ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8;
        private DataTable dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8;
        private int inc = 0;
        private int maxRow, maxRow1, maxRow2, maxRow3, maxRow4, maxRow5;
        private int edit;
        private System.Data.OleDb.OleDbDataAdapter da, da1, da2, da3, da4, da5, da6, da7, da8;
        System.Data.OleDb.OleDbConnection con, con1, con2, con3, con4, con5, con6, con7, con8;

        public Ordes()
        {
            InitializeComponent();
        }

        private void Oredrs_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectToMenu();
                ConnectToWaiter();
                ConnectToCustomers();
                ConnectToOrders();
                updateFields();
                lockForm();
            }
            catch (System.Exception)
            {
                MessageBox.Show( "התקשרות למסד נתונים נכשלה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectToOrders()
        {
            con = new OleDbConnection();
            con.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con.Open();
            string sql = "SELECT * FROM Orders";
            da = new OleDbDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds, "Orders");
            dt = ds.Tables["Orders"];
            maxRow = ds.Tables["Orders"].Rows.Count;

        }

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
            if (con5 != null)
            {
                con5.Close();
                con5.Dispose();
            }
            if (con6 != null)
            {
                con6.Close();
                con6.Dispose();
            }
            if (con7 != null)
            {
                con7.Close();
                con7.Dispose();
            }
            if (con8 != null)
            {
                con8.Close();
                con8.Dispose();
            }
            this.Close();

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

        private void ConnectToCustomers()
        {
            con2 = new OleDbConnection();
            con2.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con2.Open();
            string sql = "SELECT * FROM Costumer";
            da2 = new OleDbDataAdapter(sql, con2);
            ds2 = new DataSet();
            da2.Fill(ds2, "Costumer");
            dt2 = ds2.Tables["Costumer"];
            maxRow2 = ds2.Tables["Costumer"].Rows.Count;
            cmbIDCustomer.Text = " ";
            cmbIDCustomer.Items.Clear();
            for (int i = 0; i < maxRow2; i++)
                cmbIDCustomer.Items.Add(dt2.Rows[i][0] + "/" + dt2.Rows[i][1]);

        }

        private void ConnectToMenu()
        {
            con4 = new OleDbConnection();
            con4.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con4.Open();
            string sql = "SELECT * FROM Menu";
            da4 = new OleDbDataAdapter(sql, con4);
            ds4 = new DataSet();
            da4.Fill(ds4, "Menu");
            dt4 = ds4.Tables["Menu"];
            maxRow4 = ds4.Tables["Menu"].Rows.Count;
            cmbNumP.Text = " ";
            cmbNumP.Items.Clear();
            for (int i = 0; i < maxRow4; i++)
                cmbNumP.Items.Add(dt4.Rows[i][0] + "/" + dt4.Rows[i][1] + "/" + dt4.Rows[i][4]);

        }

        private void ConnectToOrderDetails()
        {
            con5 = new OleDbConnection();
            con5.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con5.Open();
            string sql = "SELECT * FROM OrderDetails";
            da5 = new OleDbDataAdapter(sql, con5);
            ds5 = new DataSet();
            da5.Fill(ds5, "OrderDetails");
            dt5 = ds5.Tables["OrderDetails"];
            maxRow5 = ds5.Tables["OrderDetails"].Rows.Count;
        }

        private void ConnectToRevah()
        {
            con8 = new OleDbConnection();
            con8.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con8.Open();
            string sql = "SELECT Month([DateOrder]), Year([DateOrder]), Sum(SumOrder) FROM Orders GROUP BY Month([DateOrder]), Year([DateOrder]) HAVING Month([DateOrder])='" + dtpOrder.Value.Month + "'" + "AND Year([DateOrder])='" + dtpOrder.Value.Year + "'";
            da8 = new OleDbDataAdapter(sql, con8);
            ds8 = new DataSet();
            da8.Fill(ds8, "Orders");
            dt8 = ds8.Tables["Orders"];
        }


        public void updateFields()
        {
            int k = 0;
            int r = 0;
            try {
                r = 1;
                txtNumOrder.Text = dt.Rows[inc][0].ToString();
                r = 2;
                cmbNumWaiter.Text = dt.Rows[inc][2].ToString();
                r = 4;
                txtSumOrder.Text = dt.Rows[inc][3].ToString();
                r = 5;
                cmbIDCustomer.Text = dt.Rows[inc][4].ToString();
                r = 6;
                dtpOrder.Text = dt.Rows[inc][1].ToString();       //////////// dtp is the problem
                r = 3;

                k = 1;

                con3 = new OleDbConnection();
                con3.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
                con3.Open();
                string sql = "SELECT OrderDetails.NumProduct, Menu.NameProduct, Menu.Category, Menu.PriceM, OrderDetails.SumP, OrderDetails.SumL FROM Menu INNER JOIN OrderDetails ON Menu.NumProduct = OrderDetails.NumProduct WHERE OrderDetails.NumOrder='" + txtNumOrder.Text + "'";

                k = 2;

                da3 = new OleDbDataAdapter(sql, con3);
                ds3 = new DataSet();
                da3.Fill(ds3, "OrderDetails");
                dt3 = ds3.Tables["OrderDetails"];
                maxRow3 = ds3.Tables["OrderDetails"].Rows.Count;
                DataView view = new DataView(ds3.Tables["OrderDetails"]);
                dgv.DataSource = view;

                k = 3;

                int index = 0, index1 = 0;
                string str = cmbNumWaiter.Text.ToString();
                string[] str1 = str.Split('/');
                for (int i = 0; i < maxRow1; i++)
                {
                    string s = dt1.Rows[i][0].ToString();
                    if (str1[0] == s)
                        index = i;
                }
                txtNameW.Text = dt1.Rows[index][1].ToString();

                k = 4;

                string str2 = cmbIDCustomer.Text.ToString();
                string[] str3 = str2.Split('/');
                for (int i = 0; i < maxRow2; i++)
                {
                    string s1 = dt2.Rows[i][0].ToString();
                    if (str3[0] == s1)
                        index1 = i;
                }
                txtFName.Text = dt2.Rows[index1][1].ToString();
                txtLname.Text = dt2.Rows[index1][2].ToString();

                k = 5;

            }
         catch (System.Exception){
                MessageBox.Show("this is k  " + k + "this is r  " + r + "התקשרות למסך הזמנות עצמו נכשלה   ", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        public void lockForm()
        {
            Gbox.Visible = false;
            btnDone.Visible = false;
            dtpOrder.Enabled = false;
            txtNumOrder.ReadOnly = true;
            txtSumOrder.ReadOnly = true;
            txtSerch.ReadOnly = false;
            cmbIDCustomer.Enabled = false;
            cmbNumWaiter.Enabled = false;
            bthSearch.Enabled = true;
            btnAdd.Enabled = true;
            btnBack.Enabled = true;
            btnBitol.Enabled = false;
            btnDelet.Enabled = true;
            btnMainMenu.Enabled = true;
            btnNext.Enabled = true;
            btnSave.Enabled = false;
            btnUpDate.Enabled = true;
            txtNameW.ReadOnly = true;
            txtFName.ReadOnly = true;
            txtLname.ReadOnly = true;
            DohRevah.Enabled = true;
            btnKabala.Enabled = true;
        }

        public void UnLockForm()
        {
            btnDone.Visible = true;
            dtpOrder.Enabled = true;
            txtNumOrder.ReadOnly = true;
            txtSumOrder.ReadOnly = true;
            txtSerch.ReadOnly = true;
            cmbIDCustomer.Enabled = true;
            cmbNumWaiter.Enabled = true;
            bthSearch.Enabled = false;
            btnAdd.Enabled = false;
            btnBack.Enabled = false;
            btnBitol.Enabled = true;
            btnDelet.Enabled = false;
            btnMainMenu.Enabled = false;
            btnNext.Enabled = false;
            btnSave.Enabled = true;
            btnUpDate.Enabled = false;
            DohRevah.Enabled = false;
            btnKabala.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (inc > 0)
                inc--;
            else inc = maxRow - 1;
            updateFields();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc < maxRow - 1)
                inc++;
            else inc = 0;
            updateFields();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmbNumP.Text = " ";
            txtSumP.Clear();
            UnLockForm();
            edit = 0;
            cmbIDCustomer.Text = " ";
            cmbNumWaiter.Text = " ";
            txtSumOrder.Clear();
            txtFName.Clear();
            txtLname.Clear();
            txtNameW.Clear();
            ConnectToWaiter();
            ConnectToCustomers();
            int x = 0;
            int num = 1;
            while (x < maxRow)
                if (num == int.Parse(ds.Tables["Orders"].Rows[x][0].ToString()))
                {
                    num++;
                    x = 0;
                }
                else x++;
            txtNumOrder.Text = num.ToString();
            btnDone.Visible = false;
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            cmbNumP.Text = " ";
            txtSumP.Clear();
            edit = 1;
            UnLockForm();
            btnDone.Visible = false;

        }

        private void btnBitol_Click(object sender, EventArgs e)
        {
            lockForm();
            updateFields();
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
                        dr = ds.Tables["Orders"].NewRow();
                    else dr = ds.Tables["Orders"].Rows[inc];

                    string str2 = cmbIDCustomer.Text.ToString();
                    string[] str3 = str2.Split('/');
                    string str = cmbNumWaiter.Text.ToString();
                    string[] str1 = str.Split('/');

                    dr[0] = txtNumOrder.Text.ToString();
                    dr[1] = dtpOrder.Value.ToShortDateString();
                    dr[2] = str1[0];
                    dr[3] = txtSumOrder.Text.ToString();
                    dr[4] = str3[0];
                    string message = "ההזמנה נשמרה בהצלחה";

                    if (edit == 0)
                    {
                        ds.Tables["Orders"].Rows.Add(dr);
                        maxRow++;
                        inc = maxRow - 1;
                        message = "ההזמנה התווספה";
                    }

                    da.Update(ds, "Orders");
                    MessageBox.Show(message, "הזמנות", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                updateFields();
            }
            catch (System.Exception)
            {
                MessageBox.Show("אין אפשרות להוסיף את ההזמנה.ייתכן וההזמנה כבר קיימת      .", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            btnDelet.Enabled = true;
            btnBitol.Enabled = false;
            btnSave.Enabled = false;
            Gbox.Visible = true;
            btnDone.Visible = true;
            cmbIDCustomer.Enabled = false;
            cmbNumWaiter.Enabled = false;
            dtpOrder.Enabled = false;
        }

        private bool checkInput()
        {
            bool ok = true;

            if (cmbIDCustomer.Text == " ")
            {
                MessageBox.Show("חובה לבחור מספר מלצר", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            if (cmbNumWaiter.Text == " ")
            {
                MessageBox.Show("חובה לבחור מספר מלצר", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            return ok;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (maxRow != 0)
            {

                con7 = new OleDbConnection();
                con7.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
                con7.Open();
                string sql = "DELETE NumOrder FROM Orders WHERE NumOrder='" + txtNumOrder.Text + "'";
                da7 = new OleDbDataAdapter(sql, con7);
                ds7 = new DataSet();
                da7.Fill(ds7, "Orders");
                dt7 = ds7.Tables["Orders"];
                MessageBox.Show("בוצע בהצלחה", "ההזמנה נמחקה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            lockForm();
            updateFields();
        }
        private bool checkInput1()
        {
            bool ok = true;

            if (cmbNumP.Text == " ")
            {
                MessageBox.Show("חובה לבחור מספר מוצר", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            if (txtSumP.Text.Length == 0)
            {
                MessageBox.Show("חובה להכניס כמות", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            else
            {
                bool ok1 = true;
                string str1 = txtSumP.Text.ToString();
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] > '9' || str1[i] < '0')
                        ok1 = false;
                }
                if (ok1 == false)
                {
                    MessageBox.Show("חובה להכניס רק מספרים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }
            }

            return ok;
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput1())
                {
                    ConnectToOrderDetails();

                    System.Data.OleDb.OleDbCommandBuilder cb;
                    cb = new System.Data.OleDb.OleDbCommandBuilder(da5);
                    DataRow dr;
                    dr = ds5.Tables["OrderDetails"].NewRow();

                    string str = cmbNumP.Text.ToString();
                    string[] str1 = str.Split('/');
                    int x = Convert.ToInt32(txtSumP.Text);
                    int num = Convert.ToInt32(str1[2]);


                    dr[0] = txtNumOrder.Text.ToString();
                    dr[1] = str1[0];
                    dr[2] = txtSumP.Text.ToString();
                    dr[3] = (x * num).ToString();
                    ds5.Tables["OrderDetails"].Rows.Add(dr);
                    da5.Update(ds5, "OrderDetails");
                    MessageBox.Show("הפריט התווסף להזמנה", "פרטי הזמנה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    updateFields();
                    cmbNumP.Text = " ";
                    txtSumP.Clear();
                    
                }
            }

            catch
            {
                MessageBox.Show("הפריט קיים כבר בהזמנה אנא מחק אותו בכדי לשנות את הכמות", "פרטי הזמנה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void bthSearch_Click(object sender, EventArgs e)
        {

            int i;
            int flag = 0;
            for (i = 0; i < maxRow; i++)
            {
                string str_NumOrder = dt.Rows[i][0].ToString();
                if (txtSerch.Text.ToString() == str_NumOrder)
                {
                    inc = i;
                    updateFields();
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("ההזמנה לא נמצא", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerch.Text = dt.Rows[inc][0].ToString();
            }
        }

        private void btnDelet1_Click(object sender, EventArgs e)
        {
            string str = cmbNumP.Text.ToString();
            string[] str1 = str.Split('/');
            con8 = new OleDbConnection();
            con8.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con8.Open();
            string sql = "DELETE OrderDetails.NumOrder, OrderDetails.NumProduct FROM OrderDetails WHERE OrderDetails.NumOrder='" + txtNumOrder.Text + "' AND OrderDetails.NumProduct='" + str[0] + "'";
            da8 = new OleDbDataAdapter(sql, con5);
            ds8 = new DataSet();
            da8.Fill(ds8, "OrderDetails");
            dt8 = ds8.Tables["OrderDetails"];
            MessageBox.Show("בוצע בהצלחה", "המוצר נמחק בהצלחה ממהזמנה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateFields();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            ConnectToOrderDetails();
            string g;
            int x = 0, t;
            for (int i = 0; i < maxRow5; i++)
            {
                string str_NumOrder = dt5.Rows[i][0].ToString();
                if (txtNumOrder.Text.ToString() == str_NumOrder)
                {
                    g = dt5.Rows[i][3].ToString();
                    t = Convert.ToInt32(g);
                    x += t;
                }
            }
            txtSumOrder.Text = x.ToString();
            con6 = new OleDbConnection();
            con6.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con6.Open();
            string sql = "UPDATE Orders SET Orders.SumOrder ='" + txtSumOrder.Text + "'" + "WHERE Orders.NumOredr='" + txtNumOrder.Text + "'";

            da6 = new OleDbDataAdapter(sql, con6);
            ds6 = new DataSet();
            da6.Fill(ds6,"Orders");
            dt6 = ds6.Tables["Orders"];
            MessageBox.Show("סכום הזמנה עודכן והכנסת פרטי הזמנה נגמרה");
            updateFields();
            lockForm();
            Gbox.Visible = false;
            txtSumOrder.Text = x.ToString();                                                      
        }

        private void btnKabala_Click(object sender, EventArgs e)
        {
            StreamWriter file = File.CreateText("דוח קבלה" + txtNumOrder.Text + ".txt");
            DataTable ct = ds3.Tables["OrderDetails"];
            file.WriteLine("חשבונית מס קבלה מספר:  " + txtNumOrder.Text);
            file.WriteLine();
            file.WriteLine("תז לקוח :  " + cmbIDCustomer.Text + "  " + "שם פרטי ושם משפחה של הלקוח:  " + txtFName.Text + "  " + txtLname.Text);
            file.WriteLine(" שם המלצר:  " + txtNameW.Text + "  מספר מלצר  " + cmbNumWaiter.Text);
            if ((maxRow != 0))
            {
                foreach (DataRow dr in ct.Rows)
                {
                    file.WriteLine("מספר מוצר  " + dr[0]);
                    file.WriteLine("שם מוצר  " + dr[1]);
                    file.WriteLine("קטגוריה  " + dr[2]);
                    file.WriteLine("מחיר מוצר  " + dr[3]);
                    file.WriteLine("מספר מוצרים  " + dr[4]);
                    file.WriteLine("סכום שורה  " + dr[5]);
                    file.WriteLine(" ");
                }
                file.WriteLine(" סכום הזמנה סופי  " + txtSumOrder.Text);
                file.Close();
                MessageBox.Show("הופק דוח בהצלחה", "בוצע בהצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void DohRevah_Click(object sender, EventArgs e)
        {
            ConnectToRevah();
            StreamWriter file1 = File.CreateText(" דוח רווח חודשי" + dt8.Rows[0][0].ToString() + "_" + dt8.Rows[0][1].ToString() + ".txt");
            DataTable ct1 = ds8.Tables["Order"];
            file1.WriteLine("רווח חודשי לחודש מספר  " + dt8.Rows[0][0].ToString());
            file1.WriteLine("רווח חודשי לשנה מספר  " + dt8.Rows[0][1].ToString());
            file1.WriteLine(" ");
            file1.WriteLine("הרווחי החודשי הוא  " + dt8.Rows[0][2].ToString());
            file1.Close();
            MessageBox.Show("הופק דוח בהצלחה", "בוצע בהצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void bthSearch_Click_1(object sender, EventArgs e)
        {
            int i;
            int flag = 0;
            for (i = 0; i < maxRow; i++)
            {
                string str_NumOrder = dt.Rows[i][0].ToString();
                if (txtSerch.Text.ToString() == str_NumOrder)
                {
                    inc = i;
                    updateFields();
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("הזמנה לא נמצאה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerch.Text = dt.Rows[inc][0].ToString();
            }
            flag = 0;

        }

        private void DohRevah_Click_1(object sender, EventArgs e)
        {
            ConnectToRevah();
            StreamWriter file1 = File.CreateText(" דוח רווח חודשי" + dt8.Rows[0][0].ToString() + "_" + dt8.Rows[0][1].ToString() + ".txt");
            DataTable ct1 = ds8.Tables["Order"];
            file1.WriteLine("רווח חודשי לחודש מספר  " + dt8.Rows[0][0].ToString());
            file1.WriteLine("רווח חודשי לשנה מספר  " + dt8.Rows[0][1].ToString());
            file1.WriteLine(" ");
            file1.WriteLine("הרווחי החודשי הוא  " + dt8.Rows[0][2].ToString());
            file1.Close();
            MessageBox.Show("הופק דוח בהצלחה", "בוצע בהצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}
