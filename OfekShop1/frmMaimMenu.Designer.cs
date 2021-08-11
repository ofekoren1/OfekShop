namespace OfekShop1
{
    partial class frmMaimMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaimMenu));
            this.btnCostumer = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnWaiters = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCostumer
            // 
            this.btnCostumer.Location = new System.Drawing.Point(12, 211);
            this.btnCostumer.Name = "btnCostumer";
            this.btnCostumer.Size = new System.Drawing.Size(75, 23);
            this.btnCostumer.TabIndex = 9;
            this.btnCostumer.Text = "לקוחות";
            this.btnCostumer.UseVisualStyleBackColor = true;
            this.btnCostumer.Click += new System.EventHandler(this.btnCostumer_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(12, 291);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(75, 23);
            this.btnOrders.TabIndex = 8;
            this.btnOrders.Text = "הזמנות";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.Location = new System.Drawing.Point(12, 336);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(75, 23);
            this.btnSalary.TabIndex = 7;
            this.btnSalary.Text = "משכורות";
            this.btnSalary.UseVisualStyleBackColor = true;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnWaiters
            // 
            this.btnWaiters.Location = new System.Drawing.Point(12, 247);
            this.btnWaiters.Name = "btnWaiters";
            this.btnWaiters.Size = new System.Drawing.Size(75, 23);
            this.btnWaiters.TabIndex = 6;
            this.btnWaiters.Text = "מלצרים";
            this.btnWaiters.UseVisualStyleBackColor = true;
            this.btnWaiters.Click += new System.EventHandler(this.btnWaiters_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(12, 376);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(75, 23);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "תפריט";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(501, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "יציאה";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMaimMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(588, 421);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCostumer);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnSalary);
            this.Controls.Add(this.btnWaiters);
            this.Controls.Add(this.btnMenu);
            this.DoubleBuffered = true;
            this.Name = "frmMaimMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCostumer;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnSalary;
        private System.Windows.Forms.Button btnWaiters;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnExit;
    }
}

