namespace transmission_renamer.Forms
{
    partial class RulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            this.RuleTypeListBox = new System.Windows.Forms.ListBox();
            this.RuleTypeTabControl = new System.Windows.Forms.TabControl();
            this.InsertRuleTabPage = new System.Windows.Forms.TabPage();
            this.InsertIgnoreExtensionCheckBox = new System.Windows.Forms.CheckBox();
            this.ReplaceCurrentFileNameRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertAfterTextTextBox = new System.Windows.Forms.TextBox();
            this.InsertAfterTextRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertBeforeTextTextBox = new System.Windows.Forms.TextBox();
            this.InsertBeforeTextRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertPositionRightLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.InsertPositionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InsertAtPositionRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertSuffixRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertPrefixRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertWhereLabel = new System.Windows.Forms.Label();
            this.InsertTextTextBox = new System.Windows.Forms.TextBox();
            this.InsertTextLabel = new System.Windows.Forms.Label();
            this.InsertRuleTitleLabel = new System.Windows.Forms.Label();
            this.DeleteRuleTabPage = new System.Windows.Forms.TabPage();
            this.DeleteIgnoreExtensionCheckBox = new System.Windows.Forms.CheckBox();
            this.DeleteKeepDelimitersCheckBox = new System.Windows.Forms.CheckBox();
            this.DeleteEntireFileNameCheckBox = new System.Windows.Forms.CheckBox();
            this.DeleteToGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteToEndRadioButton = new System.Windows.Forms.RadioButton();
            this.DeleteToDelimiterTextBox = new System.Windows.Forms.TextBox();
            this.DeleteToPositionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DeleteToDelimiterRadioButton = new System.Windows.Forms.RadioButton();
            this.DeleteToPositionRadioButton = new System.Windows.Forms.RadioButton();
            this.DeleteFromGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteFromDelimiterTextBox = new System.Windows.Forms.TextBox();
            this.DeleteFromDelimiterRadioButton = new System.Windows.Forms.RadioButton();
            this.DeleteFromPositionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DeleteFromPositionRadioButton = new System.Windows.Forms.RadioButton();
            this.DeleteRuleTitleLabel = new System.Windows.Forms.Label();
            this.RemoveRuleTabPage = new System.Windows.Forms.TabPage();
            this.RemoveRuleTitleLabel = new System.Windows.Forms.Label();
            this.ReplaceRuleTabPage = new System.Windows.Forms.TabPage();
            this.ReplaceRuleTitleLabel = new System.Windows.Forms.Label();
            this.CleanRuleTabPage = new System.Windows.Forms.TabPage();
            this.CleanRuleTitleLabel = new System.Windows.Forms.Label();
            this.RegexRuleTabPage = new System.Windows.Forms.TabPage();
            this.RegexRuleTitleLabel = new System.Windows.Forms.Label();
            this.ConfirmRuleButton = new System.Windows.Forms.Button();
            this.CancelRuleButton = new System.Windows.Forms.Button();
            this.RuleTypeTabControl.SuspendLayout();
            this.InsertRuleTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InsertPositionNumericUpDown)).BeginInit();
            this.DeleteRuleTabPage.SuspendLayout();
            this.DeleteToGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteToPositionNumericUpDown)).BeginInit();
            this.DeleteFromGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteFromPositionNumericUpDown)).BeginInit();
            this.RemoveRuleTabPage.SuspendLayout();
            this.ReplaceRuleTabPage.SuspendLayout();
            this.CleanRuleTabPage.SuspendLayout();
            this.RegexRuleTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // RuleTypeListBox
            // 
            this.RuleTypeListBox.BackColor = System.Drawing.Color.White;
            this.RuleTypeListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RuleTypeListBox.FormattingEnabled = true;
            this.RuleTypeListBox.ItemHeight = 17;
            this.RuleTypeListBox.Items.AddRange(new object[] {
            "Insert",
            "Delete",
            "Remove",
            "Replace",
            "Clean",
            "Regular Expressions"});
            this.RuleTypeListBox.Location = new System.Drawing.Point(12, 12);
            this.RuleTypeListBox.Name = "RuleTypeListBox";
            this.RuleTypeListBox.Size = new System.Drawing.Size(130, 344);
            this.RuleTypeListBox.TabIndex = 0;
            this.RuleTypeListBox.SelectedIndexChanged += new System.EventHandler(this.SelectRuleTab);
            // 
            // RuleTypeTabControl
            // 
            this.RuleTypeTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.RuleTypeTabControl.Controls.Add(this.InsertRuleTabPage);
            this.RuleTypeTabControl.Controls.Add(this.DeleteRuleTabPage);
            this.RuleTypeTabControl.Controls.Add(this.RemoveRuleTabPage);
            this.RuleTypeTabControl.Controls.Add(this.ReplaceRuleTabPage);
            this.RuleTypeTabControl.Controls.Add(this.CleanRuleTabPage);
            this.RuleTypeTabControl.Controls.Add(this.RegexRuleTabPage);
            this.RuleTypeTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.RuleTypeTabControl.Location = new System.Drawing.Point(148, 8);
            this.RuleTypeTabControl.Name = "RuleTypeTabControl";
            this.RuleTypeTabControl.SelectedIndex = 0;
            this.RuleTypeTabControl.Size = new System.Drawing.Size(524, 352);
            this.RuleTypeTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.RuleTypeTabControl.TabIndex = 999;
            this.RuleTypeTabControl.TabStop = false;
            // 
            // InsertRuleTabPage
            // 
            this.InsertRuleTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InsertRuleTabPage.Controls.Add(this.InsertIgnoreExtensionCheckBox);
            this.InsertRuleTabPage.Controls.Add(this.ReplaceCurrentFileNameRadioButton);
            this.InsertRuleTabPage.Controls.Add(this.InsertAfterTextTextBox);
            this.InsertRuleTabPage.Controls.Add(this.InsertAfterTextRadioButton);
            this.InsertRuleTabPage.Controls.Add(this.InsertBeforeTextTextBox);
            this.InsertRuleTabPage.Controls.Add(this.InsertBeforeTextRadioButton);
            this.InsertRuleTabPage.Controls.Add(this.InsertPositionRightLeftCheckBox);
            this.InsertRuleTabPage.Controls.Add(this.InsertPositionNumericUpDown);
            this.InsertRuleTabPage.Controls.Add(this.InsertAtPositionRadioButton);
            this.InsertRuleTabPage.Controls.Add(this.InsertSuffixRadioButton);
            this.InsertRuleTabPage.Controls.Add(this.InsertPrefixRadioButton);
            this.InsertRuleTabPage.Controls.Add(this.InsertWhereLabel);
            this.InsertRuleTabPage.Controls.Add(this.InsertTextTextBox);
            this.InsertRuleTabPage.Controls.Add(this.InsertTextLabel);
            this.InsertRuleTabPage.Controls.Add(this.InsertRuleTitleLabel);
            this.InsertRuleTabPage.Location = new System.Drawing.Point(4, 5);
            this.InsertRuleTabPage.Name = "InsertRuleTabPage";
            this.InsertRuleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.InsertRuleTabPage.Size = new System.Drawing.Size(516, 343);
            this.InsertRuleTabPage.TabIndex = 0;
            this.InsertRuleTabPage.Text = "Insert";
            this.InsertRuleTabPage.UseVisualStyleBackColor = true;
            // 
            // InsertIgnoreExtensionCheckBox
            // 
            this.InsertIgnoreExtensionCheckBox.AutoSize = true;
            this.InsertIgnoreExtensionCheckBox.Checked = true;
            this.InsertIgnoreExtensionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InsertIgnoreExtensionCheckBox.Location = new System.Drawing.Point(108, 266);
            this.InsertIgnoreExtensionCheckBox.Name = "InsertIgnoreExtensionCheckBox";
            this.InsertIgnoreExtensionCheckBox.Size = new System.Drawing.Size(113, 17);
            this.InsertIgnoreExtensionCheckBox.TabIndex = 14;
            this.InsertIgnoreExtensionCheckBox.Text = "Ignore extension";
            this.InsertIgnoreExtensionCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReplaceCurrentFileNameRadioButton
            // 
            this.ReplaceCurrentFileNameRadioButton.AutoSize = true;
            this.ReplaceCurrentFileNameRadioButton.Location = new System.Drawing.Point(108, 234);
            this.ReplaceCurrentFileNameRadioButton.Name = "ReplaceCurrentFileNameRadioButton";
            this.ReplaceCurrentFileNameRadioButton.Size = new System.Drawing.Size(152, 17);
            this.ReplaceCurrentFileNameRadioButton.TabIndex = 13;
            this.ReplaceCurrentFileNameRadioButton.Text = "Replace current filename";
            this.ReplaceCurrentFileNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertAfterTextTextBox
            // 
            this.InsertAfterTextTextBox.Location = new System.Drawing.Point(197, 199);
            this.InsertAfterTextTextBox.Name = "InsertAfterTextTextBox";
            this.InsertAfterTextTextBox.Size = new System.Drawing.Size(259, 22);
            this.InsertAfterTextTextBox.TabIndex = 12;
            // 
            // InsertAfterTextRadioButton
            // 
            this.InsertAfterTextRadioButton.AutoSize = true;
            this.InsertAfterTextRadioButton.Location = new System.Drawing.Point(108, 200);
            this.InsertAfterTextRadioButton.Name = "InsertAfterTextRadioButton";
            this.InsertAfterTextRadioButton.Size = new System.Drawing.Size(75, 17);
            this.InsertAfterTextRadioButton.TabIndex = 11;
            this.InsertAfterTextRadioButton.Text = "After text:";
            this.InsertAfterTextRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertBeforeTextTextBox
            // 
            this.InsertBeforeTextTextBox.Location = new System.Drawing.Point(197, 171);
            this.InsertBeforeTextTextBox.Name = "InsertBeforeTextTextBox";
            this.InsertBeforeTextTextBox.Size = new System.Drawing.Size(259, 22);
            this.InsertBeforeTextTextBox.TabIndex = 10;
            // 
            // InsertBeforeTextRadioButton
            // 
            this.InsertBeforeTextRadioButton.AutoSize = true;
            this.InsertBeforeTextRadioButton.Location = new System.Drawing.Point(108, 172);
            this.InsertBeforeTextRadioButton.Name = "InsertBeforeTextRadioButton";
            this.InsertBeforeTextRadioButton.Size = new System.Drawing.Size(83, 17);
            this.InsertBeforeTextRadioButton.TabIndex = 9;
            this.InsertBeforeTextRadioButton.Text = "Before text:";
            this.InsertBeforeTextRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertPositionRightLeftCheckBox
            // 
            this.InsertPositionRightLeftCheckBox.AutoSize = true;
            this.InsertPositionRightLeftCheckBox.Location = new System.Drawing.Point(256, 146);
            this.InsertPositionRightLeftCheckBox.Name = "InsertPositionRightLeftCheckBox";
            this.InsertPositionRightLeftCheckBox.Size = new System.Drawing.Size(90, 17);
            this.InsertPositionRightLeftCheckBox.TabIndex = 8;
            this.InsertPositionRightLeftCheckBox.Text = "Right-to-left";
            this.InsertPositionRightLeftCheckBox.UseVisualStyleBackColor = true;
            // 
            // InsertPositionNumericUpDown
            // 
            this.InsertPositionNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InsertPositionNumericUpDown.Location = new System.Drawing.Point(197, 143);
            this.InsertPositionNumericUpDown.Name = "InsertPositionNumericUpDown";
            this.InsertPositionNumericUpDown.Size = new System.Drawing.Size(50, 22);
            this.InsertPositionNumericUpDown.TabIndex = 7;
            // 
            // InsertAtPositionRadioButton
            // 
            this.InsertAtPositionRadioButton.AutoSize = true;
            this.InsertAtPositionRadioButton.Location = new System.Drawing.Point(108, 143);
            this.InsertAtPositionRadioButton.Name = "InsertAtPositionRadioButton";
            this.InsertAtPositionRadioButton.Size = new System.Drawing.Size(70, 17);
            this.InsertAtPositionRadioButton.TabIndex = 6;
            this.InsertAtPositionRadioButton.Text = "Position:";
            this.InsertAtPositionRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertSuffixRadioButton
            // 
            this.InsertSuffixRadioButton.AutoSize = true;
            this.InsertSuffixRadioButton.Location = new System.Drawing.Point(108, 120);
            this.InsertSuffixRadioButton.Name = "InsertSuffixRadioButton";
            this.InsertSuffixRadioButton.Size = new System.Drawing.Size(54, 17);
            this.InsertSuffixRadioButton.TabIndex = 5;
            this.InsertSuffixRadioButton.Text = "Suffix";
            this.InsertSuffixRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertPrefixRadioButton
            // 
            this.InsertPrefixRadioButton.AutoSize = true;
            this.InsertPrefixRadioButton.Checked = true;
            this.InsertPrefixRadioButton.Location = new System.Drawing.Point(108, 97);
            this.InsertPrefixRadioButton.Name = "InsertPrefixRadioButton";
            this.InsertPrefixRadioButton.Size = new System.Drawing.Size(53, 17);
            this.InsertPrefixRadioButton.TabIndex = 4;
            this.InsertPrefixRadioButton.TabStop = true;
            this.InsertPrefixRadioButton.Text = "Prefix";
            this.InsertPrefixRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertWhereLabel
            // 
            this.InsertWhereLabel.AutoSize = true;
            this.InsertWhereLabel.Location = new System.Drawing.Point(58, 99);
            this.InsertWhereLabel.Name = "InsertWhereLabel";
            this.InsertWhereLabel.Size = new System.Drawing.Size(44, 13);
            this.InsertWhereLabel.TabIndex = 3;
            this.InsertWhereLabel.Text = "Where:";
            // 
            // InsertTextTextBox
            // 
            this.InsertTextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InsertTextTextBox.Location = new System.Drawing.Point(108, 57);
            this.InsertTextTextBox.Name = "InsertTextTextBox";
            this.InsertTextTextBox.Size = new System.Drawing.Size(348, 22);
            this.InsertTextTextBox.TabIndex = 2;
            // 
            // InsertTextLabel
            // 
            this.InsertTextLabel.AutoSize = true;
            this.InsertTextLabel.Location = new System.Drawing.Point(63, 60);
            this.InsertTextLabel.Name = "InsertTextLabel";
            this.InsertTextLabel.Size = new System.Drawing.Size(39, 13);
            this.InsertTextLabel.TabIndex = 1;
            this.InsertTextLabel.Text = "Insert:";
            // 
            // InsertRuleTitleLabel
            // 
            this.InsertRuleTitleLabel.AutoSize = true;
            this.InsertRuleTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertRuleTitleLabel.Location = new System.Drawing.Point(6, 6);
            this.InsertRuleTitleLabel.Name = "InsertRuleTitleLabel";
            this.InsertRuleTitleLabel.Size = new System.Drawing.Size(37, 15);
            this.InsertRuleTitleLabel.TabIndex = 0;
            this.InsertRuleTitleLabel.Text = "Insert";
            // 
            // DeleteRuleTabPage
            // 
            this.DeleteRuleTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeleteRuleTabPage.Controls.Add(this.DeleteIgnoreExtensionCheckBox);
            this.DeleteRuleTabPage.Controls.Add(this.DeleteKeepDelimitersCheckBox);
            this.DeleteRuleTabPage.Controls.Add(this.DeleteEntireFileNameCheckBox);
            this.DeleteRuleTabPage.Controls.Add(this.DeleteToGroupBox);
            this.DeleteRuleTabPage.Controls.Add(this.DeleteFromGroupBox);
            this.DeleteRuleTabPage.Controls.Add(this.DeleteRuleTitleLabel);
            this.DeleteRuleTabPage.Location = new System.Drawing.Point(4, 5);
            this.DeleteRuleTabPage.Name = "DeleteRuleTabPage";
            this.DeleteRuleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DeleteRuleTabPage.Size = new System.Drawing.Size(516, 343);
            this.DeleteRuleTabPage.TabIndex = 1;
            this.DeleteRuleTabPage.Text = "Delete";
            this.DeleteRuleTabPage.UseVisualStyleBackColor = true;
            // 
            // DeleteIgnoreExtensionCheckBox
            // 
            this.DeleteIgnoreExtensionCheckBox.AutoSize = true;
            this.DeleteIgnoreExtensionCheckBox.Checked = true;
            this.DeleteIgnoreExtensionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DeleteIgnoreExtensionCheckBox.Location = new System.Drawing.Point(111, 266);
            this.DeleteIgnoreExtensionCheckBox.Name = "DeleteIgnoreExtensionCheckBox";
            this.DeleteIgnoreExtensionCheckBox.Size = new System.Drawing.Size(113, 17);
            this.DeleteIgnoreExtensionCheckBox.TabIndex = 7;
            this.DeleteIgnoreExtensionCheckBox.Text = "Ignore extension";
            this.DeleteIgnoreExtensionCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeleteKeepDelimitersCheckBox
            // 
            this.DeleteKeepDelimitersCheckBox.AutoSize = true;
            this.DeleteKeepDelimitersCheckBox.Location = new System.Drawing.Point(264, 243);
            this.DeleteKeepDelimitersCheckBox.Name = "DeleteKeepDelimitersCheckBox";
            this.DeleteKeepDelimitersCheckBox.Size = new System.Drawing.Size(104, 17);
            this.DeleteKeepDelimitersCheckBox.TabIndex = 6;
            this.DeleteKeepDelimitersCheckBox.Text = "Keep delimiters";
            this.DeleteKeepDelimitersCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeleteEntireFileNameCheckBox
            // 
            this.DeleteEntireFileNameCheckBox.AutoSize = true;
            this.DeleteEntireFileNameCheckBox.Location = new System.Drawing.Point(111, 243);
            this.DeleteEntireFileNameCheckBox.Name = "DeleteEntireFileNameCheckBox";
            this.DeleteEntireFileNameCheckBox.Size = new System.Drawing.Size(139, 17);
            this.DeleteEntireFileNameCheckBox.TabIndex = 4;
            this.DeleteEntireFileNameCheckBox.Text = "Delete entire filename";
            this.DeleteEntireFileNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeleteToGroupBox
            // 
            this.DeleteToGroupBox.Controls.Add(this.DeleteToEndRadioButton);
            this.DeleteToGroupBox.Controls.Add(this.DeleteToDelimiterTextBox);
            this.DeleteToGroupBox.Controls.Add(this.DeleteToPositionNumericUpDown);
            this.DeleteToGroupBox.Controls.Add(this.DeleteToDelimiterRadioButton);
            this.DeleteToGroupBox.Controls.Add(this.DeleteToPositionRadioButton);
            this.DeleteToGroupBox.Location = new System.Drawing.Point(260, 45);
            this.DeleteToGroupBox.Name = "DeleteToGroupBox";
            this.DeleteToGroupBox.Size = new System.Drawing.Size(200, 150);
            this.DeleteToGroupBox.TabIndex = 3;
            this.DeleteToGroupBox.TabStop = false;
            this.DeleteToGroupBox.Text = "To";
            // 
            // DeleteToEndRadioButton
            // 
            this.DeleteToEndRadioButton.AutoSize = true;
            this.DeleteToEndRadioButton.Location = new System.Drawing.Point(21, 87);
            this.DeleteToEndRadioButton.Name = "DeleteToEndRadioButton";
            this.DeleteToEndRadioButton.Size = new System.Drawing.Size(91, 17);
            this.DeleteToEndRadioButton.TabIndex = 16;
            this.DeleteToEndRadioButton.Text = "End position";
            this.DeleteToEndRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeleteToDelimiterTextBox
            // 
            this.DeleteToDelimiterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeleteToDelimiterTextBox.Location = new System.Drawing.Point(110, 59);
            this.DeleteToDelimiterTextBox.Name = "DeleteToDelimiterTextBox";
            this.DeleteToDelimiterTextBox.Size = new System.Drawing.Size(70, 22);
            this.DeleteToDelimiterTextBox.TabIndex = 15;
            // 
            // DeleteToPositionNumericUpDown
            // 
            this.DeleteToPositionNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeleteToPositionNumericUpDown.Location = new System.Drawing.Point(110, 31);
            this.DeleteToPositionNumericUpDown.Name = "DeleteToPositionNumericUpDown";
            this.DeleteToPositionNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.DeleteToPositionNumericUpDown.TabIndex = 13;
            // 
            // DeleteToDelimiterRadioButton
            // 
            this.DeleteToDelimiterRadioButton.AutoSize = true;
            this.DeleteToDelimiterRadioButton.Location = new System.Drawing.Point(21, 60);
            this.DeleteToDelimiterRadioButton.Name = "DeleteToDelimiterRadioButton";
            this.DeleteToDelimiterRadioButton.Size = new System.Drawing.Size(74, 17);
            this.DeleteToDelimiterRadioButton.TabIndex = 14;
            this.DeleteToDelimiterRadioButton.Text = "Delimiter:";
            this.DeleteToDelimiterRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeleteToPositionRadioButton
            // 
            this.DeleteToPositionRadioButton.AutoSize = true;
            this.DeleteToPositionRadioButton.Checked = true;
            this.DeleteToPositionRadioButton.Location = new System.Drawing.Point(21, 31);
            this.DeleteToPositionRadioButton.Name = "DeleteToPositionRadioButton";
            this.DeleteToPositionRadioButton.Size = new System.Drawing.Size(70, 17);
            this.DeleteToPositionRadioButton.TabIndex = 12;
            this.DeleteToPositionRadioButton.TabStop = true;
            this.DeleteToPositionRadioButton.Text = "Position:";
            this.DeleteToPositionRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeleteFromGroupBox
            // 
            this.DeleteFromGroupBox.Controls.Add(this.DeleteFromDelimiterTextBox);
            this.DeleteFromGroupBox.Controls.Add(this.DeleteFromDelimiterRadioButton);
            this.DeleteFromGroupBox.Controls.Add(this.DeleteFromPositionNumericUpDown);
            this.DeleteFromGroupBox.Controls.Add(this.DeleteFromPositionRadioButton);
            this.DeleteFromGroupBox.Location = new System.Drawing.Point(54, 45);
            this.DeleteFromGroupBox.Name = "DeleteFromGroupBox";
            this.DeleteFromGroupBox.Size = new System.Drawing.Size(200, 150);
            this.DeleteFromGroupBox.TabIndex = 2;
            this.DeleteFromGroupBox.TabStop = false;
            this.DeleteFromGroupBox.Text = "From";
            // 
            // DeleteFromDelimiterTextBox
            // 
            this.DeleteFromDelimiterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeleteFromDelimiterTextBox.Location = new System.Drawing.Point(110, 59);
            this.DeleteFromDelimiterTextBox.Name = "DeleteFromDelimiterTextBox";
            this.DeleteFromDelimiterTextBox.Size = new System.Drawing.Size(70, 22);
            this.DeleteFromDelimiterTextBox.TabIndex = 11;
            // 
            // DeleteFromDelimiterRadioButton
            // 
            this.DeleteFromDelimiterRadioButton.AutoSize = true;
            this.DeleteFromDelimiterRadioButton.Location = new System.Drawing.Point(21, 60);
            this.DeleteFromDelimiterRadioButton.Name = "DeleteFromDelimiterRadioButton";
            this.DeleteFromDelimiterRadioButton.Size = new System.Drawing.Size(74, 17);
            this.DeleteFromDelimiterRadioButton.TabIndex = 10;
            this.DeleteFromDelimiterRadioButton.Text = "Delimiter:";
            this.DeleteFromDelimiterRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeleteFromPositionNumericUpDown
            // 
            this.DeleteFromPositionNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeleteFromPositionNumericUpDown.Location = new System.Drawing.Point(110, 31);
            this.DeleteFromPositionNumericUpDown.Name = "DeleteFromPositionNumericUpDown";
            this.DeleteFromPositionNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.DeleteFromPositionNumericUpDown.TabIndex = 9;
            // 
            // DeleteFromPositionRadioButton
            // 
            this.DeleteFromPositionRadioButton.AutoSize = true;
            this.DeleteFromPositionRadioButton.Checked = true;
            this.DeleteFromPositionRadioButton.Location = new System.Drawing.Point(21, 31);
            this.DeleteFromPositionRadioButton.Name = "DeleteFromPositionRadioButton";
            this.DeleteFromPositionRadioButton.Size = new System.Drawing.Size(70, 17);
            this.DeleteFromPositionRadioButton.TabIndex = 8;
            this.DeleteFromPositionRadioButton.TabStop = true;
            this.DeleteFromPositionRadioButton.Text = "Position:";
            this.DeleteFromPositionRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeleteRuleTitleLabel
            // 
            this.DeleteRuleTitleLabel.AutoSize = true;
            this.DeleteRuleTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteRuleTitleLabel.Location = new System.Drawing.Point(6, 6);
            this.DeleteRuleTitleLabel.Name = "DeleteRuleTitleLabel";
            this.DeleteRuleTitleLabel.Size = new System.Drawing.Size(41, 15);
            this.DeleteRuleTitleLabel.TabIndex = 1;
            this.DeleteRuleTitleLabel.Text = "Delete";
            // 
            // RemoveRuleTabPage
            // 
            this.RemoveRuleTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RemoveRuleTabPage.Controls.Add(this.RemoveRuleTitleLabel);
            this.RemoveRuleTabPage.Location = new System.Drawing.Point(4, 5);
            this.RemoveRuleTabPage.Name = "RemoveRuleTabPage";
            this.RemoveRuleTabPage.Size = new System.Drawing.Size(516, 343);
            this.RemoveRuleTabPage.TabIndex = 2;
            this.RemoveRuleTabPage.Text = "Remove";
            this.RemoveRuleTabPage.UseVisualStyleBackColor = true;
            // 
            // RemoveRuleTitleLabel
            // 
            this.RemoveRuleTitleLabel.AutoSize = true;
            this.RemoveRuleTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveRuleTitleLabel.Location = new System.Drawing.Point(6, 6);
            this.RemoveRuleTitleLabel.Name = "RemoveRuleTitleLabel";
            this.RemoveRuleTitleLabel.Size = new System.Drawing.Size(50, 15);
            this.RemoveRuleTitleLabel.TabIndex = 3;
            this.RemoveRuleTitleLabel.Text = "Remove";
            // 
            // ReplaceRuleTabPage
            // 
            this.ReplaceRuleTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReplaceRuleTabPage.Controls.Add(this.ReplaceRuleTitleLabel);
            this.ReplaceRuleTabPage.Location = new System.Drawing.Point(4, 5);
            this.ReplaceRuleTabPage.Name = "ReplaceRuleTabPage";
            this.ReplaceRuleTabPage.Size = new System.Drawing.Size(516, 343);
            this.ReplaceRuleTabPage.TabIndex = 3;
            this.ReplaceRuleTabPage.Text = "Replace";
            this.ReplaceRuleTabPage.UseVisualStyleBackColor = true;
            // 
            // ReplaceRuleTitleLabel
            // 
            this.ReplaceRuleTitleLabel.AutoSize = true;
            this.ReplaceRuleTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReplaceRuleTitleLabel.Location = new System.Drawing.Point(6, 6);
            this.ReplaceRuleTitleLabel.Name = "ReplaceRuleTitleLabel";
            this.ReplaceRuleTitleLabel.Size = new System.Drawing.Size(48, 15);
            this.ReplaceRuleTitleLabel.TabIndex = 3;
            this.ReplaceRuleTitleLabel.Text = "Replace";
            // 
            // CleanRuleTabPage
            // 
            this.CleanRuleTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CleanRuleTabPage.Controls.Add(this.CleanRuleTitleLabel);
            this.CleanRuleTabPage.Location = new System.Drawing.Point(4, 5);
            this.CleanRuleTabPage.Name = "CleanRuleTabPage";
            this.CleanRuleTabPage.Size = new System.Drawing.Size(516, 343);
            this.CleanRuleTabPage.TabIndex = 4;
            this.CleanRuleTabPage.Text = "Clean";
            this.CleanRuleTabPage.UseVisualStyleBackColor = true;
            // 
            // CleanRuleTitleLabel
            // 
            this.CleanRuleTitleLabel.AutoSize = true;
            this.CleanRuleTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CleanRuleTitleLabel.Location = new System.Drawing.Point(6, 6);
            this.CleanRuleTitleLabel.Name = "CleanRuleTitleLabel";
            this.CleanRuleTitleLabel.Size = new System.Drawing.Size(36, 15);
            this.CleanRuleTitleLabel.TabIndex = 2;
            this.CleanRuleTitleLabel.Text = "Clean";
            // 
            // RegexRuleTabPage
            // 
            this.RegexRuleTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegexRuleTabPage.Controls.Add(this.RegexRuleTitleLabel);
            this.RegexRuleTabPage.Location = new System.Drawing.Point(4, 5);
            this.RegexRuleTabPage.Name = "RegexRuleTabPage";
            this.RegexRuleTabPage.Size = new System.Drawing.Size(516, 343);
            this.RegexRuleTabPage.TabIndex = 5;
            this.RegexRuleTabPage.Text = "Regular Expressions";
            this.RegexRuleTabPage.UseVisualStyleBackColor = true;
            // 
            // RegexRuleTitleLabel
            // 
            this.RegexRuleTitleLabel.AutoSize = true;
            this.RegexRuleTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegexRuleTitleLabel.Location = new System.Drawing.Point(6, 6);
            this.RegexRuleTitleLabel.Name = "RegexRuleTitleLabel";
            this.RegexRuleTitleLabel.Size = new System.Drawing.Size(111, 15);
            this.RegexRuleTitleLabel.TabIndex = 3;
            this.RegexRuleTitleLabel.Text = "Regular Expressions";
            // 
            // ConfirmRuleButton
            // 
            this.ConfirmRuleButton.Location = new System.Drawing.Point(593, 376);
            this.ConfirmRuleButton.Name = "ConfirmRuleButton";
            this.ConfirmRuleButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmRuleButton.TabIndex = 1000;
            this.ConfirmRuleButton.Text = "Confirm";
            this.ConfirmRuleButton.UseVisualStyleBackColor = true;
            this.ConfirmRuleButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // CancelRuleButton
            // 
            this.CancelRuleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelRuleButton.Location = new System.Drawing.Point(512, 376);
            this.CancelRuleButton.Name = "CancelRuleButton";
            this.CancelRuleButton.Size = new System.Drawing.Size(75, 23);
            this.CancelRuleButton.TabIndex = 1001;
            this.CancelRuleButton.Text = "Cancel";
            this.CancelRuleButton.UseVisualStyleBackColor = true;
            this.CancelRuleButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // RulesForm
            // 
            this.AcceptButton = this.ConfirmRuleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.CancelRuleButton);
            this.Controls.Add(this.ConfirmRuleButton);
            this.Controls.Add(this.RuleTypeTabControl);
            this.Controls.Add(this.RuleTypeListBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Rule";
            this.Shown += new System.EventHandler(this.RulesForm_Shown);
            this.RuleTypeTabControl.ResumeLayout(false);
            this.InsertRuleTabPage.ResumeLayout(false);
            this.InsertRuleTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InsertPositionNumericUpDown)).EndInit();
            this.DeleteRuleTabPage.ResumeLayout(false);
            this.DeleteRuleTabPage.PerformLayout();
            this.DeleteToGroupBox.ResumeLayout(false);
            this.DeleteToGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteToPositionNumericUpDown)).EndInit();
            this.DeleteFromGroupBox.ResumeLayout(false);
            this.DeleteFromGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteFromPositionNumericUpDown)).EndInit();
            this.RemoveRuleTabPage.ResumeLayout(false);
            this.RemoveRuleTabPage.PerformLayout();
            this.ReplaceRuleTabPage.ResumeLayout(false);
            this.ReplaceRuleTabPage.PerformLayout();
            this.CleanRuleTabPage.ResumeLayout(false);
            this.CleanRuleTabPage.PerformLayout();
            this.RegexRuleTabPage.ResumeLayout(false);
            this.RegexRuleTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox RuleTypeListBox;
        private System.Windows.Forms.TabControl RuleTypeTabControl;
        private System.Windows.Forms.TabPage InsertRuleTabPage;
        private System.Windows.Forms.TabPage DeleteRuleTabPage;
        private System.Windows.Forms.TabPage RemoveRuleTabPage;
        private System.Windows.Forms.TabPage ReplaceRuleTabPage;
        private System.Windows.Forms.TabPage CleanRuleTabPage;
        private System.Windows.Forms.TabPage RegexRuleTabPage;
        private System.Windows.Forms.Label InsertRuleTitleLabel;
        private System.Windows.Forms.Label DeleteRuleTitleLabel;
        private System.Windows.Forms.Label CleanRuleTitleLabel;
        private System.Windows.Forms.Label RegexRuleTitleLabel;
        private System.Windows.Forms.Label RemoveRuleTitleLabel;
        private System.Windows.Forms.Label ReplaceRuleTitleLabel;
        private System.Windows.Forms.Button ConfirmRuleButton;
        private System.Windows.Forms.Button CancelRuleButton;
        private System.Windows.Forms.TextBox InsertTextTextBox;
        private System.Windows.Forms.Label InsertTextLabel;
        private System.Windows.Forms.Label InsertWhereLabel;
        private System.Windows.Forms.RadioButton InsertPrefixRadioButton;
        private System.Windows.Forms.RadioButton InsertSuffixRadioButton;
        private System.Windows.Forms.NumericUpDown InsertPositionNumericUpDown;
        private System.Windows.Forms.RadioButton InsertAtPositionRadioButton;
        private System.Windows.Forms.CheckBox InsertPositionRightLeftCheckBox;
        private System.Windows.Forms.RadioButton InsertBeforeTextRadioButton;
        private System.Windows.Forms.TextBox InsertBeforeTextTextBox;
        private System.Windows.Forms.TextBox InsertAfterTextTextBox;
        private System.Windows.Forms.RadioButton InsertAfterTextRadioButton;
        private System.Windows.Forms.RadioButton ReplaceCurrentFileNameRadioButton;
        private System.Windows.Forms.CheckBox InsertIgnoreExtensionCheckBox;
        private System.Windows.Forms.GroupBox DeleteFromGroupBox;
        private System.Windows.Forms.GroupBox DeleteToGroupBox;
        private System.Windows.Forms.NumericUpDown DeleteFromPositionNumericUpDown;
        private System.Windows.Forms.RadioButton DeleteFromPositionRadioButton;
        private System.Windows.Forms.RadioButton DeleteFromDelimiterRadioButton;
        private System.Windows.Forms.TextBox DeleteFromDelimiterTextBox;
        private System.Windows.Forms.TextBox DeleteToDelimiterTextBox;
        private System.Windows.Forms.NumericUpDown DeleteToPositionNumericUpDown;
        private System.Windows.Forms.RadioButton DeleteToDelimiterRadioButton;
        private System.Windows.Forms.RadioButton DeleteToPositionRadioButton;
        private System.Windows.Forms.CheckBox DeleteEntireFileNameCheckBox;
        private System.Windows.Forms.RadioButton DeleteToEndRadioButton;
        private System.Windows.Forms.CheckBox DeleteKeepDelimitersCheckBox;
        private System.Windows.Forms.CheckBox DeleteIgnoreExtensionCheckBox;
    }
}