﻿using System;
using System.Globalization;
using System.Threading;
using Transmission.API.RPC.Entity;

namespace transmission_renamer
{
    public class FriendlyTorrentInfo
    {
        enum EStatus
        {
            STOPPED, // Torrent is stopped
            QUEUED_FOR_VERIFYING, // Queued to verify files
            VERIFYING, // Verifying files
            QUEUED_FOR_DOWNLOAD, // Queued to download
            DOWNLOADING, // Downloading
            QUEUED_FOR_SEEDING, // Queued to seed
            SEEDING, // Seeding
            ISOLATED
        }

        public string QueuePosition { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Size { get; set; }
        public string Progress { get; set; }
        public TorrentInfo Torrent { get; set; }

        public FriendlyTorrentInfo(TorrentInfo torrent)
        {
            Torrent = torrent;
            QueuePosition = SetFriendlyQueuePosition(torrent.QueuePosition);
            Name = torrent.Name;
            Status = SetFriendlyStatus(torrent.Status);
            Size = SetFriendlySize(torrent.TotalSize);
            Progress = SetFriendlyProgress(torrent.PercentDone);
        }

        private string SetFriendlyQueuePosition(int queuePosition) => queuePosition.ToString();

        private string SetFriendlyStatus(int status)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            EStatus eStatus = (EStatus)status;
            return textInfo.ToTitleCase(eStatus.ToString().ToLower().Replace("_", " "));
        }

        private string SetFriendlySize(long size) => SizeSuffix(size, 2);

        private string SetFriendlyProgress(double percentDone) => Math.Round(percentDone * 100, 2).ToString() + "%";

        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(long value, int decimalPlaces = 0)
        {
            if (value < 0)
            {
                throw new ArgumentException("Bytes should not be negative", "value");
            }
            var mag = (int)Math.Max(0, Math.Log(value, 1024));
            var adjustedSize = Math.Round(value / Math.Pow(1024, mag), decimalPlaces);
            return String.Format("{0} {1}", adjustedSize, SizeSuffixes[mag]);
        }
    }
}
