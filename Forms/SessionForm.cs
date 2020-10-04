using System;
using System.IO;
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
            if (debug && File.Exists("Settings.xml"))
            {
                XmlDocument debugXmlDoc = new XmlDocument();
                debugXmlDoc.Load("Settings.xml");
                XmlNode loginNodes = debugXmlDoc.SelectSingleNode("/Login");
                HostTextBox.Text = loginNodes["Host"].InnerText;
                PortUpDown.Value = decimal.Parse(loginNodes["Port"].InnerText);
                UsernameTextBox.Text = loginNodes["Username"].InnerText;
                PasswordTextBox.Text = loginNodes["Password"].InnerText;
                RPCPathTextBox.Text = loginNodes["RPCPath"].InnerText;
                AuthenticationRequiredCheckBox.Checked = loginNodes["Authentication"].InnerText.ToLower() == "true";
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
            Globals.RequestResult connectionResult = Globals.RequestResult.Unknown;

            if (AuthenticationRequiredCheckBox.Checked)
                Globals.SessionHandler = new SessionHandler(HostTextBox.Text, RPCPathTextBox.Text, (int)PortUpDown.Value, UsernameTextBox.Text, PasswordTextBox.Text);
            else
                Globals.SessionHandler = new SessionHandler(HostTextBox.Text, RPCPathTextBox.Text, (int)PortUpDown.Value, null, null);
            await Task.Run(async () => { connectionResult = await Globals.SessionHandler.TestConnection(); });

            if (isConnecting)
            {
                bool revertUi = true;
                switch (connectionResult)
                {
                    case Globals.RequestResult.Success:
                        Hide();
                        SelectTorrentFilesForm selectTorrentFilesForm = new SelectTorrentFilesForm();
                        selectTorrentFilesForm.Text = $"Transmission Renamer - {Globals.SessionHandler.SessionUrl}";
                        selectTorrentFilesForm.ShowDialog();
                        Show();
                        break;
                    case Globals.RequestResult.Timeout:
                        MessageBox.Show("The connection to the host has timed out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Globals.RequestResult.InvalidResponse:
                        MessageBox.Show("The host returned an invalid response.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Globals.RequestResult.Failed:
                        MessageBox.Show("The specified host or RPC path is invalid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Globals.RequestResult.Unauthorized:
                        MessageBox.Show("The specified port or login credentials are invalid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Globals.RequestResult.Cancelled:
                        // show no message but keep UI controls and behavior intact
                        revertUi = false;
                        break;
                    case Globals.RequestResult.Unknown:
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

        private void AuthenticationRequiredCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            UsernameLabel.Enabled = AuthenticationRequiredCheckBox.Checked;
            UsernameTextBox.Enabled = AuthenticationRequiredCheckBox.Checked;
            PasswordLabel.Enabled = AuthenticationRequiredCheckBox.Checked;
            PasswordTextBox.Enabled = AuthenticationRequiredCheckBox.Checked;
        }
    }
}