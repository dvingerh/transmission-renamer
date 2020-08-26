using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transmission.API.RPC.Entity;

namespace transmission_renamer.Classes
{
    public class FriendlyTorrentFileInfo
    {
        private string initialPath;
        private string newestName;
        private TransmissionTorrentFiles torrentFile;
        private TorrentInfo parentTorrent;

        public string InitialPath { get => initialPath; set => initialPath = value; }
        public string NewestName { get => newestName; set => newestName = value; }
        public TransmissionTorrentFiles TorrentFile { get => torrentFile; set => torrentFile = value; }
        public TorrentInfo ParentTorrent { get => parentTorrent; set => parentTorrent = value; }

        public FriendlyTorrentFileInfo(TransmissionTorrentFiles torrentFile, TorrentInfo parentTorrent)
        {
            this.InitialPath = torrentFile.Name;
            this.NewestName = InitialPath;
            this.TorrentFile = torrentFile;
            this.ParentTorrent = parentTorrent;
        }
    }
}
