using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static transmission_renamer.Globals;

namespace transmission_renamer
{
    public partial class SessionForm : Form
    {
        private readonly bool debug = true;
        private bool isConnecting = false;

        public SessionForm()
        {
            InitializeComponent();
            if (debug)
            {
                XmlDocument debugXmlDoc = new XmlDocument();
                debugXmlDoc.Load("DebugSettings.xml");
                XmlNode loginNodes = debugXmlDoc.SelectSingleNode("/Debug/Login");
                HostTextBox.Text = loginNodes["Host"].InnerText;
                PortUpDown.Value = decimal.Parse(loginNodes["Port"].InnerText);
                UsernameTextBox.Text = loginNodes["Username"].InnerText;
                PasswordTextBox.Text = loginNodes["Password"].InnerText;
            }

        }

        private void CloseCancelButtonPressed(object sender, EventArgs e)
        {
            if (isConnecting)
            {
                TimeOutTimer.Stop();
                TimeOutTimer.Enabled = false;
                TimeOutTimer.Tag = "10";
                ConnectButton.Text = "Connect";
                CloseCancelButton.Text = "Close";
                RemoteGroupBox.Enabled = true;
                ConnectButton.Enabled = true;
                isConnecting = false;
                Globals.SessionHandler.CancelConnecting();
            }
            else
            {
                if (Globals.SessionHandler != null)
                    Globals.SessionHandler.CloseConnection();
                Application.Exit();
            }
        }

        private async void ConnectButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HostTextBox.Text))
            {
                MessageBox.Show("The host value may not be empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isConnecting = true;
            RemoteGroupBox.Enabled = false;
            ConnectButton.Enabled = false;
            ConnectButton.Text = "Waiting (10)";
            CloseCancelButton.Text = "Cancel";
            TimeOutTimer.Enabled = true;
            TimeOutTimer.Start();
            ConnectionResult connectionResult = ConnectionResult.Unknown;
            try
            {
                Globals.SessionHandler = new SessionHandler(HostTextBox.Text, (int)PortUpDown.Value, UsernameTextBox.Text, PasswordTextBox.Text);
                connectionResult = await Globals.SessionHandler.TestConnection();
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    if (ex is WebException)
                    {
                        WebException we = (WebException)ex;
                        HttpWebResponse webResponse = we.Response as HttpWebResponse;
                        if (webResponse != null && webResponse.StatusCode == HttpStatusCode.Unauthorized)
                            connectionResult = ConnectionResult.Unauthorized;
                        else
                            connectionResult = ConnectionResult.Unknown;
                    }
                    else if (ex is NullReferenceException)
                        connectionResult = ConnectionResult.InvalidUrl;
                    return ex is WebException || ex is NullReferenceException;
                });
            }
            if (isConnecting)
            {
                bool revertUi = true;
                switch (connectionResult)
                {
                    case ConnectionResult.Success:
                        Hide();
                        SelectTorrentFilesForm selectTorrentFilesForm = new SelectTorrentFilesForm();
                        selectTorrentFilesForm.ShowDialog();
                        Show();
                        break;
                    case ConnectionResult.Timeout:
                        MessageBox.Show("The connection to the host has timed out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case ConnectionResult.InvalidResp:
                        MessageBox.Show("The host returned an invalid response.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case ConnectionResult.InvalidUrl:
                        MessageBox.Show("The specified host address is invalid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case ConnectionResult.Unauthorized:
                        MessageBox.Show("The host rejected the login credentials.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case ConnectionResult.Cancelled:
                        // show no message but keep UI controls and behavior intact
                        revertUi = false;
                        break;
                    case ConnectionResult.Unknown:
                        MessageBox.Show("An unknown error has occurred.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("An unknown error has occurred.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                if (revertUi)
                {
                    ConnectButton.Text = "Connect";
                    CloseCancelButton.Text = "Close";
                    RemoteGroupBox.Enabled = true;
                    ConnectButton.Enabled = true;
                    isConnecting = false;
                    TimeOutTimer.Stop();
                    TimeOutTimer.Enabled = false;
                    TimeOutTimer.Tag = "10";
                }
            }
        }

        private void TimeOutTimerTick(object sender, EventArgs e)
        {
                int secondsLeft = int.Parse(TimeOutTimer.Tag.ToString()) - 1;
                ConnectButton.Text = $"Waiting ({secondsLeft})";
                TimeOutTimer.Tag = secondsLeft--.ToString();
        }
    }
}
