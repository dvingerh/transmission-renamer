using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;
using static transmission_renamer.Globals;

namespace transmission_renamer
{
    public class SessionHandler
    {
        private string host;
        private int port;
        private string username;
        private string password;
        private string address;

        public string Host { get => host; set => host = value; }
        public int Port { get => port; set => port = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Url { get => address; set => address = value; }

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
                Uri uri = new Uri("http://" + Host + ":" + Port + Constants.RPC_PATH);
                Url = uri.ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ConnectionResult> TestConnection()
        {
            if (client != null)
                client.CloseSessionAsync();
            if (ValidateUrl())
                client = new Client(url: Url, login: Username, password: Password);
            else
                return ConnectionResult.InvalidUrl;

            ConnectionResult connectionResult;
            Task<SessionInfo> sessionInfoTask = client.GetSessionInformationAsync();
            Task delayTask = Task.Delay(TimeSpan.FromSeconds(10));

            await Task.Run(async () => await Task.WhenAny(sessionInfoTask, delayTask));

            
            if (!requestCancelled)
            {
                if (delayTask.IsCompleted)
                    connectionResult = ConnectionResult.Timeout;
                else
                {
                    SessionInfo sessionInfo = sessionInfoTask.Result;
                    if (sessionInfo != null && sessionInfo.Version != null)
                        connectionResult = ConnectionResult.Success;
                    else
                        connectionResult = ConnectionResult.InvalidResp;
                }
            }
            else
                connectionResult = ConnectionResult.Cancelled;
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
                    return null;
                else
                {
                    TransmissionTorrents torrentsList = getTorrentsTask.Result;
                    if (torrentsList != null && torrentsList.Torrents != null)
                        return torrentsList.Torrents.ToList();
                    else
                        return new List<TorrentInfo>();
                }
            }
            else
            {
                return null;
            }
        }

        public void CloseConnection()
        {
            client.CloseSessionAsync();
        }

        public void CancelConnecting()
        {
            requestCancelled = true;
        }

    }
}
