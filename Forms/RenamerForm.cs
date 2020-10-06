using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transmission.API.RPC.Entity;
using transmission_renamer.Classes;

namespace transmission_renamer.Forms
{
    public partial class RenamerForm : Form
    {
        private readonly List<ListViewItem> torrentRenameItems = new List<ListViewItem>();
        private bool isAbortedOrFinished = false;

        public RenamerForm(List<ListViewItem> items)
        {
            torrentRenameItems = items;
            foreach(ListViewItem torrentItem in torrentRenameItems)
                torrentItem.ImageIndex = 2;
            InitializeComponent();
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
            FileNamesOldNewListView.SmallImageList = torrentFilesImageList;
        }

        private async void OnFormLoad(object sender, EventArgs e)
        {
            FileNamesOldNewListView.Items.AddRange(torrentRenameItems.ToArray());
            await Task.Run(async () => { await RenameTorrentFiles(); });
            isAbortedOrFinished = true;
            CurrentFileRenameLabel.Text = "Renaming finished.";
            Abortutton.Enabled = false;
            DoneButton.Enabled = true;
        }

        private async Task RenameTorrentFiles()
        {
            int success = 0, timeout = 0, failed = 0, current = 1, total = FileNamesOldNewListView.Items.Count;
            Invoke((MethodInvoker)delegate
            {
                TotalFilesLabel.Text = $"Total files: {FileNamesOldNewListView.Items.Count}";
                RenamingProgressBar.Maximum = total;
            });
            for (int i = 0; i < FileNamesOldNewListView.Items.Count; i++)
            {
                if (!isAbortedOrFinished)
                {
                    string curFilePath = null, newFileName = null;
                    TorrentInfo torrent = null;
                    Globals.RequestResult renameResult = Globals.RequestResult.Unknown;
                    Invoke((MethodInvoker)delegate
                    {
                        ListViewItem fileItem = FileNamesOldNewListView.Items[i];
                        FileNamesOldNewListView.Items[i].EnsureVisible();
                        FriendlyTorrentFileInfo friendlyTorrentFileInfo = (FriendlyTorrentFileInfo)fileItem.Tag;
                        curFilePath = friendlyTorrentFileInfo.InitialPath;
                        newFileName = friendlyTorrentFileInfo.NewestName;
                        torrent = friendlyTorrentFileInfo.ParentTorrent;
                        CurrentFileRenameLabel.Text = $"File {current} of {total}: {FileNamesOldNewListView.Items[i].Text}";
                        if (RenamingProgressBar.Value + 2 <= RenamingProgressBar.Maximum)
                        {
                            RenamingProgressBar.Value += 2;
                            RenamingProgressBar.Value--;
                        }
                        else
                        {
                            RenamingProgressBar.Maximum++;
                            RenamingProgressBar.Value += 2;
                            RenamingProgressBar.Value--;
                            RenamingProgressBar.Maximum--;
                        }
                    });
                    if (curFilePath != null && newFileName != null && torrent != null && (curFilePath != newFileName))
                    {
                        renameResult = await Globals.SessionHandler.RenameTorrent(curFilePath, newFileName, torrent);

                        switch (renameResult)
                        {
                            case Globals.RequestResult.Success:
                                success++;
                                Invoke((MethodInvoker)delegate
                                {
                                    FileNamesOldNewListView.Items[i].ImageIndex = 3;
                                    SuccessFilesLabel.Text = $"Success: {success}";
                                });
                                break;
                            case Globals.RequestResult.Timeout:
                                timeout++;
                                Invoke((MethodInvoker)delegate
                                {
                                    FileNamesOldNewListView.Items[i].ImageIndex = 4;
                                    TimedOutFilesLabel.Text = $"Timed out: {timeout}";
                                }); break;
                            case Globals.RequestResult.Failed:
                                failed++;
                                Invoke((MethodInvoker)delegate
                                {
                                    FileNamesOldNewListView.Items[i].ImageIndex = 5;
                                    FailedFilesLabel.Text = $"Failed: {failed}";
                                }); break;
                            case Globals.RequestResult.Unknown:
                                Invoke((MethodInvoker)delegate
                                {
                                    FileNamesOldNewListView.Items[i].ImageIndex = 5;
                                }); break;
                            default:
                                MessageBox.Show("An unknown error has occurred. The renaming process will be cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                isAbortedOrFinished = true;
                                break;
                        }
                    }
                    else
                    {
                        success++;
                        Invoke((MethodInvoker)delegate
                        {
                            FileNamesOldNewListView.Items[i].ImageIndex = 3;
                            SuccessFilesLabel.Text = $"Success: {success}";
                        });
                    }
                    current++;
                }
                else
                    break;
            }
        }

        private void DoneButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AbortButtonClick(object sender, EventArgs e)
        {
            isAbortedOrFinished = true;
        }

        private void CloseFormCancel(object sender, FormClosingEventArgs e)
        {
            if (!isAbortedOrFinished)
            {
                DialogResult cancelResult = MessageBox.Show("The renaming process will be aborted.\n\nDo you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cancelResult == DialogResult.Yes)
                    isAbortedOrFinished = true;

                e.Cancel = true;
            }
        }
    }
}
