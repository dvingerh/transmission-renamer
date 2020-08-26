using System.Collections.Generic;
using System.Data;
using Transmission.API.RPC.Entity;
using transmission_renamer.Classes;
using transmission_renamer.Classes.Rules;

namespace transmission_renamer
{
    public static class Globals
    {
        private static List<RenameRule> renameRules = new List<RenameRule>();
        private static List<FriendlyTorrentFileInfo> selectedTorrentFiles = new List<FriendlyTorrentFileInfo>();
        private static List<FriendlyTorrentInfo> torrentsInfo = new List<FriendlyTorrentInfo>();

        public enum RequestResult
        {
            Success,
            Timeout,
            InvalidResp,
            InvalidUrl,
            Unauthorized,
            Cancelled,
            Unknown,
            Failed
        }

        public static SessionHandler SessionHandler { get; set; }
        public static FriendlyTorrentInfo SelectedTorrent { get; set; }
        public static List<RenameRule> RenameRules { get => renameRules; set => renameRules = value; }
        public static List<FriendlyTorrentInfo> TorrentsInfo { get => torrentsInfo; set => torrentsInfo = value; }
        public static List<FriendlyTorrentFileInfo> SelectedTorrentFiles { get => selectedTorrentFiles; set => selectedTorrentFiles = value; }
    }
}
