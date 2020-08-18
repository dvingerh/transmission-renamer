using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;

namespace transmission_renamer
{
    public class SessionHandler
    {
        private string host;
        private int port;
        private string username;
        private string password;

        public string Host { get => host; set => host = value; }
        public int Port { get => port; set => port = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        private Client client;
        private bool isCancelled = false;

        public SessionHandler(string host, int port, string username, string password)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
        }


        public async Task<int> TestConnection()
        {
            int connectionResult;
            client = new Client("http://" + Host + ":" + Port + Constants.RPC_PATH, null, Username, Password);

            Task<SessionInfo> sessionInfoTask = client.GetSessionInformationAsync();
            Task delayTask = Task.Delay(TimeSpan.FromSeconds(10));
            await Task.WhenAny(sessionInfoTask, delayTask);
            if (!isCancelled)
            {
                if (delayTask.IsCompleted)
                    connectionResult = 1;
                else
                {
                    SessionInfo sessionInfo = sessionInfoTask.Result;
                    if (sessionInfo != null && sessionInfo.Version != null)
                        connectionResult = 0;
                    else
                        connectionResult = 2;
                }
            }
            else
            {
                connectionResult = 4;
            }


            return connectionResult;
        }

        public async Task<List<TorrentInfo>> GetSessionTorrents()
        {
            Task<TransmissionTorrents> transmissionTorrentsTask = client.TorrentGetAsync(TorrentFields.ALL_FIELDS);
            Task delayTask = Task.Delay(TimeSpan.FromSeconds(10));
            await Task.WhenAny(transmissionTorrentsTask, delayTask);
            if (!isCancelled)
            {
                if (delayTask.IsCompleted)
                    return null;
                else
                {
                    TransmissionTorrents torrentsList = transmissionTorrentsTask.Result;
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
            isCancelled = true;
        }

    }
}
