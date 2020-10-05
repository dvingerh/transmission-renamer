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
        // private properties
        private readonly ListViewColumnSorter lvwColumnSorter;
        private ListViewItem currentTorrentListViewItem;
        private TreeNode rootNode;
        private List<ListViewItem> allItems = new List<ListViewItem>();

        public SelectTorrentFilesForm()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            TorrentsListView.ListViewItemSorter = lvwColumnSorter;

            // adjust row height for TorrentsListView, RulesListView
            ImageList rowHeightFix = new ImageList
            {
                ImageSize = new Size(1, 19),
                TransparentColor = Color.Transparent
            };
            TorrentsListView.SmallImageList = rowHeightFix;
            RulesListView.SmallImageList = rowHeightFix;

            // programatically load file, folder icons list to bypass transparency loss bug if done in Designer instead
            ImageList torrentFilesImageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                TransparentColor = Color.Transparent
            };
            torrentFilesImageList.Images.Add(Properties.Resources.file);
            torrentFilesImageList.Images.Add(Properties.Resources.folder);
            torrentFilesImageList.Images.Add(Properties.Resources.pending);
            torrentFilesImageList.Images.Add(Properties.Resources.success);
            torrentFilesImageList.Images.Add(Properties.Resources.warning);
            torrentFilesImageList.Images.Add(Properties.Resources.error);
            TorrentFileListTreeView.ImageList = torrentFilesImageList;
            FileNamesOldNewListView.SmallImageList = torrentFilesImageList;
        }

        #region UI Functions

        // close current connection, go back to SessionForm
        private void BackButtonClick(object sender, EventArgs e)
        {
            if (Globals.SessionHandler != null)
                Globals.SessionHandler.CloseConnection();
            Close();
        }

        // view or hide loading panels, update UI state accordingly
        private void ToggleLoadingPanels(bool state)
        {
            foreach (TabPage tabPage in PagesTabControl.TabPages)
            {
                if (tabPage != FilesTabPage)
                {
                    foreach (Control control in tabPage.Controls)
                    {
                        if (control.Name.IndexOf("Loading") == -1)
                            control.Enabled = !state;
                    }
                }
            }
            UpdateRuleButtonStates(null, null);
            RetrievingInformationLoadingPanel.Visible = state;
            ProcessingRulesFilesLoadingPanel.Visible = state;
            ProcessingFilesLoadingPanel.Visible = state;
            RetrievingInformationLoadingPanel.Update();
            ProcessingRulesFilesLoadingPanel.Update();
            ProcessingFilesLoadingPanel.Update();
        }

        // update RefreshTorrentListButton text state while refreshing
        private void TimeOutTimerTick(object sender, EventArgs e)
        {
            var secondsLeft = int.Parse(TimeOutTimer.Tag.ToString()) - 1;
            RefreshTorrentListButton.Text = $"Waiting ({secondsLeft})";
            TimeOutTimer.Tag = secondsLeft--.ToString();
        }

        // load torrent list on MainSettingsForm load
        private async void RefreshOnLoad(object sender, EventArgs e)
        {
            await RefreshTorrentList();
        }
        #endregion

        #region Torrents Tab Functions

        // load torrent list on RefreshTorrentListButton click
        private async void RefreshTorrentListButtonClick(object sender, EventArgs e)
        {
            await RefreshTorrentList();
        }

        // load list of torrents from active session
        private async Task RefreshTorrentList()
        {
            DialogResult dialogResult;
            bool doContinue = true;
            // warn user current selection will be lost
            if (TorrentFileListTreeView.TotalFilesSelected != 0)
            {
                dialogResult = MessageBox.Show("Refreshing the torrent list will cause the current file selection to be lost.\r\n\r\nDo you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                    doContinue = false;
            }
            if (doContinue)
            {
                // update UI state on continue
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
                ToggleLoadingPanels(true);

                // retrieve torrents list
                List<TorrentInfo> torrentsInfo = await Task.Run(() => Globals.SessionHandler.GetTorrents());

                TimeOutTimer.Stop();
                TimeOutTimer.Tag = "10";

                // handle list response
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
                            var torrentLVItem = new ListViewItem(new[] {
                                fTorrentInfo.QueuePosition,
                                fTorrentInfo.Name, fTorrentInfo.Status,
                                fTorrentInfo.Size, fTorrentInfo.Progress
                            })
                            {
                                Tag = fTorrentInfo.Torrent
                            };
                            torrentLVItems.Add(torrentLVItem);
                        }
                        TorrentsListView.Items.AddRange(torrentLVItems.ToArray());
                        TorrentsListView.EndUpdate();
                        Globals.TorrentsInfo = globalTorrentsInfo;
                    }
                }
                else
                    MessageBox.Show("The torrent list could not be retrieved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                allItems.Clear();
                allItems.AddRange(TorrentsListView.Items.Cast<ListViewItem>());
                ToggleLoadingPanels(false);
                RefreshTorrentListButton.Text = "Refresh Torrent List";
                RefreshTorrentListButton.Enabled = true;
                SearchTorrentListTextBox.Focus();
            }
        }

        // sort torrents list based on clicked column
        private void SortTorrentsListView(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                lvwColumnSorter.Order = lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
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

        // handle user selected a torrent from the torrent list
        private async void SelectedTorrentChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            DialogResult dialogResult;
            bool doUpdateFileList = false;
            if (TorrentsListView.SelectedItems.Count > 0)
            {
                if (Globals.SelectedTorrent != null)
                {
                    // retrieve current torrent selection, new selection id's
                    int currentTorrentId = Globals.SelectedTorrent.Torrent.ID;
                    TorrentInfo newSelectedTorrent = (TorrentInfo)e.Item.Tag;
                    int newTorrentId = newSelectedTorrent.ID;
                    if (currentTorrentId != newTorrentId && TorrentFileListTreeView.TotalFilesSelected != 0)
                    {
                        dialogResult = MessageBox.Show("Changing the selected torrent will cause the current file selection to be lost.\r\n\r\nDo you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Globals.SelectedTorrent = Globals.TorrentsInfo.Find(torrent => torrent.Torrent.ID == newTorrentId);
                            doUpdateFileList = true;
                        }
                        else
                            return;
                    }
                    else if (TorrentFileListTreeView.TotalFilesSelected == 0)
                    {
                        Globals.SelectedTorrent = Globals.TorrentsInfo[TorrentsListView.SelectedItems[0].Index];
                        doUpdateFileList = true;
                    }
                }
                else
                {
                    TorrentInfo newSelectedTorrent = (TorrentInfo)e.Item.Tag;
                    int newTorrentId = newSelectedTorrent.ID;
                    Globals.SelectedTorrent = Globals.TorrentsInfo.Find(torrent => torrent.Torrent.ID == newTorrentId);
                    doUpdateFileList = true;
                }
            }
            TorrentsListView.BeginUpdate();

            if (doUpdateFileList)
            {
                // update UI state, load the file list of newly selected torrent
                SelectedTorrentLabel.Text = $"Selected torrent: {TorrentsListView.SelectedItems[0].SubItems[1].Text}";
                RenameButton.Enabled = false;
                currentTorrentListViewItem = TorrentsListView.SelectedItems[0];
                await LoadTorrentFilesList();
            }

            // make current torrent selection easier to find in TorrentsListView
            foreach (ListViewItem torrentItem in TorrentsListView.Items)
                if (torrentItem != null)
                    torrentItem.ForeColor = (torrentItem != currentTorrentListViewItem) ? Color.Black : Color.Blue;

            TorrentsListView.EndUpdate();
        }
        #endregion

        #region Files Tab Functions

        // load list of files of the selected torrent
        private async Task LoadTorrentFilesList()
        {
            ToggleLoadingPanels(true);
            Globals.SelectedTorrentFiles.Clear();
            TorrentFileListTreeView.Nodes.Clear();

            // prepare torrent file paths for TorrentFileListTreeView display
            List<string> torrentPaths = new List<string>();
            foreach (TransmissionTorrentFiles torrentFile in Globals.SelectedTorrent.Torrent.Files)
            {
                FriendlyTorrentFileInfo friendlyTorrentFileInfo = new FriendlyTorrentFileInfo(torrentFile, Globals.SelectedTorrent.Torrent);
                torrentPaths.Add(item: friendlyTorrentFileInfo.InitialPath);
            }

            // populate TorrentFileListTreeView
            foreach (TreeNode node in GenerateTorrentFilesTreeViewItems(torrentPaths).Nodes)
            {
                node.Checked = true;
                TorrentFileListTreeView.Nodes.Add(node);
            }

            // update UI state
            TorrentFileListTreeView.BeginUpdate();
            rootNode = TorrentFileListTreeView.GetNodeAt(0, 0);
            rootNode.Checked = true;
            rootNode.Expand();
            TorrentFileListTreeView.EndUpdate();
            await TorrentFileListTreeView.UpdateCounters();
            ToggleLoadingPanels(false);
        }

        // generate TorrentFileListTreeView file, directory nodes
        // https://stackoverflow.com/a/24861947 for reference
        public TreeNode GenerateTorrentFilesTreeViewItems(List<string> paths)
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
                        // determine node type
                        if (isFile)
                        {
                            FriendlyTorrentFileInfo torrentInfo = new FriendlyTorrentFileInfo(Globals.SelectedTorrent.Torrent.Files[paths.IndexOf(path)], Globals.SelectedTorrent.Torrent);
                            treeNode.ImageIndex = 0;
                            treeNode.SelectedImageIndex = 0;
                            treeNode.Tag = torrentInfo;
                            treeNode.ToolTipText = torrentInfo.InitialPath;
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

        // update UI state for checked file count, update rules tab file list
        public async Task UpdateCheckedFileCountStatus()
        {
            RenameButton.Enabled = TorrentFileListTreeView.TotalFilesSelected > 0;
            SelectedFileCountLabel.Text = $"Selected files: {TorrentFileListTreeView.TotalFilesSelected} of {TorrentFileListTreeView.TotalFiles} files currently selected";

            // one liner with conditional determination if the buttons should be enabled or not.
            FilesTabPage.Controls.OfType<Button>().ToList().ForEach(x => x.Enabled = (TorrentFileListTreeView.TotalFiles > 1));
            await LoadSelectedFilesToRulesTab();
        }

        // load selected files to rules tab
        private async Task LoadSelectedFilesToRulesTab()
        {
            ToggleLoadingPanels(true);
            FileNamesOldNewListView.BeginUpdate();
            FileNamesOldNewListView.Items.Clear();
            await Task.Run(() =>
            {
                List<ListViewItem> torrentFilesLVItems = new List<ListViewItem>();
                foreach (FriendlyTorrentFileInfo torrentFile in Globals.SelectedTorrentFiles)
                {
                    ListViewItem torrentFileLVItem = new ListViewItem()
                    {
                        Text = torrentFile.InitialPath.Split('/').Last(), // don't show entire path, just the file name
                        ToolTipText = torrentFile.InitialPath,
                        ImageIndex = 0,
                        Tag = torrentFile
                    };
                    torrentFileLVItem.SubItems.Add(torrentFileLVItem.Text);
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
            ToggleLoadingPanels(false);
        }

        // select all files in file tab, update UI state
        private async void SelectAllButtonClick(object sender, EventArgs e)
        {
            TorrentFileListTreeView.BeginUpdate();
            ToggleFilesSelectState(rootNode, true);
            await TorrentFileListTreeView.UpdateCounters();
            TorrentFileListTreeView.EndUpdate();
        }

        // deselect all files in file tab, update UI state
        private async void DeselectAllButtonClick(object sender, EventArgs e)
        {
            TorrentFileListTreeView.BeginUpdate();
            ToggleFilesSelectState(rootNode, false);
            await TorrentFileListTreeView.UpdateCounters();
            TorrentFileListTreeView.EndUpdate();
        }

        // invert currently selected files in file tab
        // unused, function works but introduces buggy UI checked state which causes confusion
        private void InverseButtonClick(object sender, EventArgs e)
        {
            TorrentFileListTreeView.BeginUpdate();
            InvertFileSelection(rootNode);
            TorrentFileListTreeView.EndUpdate();
        }

        // invert select state of files in the files list
        private void InvertFileSelection(TreeNode node)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                if (tn.Tag.ToString() != "Folder")
                    tn.Checked = !tn.Checked;
                InvertFileSelection(tn);
            }
        }

        // sets select state of all child nodes of the given node parameter in files list
        private void ToggleFilesSelectState(TreeNode node, bool state)
        {
            node.Nodes.OfType<TreeNode>().ToList().ForEach(x => x.Checked = state);
        }

        // expand all folder nodes in files list 
        private async void ExpandAllButtonClick(object sender, EventArgs e)
        {
            ToggleLoadingPanels(true);
            TorrentFileListTreeView.BeginUpdate();
            await Task.Run(() =>
            {
                BeginInvoke((Action)(() => { rootNode.ExpandAll(); }));
            });
            TorrentFileListTreeView.EndUpdate();
            ToggleLoadingPanels(false);
        }

        // collapse all folder nodes in files list 
        private async void CollapseAllButtonClick(object sender, EventArgs e)
        {
            ToggleLoadingPanels(true);
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
            ToggleLoadingPanels(false);
        }
        #endregion

        #region Rules Tab Functions

        // create a new rename rule, update UI state
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

        // update the RulesListView rename rule items
        private void UpdateRulesListView()
        {
            RulesListView.Items.Clear();
            for (int i = 0; i < Globals.RenameRules.Count; i++)
            {
                IRenameRule rule = Globals.RenameRules[i];
                ListViewItem ruleLVItem = new ListViewItem
                {
                    Text = (i + 1).ToString()
                };
                ruleLVItem.SubItems.Add(rule.Name);
                ruleLVItem.SubItems.Add(rule.Description);
                ruleLVItem.Tag = rule;
                RulesListView.Items.Add(ruleLVItem);
            }
            ResetOldNewFileNameValues();
        }

        private void ResetOldNewFileNameValues()
        {
            FileNamesOldNewListView.BeginUpdate();
            foreach (ListViewItem torrentFileItem in FileNamesOldNewListView.Items)
            {
                FriendlyTorrentFileInfo torrentFileInfo = (FriendlyTorrentFileInfo)torrentFileItem.Tag;
                torrentFileInfo.NewestName = torrentFileInfo.InitialPath;
                torrentFileItem.SubItems[1].Text = torrentFileItem.Text;
                torrentFileItem.Tag = torrentFileInfo;
            }
            FileNamesOldNewListView.EndUpdate();
        }

        // update all the new file name previews in FileNamesOldNewListView
        private void UpdateFileRenameListView()
        {
            ResetOldNewFileNameValues();
            if (Globals.RenameRules.Count > 0)
            {
                FileNamesOldNewListView.BeginUpdate();
                foreach (IRenameRule renameRule in Globals.RenameRules)
                {
                    foreach (ListViewItem torrentFileItem in FileNamesOldNewListView.Items)
                    {
                        FriendlyTorrentFileInfo torrentFileInfo = (FriendlyTorrentFileInfo)torrentFileItem.Tag;
                        torrentFileInfo.NewestName = renameRule.DoRename(torrentFileInfo, torrentFileItem.Index);
                        torrentFileItem.SubItems[1].Text = torrentFileInfo.NewestName;
                        torrentFileItem.Tag = torrentFileInfo;
                    }
                }
                FileNamesOldNewListView.EndUpdate();
            }
        }

        // move selected rule up in the RulesListView item order
        private void MoveRuleUpButtonClick(object sender, EventArgs e)
        {
            IRenameRule currentSelectedRule = (IRenameRule)RulesListView.SelectedItems[0].Tag;
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

        // move selected rule down in the RulesListView item order
        private void MoveRuleDownButtonClick(object sender, EventArgs e)
        {
            IRenameRule currentSelectedRule = (IRenameRule)RulesListView.SelectedItems[0].Tag;
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

        // update rules tab UI state based on rule count, selected rule
        private void UpdateRuleButtonStates(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool enableState = RulesListView.SelectedItems.Count == 1;
            EditRuleButton.Enabled = enableState;
            DeleteRuleButton.Enabled = enableState;
            if (enableState)
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

        // remove selected rule from the list of rules, update UI state
        private void DeleteRuleButtonClick(object sender, EventArgs e)
        {
            IRenameRule currentSelectedRule = (IRenameRule)RulesListView.SelectedItems[0].Tag;
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
            {
                DeleteRuleButton.Enabled = false;
                EditRuleButton.Enabled = false;
            }
        }

        // edit selected rule from the list of rules, update UI state
        private void EditRuleButtonClick(object sender, EventArgs e)
        {
            IRenameRule currentSelectedRule = (IRenameRule)RulesListView.SelectedItems[0].Tag;
            int currentRuleIndex = RulesListView.SelectedItems[0].Index;
            RulesForm rulesForm = new RulesForm(editMode: true, currentSelectedRule);
            DialogResult dialogResult = rulesForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                UpdateRulesListView();
                UpdateFileRenameListView();
                RulesListView.Focus();
                RulesListView.Items[currentRuleIndex].Focused = true;
                RulesListView.Items[currentRuleIndex].Selected = true;
            }
        }
        #endregion

        private void RenameButtonClick(object sender, EventArgs e)
        {

            Hide();
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (ListViewItem item in FileNamesOldNewListView.Items)
            {
                items.Add((ListViewItem)item.Clone());
            }
            RenamerForm renamerForm = new RenamerForm(items);
            renamerForm.ShowDialog();
            Show();
            RefreshTorrentListButton.PerformClick();
        }

        private void FocusTorrentSearchBoxShortcut(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.F))
            {
                SearchTorrentListTextBox.Focus();
            }
        }

        private void SearchTorrentListTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TorrentsListView.SelectedItems.Count > 0)
            {
                TorrentsListView.SelectedItems[0].Focused = false;
                TorrentsListView.SelectedItems[0].Selected = false;
            }
            string query = SearchTorrentListTextBox.Text.ToLower();
            TorrentsListView.Items.Clear();
            if (query == "")
            {
                TorrentsListView.Items.AddRange(allItems.ToArray());
                return;
            }
            var list = allItems.Cast<ListViewItem>().Where(x => x.SubItems[1].Text.ToLower().Contains(query)).ToArray();
            TorrentsListView.Items.AddRange(list);
        }
    }
}