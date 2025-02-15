﻿using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace transmission_renamer
{
    public partial class ConnectForm : Form
    {
        private bool isConnecting = false;

        public ConnectForm()
        {
            Font = new Font("Segoe UI", 6.75f);
            InitializeComponent();
            TimeOutTimer.Tag = Properties.Settings.Default.MaxRequestDuration;
            if (!File.Exists("Settings.xml"))
                CreateConfig();

            try
            {
                XmlDocument debugXmlDoc = new XmlDocument();
                debugXmlDoc.Load("Settings.xml");
                XmlNode loginNodes = debugXmlDoc.SelectSingleNode("/Login");
                HostTextBox.Text = loginNodes["Host"].InnerText;
                PortUpDown.Value = decimal.Parse(loginNodes["Port"].InnerText);
                UsernameTextBox.Text = loginNodes["Username"].InnerText;
                PasswordTextBox.Text = loginNodes["Password"].InnerText;
                RPCPathTextBox.Text = loginNodes["RPCPath"].InnerText;
                MaxRequestDurationUpDown.Value = decimal.Parse(loginNodes["MaxRequestDuration"].InnerText);
                AuthenticationRequiredCheckBox.Checked = loginNodes["Authentication"].InnerText.ToLower() == "true";
            }
            catch (XmlException)
            {
                MessageBox.Show("Settings.xml file was found but does not contain a valid configuration.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void CreateConfig()
        {
            string configPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            StreamWriter sw = File.CreateText(Path.Combine(configPath, "Settings.xml"));
            sw.Write(Constants.CONFIG);
            sw.Flush();
            sw.Close();
        }

        private void SaveConfig()
        {
            XmlDocument debugXmlDoc = new XmlDocument();
            debugXmlDoc.Load("Settings.xml");
            XmlNode loginNodes = debugXmlDoc.SelectSingleNode("/Login");

            loginNodes["Host"].InnerText = HostTextBox.Text;
            loginNodes["Port"].InnerText = PortUpDown.Value.ToString();
            loginNodes["Username"].InnerText = UsernameTextBox.Text;
            loginNodes["Password"].InnerText = PasswordTextBox.Text;
            loginNodes["RPCPath"].InnerText = RPCPathTextBox.Text;
            loginNodes["Authentication"].InnerText = AuthenticationRequiredCheckBox.Checked.ToString().ToLower();
            loginNodes["MaxRequestDuration"].InnerText = MaxRequestDurationUpDown.Value.ToString().ToLower();

            Properties.Settings.Default.MaxRequestDuration = (double)MaxRequestDurationUpDown.Value;
            Properties.Settings.Default.Save();

            debugXmlDoc.Save("Settings.xml");
        }

        private void CloseCancelButtonPressed(object sender, EventArgs e)
        {
            if (isConnecting)
            {
                TimeOutTimer.Stop();
                TimeOutTimer.Enabled = false;
                TimeOutTimer.Tag = Properties.Settings.Default.MaxRequestDuration;
                ConnectButton.Text = "Connect";
                CloseCancelButton.Text = "Close";
                RemoteGroupBox.Enabled = true;
                ConnectButton.Enabled = true;
                isConnecting = false;
                Globals.SessionHandler.CancelConnecting();
            }
            else
            {
                Globals.SessionHandler?.CloseConnection();
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
            SaveConfig();

            isConnecting = true;
            RemoteGroupBox.Enabled = false;
            ConnectButton.Enabled = false;
            ConnectButton.Text = $"Waiting ({Properties.Settings.Default.MaxRequestDuration})";
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
                        SaveConfig();
                        Hide();
                        SettingsForm selectTorrentFilesForm = new SettingsForm
                        {
                            Text = $"Transmission Renamer - {Globals.SessionHandler.SessionUrl}"
                        };
                        selectTorrentFilesForm.ShowDialog();
                        Show();
                        break;
                    case Globals.RequestResult.Timeout:
                        MessageBox.Show("The connection to the host has timed out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Globals.RequestResult.InvalidResponse:
                        MessageBox.Show("The host returned an invalid response.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Globals.RequestResult.Error:
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
                    TimeOutTimer.Tag = Properties.Settings.Default.MaxRequestDuration;
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

        private void PortUpDown_Enter(object sender, EventArgs e)
        {
           PortUpDown.Select(0, PortUpDown.Text.Length);
        }

        private void TextBoxCtrlKeyBack(object sender, KeyEventArgs e)
        {
            Classes.TextBoxBackFix.SearchCtrlBackSpace(sender, e);
        }

        private void MaxRequestDurationUpDown_Enter(object sender, EventArgs e)
        {
            MaxRequestDurationUpDown.Select(0, MaxRequestDurationUpDown.Text.Length);
        }
    }
}