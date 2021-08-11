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
    public partial class frmMenu : Form
    {
        private DataSet ds;
        private DataTable dt;
        private int inc = 0;
        private int maxRow;
        private int edit;
        private System.Data.OleDb.OleDbDataAdapter da;
        System.Data.OleDb.OleDbConnection con;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectToMenu();
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
        }
        private void lockForm()
        {
            txtNameP.ReadOnly = true;
            txtPrice.ReadOnly = true;
            txtSerch.ReadOnly = false;
            txtTeorMana.ReadOnly = true;
            btnSave.Enabled = false;
            btnBitol.Enabled = false;
            btnBack.Enabled = true;
            btnDelete.Enabled = true;
            btnMainMenu.Enabled = true;
            btnNext.Enabled = true;
            btnAdd.Enabled = true;
            btnSerch.Enabled = true;
            btnUpDate.Enabled = true;
            cmbKategorya.Enabled = false;
            txtNumP.ReadOnly = true;
            DohTafrit.Enabled = true;
        }

        private void UnLockForm()
        {
            txtNameP.ReadOnly = false;
            txtPrice.ReadOnly = false;
            txtSerch.ReadOnly = true;
            txtTeorMana.ReadOnly = false;
            btnSave.Enabled = true;
            btnBitol.Enabled = true;
            btnBack.Enabled = false;
            btnDelete.Enabled = false;
            btnMainMenu.Enabled = false;
            btnNext.Enabled = false;
            btnAdd.Enabled = false;
            btnSerch.Enabled = false;
            btnUpDate.Enabled = false;
            cmbKategorya.Enabled = true;
            DohTafrit.Enabled = false;
        }

        private void ConnectToMenu()
        {
            con = new OleDbConnection();
            con.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb";
            con.Open();
            string sql = "SELECT * FROM Menu";
            da = new OleDbDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds, "Menu");
            dt = ds.Tables["Menu"];
            maxRow = ds.Tables["Menu"].Rows.Count;
        }

        public void updateFields()
        {
            txtNumP.Text = dt.Rows[inc][0].ToString();
            txtNameP.Text = dt.Rows[inc][1].ToString();
            cmbKategorya.Text = dt.Rows[inc][2].ToString();
            txtTeorMana.Text = dt.Rows[inc][3].ToString();
            txtPrice.Text = dt.Rows[inc][4].ToString();
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

        private void btnSerch_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("המנה לא נמצא", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSerch.Text = dt.Rows[inc][0].ToString();
                }

            }
        }

        private void btnBitol_Click(object sender, EventArgs e)
        {
            lockForm();
            updateFields();

        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            edit = 1;
            UnLockForm();
            txtNumP.ReadOnly = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnLockForm();
            edit = 0;
            txtNameP.Clear();
            txtPrice.Clear();
            txtTeorMana.Clear();
            cmbKategorya.Text = " ";
            int x = 0;
            int num = 1;
            while (x < maxRow)
                if (num == int.Parse(ds.Tables["Menu"].Rows[x][0].ToString()))
                {
                    num++;
                    x = 0;
                }
                else x++;
            txtNumP.Text = num.ToString();
            txtNumP.ReadOnly = true;

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
                        dr = ds.Tables["Menu"].NewRow();
                    else dr = ds.Tables["Menu"].Rows[inc];

                    dr[0] = txtNumP.Text.ToString();
                    dr[1] = txtNameP.Text.ToString();
                    dr[2] = cmbKategorya.Text.ToString();
                    dr[3] = txtTeorMana.Text.ToString();
                    dr[4] = txtPrice.Text.ToString();
                    string message = "התפריט עודכן בהצלחה";

                    if (edit == 0)
                    {
                        ds.Tables["Menu"].Rows.Add(dr);
                        maxRow++;
                        inc = maxRow - 1;
                        message = "המנה התווספה לתפריט";
                    }

                    da.Update(ds, "Menu");
                    MessageBox.Show(message, "תפריט", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lockForm();
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("אין אפשרות להוסיף את המנה.ייתכן והמנה כבר קיימת .", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool checkInput()
        {
            bool ok = true;
            if (txtNameP.Text.Length == 0)
            {
                MessageBox.Show("חובה להכניס שם מנה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            if (cmbKategorya.Text == " ")
            {
                MessageBox.Show("חובה להכניס קטגוריה מנה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            if (txtTeorMana.Text.Length <= 20)
            {
                MessageBox.Show("תיאור מנה חייב להכיל לפחות 20 תווים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            for (int i = 0; i < txtPrice.Text.Length; i++)
                for (char k = ':'; k <= '~'; k++)
                    if (txtPrice.Text[i] == k)
                    {
                        MessageBox.Show("מחיר יכול להכיל אך ורק מספרים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ok = false;
                    }

            if (txtPrice.Text.Length == 0)
            {
                MessageBox.Show("חייב להכניס מספר למחיר", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            else
            {
                int sr = int.Parse(txtPrice.Text);
                if (sr <= 0)
                {
                    MessageBox.Show("מחיר חייב להיות גדול מאפס", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }
            }

            return ok;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (maxRow != 0)
            {
                DialogResult dir = MessageBox.Show("האם אתה בטוח שברצונך למחוק מנה זו?", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dir == DialogResult.Yes)
                {
                    int OrderID = int.Parse(txtNumP.Text);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    int row = inc;
                    cb = new OleDbCommandBuilder(da);
                    ds.Tables["Menu"].Rows[row].Delete();
                    maxRow--;
                    inc = 0;
                    MessageBox.Show("נמחקו פרטי המנה");
                    da.Update(ds, "Menu");
                    if (maxRow == 0)
                    {
                        MessageBox.Show("אין עוד מנות", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateFields();
                    }
                    else
                        updateFields();

                    MessageBox.Show("בוצע בהצלחה", "המנה נמחקה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void DohTafrit_Click(object sender, EventArgs e)
        {
            StreamWriter file = File.CreateText("דוח תפריט.txt");
            DataTable ct = ds.Tables["Menu"];
            if ((maxRow != 0))
            {
                foreach (DataRow dr in ct.Rows)
                {
                    file.WriteLine(" ");
                    file.WriteLine("מוצר מספר  " + dr[0]);
                    file.WriteLine("שם המוצר  " + dr[1]);
                    file.WriteLine(dr[3]);
                    file.WriteLine("קטגוריה:  " + dr[2]);
                    file.WriteLine("מחיר  " + dr[4] + "ש''ח");
                    file.WriteLine(" ");
                }
                file.Close();
                MessageBox.Show("הופק דוח בהצלחה", "בוצע בהצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }




    }
}

    

