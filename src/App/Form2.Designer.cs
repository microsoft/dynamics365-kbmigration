namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.getcustfields = new System.Windows.Forms.Button();
            this.Custfieldslistbox = new System.Windows.Forms.CheckedListBox();
            this.Migratekbs = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.skiparticle = new System.Windows.Forms.TextBox();
            this.migratearticle = new System.Windows.Forms.TextBox();
            this.Created = new System.Windows.Forms.TextBox();
            this.Skipped = new System.Windows.Forms.TextBox();
            this.exportlog = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Failed = new System.Windows.Forms.TextBox();
            this.failedarticle = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // getcustfields
            // 
            this.getcustfields.Location = new System.Drawing.Point(49, 506);
            this.getcustfields.Name = "getcustfields";
            this.getcustfields.Size = new System.Drawing.Size(228, 54);
            this.getcustfields.TabIndex = 0;
            this.getcustfields.Text = "Get Custom Fields";
            this.getcustfields.UseVisualStyleBackColor = true;
            this.getcustfields.Click += new System.EventHandler(this.getcustfields_Click);
            // 
            // Custfieldslistbox
            // 
            this.Custfieldslistbox.FormattingEnabled = true;
            this.Custfieldslistbox.Location = new System.Drawing.Point(49, 40);
            this.Custfieldslistbox.Name = "Custfieldslistbox";
            this.Custfieldslistbox.Size = new System.Drawing.Size(228, 316);
            this.Custfieldslistbox.TabIndex = 1;
            // 
            // Migratekbs
            // 
            this.Migratekbs.Location = new System.Drawing.Point(489, 506);
            this.Migratekbs.Name = "Migratekbs";
            this.Migratekbs.Size = new System.Drawing.Size(219, 54);
            this.Migratekbs.TabIndex = 2;
            this.Migratekbs.Text = "Start Migration";
            this.Migratekbs.UseVisualStyleBackColor = true;
            this.Migratekbs.Click += new System.EventHandler(this.Migratekbs_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 396);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(292, 77);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Select Custom Fields to include in Migration. \r\n<<THE CUSTOM FIELDS MUST ALSO EXI" +
    "ST ON THE DESTINATION ENTITIES>>\r\n";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(991, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // skiparticle
            // 
            this.skiparticle.Location = new System.Drawing.Point(595, 388);
            this.skiparticle.Name = "skiparticle";
            this.skiparticle.Size = new System.Drawing.Size(176, 31);
            this.skiparticle.TabIndex = 6;
            this.skiparticle.Text = "0";
            // 
            // migratearticle
            // 
            this.migratearticle.Location = new System.Drawing.Point(595, 345);
            this.migratearticle.Name = "migratearticle";
            this.migratearticle.Size = new System.Drawing.Size(176, 31);
            this.migratearticle.TabIndex = 7;
            this.migratearticle.Text = "0";
            this.migratearticle.TextChanged += new System.EventHandler(this.migratearticle_TextChanged);
            // 
            // Created
            // 
            this.Created.Location = new System.Drawing.Point(489, 345);
            this.Created.Name = "Created";
            this.Created.ReadOnly = true;
            this.Created.Size = new System.Drawing.Size(100, 31);
            this.Created.TabIndex = 8;
            this.Created.Text = "Created:";
            // 
            // Skipped
            // 
            this.Skipped.Location = new System.Drawing.Point(489, 388);
            this.Skipped.Name = "Skipped";
            this.Skipped.ReadOnly = true;
            this.Skipped.Size = new System.Drawing.Size(100, 31);
            this.Skipped.TabIndex = 9;
            this.Skipped.Text = "Skipped:";
            // 
            // exportlog
            // 
            this.exportlog.Location = new System.Drawing.Point(907, 352);
            this.exportlog.Name = "exportlog";
            this.exportlog.Size = new System.Drawing.Size(182, 34);
            this.exportlog.TabIndex = 10;
            this.exportlog.Text = "Export Log";
            this.exportlog.UseVisualStyleBackColor = true;
            this.exportlog.Click += new System.EventHandler(this.exportlog_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(489, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(600, 279);
            this.listBox1.TabIndex = 11;
            // 
            // Failed
            // 
            this.Failed.Location = new System.Drawing.Point(489, 442);
            this.Failed.Name = "Failed";
            this.Failed.ReadOnly = true;
            this.Failed.Size = new System.Drawing.Size(100, 31);
            this.Failed.TabIndex = 12;
            this.Failed.Text = "Failed:";
            // 
            // failedarticle
            // 
            this.failedarticle.Location = new System.Drawing.Point(595, 442);
            this.failedarticle.Name = "failedarticle";
            this.failedarticle.Size = new System.Drawing.Size(176, 31);
            this.failedarticle.TabIndex = 13;
            this.failedarticle.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1013, 610);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(76, 31);
            this.textBox4.TabIndex = 14;
            this.textBox4.Text = "V 1.0";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(1128, 653);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.failedarticle);
            this.Controls.Add(this.Failed);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.exportlog);
            this.Controls.Add(this.Skipped);
            this.Controls.Add(this.Created);
            this.Controls.Add(this.migratearticle);
            this.Controls.Add(this.skiparticle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Migratekbs);
            this.Controls.Add(this.Custfieldslistbox);
            this.Controls.Add(this.getcustfields);
            this.Name = "Form2";
            this.Text = "KB Migration Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getcustfields;
        private System.Windows.Forms.CheckedListBox Custfieldslistbox;
        private System.Windows.Forms.Button Migratekbs;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox skiparticle;
        private System.Windows.Forms.TextBox migratearticle;
        private new System.Windows.Forms.TextBox Created;
        private System.Windows.Forms.TextBox Skipped;
        private System.Windows.Forms.Button exportlog;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox Failed;
        private System.Windows.Forms.TextBox failedarticle;
        private System.Windows.Forms.TextBox textBox4;
    }
}