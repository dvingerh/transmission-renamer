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
            this.FileNamesOldNewListView = new BufferedListView();
            this.CFOldName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CFNewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalFilesLabel = new System.Windows.Forms.Label();
            this.StatisticsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileNamesOldNewListView
            // 
            this.FileNamesOldNewListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileNamesOldNewListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CFOldName,
            this.CFNewName});
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
            // StatisticsGroupBox
            // 
            this.StatisticsGroupBox.Controls.Add(this.label2);
            this.StatisticsGroupBox.Controls.Add(this.label1);
            this.StatisticsGroupBox.Controls.Add(this.TotalFilesLabel);
            this.StatisticsGroupBox.Location = new System.Drawing.Point(17, 487);
            this.StatisticsGroupBox.Name = "StatisticsGroupBox";
            this.StatisticsGroupBox.Size = new System.Drawing.Size(203, 112);
            this.StatisticsGroupBox.TabIndex = 13;
            this.StatisticsGroupBox.TabStop = false;
            this.StatisticsGroupBox.Text = "Statistics";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Success:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Success:";
            // 
            // TotalFilesLabel
            // 
            this.TotalFilesLabel.AutoSize = true;
            this.TotalFilesLabel.Location = new System.Drawing.Point(17, 28);
            this.TotalFilesLabel.Name = "TotalFilesLabel";
            this.TotalFilesLabel.Size = new System.Drawing.Size(59, 13);
            this.TotalFilesLabel.TabIndex = 0;
            this.TotalFilesLabel.Text = "Total files:";
            // 
            // RenamerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.StatisticsGroupBox);
            this.Controls.Add(this.FileNamesOldNewListView);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RenamerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rename Selected Files";
            this.StatisticsGroupBox.ResumeLayout(false);
            this.StatisticsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BufferedListView FileNamesOldNewListView;
        private System.Windows.Forms.ColumnHeader CFOldName;
        private System.Windows.Forms.ColumnHeader CFNewName;
        private System.Windows.Forms.GroupBox StatisticsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TotalFilesLabel;
    }
}