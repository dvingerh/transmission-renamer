namespace transmission_renamer
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.PagesTabControl = new System.Windows.Forms.TabControl();
            this.TorrentTabPage = new System.Windows.Forms.TabPage();
            this.RetrievingInformationLoadingPanel = new System.Windows.Forms.Panel();
            this.RetrievingInformationLoadingLabel = new System.Windows.Forms.Label();
            this.RetrievingSpinnerLoadingPictureBox = new System.Windows.Forms.PictureBox();
            this.TorrentsListView = new BufferedListView();
            this.CTQueuePosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CTName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CTStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CTSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CTProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchTorrentListLabel = new System.Windows.Forms.Label();
            this.SearchTorrentListTextBox = new System.Windows.Forms.TextBox();
            this.FilesTabPage = new System.Windows.Forms.TabPage();
            this.ProcessingFilesLoadingPanel = new System.Windows.Forms.Panel();
            this.ProcessingFilesLoadingLabel = new System.Windows.Forms.Label();
            this.ProcessingFilesSpinnerLoadingPictureBox = new System.Windows.Forms.PictureBox();
            this.DeselectAllButton = new System.Windows.Forms.Button();
            this.CollapseAllButton = new System.Windows.Forms.Button();
            this.ExpandAllButton = new System.Windows.Forms.Button();
            this.InverseButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.TorrentFileListTreeView = new BufferedTreeView();
            this.CopyFileNameContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyFilenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RulesTabPage = new System.Windows.Forms.TabPage();
            this.LoadRulesButton = new System.Windows.Forms.Button();
            this.SaveRulesButton = new System.Windows.Forms.Button();
            this.ProcessingRulesFilesLoadingPanel = new System.Windows.Forms.Panel();
            this.ProcessingRulesFilesLoadingLabel = new System.Windows.Forms.Label();
            this.ProcessingRulesFilesSpinnerLoadingPictureBox = new System.Windows.Forms.PictureBox();
            this.FileNamesOldNewListView = new BufferedListView();
            this.CFOldName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CFNewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CopyOldNewFileNameContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyOldFilenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNewFilenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRuleButton = new System.Windows.Forms.Button();
            this.MoveRuleDownButton = new System.Windows.Forms.Button();
            this.MoveRuleUpButton = new System.Windows.Forms.Button();
            this.EditRuleButton = new System.Windows.Forms.Button();
            this.NewRuleButton = new System.Windows.Forms.Button();
            this.RulesListView = new System.Windows.Forms.ListView();
            this.CRuleQueuePosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CRuleType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CRuleDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImagesTabPageImageList = new System.Windows.Forms.ImageList(this.components);
            this.SelectedTorrentLabel = new System.Windows.Forms.Label();
            this.SelectedFileCountLabel = new System.Windows.Forms.Label();
            this.RefreshTorrentListButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.TimeOutTimer = new System.Windows.Forms.Timer(this.components);
            this.PagesTabControl.SuspendLayout();
            this.TorrentTabPage.SuspendLayout();
            this.RetrievingInformationLoadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetrievingSpinnerLoadingPictureBox)).BeginInit();
            this.FilesTabPage.SuspendLayout();
            this.ProcessingFilesLoadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingFilesSpinnerLoadingPictureBox)).BeginInit();
            this.CopyFileNameContextMenu.SuspendLayout();
            this.RulesTabPage.SuspendLayout();
            this.ProcessingRulesFilesLoadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingRulesFilesSpinnerLoadingPictureBox)).BeginInit();
            this.CopyOldNewFileNameContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagesTabControl
            // 
            this.PagesTabControl.Controls.Add(this.TorrentTabPage);
            this.PagesTabControl.Controls.Add(this.FilesTabPage);
            this.PagesTabControl.Controls.Add(this.RulesTabPage);
            this.PagesTabControl.ImageList = this.ImagesTabPageImageList;
            this.PagesTabControl.Location = new System.Drawing.Point(15, 61);
            this.PagesTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PagesTabControl.Name = "PagesTabControl";
            this.PagesTabControl.SelectedIndex = 0;
            this.PagesTabControl.Size = new System.Drawing.Size(1080, 776);
            this.PagesTabControl.TabIndex = 1;
            // 
            // TorrentTabPage
            // 
            this.TorrentTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.TorrentTabPage.Controls.Add(this.RetrievingInformationLoadingPanel);
            this.TorrentTabPage.Controls.Add(this.TorrentsListView);
            this.TorrentTabPage.Controls.Add(this.SearchTorrentListLabel);
            this.TorrentTabPage.Controls.Add(this.SearchTorrentListTextBox);
            this.TorrentTabPage.ImageIndex = 0;
            this.TorrentTabPage.Location = new System.Drawing.Point(4, 28);
            this.TorrentTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TorrentTabPage.Name = "TorrentTabPage";
            this.TorrentTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TorrentTabPage.Size = new System.Drawing.Size(1072, 744);
            this.TorrentTabPage.TabIndex = 0;
            this.TorrentTabPage.Text = "Torrents";
            // 
            // RetrievingInformationLoadingPanel
            // 
            this.RetrievingInformationLoadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RetrievingInformationLoadingPanel.Controls.Add(this.RetrievingInformationLoadingLabel);
            this.RetrievingInformationLoadingPanel.Controls.Add(this.RetrievingSpinnerLoadingPictureBox);
            this.RetrievingInformationLoadingPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetrievingInformationLoadingPanel.Location = new System.Drawing.Point(426, 334);
            this.RetrievingInformationLoadingPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RetrievingInformationLoadingPanel.Name = "RetrievingInformationLoadingPanel";
            this.RetrievingInformationLoadingPanel.Size = new System.Drawing.Size(218, 74);
            this.RetrievingInformationLoadingPanel.TabIndex = 12;
            this.RetrievingInformationLoadingPanel.Visible = false;
            // 
            // RetrievingInformationLoadingLabel
            // 
            this.RetrievingInformationLoadingLabel.AutoSize = true;
            this.RetrievingInformationLoadingLabel.Location = new System.Drawing.Point(38, 29);
            this.RetrievingInformationLoadingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RetrievingInformationLoadingLabel.Name = "RetrievingInformationLoadingLabel";
            this.RetrievingInformationLoadingLabel.Size = new System.Drawing.Size(154, 19);
            this.RetrievingInformationLoadingLabel.TabIndex = 1;
            this.RetrievingInformationLoadingLabel.Text = "Retrieving information...";
            // 
            // RetrievingSpinnerLoadingPictureBox
            // 
            this.RetrievingSpinnerLoadingPictureBox.Image = global::transmission_renamer.Properties.Resources.spinner;
            this.RetrievingSpinnerLoadingPictureBox.Location = new System.Drawing.Point(14, 26);
            this.RetrievingSpinnerLoadingPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RetrievingSpinnerLoadingPictureBox.Name = "RetrievingSpinnerLoadingPictureBox";
            this.RetrievingSpinnerLoadingPictureBox.Size = new System.Drawing.Size(16, 16);
            this.RetrievingSpinnerLoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.RetrievingSpinnerLoadingPictureBox.TabIndex = 0;
            this.RetrievingSpinnerLoadingPictureBox.TabStop = false;
            // 
            // TorrentsListView
            // 
            this.TorrentsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorrentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CTQueuePosition,
            this.CTName,
            this.CTStatus,
            this.CTSize,
            this.CTProgress});
            this.TorrentsListView.FullRowSelect = true;
            this.TorrentsListView.HideSelection = false;
            this.TorrentsListView.Location = new System.Drawing.Point(4, 44);
            this.TorrentsListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TorrentsListView.MultiSelect = false;
            this.TorrentsListView.Name = "TorrentsListView";
            this.TorrentsListView.Size = new System.Drawing.Size(1062, 696);
            this.TorrentsListView.TabIndex = 11;
            this.TorrentsListView.UseCompatibleStateImageBehavior = false;
            this.TorrentsListView.View = System.Windows.Forms.View.Details;
            this.TorrentsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortTorrentsListView);
            this.TorrentsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.SelectedTorrentChanged);
            // 
            // CTQueuePosition
            // 
            this.CTQueuePosition.Text = "#";
            this.CTQueuePosition.Width = 40;
            // 
            // CTName
            // 
            this.CTName.Text = "Name";
            this.CTName.Width = 575;
            // 
            // CTStatus
            // 
            this.CTStatus.Text = "Status";
            this.CTStatus.Width = 70;
            // 
            // CTSize
            // 
            this.CTSize.Text = "Size";
            this.CTSize.Width = 70;
            // 
            // CTProgress
            // 
            this.CTProgress.Text = "Progress";
            this.CTProgress.Width = 70;
            // 
            // SearchTorrentListLabel
            // 
            this.SearchTorrentListLabel.AutoSize = true;
            this.SearchTorrentListLabel.Location = new System.Drawing.Point(9, 14);
            this.SearchTorrentListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SearchTorrentListLabel.Name = "SearchTorrentListLabel";
            this.SearchTorrentListLabel.Size = new System.Drawing.Size(99, 19);
            this.SearchTorrentListLabel.TabIndex = 9;
            this.SearchTorrentListLabel.Text = "Search torrent:";
            // 
            // SearchTorrentListTextBox
            // 
            this.SearchTorrentListTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTorrentListTextBox.Location = new System.Drawing.Point(116, 9);
            this.SearchTorrentListTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchTorrentListTextBox.Name = "SearchTorrentListTextBox";
            this.SearchTorrentListTextBox.Size = new System.Drawing.Size(950, 26);
            this.SearchTorrentListTextBox.TabIndex = 0;
            this.SearchTorrentListTextBox.TextChanged += new System.EventHandler(this.SearchTorrentListTextBox_TextChanged);
            this.SearchTorrentListTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCtrlKeyBack);
            // 
            // FilesTabPage
            // 
            this.FilesTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.FilesTabPage.Controls.Add(this.ProcessingFilesLoadingPanel);
            this.FilesTabPage.Controls.Add(this.DeselectAllButton);
            this.FilesTabPage.Controls.Add(this.CollapseAllButton);
            this.FilesTabPage.Controls.Add(this.ExpandAllButton);
            this.FilesTabPage.Controls.Add(this.InverseButton);
            this.FilesTabPage.Controls.Add(this.SelectAllButton);
            this.FilesTabPage.Controls.Add(this.TorrentFileListTreeView);
            this.FilesTabPage.ImageIndex = 1;
            this.FilesTabPage.Location = new System.Drawing.Point(4, 28);
            this.FilesTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilesTabPage.Name = "FilesTabPage";
            this.FilesTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilesTabPage.Size = new System.Drawing.Size(1072, 744);
            this.FilesTabPage.TabIndex = 1;
            this.FilesTabPage.Text = "Files";
            // 
            // ProcessingFilesLoadingPanel
            // 
            this.ProcessingFilesLoadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcessingFilesLoadingPanel.Controls.Add(this.ProcessingFilesLoadingLabel);
            this.ProcessingFilesLoadingPanel.Controls.Add(this.ProcessingFilesSpinnerLoadingPictureBox);
            this.ProcessingFilesLoadingPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessingFilesLoadingPanel.Location = new System.Drawing.Point(426, 334);
            this.ProcessingFilesLoadingPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProcessingFilesLoadingPanel.Name = "ProcessingFilesLoadingPanel";
            this.ProcessingFilesLoadingPanel.Size = new System.Drawing.Size(218, 74);
            this.ProcessingFilesLoadingPanel.TabIndex = 13;
            this.ProcessingFilesLoadingPanel.Visible = false;
            // 
            // ProcessingFilesLoadingLabel
            // 
            this.ProcessingFilesLoadingLabel.AutoSize = true;
            this.ProcessingFilesLoadingLabel.Location = new System.Drawing.Point(75, 29);
            this.ProcessingFilesLoadingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProcessingFilesLoadingLabel.Name = "ProcessingFilesLoadingLabel";
            this.ProcessingFilesLoadingLabel.Size = new System.Drawing.Size(83, 19);
            this.ProcessingFilesLoadingLabel.TabIndex = 1;
            this.ProcessingFilesLoadingLabel.Text = "Processing...";
            // 
            // ProcessingFilesSpinnerLoadingPictureBox
            // 
            this.ProcessingFilesSpinnerLoadingPictureBox.Image = global::transmission_renamer.Properties.Resources.spinner;
            this.ProcessingFilesSpinnerLoadingPictureBox.Location = new System.Drawing.Point(51, 26);
            this.ProcessingFilesSpinnerLoadingPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProcessingFilesSpinnerLoadingPictureBox.Name = "ProcessingFilesSpinnerLoadingPictureBox";
            this.ProcessingFilesSpinnerLoadingPictureBox.Size = new System.Drawing.Size(16, 16);
            this.ProcessingFilesSpinnerLoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ProcessingFilesSpinnerLoadingPictureBox.TabIndex = 0;
            this.ProcessingFilesSpinnerLoadingPictureBox.TabStop = false;
            // 
            // DeselectAllButton
            // 
            this.DeselectAllButton.Enabled = false;
            this.DeselectAllButton.Location = new System.Drawing.Point(105, 8);
            this.DeselectAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeselectAllButton.Name = "DeselectAllButton";
            this.DeselectAllButton.Size = new System.Drawing.Size(94, 29);
            this.DeselectAllButton.TabIndex = 2;
            this.DeselectAllButton.Text = "Deselect All";
            this.DeselectAllButton.UseVisualStyleBackColor = true;
            this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllButtonClick);
            // 
            // CollapseAllButton
            // 
            this.CollapseAllButton.Enabled = false;
            this.CollapseAllButton.Location = new System.Drawing.Point(974, 8);
            this.CollapseAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CollapseAllButton.Name = "CollapseAllButton";
            this.CollapseAllButton.Size = new System.Drawing.Size(94, 29);
            this.CollapseAllButton.TabIndex = 5;
            this.CollapseAllButton.Text = "Collapse All";
            this.CollapseAllButton.UseVisualStyleBackColor = true;
            this.CollapseAllButton.Click += new System.EventHandler(this.CollapseAllButtonClick);
            // 
            // ExpandAllButton
            // 
            this.ExpandAllButton.Enabled = false;
            this.ExpandAllButton.Location = new System.Drawing.Point(872, 8);
            this.ExpandAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExpandAllButton.Name = "ExpandAllButton";
            this.ExpandAllButton.Size = new System.Drawing.Size(94, 29);
            this.ExpandAllButton.TabIndex = 4;
            this.ExpandAllButton.Text = "Expand All";
            this.ExpandAllButton.UseVisualStyleBackColor = true;
            this.ExpandAllButton.Click += new System.EventHandler(this.ExpandAllButtonClick);
            // 
            // InverseButton
            // 
            this.InverseButton.Enabled = false;
            this.InverseButton.Location = new System.Drawing.Point(206, 8);
            this.InverseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InverseButton.Name = "InverseButton";
            this.InverseButton.Size = new System.Drawing.Size(94, 29);
            this.InverseButton.TabIndex = 3;
            this.InverseButton.Text = "Inverse";
            this.InverseButton.UseVisualStyleBackColor = true;
            this.InverseButton.Click += new System.EventHandler(this.InverseButtonClick);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Enabled = false;
            this.SelectAllButton.Location = new System.Drawing.Point(4, 8);
            this.SelectAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(94, 29);
            this.SelectAllButton.TabIndex = 1;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButtonClick);
            // 
            // TorrentFileListTreeView
            // 
            this.TorrentFileListTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorrentFileListTreeView.ContextMenuStrip = this.CopyFileNameContextMenu;
            this.TorrentFileListTreeView.FullRowSelect = true;
            this.TorrentFileListTreeView.ItemHeight = 19;
            this.TorrentFileListTreeView.Location = new System.Drawing.Point(4, 44);
            this.TorrentFileListTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TorrentFileListTreeView.Name = "TorrentFileListTreeView";
            this.TorrentFileListTreeView.PathSeparator = "/";
            this.TorrentFileListTreeView.ShowNodeToolTips = true;
            this.TorrentFileListTreeView.Size = new System.Drawing.Size(1062, 696);
            this.TorrentFileListTreeView.TabIndex = 0;
            this.TorrentFileListTreeView.TriStateStyleProperty = BufferedTreeView.TriStateStyles.Standard;
            // 
            // CopyFileNameContextMenu
            // 
            this.CopyFileNameContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CopyFileNameContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFilenameToolStripMenuItem});
            this.CopyFileNameContextMenu.Name = "contextMenuStrip1";
            this.CopyFileNameContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.CopyFileNameContextMenu.Size = new System.Drawing.Size(175, 28);
            // 
            // copyFilenameToolStripMenuItem
            // 
            this.copyFilenameToolStripMenuItem.Name = "copyFilenameToolStripMenuItem";
            this.copyFilenameToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.copyFilenameToolStripMenuItem.Text = "Copy filename";
            this.copyFilenameToolStripMenuItem.Click += new System.EventHandler(this.CopyFileNameClick);
            // 
            // RulesTabPage
            // 
            this.RulesTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.RulesTabPage.Controls.Add(this.LoadRulesButton);
            this.RulesTabPage.Controls.Add(this.SaveRulesButton);
            this.RulesTabPage.Controls.Add(this.ProcessingRulesFilesLoadingPanel);
            this.RulesTabPage.Controls.Add(this.FileNamesOldNewListView);
            this.RulesTabPage.Controls.Add(this.DeleteRuleButton);
            this.RulesTabPage.Controls.Add(this.MoveRuleDownButton);
            this.RulesTabPage.Controls.Add(this.MoveRuleUpButton);
            this.RulesTabPage.Controls.Add(this.EditRuleButton);
            this.RulesTabPage.Controls.Add(this.NewRuleButton);
            this.RulesTabPage.Controls.Add(this.RulesListView);
            this.RulesTabPage.ImageIndex = 3;
            this.RulesTabPage.Location = new System.Drawing.Point(4, 28);
            this.RulesTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RulesTabPage.Name = "RulesTabPage";
            this.RulesTabPage.Size = new System.Drawing.Size(1072, 744);
            this.RulesTabPage.TabIndex = 2;
            this.RulesTabPage.Text = "Rules";
            // 
            // LoadRulesButton
            // 
            this.LoadRulesButton.Location = new System.Drawing.Point(871, 8);
            this.LoadRulesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadRulesButton.Name = "LoadRulesButton";
            this.LoadRulesButton.Size = new System.Drawing.Size(94, 29);
            this.LoadRulesButton.TabIndex = 17;
            this.LoadRulesButton.Text = "Load";
            this.LoadRulesButton.UseVisualStyleBackColor = true;
            this.LoadRulesButton.Click += new System.EventHandler(this.LoadRulesButtonClick);
            // 
            // SaveRulesButton
            // 
            this.SaveRulesButton.Location = new System.Drawing.Point(972, 8);
            this.SaveRulesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveRulesButton.Name = "SaveRulesButton";
            this.SaveRulesButton.Size = new System.Drawing.Size(94, 29);
            this.SaveRulesButton.TabIndex = 15;
            this.SaveRulesButton.Text = "Save";
            this.SaveRulesButton.UseVisualStyleBackColor = true;
            this.SaveRulesButton.Click += new System.EventHandler(this.SaveRulesButtonClick);
            // 
            // ProcessingRulesFilesLoadingPanel
            // 
            this.ProcessingRulesFilesLoadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcessingRulesFilesLoadingPanel.Controls.Add(this.ProcessingRulesFilesLoadingLabel);
            this.ProcessingRulesFilesLoadingPanel.Controls.Add(this.ProcessingRulesFilesSpinnerLoadingPictureBox);
            this.ProcessingRulesFilesLoadingPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessingRulesFilesLoadingPanel.Location = new System.Drawing.Point(426, 334);
            this.ProcessingRulesFilesLoadingPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProcessingRulesFilesLoadingPanel.Name = "ProcessingRulesFilesLoadingPanel";
            this.ProcessingRulesFilesLoadingPanel.Size = new System.Drawing.Size(218, 74);
            this.ProcessingRulesFilesLoadingPanel.TabIndex = 14;
            // 
            // ProcessingRulesFilesLoadingLabel
            // 
            this.ProcessingRulesFilesLoadingLabel.AutoSize = true;
            this.ProcessingRulesFilesLoadingLabel.Location = new System.Drawing.Point(75, 29);
            this.ProcessingRulesFilesLoadingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProcessingRulesFilesLoadingLabel.Name = "ProcessingRulesFilesLoadingLabel";
            this.ProcessingRulesFilesLoadingLabel.Size = new System.Drawing.Size(83, 19);
            this.ProcessingRulesFilesLoadingLabel.TabIndex = 1;
            this.ProcessingRulesFilesLoadingLabel.Text = "Processing...";
            // 
            // ProcessingRulesFilesSpinnerLoadingPictureBox
            // 
            this.ProcessingRulesFilesSpinnerLoadingPictureBox.Image = global::transmission_renamer.Properties.Resources.spinner;
            this.ProcessingRulesFilesSpinnerLoadingPictureBox.Location = new System.Drawing.Point(51, 26);
            this.ProcessingRulesFilesSpinnerLoadingPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProcessingRulesFilesSpinnerLoadingPictureBox.Name = "ProcessingRulesFilesSpinnerLoadingPictureBox";
            this.ProcessingRulesFilesSpinnerLoadingPictureBox.Size = new System.Drawing.Size(16, 16);
            this.ProcessingRulesFilesSpinnerLoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ProcessingRulesFilesSpinnerLoadingPictureBox.TabIndex = 0;
            this.ProcessingRulesFilesSpinnerLoadingPictureBox.TabStop = false;
            // 
            // FileNamesOldNewListView
            // 
            this.FileNamesOldNewListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileNamesOldNewListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CFOldName,
            this.CFNewName});
            this.FileNamesOldNewListView.ContextMenuStrip = this.CopyOldNewFileNameContextMenu;
            this.FileNamesOldNewListView.FullRowSelect = true;
            this.FileNamesOldNewListView.HideSelection = false;
            this.FileNamesOldNewListView.Location = new System.Drawing.Point(4, 301);
            this.FileNamesOldNewListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FileNamesOldNewListView.MultiSelect = false;
            this.FileNamesOldNewListView.Name = "FileNamesOldNewListView";
            this.FileNamesOldNewListView.ShowItemToolTips = true;
            this.FileNamesOldNewListView.Size = new System.Drawing.Size(1062, 437);
            this.FileNamesOldNewListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.FileNamesOldNewListView.TabIndex = 11;
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
            // CopyOldNewFileNameContextMenu
            // 
            this.CopyOldNewFileNameContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CopyOldNewFileNameContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyOldFilenameToolStripMenuItem,
            this.copyNewFilenameToolStripMenuItem});
            this.CopyOldNewFileNameContextMenu.Name = "CopyOldNewFileNameContextMenu";
            this.CopyOldNewFileNameContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.CopyOldNewFileNameContextMenu.Size = new System.Drawing.Size(206, 52);
            // 
            // copyOldFilenameToolStripMenuItem
            // 
            this.copyOldFilenameToolStripMenuItem.Name = "copyOldFilenameToolStripMenuItem";
            this.copyOldFilenameToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.copyOldFilenameToolStripMenuItem.Text = "Copy old filename";
            this.copyOldFilenameToolStripMenuItem.Click += new System.EventHandler(this.CopyOldFileNameClick);
            // 
            // copyNewFilenameToolStripMenuItem
            // 
            this.copyNewFilenameToolStripMenuItem.Name = "copyNewFilenameToolStripMenuItem";
            this.copyNewFilenameToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.copyNewFilenameToolStripMenuItem.Text = "Copy new filename";
            this.copyNewFilenameToolStripMenuItem.Click += new System.EventHandler(this.CopyNewFileNameClick);
            // 
            // DeleteRuleButton
            // 
            this.DeleteRuleButton.Enabled = false;
            this.DeleteRuleButton.Location = new System.Drawing.Point(206, 8);
            this.DeleteRuleButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteRuleButton.Name = "DeleteRuleButton";
            this.DeleteRuleButton.Size = new System.Drawing.Size(94, 29);
            this.DeleteRuleButton.TabIndex = 7;
            this.DeleteRuleButton.Text = "Delete";
            this.DeleteRuleButton.UseVisualStyleBackColor = true;
            this.DeleteRuleButton.Click += new System.EventHandler(this.DeleteRuleButtonClick);
            // 
            // MoveRuleDownButton
            // 
            this.MoveRuleDownButton.Enabled = false;
            this.MoveRuleDownButton.Location = new System.Drawing.Point(429, 8);
            this.MoveRuleDownButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MoveRuleDownButton.Name = "MoveRuleDownButton";
            this.MoveRuleDownButton.Size = new System.Drawing.Size(94, 29);
            this.MoveRuleDownButton.TabIndex = 10;
            this.MoveRuleDownButton.Text = "Down";
            this.MoveRuleDownButton.UseVisualStyleBackColor = true;
            this.MoveRuleDownButton.Click += new System.EventHandler(this.MoveRuleDownButtonClick);
            // 
            // MoveRuleUpButton
            // 
            this.MoveRuleUpButton.Enabled = false;
            this.MoveRuleUpButton.Location = new System.Drawing.Point(328, 8);
            this.MoveRuleUpButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MoveRuleUpButton.Name = "MoveRuleUpButton";
            this.MoveRuleUpButton.Size = new System.Drawing.Size(94, 29);
            this.MoveRuleUpButton.TabIndex = 9;
            this.MoveRuleUpButton.Text = "Up";
            this.MoveRuleUpButton.UseVisualStyleBackColor = true;
            this.MoveRuleUpButton.Click += new System.EventHandler(this.MoveRuleUpButtonClick);
            // 
            // EditRuleButton
            // 
            this.EditRuleButton.Enabled = false;
            this.EditRuleButton.Location = new System.Drawing.Point(105, 8);
            this.EditRuleButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditRuleButton.Name = "EditRuleButton";
            this.EditRuleButton.Size = new System.Drawing.Size(94, 29);
            this.EditRuleButton.TabIndex = 8;
            this.EditRuleButton.Text = "Edit";
            this.EditRuleButton.UseVisualStyleBackColor = true;
            this.EditRuleButton.Click += new System.EventHandler(this.EditRuleButtonClick);
            // 
            // NewRuleButton
            // 
            this.NewRuleButton.Location = new System.Drawing.Point(4, 8);
            this.NewRuleButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewRuleButton.Name = "NewRuleButton";
            this.NewRuleButton.Size = new System.Drawing.Size(94, 29);
            this.NewRuleButton.TabIndex = 6;
            this.NewRuleButton.Text = "New";
            this.NewRuleButton.UseVisualStyleBackColor = true;
            this.NewRuleButton.Click += new System.EventHandler(this.NewRuleButtonClick);
            // 
            // RulesListView
            // 
            this.RulesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RulesListView.CheckBoxes = true;
            this.RulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CRuleQueuePosition,
            this.CRuleType,
            this.CRuleDescription});
            this.RulesListView.FullRowSelect = true;
            this.RulesListView.HideSelection = false;
            this.RulesListView.Location = new System.Drawing.Point(4, 44);
            this.RulesListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RulesListView.MultiSelect = false;
            this.RulesListView.Name = "RulesListView";
            this.RulesListView.Size = new System.Drawing.Size(1062, 250);
            this.RulesListView.TabIndex = 0;
            this.RulesListView.UseCompatibleStateImageBehavior = false;
            this.RulesListView.View = System.Windows.Forms.View.Details;
            this.RulesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.RuleEnabledChanged);
            this.RulesListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.UpdateRuleButtonStates);
            // 
            // CRuleQueuePosition
            // 
            this.CRuleQueuePosition.Text = "#";
            this.CRuleQueuePosition.Width = 50;
            // 
            // CRuleType
            // 
            this.CRuleType.Text = "Rule type";
            this.CRuleType.Width = 100;
            // 
            // CRuleDescription
            // 
            this.CRuleDescription.Text = "Description";
            this.CRuleDescription.Width = 620;
            // 
            // ImagesTabPageImageList
            // 
            this.ImagesTabPageImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagesTabPageImageList.ImageStream")));
            this.ImagesTabPageImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagesTabPageImageList.Images.SetKeyName(0, "transmission.png");
            this.ImagesTabPageImageList.Images.SetKeyName(1, "file.png");
            this.ImagesTabPageImageList.Images.SetKeyName(2, "folder.png");
            this.ImagesTabPageImageList.Images.SetKeyName(3, "rules.png");
            // 
            // SelectedTorrentLabel
            // 
            this.SelectedTorrentLabel.AutoSize = true;
            this.SelectedTorrentLabel.Location = new System.Drawing.Point(11, 11);
            this.SelectedTorrentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectedTorrentLabel.Name = "SelectedTorrentLabel";
            this.SelectedTorrentLabel.Size = new System.Drawing.Size(199, 19);
            this.SelectedTorrentLabel.TabIndex = 1;
            this.SelectedTorrentLabel.Text = "Selected torrent: None selected";
            // 
            // SelectedFileCountLabel
            // 
            this.SelectedFileCountLabel.AutoSize = true;
            this.SelectedFileCountLabel.Location = new System.Drawing.Point(11, 36);
            this.SelectedFileCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectedFileCountLabel.Name = "SelectedFileCountLabel";
            this.SelectedFileCountLabel.Size = new System.Drawing.Size(294, 19);
            this.SelectedFileCountLabel.TabIndex = 2;
            this.SelectedFileCountLabel.Text = "Selected files: 0 (total file count not yet known)";
            // 
            // RefreshTorrentListButton
            // 
            this.RefreshTorrentListButton.Location = new System.Drawing.Point(829, 845);
            this.RefreshTorrentListButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshTorrentListButton.Name = "RefreshTorrentListButton";
            this.RefreshTorrentListButton.Size = new System.Drawing.Size(160, 29);
            this.RefreshTorrentListButton.TabIndex = 3;
            this.RefreshTorrentListButton.Text = "Refresh &Torrent List";
            this.RefreshTorrentListButton.UseVisualStyleBackColor = true;
            this.RefreshTorrentListButton.Click += new System.EventHandler(this.RefreshTorrentListButtonClick);
            // 
            // RenameButton
            // 
            this.RenameButton.Enabled = false;
            this.RenameButton.Location = new System.Drawing.Point(996, 845);
            this.RenameButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(94, 29);
            this.RenameButton.TabIndex = 4;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButtonClick);
            // 
            // BackButton
            // 
            this.BackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BackButton.Location = new System.Drawing.Point(15, 845);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(94, 29);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // TimeOutTimer
            // 
            this.TimeOutTimer.Interval = 1000;
            this.TimeOutTimer.Tag = "";
            this.TimeOutTimer.Tick += new System.EventHandler(this.TimeOutTimerTick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.BackButton;
            this.ClientSize = new System.Drawing.Size(1105, 889);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.RefreshTorrentListButton);
            this.Controls.Add(this.SelectedFileCountLabel);
            this.Controls.Add(this.SelectedTorrentLabel);
            this.Controls.Add(this.PagesTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transmission Renamer";
            this.Load += new System.EventHandler(this.RefreshOnLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FocusTorrentSearchBoxShortcut);
            this.PagesTabControl.ResumeLayout(false);
            this.TorrentTabPage.ResumeLayout(false);
            this.TorrentTabPage.PerformLayout();
            this.RetrievingInformationLoadingPanel.ResumeLayout(false);
            this.RetrievingInformationLoadingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetrievingSpinnerLoadingPictureBox)).EndInit();
            this.FilesTabPage.ResumeLayout(false);
            this.ProcessingFilesLoadingPanel.ResumeLayout(false);
            this.ProcessingFilesLoadingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingFilesSpinnerLoadingPictureBox)).EndInit();
            this.CopyFileNameContextMenu.ResumeLayout(false);
            this.RulesTabPage.ResumeLayout(false);
            this.ProcessingRulesFilesLoadingPanel.ResumeLayout(false);
            this.ProcessingRulesFilesLoadingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingRulesFilesSpinnerLoadingPictureBox)).EndInit();
            this.CopyOldNewFileNameContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl PagesTabControl;
        private System.Windows.Forms.TabPage TorrentTabPage;
        private System.Windows.Forms.TabPage FilesTabPage;
        private System.Windows.Forms.Label SelectedTorrentLabel;
        private System.Windows.Forms.Label SelectedFileCountLabel;
        private System.Windows.Forms.Button RefreshTorrentListButton;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Timer TimeOutTimer;
        private System.Windows.Forms.Button DeselectAllButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button InverseButton;
        private System.Windows.Forms.Label SearchTorrentListLabel;
        private System.Windows.Forms.Button CollapseAllButton;
        private System.Windows.Forms.Button ExpandAllButton;
        private System.Windows.Forms.TabPage RulesTabPage;
        private BufferedTreeView TorrentFileListTreeView;
        private System.Windows.Forms.ImageList ImagesTabPageImageList;
        private System.Windows.Forms.ListView RulesListView;
        private System.Windows.Forms.ColumnHeader CRuleQueuePosition;
        private System.Windows.Forms.ColumnHeader CRuleType;
        private System.Windows.Forms.ColumnHeader CRuleDescription;
        private System.Windows.Forms.Button DeleteRuleButton;
        private System.Windows.Forms.Button MoveRuleDownButton;
        private System.Windows.Forms.Button MoveRuleUpButton;
        private System.Windows.Forms.Button EditRuleButton;
        private System.Windows.Forms.Button NewRuleButton;
        private BufferedListView TorrentsListView;
        private System.Windows.Forms.ColumnHeader CTQueuePosition;
        private System.Windows.Forms.ColumnHeader CTName;
        private System.Windows.Forms.ColumnHeader CTStatus;
        private System.Windows.Forms.ColumnHeader CTSize;
        private System.Windows.Forms.ColumnHeader CTProgress;
        private BufferedListView FileNamesOldNewListView;
        private System.Windows.Forms.ColumnHeader CFOldName;
        private System.Windows.Forms.Panel RetrievingInformationLoadingPanel;
        private System.Windows.Forms.Label RetrievingInformationLoadingLabel;
        private System.Windows.Forms.PictureBox RetrievingSpinnerLoadingPictureBox;
        private System.Windows.Forms.Panel ProcessingFilesLoadingPanel;
        private System.Windows.Forms.Label ProcessingFilesLoadingLabel;
        private System.Windows.Forms.PictureBox ProcessingFilesSpinnerLoadingPictureBox;
        private System.Windows.Forms.Panel ProcessingRulesFilesLoadingPanel;
        private System.Windows.Forms.Label ProcessingRulesFilesLoadingLabel;
        private System.Windows.Forms.PictureBox ProcessingRulesFilesSpinnerLoadingPictureBox;
        private System.Windows.Forms.ColumnHeader CFNewName;
        private System.Windows.Forms.ContextMenuStrip CopyOldNewFileNameContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyOldFilenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyNewFilenameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CopyFileNameContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyFilenameToolStripMenuItem;
        private System.Windows.Forms.Button SaveRulesButton;
        private System.Windows.Forms.Button LoadRulesButton;
        private System.Windows.Forms.TextBox SearchTorrentListTextBox;
    }
}