using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            isConnecting = true;
            RemoteGroupBox.Enabled = false;
            ConnectButton.Enabled = false;
            ConnectButton.Text = "Waiting (10)";
            CloseCancelButton.Text = "Cancel";
            TimeOutTimer.Enabled = true;
            TimeOutTimer.Start();
            Globals.SessionHandler = new SessionHandler(HostTextBox.Text, (int)PortUpDown.Value, UsernameTextBox.Text, PasswordTextBox.Text);
            var connectionResult = -1;

            await Task.Run(async() => {
                try
                {
                    connectionResult = await Globals.SessionHandler.TestConnection();
                }
                catch (AggregateException ae)
                {
                    WebException ex = (WebException)ae.GetBaseException();
                    HttpWebResponse webResponse = ex.Response as HttpWebResponse;
                    if (webResponse != null && webResponse.StatusCode == HttpStatusCode.Unauthorized)
                        connectionResult = 3;
                }
            });


            if (isConnecting)
            {
                bool revertButtons = true;
                switch (connectionResult)
                {
                    case 0:
                        Hide();
                        SelectTorrentFilesForm selectTorrentFilesForm = new SelectTorrentFilesForm();
                        selectTorrentFilesForm.ShowDialog();
                        Show();
                        break;
                    case 1:
                        MessageBox.Show("The connection to the host has timed out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2:
                        MessageBox.Show("The host returned an invalid response.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 3:
                        MessageBox.Show("The host rejected the login credentials.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 4:
                        // Connection was cancelled in this case, show no message but keep UI controls and behavior intact
                        revertButtons = false;
                        break;
                    default:
                        MessageBox.Show("An unknown error has occurred.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                if (revertButtons)
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
