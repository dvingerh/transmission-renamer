using Transmission.API.RPC.Entity;

namespace transmission_renamer.Classes
{
    public class FriendlyTorrentFileInfo
    {
        public string InitialPath { get; set; }
        public string NewestName { get; set; }
        public TransmissionTorrentFiles TorrentFile { get; set; }
        public TorrentInfo ParentTorrent { get; set; }

        public FriendlyTorrentFileInfo(TransmissionTorrentFiles torrentFile, TorrentInfo parentTorrent)
        {
            this.InitialPath = torrentFile.Name;
            this.NewestName = InitialPath;
            this.TorrentFile = torrentFile;
            this.ParentTorrent = parentTorrent;
        }
    }
}
