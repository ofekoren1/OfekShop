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
    public partial class frmWaiters : Form
    {
        public frmWaiters()
        {
            InitializeComponent();
        }

        private DataSet ds, ds1;
        private DataTable dt, dt1;
        private int inc = 0;
        private int maxRow;
        private int edit;
        private System.Data.OleDb.OleDbDataAdapter da, da1;
        System.Data.OleDb.OleDbConnection con, con1;


        private void frmWaiters_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectToWaiter();
                updateFields();
                lockForm();
            }

            catch (System.Exception)
            {
                MessageBox.Show("התקשרות למסד נתונים נכשלה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            this.Close();
        }

        private void lockForm()
        {
            txtAdress.ReadOnly = true;
            txtAhoz.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtFname.ReadOnly = true;
            txtNumWaiters.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtSerch.ReadOnly = false;
            btnDohMe.Enabled = true;
            DohMascoret.Enabled = true;
            btnAdd.Enabled = true;
            btnBack.Enabled = true;
            btnBitol.Enabled = false;
            btnDelete.Enabled = true;
            btnMainMenu.Enabled = true;
            btnNext.Enabled = true;
            btnSave.Enabled = false;
            btnSerch.Enabled = true;
            btnUpDatde.Enabled = true;
            cmbKidomet.Enabled = false;

        }

        private void UnLockForm()
        {
            txtAdress.ReadOnly = false;
            txtAhoz.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtFname.ReadOnly = false;
            txtNumWaiters.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtSerch.ReadOnly = true;
            btnDohMe.Enabled = false;
            DohMascoret.Enabled = false;
            btnAdd.Enabled = false;
            btnBack.Enabled = false;
            btnBitol.Enabled = true;
            btnDelete.Enabled = false;
            btnMainMenu.Enabled = false;
            btnNext.Enabled = false;
            btnSave.Enabled = true;
            btnSerch.Enabled = false;
            btnUpDatde.Enabled = false;
            cmbKidomet.Enabled = true;
        }

        private void ConnectToWaiter()
        {
            con = new OleDbConnection();
            con.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con.Open();
            string sql = "SELECT * FROM Waiters";
            da = new OleDbDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds, "Waiters");
            dt = ds.Tables["Waiters"];
            maxRow = ds.Tables["Waiters"].Rows.Count;
        }
        private void ConnectToDohMascoret()
        {
            con1 = new OleDbConnection();
            con1.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con1.Open();
            string sql = "SELECT Salary.NumWaiter, Salary.MonthWaiter, Salary.YearWaiter, Salary.SalaryW, Salary.SumSale FROM Salary WHERE (Salary.NumWaiter)='" + txtNumWaiters.Text + "'";
            da1 = new OleDbDataAdapter(sql, con1);
            ds1 = new DataSet();
            da1.Fill(ds1, "Salary");
            dt1 = ds1.Tables["Salary"];
        }

        public void updateFields()
        {
            txtNumWaiters.Text = dt.Rows[inc][0].ToString();
            txtFname.Text = dt.Rows[inc][1].ToString();
            txtAdress.Text = dt.Rows[inc][2].ToString();
            txtEmail.Text = dt.Rows[inc][3].ToString();

            string str = dt.Rows[inc][4].ToString();
            string[] strS = str.Split('-');
            cmbKidomet.Text = strS[0];
            txtPhone.Text = strS[1];
            txtAhoz.Text = dt.Rows[inc][5].ToString();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc < maxRow - 1)
                inc++;
            else inc = 0;
            updateFields();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (inc > 0)
                inc--;
            else inc = maxRow - 1;
            updateFields();

        }

        private void btnSerch_Click(object sender, EventArgs e)
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
                MessageBox.Show("המלצר לא נמצא", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerch.Text = dt.Rows[inc][0].ToString();
            }
            flag = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnLockForm();
            edit = 0;
            cmbKidomet.Text = " ";
            txtFname.Clear();
            txtNumWaiters.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAdress.Clear();
            txtAhoz.Clear();
            int x = 0;
            int num = 1;
            while (x < maxRow)
                if (num == int.Parse(ds.Tables["Waiters"].Rows[x][0].ToString()))
                {
                    num++;
                    x = 0;
                }
                else x++;
            txtNumWaiters.Text = num.ToString();
            txtNumWaiters.ReadOnly = true;

        }

        private void btnBitol_Click(object sender, EventArgs e)
        {
            lockForm();
            updateFields();
        }

        private void btnUpDatde_Click(object sender, EventArgs e)
        {
            edit = 1;
            UnLockForm();
            txtNumWaiters.ReadOnly = true;

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
                        dr = ds.Tables["Waiters"].NewRow();
                    else dr = ds.Tables["Waiters"].Rows[inc];

                    dr[0] = txtNumWaiters.Text.ToString();
                    dr[1] = txtFname.Text.ToString();
                    dr[4] = cmbKidomet.Text.ToString() + "-" + txtPhone.Text.ToString();
                    dr[2] = txtAdress.Text.ToString();
                    dr[3] = txtEmail.Text.ToString();
                    dr[5] = txtAhoz.Text.ToString();

                    string message = "המלצר עודכן בהצלחה";

                    if (edit == 0)
                    {
                        ds.Tables["Waiters"].Rows.Add(dr);
                        maxRow++;
                        inc = maxRow - 1;
                        message = "המלצר התווסף בהצלחה";
                    }

                    da.Update(ds, "Waiters");
                    MessageBox.Show(message, "מלצרים", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lockForm();
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("אין אפשרות להוסיף את המלצר.ייתכן והמלצר כבר קיים .", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool checkInput()
        {
            bool ok = true;
            if (txtFname.Text.Length == 0)
            {
                MessageBox.Show("חובה להכניס שם", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            else
            {
                string str1 = txtFname.Text.ToString();
                for (int i = 0; i < str1.Length; i++)
                    if ((str1[i] <= 'ת' && str1[i] >= 'א') || str1[i] == ' ' || str1[i] == '-')
                        i++;
                    else
                    {
                        MessageBox.Show("שם המלצר יכול להכיל רק אותיות", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ok = false;
                    }
            }
            if (cmbKidomet.Text == " ")
            {
                MessageBox.Show("חובה להכניס קידומת", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            if (txtPhone.Text.Length != 7)
            {
                MessageBox.Show("אורך המספר לא תקין", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            else
            {
                bool ok2 = true;
                string str2 = txtPhone.Text.ToString();
                for (int i = 0; i < str2.Length; i++)
                {
                    if (str2[i] > '9' || str2[i] < '0')
                        ok2 = false;
                }

                if (ok2 == false)
                {
                    MessageBox.Show("חובה להכניס רק מספרים לפלאפון", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }
            }
            if (txtAdress.Text.Length == 0)
            {
                MessageBox.Show("חובה להכניס רחוב", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("חובה להכניס כתובת מייל", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            char h = '@';
            bool ok1 = false;
            for (int i = 0; i < txtEmail.Text.Length; i++)
            {
                if (txtEmail.Text[i] == h)
                    ok1 = true;
            }
            if (ok1 == false)
            {
                MessageBox.Show("@ לא יכולה להיות כתובת מייל ללא ", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            bool ok3 = true;
            string str3 = txtAhoz.Text.ToString();
            for (int i = 0; i < str3.Length; i++)
            {
                if (str3[i] > '9' || str3[i] < '0')
                    ok3 = false;
            }
            if (ok3 == false)
            {
                MessageBox.Show("חובה להכניס רק מספרים לפלאפון", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }


            return ok;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (maxRow != 0)
            {
                DialogResult dir = MessageBox.Show("האם אתה בטוח שברצונך למחוק מלצר זה?", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dir == DialogResult.Yes)
                {
                    int OrderID = int.Parse(txtNumWaiters.Text);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    int row = inc;
                    cb = new OleDbCommandBuilder(da);
                    ds.Tables["Waiters"].Rows[row].Delete();
                    maxRow--;
                    inc = 0;
                    MessageBox.Show("נמחקו פרטי המלצר");
                    da.Update(ds, "Waiters");
                    if (maxRow == 0)
                    {
                        MessageBox.Show("אין עוד מלצרים", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateFields();
                    }
                    else
                        updateFields();

                    MessageBox.Show("בוצע בהצלחה", "המלצר נמחק", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnDohMe_Click(object sender, EventArgs e)
        {
            StreamWriter file = File.CreateText("דוח מלצרים.txt");
            DataTable ct = ds.Tables["Waiters"];
            if ((maxRow != 0))
            {
                foreach (DataRow dr in ct.Rows)
                {
                    file.WriteLine(" ");
                    file.WriteLine("מספר מלצר  " + dr[0]);
                    file.WriteLine("שם פרטי מלצר  " + dr[1]);
                    file.WriteLine("מספר פלאפון  " + dr[2]);
                    file.WriteLine("כתובת  " + dr[3]);
                    file.WriteLine("דואר אלקטרוני  " + dr[4]);
                    file.WriteLine("אחוז מכירות  " + dr[5]);
                    file.WriteLine(" ");
                }
                file.Close();
                MessageBox.Show("הופק דוח בהצלחה", "בוצע בהצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 

        }

        private void DohMascoret_Click(object sender, EventArgs e)
        {
            int x = 0;
            ConnectToDohMascoret();
            StreamWriter file1 = File.CreateText("דוח משכורת למלצר מספר" + txtNumWaiters.Text.ToString() + ".txt");
            DataTable ct1 = ds1.Tables["Salary"];
            file1.WriteLine("מספר מלצר  " + txtNumWaiters.Text.ToString());
            file1.WriteLine(" שם המלצר:  " + txtFname.Text.ToString());
            if ((maxRow != 0))
            {
                foreach (DataRow dr1 in ct1.Rows)
                {
                    file1.WriteLine(" ");
                    file1.WriteLine("חודש מספר  " + dr1[1]);
                    file1.WriteLine("שנה מספר  " + dr1[2]);
                    file1.WriteLine("סכום מכירות חודשי  " + dr1[4]);
                    file1.WriteLine("משכורת  " + dr1[3]);
                    file1.WriteLine(" ");
                    x += Convert.ToInt32(dr1[3].ToString());
                }
                file1.WriteLine(" סכום משכורות של המלצר  " + x.ToString());
                file1.Close();
                MessageBox.Show("הופק דוח בהצלחה", "בוצע בהצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 

        }




    }
}
