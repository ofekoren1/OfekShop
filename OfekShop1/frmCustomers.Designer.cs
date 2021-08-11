namespace OfekShop1
{
    partial class frmCustomers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bthSearch = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpDate = new System.Windows.Forms.Button();
            this.btnBitol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtSerch = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cmbKidomet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDohla = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "שמור";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(12, 427);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(125, 23);
            this.btnMainMenu.TabIndex = 18;
            this.btnMainMenu.Text = "חזרה לתפריט הראשי";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 398);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "מחק";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bthSearch
            // 
            this.bthSearch.Location = new System.Drawing.Point(399, 429);
            this.bthSearch.Name = "bthSearch";
            this.bthSearch.Size = new System.Drawing.Size(75, 23);
            this.bthSearch.TabIndex = 16;
            this.bthSearch.Text = "חפש";
            this.bthSearch.UseVisualStyleBackColor = true;
            this.bthSearch.Click += new System.EventHandler(this.bthSearch_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(256, 427);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(223, 427);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(27, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "הוסף";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpDate
            // 
            this.btnUpDate.Location = new System.Drawing.Point(12, 340);
            this.btnUpDate.Name = "btnUpDate";
            this.btnUpDate.Size = new System.Drawing.Size(75, 23);
            this.btnUpDate.TabIndex = 12;
            this.btnUpDate.Text = "עדכון";
            this.btnUpDate.UseVisualStyleBackColor = true;
            this.btnUpDate.Click += new System.EventHandler(this.btnUpDate_Click);
            // 
            // btnBitol
            // 
            this.btnBitol.Location = new System.Drawing.Point(12, 369);
            this.btnBitol.Name = "btnBitol";
            this.btnBitol.Size = new System.Drawing.Size(75, 23);
            this.btnBitol.TabIndex = 11;
            this.btnBitol.Text = "ביטול";
            this.btnBitol.UseVisualStyleBackColor = true;
            this.btnBitol.Click += new System.EventHandler(this.btnBitol_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(362, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "תעודת זהות";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(403, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "חפש לקוח";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(365, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "פלאפון";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(362, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "כתובת";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(365, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "אימייל";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(362, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "שם משפחה";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(362, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "שם פרטי";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(234, 139);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 28;
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(234, 198);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(100, 20);
            this.txtLname.TabIndex = 29;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(234, 259);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 30;
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(234, 289);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(100, 20);
            this.txtAdress.TabIndex = 31;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(234, 169);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(100, 20);
            this.txtFname.TabIndex = 32;
            // 
            // txtSerch
            // 
            this.txtSerch.Location = new System.Drawing.Point(385, 400);
            this.txtSerch.Name = "txtSerch";
            this.txtSerch.Size = new System.Drawing.Size(109, 20);
            this.txtSerch.TabIndex = 33;
            this.txtSerch.Text = "הקלד תעודת זהות";
            this.txtSerch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerch.TextChanged += new System.EventHandler(this.txtSerch_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(234, 230);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 34;
            // 
            // cmbKidomet
            // 
            this.cmbKidomet.FormattingEnabled = true;
            this.cmbKidomet.Items.AddRange(new object[] {
            "050",
            "052",
            "053",
            "054",
            "056",
            "057",
            "058"});
            this.cmbKidomet.Location = new System.Drawing.Point(164, 231);
            this.cmbKidomet.Name = "cmbKidomet";
            this.cmbKidomet.Size = new System.Drawing.Size(47, 21);
            this.cmbKidomet.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(216, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "-";
            // 
            // btnDohla
            // 
            this.btnDohla.Location = new System.Drawing.Point(12, 126);
            this.btnDohla.Name = "btnDohla";
            this.btnDohla.Size = new System.Drawing.Size(75, 23);
            this.btnDohla.TabIndex = 37;
            this.btnDohla.Text = "דוח לקוחות";
            this.btnDohla.UseVisualStyleBackColor = true;
            this.btnDohla.Click += new System.EventHandler(this.btnDohla_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(324, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 42);
            this.label9.TabIndex = 38;
            this.label9.Text = "לקוחות";
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OfekShop1.Properties.Resources.תמונת_רקע_לטפסים1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(506, 462);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnDohla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbKidomet);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtSerch);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.bthSearch);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpDate);
            this.Controls.Add(this.btnBitol);
            this.Name = "frmCustomers";
            this.Text = "Costumers";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button bthSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpDate;
        private System.Windows.Forms.Button btnBitol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtSerch;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cmbKidomet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDohla;
        private System.Windows.Forms.Label label9;
    }
}