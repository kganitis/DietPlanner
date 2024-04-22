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
            this.listBoxFoods = new System.Windows.Forms.ListBox();
            this.listBoxMeals = new System.Windows.Forms.ListBox();
            this.listBoxMealTypes = new System.Windows.Forms.ListBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.treeViewFoodCategories = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // listBoxFoods
            // 
            this.listBoxFoods.DisplayMember = "Name";
            this.listBoxFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxFoods.FormattingEnabled = true;
            this.listBoxFoods.ItemHeight = 20;
            this.listBoxFoods.Location = new System.Drawing.Point(215, 28);
            this.listBoxFoods.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxFoods.Name = "listBoxFoods";
            this.listBoxFoods.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxFoods.Size = new System.Drawing.Size(200, 464);
            this.listBoxFoods.TabIndex = 1;
            // 
            // listBoxMeals
            // 
            this.listBoxMeals.DisplayMember = "Name";
            this.listBoxMeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxMeals.FormattingEnabled = true;
            this.listBoxMeals.ItemHeight = 20;
            this.listBoxMeals.Location = new System.Drawing.Point(419, 28);
            this.listBoxMeals.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxMeals.Name = "listBoxMeals";
            this.listBoxMeals.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxMeals.Size = new System.Drawing.Size(200, 464);
            this.listBoxMeals.TabIndex = 2;
            // 
            // listBoxMealTypes
            // 
            this.listBoxMealTypes.DisplayMember = "Name";
            this.listBoxMealTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxMealTypes.FormattingEnabled = true;
            this.listBoxMealTypes.ItemHeight = 20;
            this.listBoxMealTypes.Location = new System.Drawing.Point(623, 28);
            this.listBoxMealTypes.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxMealTypes.Name = "listBoxMealTypes";
            this.listBoxMealTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxMealTypes.Size = new System.Drawing.Size(200, 464);
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
            // treeViewFoodCategories
            // 
            this.treeViewFoodCategories.CheckBoxes = true;
            this.treeViewFoodCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.treeViewFoodCategories.Location = new System.Drawing.Point(10, 28);
            this.treeViewFoodCategories.Name = "treeViewFoodCategories";
            this.treeViewFoodCategories.Size = new System.Drawing.Size(200, 464);
            this.treeViewFoodCategories.TabIndex = 6;
            this.treeViewFoodCategories.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFoodCategories_AfterCheck);
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.treeViewFoodCategories);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.listBoxMealTypes);
            this.Controls.Add(this.listBoxMeals);
            this.Controls.Add(this.listBoxFoods);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPreferences";
            this.Text = "Diet Planner";
            this.Load += new System.EventHandler(this.FormPreferences_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxFoods;
        private System.Windows.Forms.ListBox listBoxMeals;
        private System.Windows.Forms.ListBox listBoxMealTypes;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.TreeView treeViewFoodCategories;
    }
}