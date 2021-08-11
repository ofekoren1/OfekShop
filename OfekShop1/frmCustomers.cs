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
    public partial class frmCustomers : Form
    {
        private DataSet ds;
        private DataTable dt;
        private int inc = 0;
        private int maxRow;
        private int edit;
        private System.Data.OleDb.OleDbDataAdapter da;
        System.Data.OleDb.OleDbConnection con;

        public frmCustomers()
        {
            InitializeComponent();
        }

        public void updateFields()
        {

            txtID.Text = dt.Rows[inc][0].ToString();
            txtFname.Text = dt.Rows[inc][1].ToString();
            txtLname.Text = dt.Rows[inc][2].ToString();
            txtPhone.Text = dt.Rows[inc][3].ToString();
            string str = dt.Rows[inc][3].ToString();
            string[] strS = str.Split('-');
            cmbKidomet.Text = strS[0];
            txtPhone.Text = strS[1];
            txtAdress.Text = dt.Rows[inc][4].ToString();
            txtEmail.Text = dt.Rows[inc][5].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnLockform();
            edit = 0;
            txtID.Clear();
            cmbKidomet.Text = " ";
            txtFname.Clear();
            txtLname.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAdress.Clear();
            bthSearch.Enabled = false;
            txtSerch.ReadOnly = true;
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
                        dr = ds.Tables["Costumer"].NewRow();
                    else dr = ds.Tables["Costumer"].Rows[inc];

                    dr[0] = txtID.Text.ToString();
                    dr[1] = txtFname .Text.ToString();
                    dr[2] = txtLname .Text.ToString();
                    dr[3] = cmbKidomet.Text.ToString() + "-" + txtPhone.Text.ToString();
                    dr[4] = txtAdress.Text.ToString();
                    dr[5] = txtEmail.Text.ToString();

                    string message = "הלקוח עודכן בהצלחה";

                    if (edit == 0)
                    {
                        ds.Tables["Costumer"].Rows.Add(dr);
                        maxRow++;
                        inc = maxRow - 1;
                        message = "ההלקוח התווסף בהצלחה";
                    }

                    da.Update(ds, "Costumer");
                    MessageBox.Show(message, "לקוחות", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lockForm();
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("אין אפשרות להוסיף את ההלקוח.ייתכן והלקוח כבר קיים      .", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            edit = 1;
            UnLockform();
            txtID.ReadOnly = true;

        }

        private void btnBitol_Click(object sender, EventArgs e)
        {
                lockForm();
            updateFields();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                if (maxRow != 0)
            {
                DialogResult dir = MessageBox.Show("האם אתה בטוח שברצונך למחוק לקוח זה?", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	
                if (dir == DialogResult.Yes)
                {
                    int OrderID = int.Parse(txtID.Text);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    int row = inc;
                    cb = new OleDbCommandBuilder(da);
                    ds.Tables["Costumer"].Rows[row].Delete();
                    maxRow--;
                    inc = 0;
                    MessageBox.Show("נמחקו פרטי הלקוח");
                    da.Update(ds, "Costumer");
                    if (maxRow == 0)
                    {
                        MessageBox.Show("אין עוד לקוחות", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateFields();
                    }
                    else
                        updateFields();

                    MessageBox.Show("בוצע בהצלחה", "הלקוח נמחק", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            this.Close();

        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectToCustomers();
                updateFields();
                lockForm();
            }
            catch (System.Exception)
            {
                MessageBox.Show("התקשרות למסד נתונים נכשלה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ConnectToCustomers()
        {
            con = new OleDbConnection();
            con.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con.Open();
            string sql = "SELECT * FROM Costumer";
            da = new OleDbDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds, "Costumer");
            dt = ds.Tables["Costumer"];
            maxRow = ds.Tables["Costumer"].Rows.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc > 0)
                inc--;
            else inc = maxRow - 1;
            updateFields();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (inc < maxRow - 1)
                inc++;
            else inc = 0;
            updateFields();

        }
        private void lockForm()
        {
            txtSerch.ReadOnly = false;
            txtID.ReadOnly = true;
            txtFname.ReadOnly = true;
            txtLname.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtAdress.ReadOnly = true;
            btnBitol.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnBack.Enabled = true;
            btnNext.Enabled = true;
            btnUpDate.Enabled = true;
            cmbKidomet.Enabled = false;
            btnMainMenu.Enabled = true;
            bthSearch.Enabled = true;
            btnDohla.Enabled = true;
        }

        private void UnLockform()
        {
            txtSerch.ReadOnly = true;
            txtID.ReadOnly = false;
            txtFname.ReadOnly = false;
            txtLname.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtAdress.ReadOnly = false;
            btnBitol.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnBack.Enabled = false;
            btnNext.Enabled = false;
            btnUpDate.Enabled = false;
            cmbKidomet.Enabled = true;
            btnMainMenu.Enabled = false;
            bthSearch.Enabled = false;
            btnDohla.Enabled = false;

        }
        private bool checkInput()
        {
            {
                bool ok = true;
                if (txtID.Text.Length != 9)
                {
                    MessageBox.Show("חובה תעודת זהות תקינה בעלת 9 ספרות", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }
                else
                {
                    int[] id = new int[9];
                    for (int i = 0; i < 9; i++)
                        id[i] = int.Parse(txtID.Text[i].ToString());
                    for (int i = 1; i < 9; i += 2)
                        id[i] = id[i] * 2;
                    int sum = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        while (id[i] != 0)
                        {
                            sum += id[i] % 10;
                            id[i] = id[i] / 10;
                        }
                        id[i] = sum;
                        sum = 0;
                    }
                    for (int i = 0; i < 9; i++)
                        sum += id[i];
                    if (sum % 10 != 0)
                    {
                        MessageBox.Show("התעודת זהות שהכנסת אינה תקינה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ok = false;
                    }
                }

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
                            MessageBox.Show("שם הלקוח יכול להכיל רק אותיות", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ok = false;
                        }
                }

                if (txtLname.Text.Length == 0)
                {
                    MessageBox.Show(" חובה להכניס שם משפחה ", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }
                else
                {
                    string str1 = txtLname.Text.ToString();
                    for (int i = 0; i < str1.Length; i++)
                        if ((str1[i] <= 'ת' && str1[i] >= 'א') || str1[i] == ' ' || str1[i] == '-')
                            i++;
                        else
                        {
                            MessageBox.Show("שם משפחה יכול להכיל רק אותיות", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ok = false;
                        }
                }
                if(cmbKidomet.Text ==" ")
                {
                    MessageBox.Show("חובה להכניס קידומת", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }

                if (txtPhone.Text.Length != 7)
                {
                    MessageBox.Show("אורך מספר הפלאפון לא תקין", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("חובה להכניס כתובת", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (txtEmail.Text[i] == h)
                        ok1 = true;
                if (ok1 == false)
                {
                    MessageBox.Show("@ לא יכולה להיות כתובת מייל ללא ", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }

                return ok;
            }
        }

        private void bthSearch_Click(object sender, EventArgs e)
        {
            int i;
            int flag = 0;
            for (i = 0; i < maxRow; i++)
            {
                string str_NumCutomers = dt.Rows[i][0].ToString();
                if (txtSerch.Text.ToString() == str_NumCutomers)
                {
                    inc = i;
                    updateFields();
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("הלקוח לא קיים במערכת", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerch.Text = dt.Rows[inc][0].ToString();
            }
            flag = 0;
        }

        private void btnDohla_Click(object sender, EventArgs e)
        {
            StreamWriter file = File.CreateText("דוח לקוחות.txt");
            DataTable ct = ds.Tables["Costumer"];
            if ((maxRow != 0))
            {
                foreach (DataRow dr in ct.Rows)
                {
                    file.WriteLine(" ");
                    file.WriteLine("תז לקוח  " + dr[0]);
                    file.WriteLine("שם פרטי לקוח  " + dr[1]);
                    file.WriteLine("שם משפחה לקוח  " + dr[2]);
                    file.WriteLine("מספר פלאפון  " + dr[3]);
                    file.WriteLine("כתובת  " + dr[4]);
                    file.WriteLine("דואר אלקטרוני  " + dr[5]);
                    file.WriteLine(" ");
                }
                file.Close();
                MessageBox.Show("הופק דוח בהצלחה", "בוצע בהצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtSerch_TextChanged(object sender, EventArgs e)
        {           
        }


    }
}
