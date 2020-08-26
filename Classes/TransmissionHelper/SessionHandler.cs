using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;
using static transmission_renamer.Globals;

namespace transmission_renamer
{
    public class SessionHandler
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }

        private Client client;
        private bool requestCancelled = false;

        public SessionHandler(string host, int port, string username, string password)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
        }

        private bool ValidateUrl()
        {
            try
            {
                Url = new Uri("http://" + Host + ":" + Port + Constants.RPC_PATH).ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<RequestResult> TestConnection()
        {
            if (client != null)
                client.CloseSessionAsync();
            if (ValidateUrl())
            {
                client = new Client(url: Url, login: Username, password: Password);
            }
            else
            {
                return RequestResult.InvalidUrl;
            }

            RequestResult connectionResult;
            Task<SessionInfo> sessionInfoTask = client.GetSessionInformationAsync();
            Task delayTask = Task.Delay(TimeSpan.FromSeconds(10));

            await Task.Run(async () => await Task.WhenAny(sessionInfoTask, delayTask));


            if (!requestCancelled)
            {
                if (delayTask.IsCompleted)
                {
                    connectionResult = RequestResult.Timeout;
                }
                else
                {
                    SessionInfo sessionInfo = sessionInfoTask.Result;
                    connectionResult = sessionInfo != null && sessionInfo.Version != null ? RequestResult.Success : RequestResult.InvalidResp;
                }
            }
            else
                connectionResult = RequestResult.Cancelled;
            return connectionResult;
        }

        public async Task<List<TorrentInfo>> GetTorrents()
        {
            Task<TransmissionTorrents> getTorrentsTask = client.TorrentGetAsync(TorrentFields.ALL_FIELDS);
            Task delayTask = Task.Delay(TimeSpan.FromSeconds(10));
            await Task.WhenAny(getTorrentsTask, delayTask);
            if (!requestCancelled)
            {
                if (delayTask.IsCompleted)
                {
                    return null;
                }
                else
                {
                    TransmissionTorrents torrentsList = getTorrentsTask.Result;
                    return torrentsList != null && torrentsList.Torrents != null ? torrentsList.Torrents.ToList() : new List<TorrentInfo>();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<RequestResult> RenameTorrent(string filePath, string newName, TorrentInfo torrent)
        {
            RequestResult renameResult;
            Task<RenameTorrentInfo> renameFileTask = client.TorrentRenamePathAsync(torrent.ID, filePath, newName);
            Task delayTask = Task.Delay(TimeSpan.FromSeconds(10));

            await Task.Run(async () => await Task.WhenAny(renameFileTask, delayTask));

            if (delayTask.IsCompleted)
                renameResult = RequestResult.Timeout;
            else
            {
                RenameTorrentInfo renameTorrentInfo = renameFileTask.Result;
                renameResult = renameTorrentInfo != null && renameTorrentInfo.Name == newName ? RequestResult.Success : RequestResult.Failed;
            }
            return renameResult;
        }

        public void CloseConnection() => client.CloseSessionAsync();

        public void CancelConnecting() => requestCancelled = true;

    }
}
