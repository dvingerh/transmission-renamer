﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;
using static transmission_renamer.Globals;

namespace transmission_renamer
{
    public class SessionHandler
    {
        public string Host { get; set; }
        public string RpcPath { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private Client client;
        private bool requestCancelled = false;

        public SessionHandler(string host, string rpcPath, int port, string username, string password)
        {
            Host = host;
            RpcPath = rpcPath;
            Port = port;
            Username = username;
            Password = password;
        }

        public async Task<RequestResult> TestConnection()
        {
            try
            {
                if (client != null)
                    client.CloseSessionAsync();
                client = new Client(url: $"http://{Host}:{Port}{RpcPath}", login: Username, password: Password);

                RequestResult connectionResult;
                Task<SessionInfo> sessionInfoTask = client.GetSessionInformationAsync();
                Task delayTask = Task.Delay(TimeSpan.FromSeconds(5));

                await Task.Run(async () => await Task.WhenAny(sessionInfoTask, delayTask));


                if (!requestCancelled)
                {
                    if (delayTask.IsCompleted)
                        connectionResult = RequestResult.Timeout;
                    else
                    {
                        SessionInfo sessionInfo = sessionInfoTask.Result;
                        connectionResult = sessionInfo != null && sessionInfo.Version != null ? RequestResult.Success : RequestResult.InvalidResponse;
                    }
                }
                else
                    connectionResult = RequestResult.Cancelled;
                return connectionResult;
            }
            catch (AggregateException ae)
            {
                WebException exception = (WebException)ae.GetBaseException();
                HttpWebResponse httpWebResponse = (HttpWebResponse)exception.Response;
                if (httpWebResponse.StatusCode == HttpStatusCode.Unauthorized)
                    return RequestResult.Unauthorized;
                else
                    return RequestResult.Failed;
            }
        }

        public async Task<List<TorrentInfo>> GetTorrents()
        {
            try
            {
                Task<TransmissionTorrents> getTorrentsTask = client.TorrentGetAsync(TorrentFields.ALL_FIELDS);
                Task delayTask = Task.Delay(TimeSpan.FromSeconds(5));
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
            catch (AggregateException)
            {
                return null;
            }
        }

        public async Task<RequestResult> RenameTorrent(string filePath, string newName, TorrentInfo torrent)
        {
            try
            {
                RequestResult renameResult;
                Task<RenameTorrentInfo> renameFileTask = client.TorrentRenamePathAsync(torrent.ID, filePath, newName);
                Task delayTask = Task.Delay(TimeSpan.FromSeconds(5));

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
            catch (AggregateException)
            {
                return RequestResult.Failed;
            }
        }

        public void CloseConnection() => client.CloseSessionAsync();

        public void CancelConnecting() => requestCancelled = true;

    }
}
