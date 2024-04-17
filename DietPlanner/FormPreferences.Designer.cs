namespace DietPlanner
{
    partial class FormPreferences
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
            this.listBoxCategories = new System.Windows.Forms.ListBox();
            this.listBoxFoods = new System.Windows.Forms.ListBox();
            this.listBoxMeals = new System.Windows.Forms.ListBox();
            this.listBoxMealTypes = new System.Windows.Forms.ListBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.ItemHeight = 17;
            this.listBoxCategories.Items.AddRange(new object[] {
            "ΨΑΡΙΑ",
            "ΖΩΙΚΑ ΠΡΟΪΌΝΤΑ",
            "ΛΑΧΑΝΙΚΑ",
            "ΞΗΡΟΙ ΚΑΡΠΟΙ"});
            this.listBoxCategories.Location = new System.Drawing.Point(11, 28);
            this.listBoxCategories.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(200, 463);
            this.listBoxCategories.TabIndex = 0;
            // 
            // listBoxFoods
            // 
            this.listBoxFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxFoods.FormattingEnabled = true;
            this.listBoxFoods.ItemHeight = 17;
            this.listBoxFoods.Items.AddRange(new object[] {
            "ΓΑΛΑ 1,5%",
            "ΑΥΓΟ(Μ)",
            "ΜΑΡΟΥΛΙ",
            "ΤΟΝΟΣ"});
            this.listBoxFoods.Location = new System.Drawing.Point(215, 28);
            this.listBoxFoods.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxFoods.Name = "listBoxFoods";
            this.listBoxFoods.Size = new System.Drawing.Size(200, 463);
            this.listBoxFoods.TabIndex = 1;
            // 
            // listBoxMeals
            // 
            this.listBoxMeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxMeals.FormattingEnabled = true;
            this.listBoxMeals.ItemHeight = 17;
            this.listBoxMeals.Items.AddRange(new object[] {
            "ΟΜΕΛΕΤΑ",
            "ΤΟΝΟΣΑΛΑΤΑ"});
            this.listBoxMeals.Location = new System.Drawing.Point(419, 28);
            this.listBoxMeals.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxMeals.Name = "listBoxMeals";
            this.listBoxMeals.Size = new System.Drawing.Size(200, 463);
            this.listBoxMeals.TabIndex = 2;
            // 
            // listBoxMealTypes
            // 
            this.listBoxMealTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxMealTypes.FormattingEnabled = true;
            this.listBoxMealTypes.ItemHeight = 17;
            this.listBoxMealTypes.Items.AddRange(new object[] {
            "ΕΠΙΔΟΡΠΙΟ",
            "ΚΡΕΠΑΛΗ"});
            this.listBoxMealTypes.Location = new System.Drawing.Point(623, 28);
            this.listBoxMealTypes.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxMealTypes.Name = "listBoxMealTypes";
            this.listBoxMealTypes.Size = new System.Drawing.Size(200, 463);
            this.listBoxMealTypes.TabIndex = 3;
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.buttonInsert.Location = new System.Drawing.Point(708, 505);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(115, 43);
            this.buttonInsert.TabIndex = 5;
            this.buttonInsert.Text = "ΕΙΣΑΓΩΓΗ";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.listBoxMealTypes);
            this.Controls.Add(this.listBoxMeals);
            this.Controls.Add(this.listBoxFoods);
            this.Controls.Add(this.listBoxCategories);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPreferences";
            this.Text = "FoodPreferences";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCategories;
        private System.Windows.Forms.ListBox listBoxFoods;
        private System.Windows.Forms.ListBox listBoxMeals;
        private System.Windows.Forms.ListBox listBoxMealTypes;
        private System.Windows.Forms.Button buttonInsert;
    }
}