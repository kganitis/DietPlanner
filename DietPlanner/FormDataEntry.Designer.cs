namespace DietPlanner
{
    partial class FormDataEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataEntry));
            this.patientNameTextBox = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.labelWeight = new System.Windows.Forms.Label();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.labelActivityLevel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxGoal = new System.Windows.Forms.ComboBox();
            this.btnAddPreferred = new System.Windows.Forms.Button();
            this.btnRemovePreferred = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddAvoided = new System.Windows.Forms.Button();
            this.btnRemoveAvoided = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnGeneratePlan = new System.Windows.Forms.Button();
            this.listBoxPreferred = new System.Windows.Forms.ListBox();
            this.listBoxAvoided = new System.Windows.Forms.ListBox();
            this.maleRadioButton = new System.Windows.Forms.RadioButton();
            this.femaleRadioButton = new System.Windows.Forms.RadioButton();
            this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxActivityLevel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // patientNameTextBox
            // 
            this.patientNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.patientNameTextBox.Location = new System.Drawing.Point(213, 81);
            this.patientNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.patientNameTextBox.Name = "patientNameTextBox";
            this.patientNameTextBox.Size = new System.Drawing.Size(224, 26);
            this.patientNameTextBox.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelTitle.Location = new System.Drawing.Point(335, 20);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(398, 26);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "ΕΙΣΑΓΩΓΗ ΣΤΟΙΧΕΙΩΝ ΑΣΘΕΝΟΥΣ";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelName.Location = new System.Drawing.Point(28, 81);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(157, 24);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Ονοματεπώνυμο";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelGender.Location = new System.Drawing.Point(28, 137);
            this.labelGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(58, 24);
            this.labelGender.TabIndex = 3;
            this.labelGender.Text = "Φύλο";
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelPhoneNumber.Location = new System.Drawing.Point(28, 197);
            this.labelPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(101, 24);
            this.labelPhoneNumber.TabIndex = 5;
            this.labelPhoneNumber.Text = "Τηλέφωνο";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.phoneTextBox.Location = new System.Drawing.Point(213, 197);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(224, 26);
            this.phoneTextBox.TabIndex = 6;
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelDateOfBirth.Location = new System.Drawing.Point(28, 255);
            this.labelDateOfBirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(160, 24);
            this.labelDateOfBirth.TabIndex = 7;
            this.labelDateOfBirth.Text = "Ημ/νία Γέννησης";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelHeight.Location = new System.Drawing.Point(28, 314);
            this.labelHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(100, 24);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Ύψος (εκ.)";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.heightTextBox.Location = new System.Drawing.Point(213, 314);
            this.heightTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 26);
            this.heightTextBox.TabIndex = 10;
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelWeight.Location = new System.Drawing.Point(28, 377);
            this.labelWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(118, 24);
            this.labelWeight.TabIndex = 11;
            this.labelWeight.Text = "Βάρος (κιλά)";
            // 
            // weightTextBox
            // 
            this.weightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.weightTextBox.Location = new System.Drawing.Point(213, 375);
            this.weightTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 26);
            this.weightTextBox.TabIndex = 12;
            // 
            // labelActivityLevel
            // 
            this.labelActivityLevel.AutoSize = true;
            this.labelActivityLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelActivityLevel.Location = new System.Drawing.Point(28, 438);
            this.labelActivityLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelActivityLevel.Name = "labelActivityLevel";
            this.labelActivityLevel.Size = new System.Drawing.Size(160, 48);
            this.labelActivityLevel.TabIndex = 13;
            this.labelActivityLevel.Text = "Επίπεδο\r\nΔραστηριότητας";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.Location = new System.Drawing.Point(572, 139);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 24);
            this.label9.TabIndex = 15;
            this.label9.Text = "Στόχος";
            // 
            // comboBoxGoal
            // 
            this.comboBoxGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.comboBoxGoal.FormattingEnabled = true;
            this.comboBoxGoal.Location = new System.Drawing.Point(663, 137);
            this.comboBoxGoal.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGoal.Name = "comboBoxGoal";
            this.comboBoxGoal.Size = new System.Drawing.Size(222, 28);
            this.comboBoxGoal.TabIndex = 16;
            // 
            // btnAddPreferred
            // 
            this.btnAddPreferred.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPreferred.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPreferred.BackgroundImage")));
            this.btnAddPreferred.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPreferred.Location = new System.Drawing.Point(627, 393);
            this.btnAddPreferred.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPreferred.Name = "btnAddPreferred";
            this.btnAddPreferred.Size = new System.Drawing.Size(32, 32);
            this.btnAddPreferred.TabIndex = 18;
            this.btnAddPreferred.UseVisualStyleBackColor = false;
            this.btnAddPreferred.Click += new System.EventHandler(this.btnAddPreferred_Click);
            // 
            // btnRemovePreferred
            // 
            this.btnRemovePreferred.BackColor = System.Drawing.Color.Transparent;
            this.btnRemovePreferred.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemovePreferred.BackgroundImage")));
            this.btnRemovePreferred.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemovePreferred.Location = new System.Drawing.Point(663, 393);
            this.btnRemovePreferred.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemovePreferred.Name = "btnRemovePreferred";
            this.btnRemovePreferred.Size = new System.Drawing.Size(32, 32);
            this.btnRemovePreferred.TabIndex = 19;
            this.btnRemovePreferred.UseVisualStyleBackColor = false;
            this.btnRemovePreferred.Click += new System.EventHandler(this.btnRemovePreferred_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.Location = new System.Drawing.Point(522, 232);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Προτιμώμενα Φαγητά";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.Location = new System.Drawing.Point(776, 232);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Φαγητά προς Αποφυγή";
            // 
            // btnAddAvoided
            // 
            this.btnAddAvoided.BackColor = System.Drawing.Color.Transparent;
            this.btnAddAvoided.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAvoided.BackgroundImage")));
            this.btnAddAvoided.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddAvoided.Location = new System.Drawing.Point(887, 392);
            this.btnAddAvoided.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAvoided.Name = "btnAddAvoided";
            this.btnAddAvoided.Size = new System.Drawing.Size(32, 32);
            this.btnAddAvoided.TabIndex = 24;
            this.btnAddAvoided.UseVisualStyleBackColor = false;
            this.btnAddAvoided.Click += new System.EventHandler(this.btnAddAvoided_Click);
            // 
            // btnRemoveAvoided
            // 
            this.btnRemoveAvoided.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveAvoided.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveAvoided.BackgroundImage")));
            this.btnRemoveAvoided.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveAvoided.Location = new System.Drawing.Point(923, 392);
            this.btnRemoveAvoided.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveAvoided.Name = "btnRemoveAvoided";
            this.btnRemoveAvoided.Size = new System.Drawing.Size(32, 32);
            this.btnRemoveAvoided.TabIndex = 25;
            this.btnRemoveAvoided.UseVisualStyleBackColor = false;
            this.btnRemoveAvoided.Click += new System.EventHandler(this.btnRemoveAvoided_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSaveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSaveData.Location = new System.Drawing.Point(213, 515);
            this.btnSaveData.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(224, 52);
            this.btnSaveData.TabIndex = 26;
            this.btnSaveData.Text = "Αποθήκευση Στοιχείων";
            this.btnSaveData.UseVisualStyleBackColor = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnGeneratePlan
            // 
            this.btnGeneratePlan.BackColor = System.Drawing.Color.LimeGreen;
            this.btnGeneratePlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnGeneratePlan.Location = new System.Drawing.Point(647, 515);
            this.btnGeneratePlan.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneratePlan.Name = "btnGeneratePlan";
            this.btnGeneratePlan.Size = new System.Drawing.Size(308, 52);
            this.btnGeneratePlan.TabIndex = 27;
            this.btnGeneratePlan.Text = "Έκδοση Εβδομαδιαίου Πλάνου";
            this.btnGeneratePlan.UseVisualStyleBackColor = false;
            this.btnGeneratePlan.Click += new System.EventHandler(this.btnGeneratePlan_Click);
            // 
            // listBoxPreferred
            // 
            this.listBoxPreferred.FormattingEnabled = true;
            this.listBoxPreferred.Location = new System.Drawing.Point(529, 255);
            this.listBoxPreferred.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPreferred.Name = "listBoxPreferred";
            this.listBoxPreferred.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxPreferred.Size = new System.Drawing.Size(166, 134);
            this.listBoxPreferred.TabIndex = 28;
            // 
            // listBoxAvoided
            // 
            this.listBoxAvoided.FormattingEnabled = true;
            this.listBoxAvoided.Location = new System.Drawing.Point(789, 254);
            this.listBoxAvoided.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAvoided.Name = "listBoxAvoided";
            this.listBoxAvoided.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAvoided.Size = new System.Drawing.Size(166, 134);
            this.listBoxAvoided.TabIndex = 29;
            // 
            // maleRadioButton
            // 
            this.maleRadioButton.AutoSize = true;
            this.maleRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.maleRadioButton.Location = new System.Drawing.Point(213, 137);
            this.maleRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.maleRadioButton.Name = "maleRadioButton";
            this.maleRadioButton.Size = new System.Drawing.Size(100, 24);
            this.maleRadioButton.TabIndex = 30;
            this.maleRadioButton.TabStop = true;
            this.maleRadioButton.Text = "Αρσενικό";
            this.maleRadioButton.UseVisualStyleBackColor = true;
            // 
            // femaleRadioButton
            // 
            this.femaleRadioButton.AutoSize = true;
            this.femaleRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.femaleRadioButton.Location = new System.Drawing.Point(317, 137);
            this.femaleRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.Size = new System.Drawing.Size(89, 24);
            this.femaleRadioButton.TabIndex = 31;
            this.femaleRadioButton.TabStop = true;
            this.femaleRadioButton.Text = "Θηλυκό";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // birthDatePicker
            // 
            this.birthDatePicker.CustomFormat = "\"dd/MM/yyyy\"";
            this.birthDatePicker.Location = new System.Drawing.Point(213, 259);
            this.birthDatePicker.Name = "birthDatePicker";
            this.birthDatePicker.Size = new System.Drawing.Size(138, 20);
            this.birthDatePicker.TabIndex = 32;
            // 
            // comboBoxActivityLevel
            // 
            this.comboBoxActivityLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxActivityLevel.FormattingEnabled = true;
            this.comboBoxActivityLevel.Location = new System.Drawing.Point(213, 447);
            this.comboBoxActivityLevel.Name = "comboBoxActivityLevel";
            this.comboBoxActivityLevel.Size = new System.Drawing.Size(224, 28);
            this.comboBoxActivityLevel.TabIndex = 33;
            // 
            // FormDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 600);
            this.Controls.Add(this.comboBoxActivityLevel);
            this.Controls.Add(this.birthDatePicker);
            this.Controls.Add(this.femaleRadioButton);
            this.Controls.Add(this.maleRadioButton);
            this.Controls.Add(this.listBoxAvoided);
            this.Controls.Add(this.listBoxPreferred);
            this.Controls.Add(this.btnGeneratePlan);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.btnRemoveAvoided);
            this.Controls.Add(this.btnAddAvoided);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRemovePreferred);
            this.Controls.Add(this.btnAddPreferred);
            this.Controls.Add(this.comboBoxGoal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelActivityLevel);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelDateOfBirth);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.patientNameTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDataEntry";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FormDataEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox patientNameTextBox;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.Label labelActivityLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxGoal;
        private System.Windows.Forms.Button btnAddPreferred;
        private System.Windows.Forms.Button btnRemovePreferred;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddAvoided;
        private System.Windows.Forms.Button btnRemoveAvoided;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnGeneratePlan;
        private System.Windows.Forms.ListBox listBoxPreferred;
        private System.Windows.Forms.ListBox listBoxAvoided;
        private System.Windows.Forms.RadioButton maleRadioButton;
        private System.Windows.Forms.RadioButton femaleRadioButton;
        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.ComboBox comboBoxActivityLevel;
    }
}