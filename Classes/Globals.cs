using System.Collections.Generic;
using transmission_renamer.Classes;
using transmission_renamer.Classes.Rules;

namespace transmission_renamer
{
    public static partial class Globals
    {
        public static SessionHandler SessionHandler { get; set; }
        public static FriendlyTorrentInfo SelectedTorrent { get; set; }
        public static List<RenameRule> RenameRules { get; set; } = new List<RenameRule>();
        public static List<FriendlyTorrentInfo> TorrentsInfo { get; set; } = new List<FriendlyTorrentInfo>();
        public static List<FriendlyTorrentFileInfo> SelectedTorrentFiles { get; set; } = new List<FriendlyTorrentFileInfo>();
    }
}
