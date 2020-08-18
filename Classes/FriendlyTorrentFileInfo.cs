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
        private string initialName;
        private string newestName;
        private TransmissionTorrentFiles torrentFile;

        public string InitialName { get => initialName; set => initialName = value; }
        public string NewestName { get => newestName; set => newestName = value; }
        public TransmissionTorrentFiles TorrentFile { get => torrentFile; set => torrentFile = value; }

        public FriendlyTorrentFileInfo(TransmissionTorrentFiles torrentFile)
        {
            this.InitialName = torrentFile.Name;
            this.NewestName = InitialName;
            this.TorrentFile = torrentFile;
        }
    }
}
