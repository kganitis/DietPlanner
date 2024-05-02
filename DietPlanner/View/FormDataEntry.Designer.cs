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
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientNameTextBox
            // 
            this.patientNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.patientNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.patientNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.patientNameTextBox.Location = new System.Drawing.Point(213, 148);
            this.patientNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.patientNameTextBox.Name = "patientNameTextBox";
            this.patientNameTextBox.Size = new System.Drawing.Size(224, 29);
            this.patientNameTextBox.TabIndex = 0;
            this.patientNameTextBox.TextChanged += new System.EventHandler(this.UpdateSearchButtonState);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelTitle.Location = new System.Drawing.Point(27, 24);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(306, 30);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Εισαγωγή Στοιχείων Ασθενούς";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelName.Location = new System.Drawing.Point(28, 151);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(138, 21);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Ονοματεπώνυμο";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelGender.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelGender.Location = new System.Drawing.Point(30, 196);
            this.labelGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(50, 21);
            this.labelGender.TabIndex = 3;
            this.labelGender.Text = "Φύλο";
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelPhoneNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPhoneNumber.Location = new System.Drawing.Point(28, 243);
            this.labelPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(86, 21);
            this.labelPhoneNumber.TabIndex = 5;
            this.labelPhoneNumber.Text = "Τηλέφωνο";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.phoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phoneTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.phoneTextBox.Location = new System.Drawing.Point(213, 240);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(224, 29);
            this.phoneTextBox.TabIndex = 6;
            this.phoneTextBox.TextChanged += new System.EventHandler(this.UpdateSearchButtonState);
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelDateOfBirth.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelDateOfBirth.Location = new System.Drawing.Point(28, 292);
            this.labelDateOfBirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(133, 21);
            this.labelDateOfBirth.TabIndex = 7;
            this.labelDateOfBirth.Text = "Ημ/νία Γέννησης";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelHeight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHeight.Location = new System.Drawing.Point(28, 343);
            this.labelHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(84, 21);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Ύψος (εκ.)";
            // 
            // heightTextBox
            // 
            this.heightTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.heightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heightTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.heightTextBox.Location = new System.Drawing.Point(213, 340);
            this.heightTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 29);
            this.heightTextBox.TabIndex = 10;
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelWeight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelWeight.Location = new System.Drawing.Point(28, 391);
            this.labelWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(105, 21);
            this.labelWeight.TabIndex = 11;
            this.labelWeight.Text = "Βάρος (κιλά)";
            // 
            // weightTextBox
            // 
            this.weightTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.weightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weightTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.weightTextBox.Location = new System.Drawing.Point(213, 387);
            this.weightTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 29);
            this.weightTextBox.TabIndex = 12;
            // 
            // labelActivityLevel
            // 
            this.labelActivityLevel.AutoSize = true;
            this.labelActivityLevel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelActivityLevel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelActivityLevel.Location = new System.Drawing.Point(28, 438);
            this.labelActivityLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelActivityLevel.Name = "labelActivityLevel";
            this.labelActivityLevel.Size = new System.Drawing.Size(135, 42);
            this.labelActivityLevel.TabIndex = 13;
            this.labelActivityLevel.Text = "Επίπεδο\r\nΔραστηριότητας";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(505, 100);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 21);
            this.label9.TabIndex = 15;
            this.label9.Text = "Στόχος";
            // 
            // comboBoxGoal
            // 
            this.comboBoxGoal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxGoal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGoal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.comboBoxGoal.FormattingEnabled = true;
            this.comboBoxGoal.Location = new System.Drawing.Point(596, 98);
            this.comboBoxGoal.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGoal.Name = "comboBoxGoal";
            this.comboBoxGoal.Size = new System.Drawing.Size(222, 29);
            this.comboBoxGoal.TabIndex = 16;
            // 
            // btnAddPreferred
            // 
            this.btnAddPreferred.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPreferred.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPreferred.BackgroundImage")));
            this.btnAddPreferred.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPreferred.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPreferred.Location = new System.Drawing.Point(596, 434);
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
            this.btnRemovePreferred.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemovePreferred.Location = new System.Drawing.Point(632, 434);
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
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(493, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 21);
            this.label10.TabIndex = 21;
            this.label10.Text = "Προτιμώμενα Φαγητά";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(676, 169);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 21);
            this.label11.TabIndex = 22;
            this.label11.Text = "Φαγητά προς Αποφυγή";
            // 
            // btnAddAvoided
            // 
            this.btnAddAvoided.BackColor = System.Drawing.Color.Transparent;
            this.btnAddAvoided.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAvoided.BackgroundImage")));
            this.btnAddAvoided.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddAvoided.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAvoided.Location = new System.Drawing.Point(784, 433);
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
            this.btnRemoveAvoided.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveAvoided.Location = new System.Drawing.Point(820, 433);
            this.btnRemoveAvoided.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveAvoided.Name = "btnRemoveAvoided";
            this.btnRemoveAvoided.Size = new System.Drawing.Size(32, 32);
            this.btnRemoveAvoided.TabIndex = 25;
            this.btnRemoveAvoided.UseVisualStyleBackColor = false;
            this.btnRemoveAvoided.Click += new System.EventHandler(this.btnRemoveAvoided_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveData.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveData.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveData.Location = new System.Drawing.Point(260, 23);
            this.btnSaveData.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(177, 52);
            this.btnSaveData.TabIndex = 26;
            this.btnSaveData.Text = "Αποθήκευση Στοιχείων";
            this.btnSaveData.UseVisualStyleBackColor = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnGeneratePlan
            // 
            this.btnGeneratePlan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGeneratePlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneratePlan.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGeneratePlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePlan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePlan.Location = new System.Drawing.Point(614, 23);
            this.btnGeneratePlan.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneratePlan.Name = "btnGeneratePlan";
            this.btnGeneratePlan.Size = new System.Drawing.Size(238, 52);
            this.btnGeneratePlan.TabIndex = 27;
            this.btnGeneratePlan.Text = "Έκδοση Εβδομαδιαίου Πλάνου";
            this.btnGeneratePlan.UseVisualStyleBackColor = false;
            this.btnGeneratePlan.Click += new System.EventHandler(this.btnViewOrGeneratePlan_Click);
            // 
            // listBoxPreferred
            // 
            this.listBoxPreferred.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxPreferred.DisplayMember = "Name";
            this.listBoxPreferred.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxPreferred.FormattingEnabled = true;
            this.listBoxPreferred.ItemHeight = 21;
            this.listBoxPreferred.Location = new System.Drawing.Point(498, 197);
            this.listBoxPreferred.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPreferred.Name = "listBoxPreferred";
            this.listBoxPreferred.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxPreferred.Size = new System.Drawing.Size(166, 235);
            this.listBoxPreferred.TabIndex = 28;
            // 
            // listBoxAvoided
            // 
            this.listBoxAvoided.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxAvoided.DisplayMember = "Name";
            this.listBoxAvoided.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBoxAvoided.FormattingEnabled = true;
            this.listBoxAvoided.ItemHeight = 21;
            this.listBoxAvoided.Location = new System.Drawing.Point(686, 196);
            this.listBoxAvoided.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAvoided.Name = "listBoxAvoided";
            this.listBoxAvoided.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAvoided.Size = new System.Drawing.Size(166, 235);
            this.listBoxAvoided.TabIndex = 29;
            // 
            // maleRadioButton
            // 
            this.maleRadioButton.AutoSize = true;
            this.maleRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.maleRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.maleRadioButton.Location = new System.Drawing.Point(215, 196);
            this.maleRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.maleRadioButton.Name = "maleRadioButton";
            this.maleRadioButton.Size = new System.Drawing.Size(92, 25);
            this.maleRadioButton.TabIndex = 30;
            this.maleRadioButton.TabStop = true;
            this.maleRadioButton.Text = "Αρσενικό";
            this.maleRadioButton.UseVisualStyleBackColor = true;
            // 
            // femaleRadioButton
            // 
            this.femaleRadioButton.AutoSize = true;
            this.femaleRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.femaleRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.femaleRadioButton.Location = new System.Drawing.Point(319, 196);
            this.femaleRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.Size = new System.Drawing.Size(83, 25);
            this.femaleRadioButton.TabIndex = 31;
            this.femaleRadioButton.TabStop = true;
            this.femaleRadioButton.Text = "Θηλυκό";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // birthDatePicker
            // 
            this.birthDatePicker.CustomFormat = "\"dd/MM/yyyy\"";
            this.birthDatePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.birthDatePicker.Location = new System.Drawing.Point(213, 291);
            this.birthDatePicker.Name = "birthDatePicker";
            this.birthDatePicker.Size = new System.Drawing.Size(189, 29);
            this.birthDatePicker.TabIndex = 32;
            // 
            // comboBoxActivityLevel
            // 
            this.comboBoxActivityLevel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxActivityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActivityLevel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.comboBoxActivityLevel.FormattingEnabled = true;
            this.comboBoxActivityLevel.Location = new System.Drawing.Point(213, 447);
            this.comboBoxActivityLevel.Name = "comboBoxActivityLevel";
            this.comboBoxActivityLevel.Size = new System.Drawing.Size(224, 29);
            this.comboBoxActivityLevel.TabIndex = 33;
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSearchPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPatient.Enabled = false;
            this.btnSearchPatient.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSearchPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPatient.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPatient.Location = new System.Drawing.Point(32, 23);
            this.btnSearchPatient.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(177, 52);
            this.btnSearchPatient.TabIndex = 34;
            this.btnSearchPatient.Text = "Αναζήτηση ασθενή";
            this.btnSearchPatient.UseVisualStyleBackColor = false;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelID.Location = new System.Drawing.Point(31, 98);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(152, 21);
            this.labelID.TabIndex = 35;
            this.labelID.Text = "Αριθμός Μητρώου";
            // 
            // textBoxID
            // 
            this.textBoxID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxID.Enabled = false;
            this.textBoxID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBoxID.Location = new System.Drawing.Point(213, 95);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(102, 29);
            this.textBoxID.TabIndex = 36;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(340, 97);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 26);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "Καθαρισμός";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelButtons.Controls.Add(this.btnSearchPatient);
            this.panelButtons.Controls.Add(this.btnSaveData);
            this.panelButtons.Controls.Add(this.btnGeneratePlan);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(894, 100);
            this.panelButtons.TabIndex = 38;
            // 
            // FormDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(894, 600);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.comboBoxActivityLevel);
            this.Controls.Add(this.birthDatePicker);
            this.Controls.Add(this.femaleRadioButton);
            this.Controls.Add(this.maleRadioButton);
            this.Controls.Add(this.listBoxAvoided);
            this.Controls.Add(this.listBoxPreferred);
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
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDataEntry";
            this.Text = "Diet Planner";
            this.Load += new System.EventHandler(this.FormDataEntry_Load);
            this.panelButtons.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelButtons;
    }
}