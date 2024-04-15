namespace DietPlanner
{
    partial class FoodPreferences
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
            this.category = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // category
            // 
            this.category.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.category.FormattingEnabled = true;
            this.category.ItemHeight = 20;
            this.category.Items.AddRange(new object[] {
            "     ΚΑΤΗΓΟΡΙΑ",
            "",
            "ΨΑΡΙΑ",
            "ΖΩΙΚΑ ΠΡΟΪΌΝΤΑ",
            "ΛΑΧΑΝΙΚΑ",
            "ΞΗΡΟΙ ΚΑΡΠΟΙ"});
            this.category.Location = new System.Drawing.Point(-2, -5);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(205, 184);
            this.category.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "     ΦΑΓΗΤΑ",
            "",
            "ΓΑΛΑ 1,5%",
            "ΑΥΓΟ(Μ)",
            "ΜΑΡΟΥΛΙ",
            "ΤΟΝΟΣ"});
            this.listBox1.Location = new System.Drawing.Point(209, -5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 184);
            this.listBox1.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Items.AddRange(new object[] {
            "     ΓΕΥΜΑΤΑ",
            "",
            "ΟΜΕΛΕΤΑ",
            "ΤΟΝΟΣΑΛΑΤΑ"});
            this.listBox2.Location = new System.Drawing.Point(421, -5);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(205, 184);
            this.listBox2.TabIndex = 2;
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Items.AddRange(new object[] {
            "     ΤΥΠΟΙ ΓΕΥΜΑΤΩΝ",
            "",
            "ΕΠΙΔΟΡΠΙΟ",
            "ΚΡΕΠΑΛΗ"});
            this.listBox3.Location = new System.Drawing.Point(631, -5);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(205, 184);
            this.listBox3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button1.Location = new System.Drawing.Point(600, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "ΕΙΣΑΓΩΓΗ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FoodPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 286);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.category);
            this.Name = "FoodPreferences";
            this.Text = "FoodPreferences";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox category;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button1;
    }
}