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
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelFoods = new System.Windows.Forms.Label();
            this.labelMeals = new System.Windows.Forms.Label();
            this.labelMealTypes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.ItemHeight = 20;
            this.listBoxCategories.Location = new System.Drawing.Point(15, 34);
            this.listBoxCategories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(265, 564);
            this.listBoxCategories.TabIndex = 0;
            // 
            // listBoxFoods
            // 
            this.listBoxFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxFoods.FormattingEnabled = true;
            this.listBoxFoods.ItemHeight = 20;
            this.listBoxFoods.Location = new System.Drawing.Point(287, 34);
            this.listBoxFoods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxFoods.Name = "listBoxFoods";
            this.listBoxFoods.Size = new System.Drawing.Size(265, 564);
            this.listBoxFoods.TabIndex = 1;
            // 
            // listBoxMeals
            // 
            this.listBoxMeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxMeals.FormattingEnabled = true;
            this.listBoxMeals.ItemHeight = 20;
            this.listBoxMeals.Location = new System.Drawing.Point(559, 34);
            this.listBoxMeals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxMeals.Name = "listBoxMeals";
            this.listBoxMeals.Size = new System.Drawing.Size(265, 564);
            this.listBoxMeals.TabIndex = 2;
            // 
            // listBoxMealTypes
            // 
            this.listBoxMealTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxMealTypes.FormattingEnabled = true;
            this.listBoxMealTypes.ItemHeight = 20;
            this.listBoxMealTypes.Location = new System.Drawing.Point(831, 34);
            this.listBoxMealTypes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxMealTypes.Name = "listBoxMealTypes";
            this.listBoxMealTypes.Size = new System.Drawing.Size(265, 564);
            this.listBoxMealTypes.TabIndex = 3;
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.buttonInsert.Location = new System.Drawing.Point(944, 622);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(153, 53);
            this.buttonInsert.TabIndex = 5;
            this.buttonInsert.Text = "ΕΙΣΑΓΩΓΗ";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelCategory.Location = new System.Drawing.Point(39, 3);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(157, 29);
            this.labelCategory.TabIndex = 6;
            this.labelCategory.Text = "ΚΑΤΗΓΟΡΙΑ";
            // 
            // labelFoods
            // 
            this.labelFoods.AutoSize = true;
            this.labelFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelFoods.Location = new System.Drawing.Point(357, 3);
            this.labelFoods.Name = "labelFoods";
            this.labelFoods.Size = new System.Drawing.Size(116, 29);
            this.labelFoods.TabIndex = 7;
            this.labelFoods.Text = "ΦΑΓΗΤΑ";
            // 
            // labelMeals
            // 
            this.labelMeals.AutoSize = true;
            this.labelMeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelMeals.Location = new System.Drawing.Point(596, 3);
            this.labelMeals.Name = "labelMeals";
            this.labelMeals.Size = new System.Drawing.Size(133, 29);
            this.labelMeals.TabIndex = 8;
            this.labelMeals.Text = "ΓΕΥΜΑΤΑ";
            // 
            // labelMealTypes
            // 
            this.labelMealTypes.AutoSize = true;
            this.labelMealTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelMealTypes.Location = new System.Drawing.Point(842, 3);
            this.labelMealTypes.Name = "labelMealTypes";
            this.labelMealTypes.Size = new System.Drawing.Size(242, 29);
            this.labelMealTypes.TabIndex = 9;
            this.labelMealTypes.Text = "ΤΥΠΟΙ ΓΕΥΜΑΤΩΝ";
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 690);
            this.Controls.Add(this.labelMealTypes);
            this.Controls.Add(this.labelMeals);
            this.Controls.Add(this.labelFoods);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.listBoxMealTypes);
            this.Controls.Add(this.listBoxMeals);
            this.Controls.Add(this.listBoxFoods);
            this.Controls.Add(this.listBoxCategories);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPreferences";
            this.Text = "FoodPreferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCategories;
        private System.Windows.Forms.ListBox listBoxFoods;
        private System.Windows.Forms.ListBox listBoxMeals;
        private System.Windows.Forms.ListBox listBoxMealTypes;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelFoods;
        private System.Windows.Forms.Label labelMeals;
        private System.Windows.Forms.Label labelMealTypes;
    }
}