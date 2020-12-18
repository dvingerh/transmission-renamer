namespace transmission_renamer.Forms
{
    partial class RenamerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenamerForm));
            this.StatisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.TimedOutFilesLabel = new System.Windows.Forms.Label();
            this.ErrorFilesLabel = new System.Windows.Forms.Label();
            this.SuccessFilesLabel = new System.Windows.Forms.Label();
            this.TotalFilesLabel = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.RenamingProgressBar = new System.Windows.Forms.ProgressBar();
            this.CurrentFileRenameLabel = new System.Windows.Forms.Label();
            this.Abortutton = new System.Windows.Forms.Button();
            this.FileNamesOldNewListView = new BufferedListView();
            this.CFOldName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CFNewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatisticsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatisticsGroupBox
            // 
            this.StatisticsGroupBox.Controls.Add(this.TimedOutFilesLabel);
            this.StatisticsGroupBox.Controls.Add(this.ErrorFilesLabel);
            this.StatisticsGroupBox.Controls.Add(this.SuccessFilesLabel);
            this.StatisticsGroupBox.Controls.Add(this.TotalFilesLabel);
            this.StatisticsGroupBox.Location = new System.Drawing.Point(17, 521);
            this.StatisticsGroupBox.Name = "StatisticsGroupBox";
            this.StatisticsGroupBox.Size = new System.Drawing.Size(227, 78);
            this.StatisticsGroupBox.TabIndex = 13;
            this.StatisticsGroupBox.TabStop = false;
            this.StatisticsGroupBox.Text = "Statistics";
            // 
            // TimedOutFilesLabel
            // 
            this.TimedOutFilesLabel.AutoSize = true;
            this.TimedOutFilesLabel.Location = new System.Drawing.Point(125, 47);
            this.TimedOutFilesLabel.Name = "TimedOutFilesLabel";
            this.TimedOutFilesLabel.Size = new System.Drawing.Size(71, 13);
            this.TimedOutFilesLabel.TabIndex = 3;
            this.TimedOutFilesLabel.Text = "Timed out: 0";
            // 
            // ErrorFilesLabel
            // 
            this.ErrorFilesLabel.AutoSize = true;
            this.ErrorFilesLabel.Location = new System.Drawing.Point(125, 24);
            this.ErrorFilesLabel.Name = "ErrorFilesLabel";
            this.ErrorFilesLabel.Size = new System.Drawing.Size(44, 13);
            this.ErrorFilesLabel.TabIndex = 2;
            this.ErrorFilesLabel.Text = "Error: 0";
            // 
            // SuccessFilesLabel
            // 
            this.SuccessFilesLabel.AutoSize = true;
            this.SuccessFilesLabel.Location = new System.Drawing.Point(9, 47);
            this.SuccessFilesLabel.Name = "SuccessFilesLabel";
            this.SuccessFilesLabel.Size = new System.Drawing.Size(58, 13);
            this.SuccessFilesLabel.TabIndex = 1;
            this.SuccessFilesLabel.Text = "Success: 0";
            // 
            // TotalFilesLabel
            // 
            this.TotalFilesLabel.AutoSize = true;
            this.TotalFilesLabel.Location = new System.Drawing.Point(9, 24);
            this.TotalFilesLabel.Name = "TotalFilesLabel";
            this.TotalFilesLabel.Size = new System.Drawing.Size(68, 13);
            this.TotalFilesLabel.TabIndex = 0;
            this.TotalFilesLabel.Text = "Total files: 0";
            // 
            // DoneButton
            // 
            this.DoneButton.Enabled = false;
            this.DoneButton.Location = new System.Drawing.Point(797, 576);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 14;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButtonClick);
            // 
            // RenamingProgressBar
            // 
            this.RenamingProgressBar.Location = new System.Drawing.Point(17, 500);
            this.RenamingProgressBar.Name = "RenamingProgressBar";
            this.RenamingProgressBar.Size = new System.Drawing.Size(855, 15);
            this.RenamingProgressBar.TabIndex = 15;
            // 
            // CurrentFileRenameLabel
            // 
            this.CurrentFileRenameLabel.AutoSize = true;
            this.CurrentFileRenameLabel.Location = new System.Drawing.Point(14, 484);
            this.CurrentFileRenameLabel.Name = "CurrentFileRenameLabel";
            this.CurrentFileRenameLabel.Size = new System.Drawing.Size(116, 13);
            this.CurrentFileRenameLabel.TabIndex = 17;
            this.CurrentFileRenameLabel.Text = "Renaming file 0 of 0: ";
            // 
            // Abortutton
            // 
            this.Abortutton.Location = new System.Drawing.Point(716, 576);
            this.Abortutton.Name = "Abortutton";
            this.Abortutton.Size = new System.Drawing.Size(75, 23);
            this.Abortutton.TabIndex = 18;
            this.Abortutton.Text = "Abort";
            this.Abortutton.UseVisualStyleBackColor = true;
            this.Abortutton.Click += new System.EventHandler(this.AbortButtonClick);
            // 
            // FileNamesOldNewListView
            // 
            this.FileNamesOldNewListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileNamesOldNewListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CFOldName,
            this.CFNewName});
            this.FileNamesOldNewListView.Enabled = false;
            this.FileNamesOldNewListView.FullRowSelect = true;
            this.FileNamesOldNewListView.HideSelection = false;
            this.FileNamesOldNewListView.Location = new System.Drawing.Point(17, 12);
            this.FileNamesOldNewListView.MultiSelect = false;
            this.FileNamesOldNewListView.Name = "FileNamesOldNewListView";
            this.FileNamesOldNewListView.ShowItemToolTips = true;
            this.FileNamesOldNewListView.Size = new System.Drawing.Size(855, 469);
            this.FileNamesOldNewListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.FileNamesOldNewListView.TabIndex = 12;
            this.FileNamesOldNewListView.UseCompatibleStateImageBehavior = false;
            this.FileNamesOldNewListView.View = System.Windows.Forms.View.Details;
            // 
            // CFOldName
            // 
            this.CFOldName.Text = "Old name";
            this.CFOldName.Width = 415;
            // 
            // CFNewName
            // 
            this.CFNewName.Text = "New name";
            this.CFNewName.Width = 415;
            // 
            // RenamerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.Abortutton);
            this.Controls.Add(this.CurrentFileRenameLabel);
            this.Controls.Add(this.RenamingProgressBar);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.StatisticsGroupBox);
            this.Controls.Add(this.FileNamesOldNewListView);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenamerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rename Selected Files";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseFormCancel);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.StatisticsGroupBox.ResumeLayout(false);
            this.StatisticsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BufferedListView FileNamesOldNewListView;
        private System.Windows.Forms.ColumnHeader CFOldName;
        private System.Windows.Forms.ColumnHeader CFNewName;
        private System.Windows.Forms.GroupBox StatisticsGroupBox;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.ProgressBar RenamingProgressBar;
        private System.Windows.Forms.Label TimedOutFilesLabel;
        private System.Windows.Forms.Label ErrorFilesLabel;
        private System.Windows.Forms.Label SuccessFilesLabel;
        private System.Windows.Forms.Label TotalFilesLabel;
        private System.Windows.Forms.Label CurrentFileRenameLabel;
        private System.Windows.Forms.Button Abortutton;
    }
}