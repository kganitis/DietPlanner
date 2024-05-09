namespace DietPlanner.View
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
            this.labelCategories = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxFoods
            // 
            this.listBoxFoods.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxFoods.DisplayMember = "Name";
            this.listBoxFoods.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFoods.FormattingEnabled = true;
            this.listBoxFoods.ItemHeight = 20;
            this.listBoxFoods.Location = new System.Drawing.Point(215, 37);
            this.listBoxFoods.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxFoods.Name = "listBoxFoods";
            this.listBoxFoods.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxFoods.Size = new System.Drawing.Size(200, 464);
            this.listBoxFoods.TabIndex = 1;
            // 
            // listBoxMeals
            // 
            this.listBoxMeals.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxMeals.DisplayMember = "Name";
            this.listBoxMeals.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMeals.FormattingEnabled = true;
            this.listBoxMeals.ItemHeight = 20;
            this.listBoxMeals.Location = new System.Drawing.Point(419, 37);
            this.listBoxMeals.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxMeals.Name = "listBoxMeals";
            this.listBoxMeals.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxMeals.Size = new System.Drawing.Size(200, 464);
            this.listBoxMeals.TabIndex = 2;
            // 
            // listBoxMealTypes
            // 
            this.listBoxMealTypes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxMealTypes.DisplayMember = "Name";
            this.listBoxMealTypes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMealTypes.FormattingEnabled = true;
            this.listBoxMealTypes.ItemHeight = 20;
            this.listBoxMealTypes.Location = new System.Drawing.Point(623, 37);
            this.listBoxMealTypes.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxMealTypes.Name = "listBoxMealTypes";
            this.listBoxMealTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxMealTypes.Size = new System.Drawing.Size(200, 464);
            this.listBoxMealTypes.TabIndex = 3;
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonInsert.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonInsert.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonInsert.Location = new System.Drawing.Point(708, 510);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(115, 43);
            this.buttonInsert.TabIndex = 5;
            this.buttonInsert.Text = "Εισαγωγή";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // treeViewFoodCategories
            // 
            this.treeViewFoodCategories.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.treeViewFoodCategories.CheckBoxes = true;
            this.treeViewFoodCategories.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewFoodCategories.Location = new System.Drawing.Point(10, 37);
            this.treeViewFoodCategories.Name = "treeViewFoodCategories";
            this.treeViewFoodCategories.Size = new System.Drawing.Size(200, 464);
            this.treeViewFoodCategories.TabIndex = 6;
            this.treeViewFoodCategories.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFoodCategories_AfterCheck);
            // 
            // labelCategories
            // 
            this.labelCategories.AutoSize = true;
            this.labelCategories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategories.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCategories.Location = new System.Drawing.Point(63, 14);
            this.labelCategories.Name = "labelCategories";
            this.labelCategories.Size = new System.Drawing.Size(98, 21);
            this.labelCategories.TabIndex = 7;
            this.labelCategories.Text = "Κατηγορίες";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(286, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Τρόφιμα";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(484, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Γεύματα";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(645, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ειδικές προτιμήσεις";
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCategories);
            this.Controls.Add(this.treeViewFoodCategories);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.listBoxMealTypes);
            this.Controls.Add(this.listBoxMeals);
            this.Controls.Add(this.listBoxFoods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPreferences";
            this.Text = "Diet Planner";
            this.Load += new System.EventHandler(this.FormPreferences_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxFoods;
        private System.Windows.Forms.ListBox listBoxMeals;
        private System.Windows.Forms.ListBox listBoxMealTypes;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.TreeView treeViewFoodCategories;
        private System.Windows.Forms.Label labelCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}