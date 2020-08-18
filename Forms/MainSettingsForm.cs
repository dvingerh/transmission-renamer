using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transmission.API.RPC.Entity;
using transmission_renamer.Classes;
using transmission_renamer.Classes.Rules;
using transmission_renamer.Forms;

namespace transmission_renamer
{
    public partial class SelectTorrentFilesForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        private ListViewItem currentTorrentListViewItem;
        private TreeNode rootNode;

        public SelectTorrentFilesForm()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            TorrentsListView.ListViewItemSorter = lvwColumnSorter;
            ImageList rowHeightFix = new ImageList(components);
            rowHeightFix.ImageSize = new Size(1, 19);
            rowHeightFix.TransparentColor = Color.Transparent;
            TorrentsListView.SmallImageList = rowHeightFix;
            RulesListView.SmallImageList = rowHeightFix;
            ImageList torrentFilesImageList = new ImageList();
            torrentFilesImageList.ColorDepth = ColorDepth.Depth32Bit;
            torrentFilesImageList.TransparentColor = Color.Transparent;
            torrentFilesImageList.Images.Add(Properties.Resources.file);
            torrentFilesImageList.Images.Add(Properties.Resources.folder);
            TorrentFileListTreeView.ImageList = torrentFilesImageList;
            FileNamesOldNewListView.SmallImageList = torrentFilesImageList;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            if (Globals.SessionHandler != null)
                Globals.SessionHandler.CloseConnection();
            Close();
        }

        private async void RefreshTorrentListButtonClick(object sender, EventArgs e)
        {
            await RefreshTorrentList();
        }

        private void ToggleLoadingPanel(bool state)
        {
            foreach (Control control in PagesTabControl.SelectedTab.Controls)
            {
                if (control.Name.IndexOf("Loading") == -1)
                    control.Enabled = !state;
            }
            RetrievingInformationLoadingPanel.Visible = state;
            ProcessingRulesFilesLoadingPanel.Visible = state;
            ProcessingFilesLoadingPanel.Visible = state;
            RetrievingInformationLoadingPanel.Update();
            ProcessingRulesFilesLoadingPanel.Update();
            ProcessingFilesLoadingPanel.Update();
        }

        private async Task RefreshTorrentList()
        {
            DialogResult dialogResult;
            bool doContinue = true;
            if (TorrentFileListTreeView.TotalFilesSelected != 0)
            {
                dialogResult = MessageBox.Show("Refreshing the torrent list will cause the current file selection to be lost.\r\n\r\nDo you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                    doContinue = false;
            }
            if (doContinue)
            {
                PagesTabControl.SelectedIndex = 0;
                SearchTorrentListTextBox.Clear();
                TorrentFileListTreeView.TotalFilesSelected = 0;
                TorrentFileListTreeView.TotalFiles = 0;
                SelectedTorrentLabel.Text = "Selected torrent: None selected";
                SelectedFileCountLabel.Text = "Selected files: 0 (total file count not yet known)";
                TorrentFileListTreeView.Nodes.Clear();
                TorrentsListView.Items.Clear();
                FileNamesOldNewListView.Items.Clear();
                Globals.TorrentsInfo.Clear();
                Globals.SelectedTorrent = null;
                Globals.SelectedTorrentFiles.Clear();
                RenameButton.Enabled = false;
                RefreshTorrentListButton.Enabled = false;
                RefreshTorrentListButton.Text = "Waiting (10)";
                TimeOutTimer.Start();
                ToggleLoadingPanel(true);
                List<TorrentInfo> torrentsInfo = await Task.Run(() => Globals.SessionHandler.GetSessionTorrents());

                TimeOutTimer.Stop();
                TimeOutTimer.Tag = "10";

                if (torrentsInfo != null)
                {
                    if (torrentsInfo.Count == 0)
                        MessageBox.Show("The host returned 0 torrents.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        List<FriendlyTorrentInfo> globalTorrentsInfo = new List<FriendlyTorrentInfo>();
                        List<ListViewItem> torrentLVItems = new List<ListViewItem>();
                        TorrentsListView.BeginUpdate();
                        foreach (TorrentInfo torrent in torrentsInfo)
                        {
                            FriendlyTorrentInfo fTorrentInfo = new FriendlyTorrentInfo(torrent);
                            globalTorrentsInfo.Add(fTorrentInfo);
                            var torrentLVItem = new ListViewItem(new[] { fTorrentInfo.QueuePosition, fTorrentInfo.Name, fTorrentInfo.Status,
                            fTorrentInfo.Size, fTorrentInfo.Progress });
                            torrentLVItem.Tag = fTorrentInfo.Torrent;
                            torrentLVItems.Add(torrentLVItem);
                        }
                        TorrentsListView.Items.AddRange(torrentLVItems.ToArray());
                        TorrentsListView.EndUpdate();
                        Globals.TorrentsInfo = globalTorrentsInfo;
                    }
                }
                else
                    MessageBox.Show("The connection to the host has timed out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ToggleLoadingPanel(false);
                RefreshTorrentListButton.Text = "Refresh Torrent List";
                RefreshTorrentListButton.Enabled = true;
                SearchTorrentListTextBox.Focus();
            }
        }

        private void SortTorrentsListView(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            TorrentsListView.BeginUpdate();
            TorrentsListView.Sort();
            TorrentsListView.EndUpdate();
        }

        private void TimeOutTimerTick(object sender, EventArgs e)
        {
            int secondsLeft = int.Parse(TimeOutTimer.Tag.ToString()) - 1;
            RefreshTorrentListButton.Text = $"Waiting ({secondsLeft})";
            TimeOutTimer.Tag = secondsLeft--.ToString();
        }

        private async Task LoadTorrentFilesList()
        {
            ToggleLoadingPanel(true);
            Globals.SelectedTorrentFiles.Clear();
            TorrentFileListTreeView.Nodes.Clear();
            List<string> torrentPaths = new List<string>();
            foreach (TransmissionTorrentFiles torrentFile in Globals.SelectedTorrent.Torrent.Files)
            {
                FriendlyTorrentFileInfo friendlyTorrentFileInfo = new FriendlyTorrentFileInfo(torrentFile);
                torrentPaths.Add(friendlyTorrentFileInfo.InitialName);
            }
            foreach (TreeNode node in MakeTreeFromPaths(torrentPaths).Nodes)
            {
                node.Checked = true;
                TorrentFileListTreeView.Nodes.Add(node);
            }

            TorrentFileListTreeView.BeginUpdate();
            rootNode = TorrentFileListTreeView.GetNodeAt(0, 0);
            rootNode.Checked = true;
            rootNode.Expand();
            TorrentFileListTreeView.EndUpdate();
            await TorrentFileListTreeView.UpdateCounters();
            ToggleLoadingPanel(false);
        }

        public TreeNode MakeTreeFromPaths(List<string> paths)
        {
            var rootNode = new TreeNode();
            foreach (var path in paths.Where(x => !string.IsNullOrEmpty(x.Trim())))
            {
                var currentNode = rootNode;
                var pathItems = path.Split('/');
                bool isFile = false;
                foreach (var item in pathItems)
                {
                    if (pathItems.ToList().IndexOf(item) == pathItems.Length - 1)
                    {
                        isFile = true;
                    }
                    var tmp = currentNode.Nodes.Cast<TreeNode>().Where(x => x.Text.Equals(item));
                    if (tmp.Count() > 0)
                        currentNode = tmp.Single();
                    else
                    {
                        TreeNode treeNode = new TreeNode(item);
                        if (isFile)
                        {
                            FriendlyTorrentFileInfo torrentInfo = new FriendlyTorrentFileInfo(Globals.SelectedTorrent.Torrent.Files[paths.IndexOf(path)]);
                            treeNode.ImageIndex = 0;
                            treeNode.SelectedImageIndex = 0;
                            treeNode.Tag = torrentInfo;
                            treeNode.ToolTipText = torrentInfo.InitialName;
                        }
                        else
                        {
                            treeNode.ImageIndex = 1;
                            treeNode.SelectedImageIndex = 1;
                            treeNode.Tag = "Folder";
                        }
                        currentNode.Nodes.Add(treeNode);
                        currentNode = treeNode;
                    }
                }
            }
            return rootNode;
        }



        private async void RefreshOnLoad(object sender, EventArgs e)
        {
            await RefreshTorrentList();
        }

        private void DoTorrentSearch(string query)
        {
            foreach (ListViewItem torrentItem in TorrentsListView.Items)
            {
                if (torrentItem.SubItems[1].Text.ToLower().IndexOf(query.ToLower()) != -1)
                {
                    TorrentsListView.Items[torrentItem.Index].Focused = true;
                    TorrentsListView.Items[torrentItem.Index].Selected = true;
                    TorrentsListView.Items[torrentItem.Index].EnsureVisible();
                    TorrentsListView.Focus();
                    break;
                }
            }
        }

        public async Task UpdateCheckedFileCountStatus()
        {
            RenameButton.Enabled = TorrentFileListTreeView.TotalFilesSelected > 0;
            SelectedFileCountLabel.Text = $"Selected files: {TorrentFileListTreeView.TotalFilesSelected} of {TorrentFileListTreeView.TotalFiles} files currently selected";
            if (TorrentFileListTreeView.TotalFiles > 1)
            {
                foreach (Control control in FilesTabPage.Controls)
                {
                    if (control is Button)
                        control.Enabled = true;
                }
            }
            else
            {
                foreach (Control control in FilesTabPage.Controls)
                {
                    if (control is Button)
                        control.Enabled = false;
                }
            }
            await LoadSelectedFilesToRulesTab();
        }

        private async Task LoadSelectedFilesToRulesTab()
        {

            ToggleLoadingPanel(true);
            FileNamesOldNewListView.BeginUpdate();
            FileNamesOldNewListView.Items.Clear();
            await Task.Run(() =>
            {
                List<ListViewItem> torrentFilesLVItems = new List<ListViewItem>();
                foreach (FriendlyTorrentFileInfo torrentFile in Globals.SelectedTorrentFiles)
                {
                    ListViewItem torrentFileLVItem = new ListViewItem();
                    torrentFileLVItem.Text = torrentFile.InitialName.Split('/').Last();
                    torrentFileLVItem.SubItems.Add(torrentFileLVItem.Text);
                    torrentFileLVItem.ToolTipText = torrentFile.InitialName;
                    torrentFileLVItem.ImageIndex = 0;
                    torrentFileLVItem.Tag = torrentFile;
                    torrentFilesLVItems.Add(torrentFileLVItem);
                }
                BeginInvoke((Action)(() =>
                {
                    FileNamesOldNewListView.Items.AddRange(torrentFilesLVItems.ToArray());
                    FileNamesOldNewListView.Sort();
                }));
            });
            UpdateFileRenameListView();
            FileNamesOldNewListView.EndUpdate();
            ToggleLoadingPanel(false);
        }

        private async void SelectAllButtonClick(object sender, EventArgs e)
        {
            TorrentFileListTreeView.BeginUpdate();
            SetFileCheckState(rootNode, true);
            await TorrentFileListTreeView.UpdateCounters();
            TorrentFileListTreeView.EndUpdate();
        }

        private async void DeselectAllButtonClick(object sender, EventArgs e)
        {
            TorrentFileListTreeView.BeginUpdate();
            SetFileCheckState(rootNode, false);
            await TorrentFileListTreeView.UpdateCounters();
            TorrentFileListTreeView.EndUpdate();
        }

        private void InverseButtonClick(object sender, EventArgs e)
        {
            TorrentFileListTreeView.BeginUpdate();
            InvertFileSelection(rootNode);
            TorrentFileListTreeView.EndUpdate();
        }

        private void InvertFileSelection(TreeNode node)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                if (tn.Tag.ToString() != "Folder")
                {
                    tn.Checked = !tn.Checked;
                }
                InvertFileSelection(tn);
            }
        }

        private void SetFileCheckState(TreeNode node, bool state)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                tn.Checked = state;
            }
        }

        private async void ExpandAllButtonClick(object sender, EventArgs e)
        {
            ToggleLoadingPanel(true);
            TorrentFileListTreeView.BeginUpdate();
            await Task.Run(() =>
            {
                BeginInvoke((Action)(() => { rootNode.ExpandAll(); }));
            });
            TorrentFileListTreeView.EndUpdate();
            ToggleLoadingPanel(false);
        }

        private async void CollapseAllButtonClick(object sender, EventArgs e)
        {
            ToggleLoadingPanel(true);
            TorrentFileListTreeView.BeginUpdate();
            await Task.Run(() =>
            {
                BeginInvoke((Action)(() =>
                {
                    foreach (var node in TorrentFileListTreeView.GetAllNodes(rootNode.Nodes))
                    {
                        node.Collapse();
                    }
                }));
            });
            TorrentFileListTreeView.EndUpdate();
            ToggleLoadingPanel(false);
        }

        private void HandleCtrlBackspace(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.Back)
            {
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            }
            if (e.KeyCode == Keys.Enter)
            {
                DoTorrentSearch(SearchTorrentListTextBox.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async void SelectedTorrentChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            DialogResult dialogResult;
            if (TorrentsListView.SelectedItems.Count > 0)
            {
                if (Globals.SelectedTorrent != null)
                {
                    int currentTorrentId = Globals.SelectedTorrent.Torrent.ID;
                    TorrentInfo newSelectedTorrent = (TorrentInfo)e.Item.Tag;
                    int newTorrentId = newSelectedTorrent.ID;
                    if (currentTorrentId != newTorrentId && TorrentFileListTreeView.TotalFilesSelected != 0)
                    {
                        dialogResult = MessageBox.Show("Changing the selected torrent will cause the current file selection to be lost.\r\n\r\nDo you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                            Globals.SelectedTorrent = Globals.TorrentsInfo.Find(torrent => torrent.Torrent.ID == newTorrentId);
                        else
                            return;
                    }
                    else if (TorrentFileListTreeView.TotalFilesSelected == 0)
                    {
                        Globals.SelectedTorrent = Globals.TorrentsInfo[TorrentsListView.SelectedItems[0].Index];
                    }
                }
                else
                {

                    TorrentInfo newSelectedTorrent = (TorrentInfo)e.Item.Tag;
                    int newTorrentId = newSelectedTorrent.ID;
                    Globals.SelectedTorrent = Globals.TorrentsInfo.Find(torrent => torrent.Torrent.ID == newTorrentId);

                }
                SelectedTorrentLabel.Text = $"Selected torrent: {TorrentsListView.SelectedItems[0].SubItems[1].Text}";
                RenameButton.Enabled = false;
                currentTorrentListViewItem = TorrentsListView.SelectedItems[0];
                await LoadTorrentFilesList();
            }
            TorrentsListView.BeginUpdate();
            foreach (ListViewItem torrentItem in TorrentsListView.Items)
            {
                if (torrentItem != currentTorrentListViewItem)
                {
                    torrentItem.ForeColor = Color.Black;
                }
                else
                {
                    torrentItem.ForeColor = Color.Blue;
                }
            }
            TorrentsListView.EndUpdate();
        }

        private void NewRuleButtonClick(object sender, EventArgs e)
        {
            RulesForm rulesForm = new RulesForm();
            DialogResult dialogResult = rulesForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                UpdateRulesListView();
                UpdateFileRenameListView();
            }
        }

        private void UpdateRulesListView()
        {
            RulesListView.Items.Clear();
            for (int i = 0; i < Globals.RenameRules.Count; i++)
            {
                RenameRule rule = Globals.RenameRules[i];
                ListViewItem ruleLVItem = new ListViewItem();
                ruleLVItem.Text = (i+1).ToString();
                ruleLVItem.SubItems.Add(rule.Name);
                ruleLVItem.SubItems.Add(rule.Description);
                ruleLVItem.Tag = rule;
                RulesListView.Items.Add(ruleLVItem);
            }
            FileNamesOldNewListView.BeginUpdate();
            foreach (ListViewItem torrentFileItem in FileNamesOldNewListView.Items)
            {
                FriendlyTorrentFileInfo torrentFileInfo = (FriendlyTorrentFileInfo)torrentFileItem.Tag;
                torrentFileInfo.NewestName = torrentFileInfo.InitialName;
                torrentFileItem.SubItems[1].Text = torrentFileInfo.InitialName;
                torrentFileItem.Tag = torrentFileInfo;
            }
            FileNamesOldNewListView.EndUpdate();
        }

        private void UpdateFileRenameListView()
        {
            if (Globals.RenameRules != null)
            {
                FileNamesOldNewListView.BeginUpdate();
                foreach (RenameRule renameRule in Globals.RenameRules)
                {
                    foreach (ListViewItem torrentFileItem in FileNamesOldNewListView.Items)
                    {
                        FriendlyTorrentFileInfo torrentFileInfo = (FriendlyTorrentFileInfo)torrentFileItem.Tag;
                        torrentFileInfo.NewestName = renameRule.DoRename(torrentFileInfo);
                        torrentFileItem.SubItems[1].Text = torrentFileInfo.NewestName;
                        torrentFileItem.Tag = torrentFileInfo;
                    }
                }
                FileNamesOldNewListView.EndUpdate();
            }
        }


        private void MoveRuleUpButtonClick(object sender, EventArgs e)
        {
            RenameRule currentSelectedRule = (RenameRule)RulesListView.SelectedItems[0].Tag;
            int oldRuleIndex = Globals.RenameRules.IndexOf(Globals.RenameRules.Find(rule => rule.Id == currentSelectedRule.Id));
            int newRuleIndex = oldRuleIndex - 1;
            Globals.RenameRules.RemoveAt(oldRuleIndex);
            Globals.RenameRules.Insert(newRuleIndex, currentSelectedRule);
            UpdateRulesListView();
            UpdateFileRenameListView();
            RulesListView.Focus();
            RulesListView.Items[newRuleIndex].Focused = true;
            RulesListView.Items[newRuleIndex].Selected = true;
        }

        private void MoveRuleDownButtonClick(object sender, EventArgs e)
        {
            RenameRule currentSelectedRule = (RenameRule)RulesListView.SelectedItems[0].Tag;
            int oldRuleIndex = Globals.RenameRules.IndexOf(Globals.RenameRules.Find(rule => rule.Id == currentSelectedRule.Id));
            int newRuleIndex = oldRuleIndex + 1;
            Globals.RenameRules.RemoveAt(oldRuleIndex);
            Globals.RenameRules.Insert(newRuleIndex, currentSelectedRule);
            UpdateRulesListView();
            UpdateFileRenameListView();
            RulesListView.Focus();
            RulesListView.Items[newRuleIndex].Focused = true;
            RulesListView.Items[newRuleIndex].Selected = true;
        }

        private void UpdateRuleButtonStates(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool enablestate = RulesListView.SelectedItems.Count == 1;
            EditRuleButton.Enabled = enablestate;
            DeleteRuleButton.Enabled = enablestate;
            if (enablestate)
            {
                MoveRuleDownButton.Enabled = RulesListView.Items.Count > 1 && RulesListView.SelectedItems[0].Index != RulesListView.Items.Count - 1;
                MoveRuleUpButton.Enabled = RulesListView.Items.Count > 1 && RulesListView.SelectedItems[0].Index != 0;
            }
            else
            {
                MoveRuleDownButton.Enabled = false;
                MoveRuleUpButton.Enabled = false;
            }
        }

        private void DeleteRuleButtonClick(object sender, EventArgs e)
        {
            RenameRule currentSelectedRule = (RenameRule)RulesListView.SelectedItems[0].Tag;
            int ruleIndex = Globals.RenameRules.IndexOf(Globals.RenameRules.Find(rule => rule.Id == currentSelectedRule.Id));
            Globals.RenameRules.RemoveAt(ruleIndex);
            UpdateRulesListView();
            UpdateFileRenameListView();
            RulesListView.Focus();
            if (RulesListView.Items.Count != 0)
            {
                RulesListView.Items[RulesListView.Items.Count - 1].Focused = true;
                RulesListView.Items[RulesListView.Items.Count - 1].Selected = true;
            }
            else
                DeleteRuleButton.Enabled = false;

        }
    }
}