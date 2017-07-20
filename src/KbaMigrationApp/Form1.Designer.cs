namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.Connect = new System.Windows.Forms.Button();
            this.URLINSTANCE = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.userBox = new System.Windows.Forms.TextBox();
            this.pswbox = new System.Windows.Forms.TextBox();
            this.usertextBox = new System.Windows.Forms.TextBox();
            this.pswtextBox = new System.Windows.Forms.TextBox();
            this.loginfail = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(284, 272);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(375, 80);
            this.Connect.TabIndex = 5;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // URLINSTANCE
            // 
            this.URLINSTANCE.Location = new System.Drawing.Point(334, 106);
            this.URLINSTANCE.Name = "URLINSTANCE";
            this.URLINSTANCE.Size = new System.Drawing.Size(438, 31);
            this.URLINSTANCE.TabIndex = 1;
            this.URLINSTANCE.TextChanged += new System.EventHandler(this.URLINSTANCE_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(194, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(578, 31);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Enter your Dynamics instance full URL and credentials";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(274, 106);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(54, 31);
            this.textBox2.TabIndex = 3;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "URL:";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(216, 179);
            this.userBox.Name = "userBox";
            this.userBox.ReadOnly = true;
            this.userBox.Size = new System.Drawing.Size(116, 31);
            this.userBox.TabIndex = 6;
            this.userBox.TabStop = false;
            this.userBox.Text = "Username:";
            // 
            // pswbox
            // 
            this.pswbox.Location = new System.Drawing.Point(216, 216);
            this.pswbox.Name = "pswbox";
            this.pswbox.ReadOnly = true;
            this.pswbox.Size = new System.Drawing.Size(116, 31);
            this.pswbox.TabIndex = 7;
            this.pswbox.TabStop = false;
            this.pswbox.Text = "Password:";
            // 
            // usertextBox
            // 
            this.usertextBox.Location = new System.Drawing.Point(338, 179);
            this.usertextBox.Name = "usertextBox";
            this.usertextBox.Size = new System.Drawing.Size(434, 31);
            this.usertextBox.TabIndex = 3;
            // 
            // pswtextBox
            // 
            this.pswtextBox.Location = new System.Drawing.Point(338, 216);
            this.pswtextBox.Name = "pswtextBox";
            this.pswtextBox.PasswordChar = '*';
            this.pswtextBox.Size = new System.Drawing.Size(434, 31);
            this.pswtextBox.TabIndex = 4;
            // 
            // loginfail
            // 
            this.loginfail.ForeColor = System.Drawing.Color.Red;
            this.loginfail.Location = new System.Drawing.Point(194, 372);
            this.loginfail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginfail.Name = "loginfail";
            this.loginfail.ReadOnly = true;
            this.loginfail.Size = new System.Drawing.Size(578, 31);
            this.loginfail.TabIndex = 8;
            this.loginfail.TextChanged += new System.EventHandler(this.loginfail_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(338, 142);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(434, 31);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "(e.g. https://contoso.crm4.dynamics.com)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(816, 382);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(76, 31);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "V 1.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 425);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.loginfail);
            this.Controls.Add(this.pswtextBox);
            this.Controls.Add(this.usertextBox);
            this.Controls.Add(this.pswbox);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.URLINSTANCE);
            this.Controls.Add(this.Connect);
            this.Name = "Form1";
            this.Text = "KB Migration Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox URLINSTANCE;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.TextBox pswbox;
        private System.Windows.Forms.TextBox usertextBox;
        private System.Windows.Forms.TextBox pswtextBox;
        private System.Windows.Forms.TextBox loginfail;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}

