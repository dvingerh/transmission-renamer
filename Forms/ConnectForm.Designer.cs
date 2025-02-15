namespace transmission_renamer
{
    partial class ConnectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.RemoteGroupBox = new System.Windows.Forms.GroupBox();
            this.RPCPathLabel = new System.Windows.Forms.Label();
            this.RPCPathTextBox = new System.Windows.Forms.TextBox();
            this.AuthenticationRequiredCheckBox = new System.Windows.Forms.CheckBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.HostLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PortUpDown = new System.Windows.Forms.NumericUpDown();
            this.HostTextBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.CloseCancelButton = new System.Windows.Forms.Button();
            this.TimeOutTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.MaxRequestDurationUpDown = new System.Windows.Forms.NumericUpDown();
            this.RemoteGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRequestDurationUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // RemoteGroupBox
            // 
            this.RemoteGroupBox.Controls.Add(this.label1);
            this.RemoteGroupBox.Controls.Add(this.MaxRequestDurationUpDown);
            this.RemoteGroupBox.Controls.Add(this.RPCPathLabel);
            this.RemoteGroupBox.Controls.Add(this.RPCPathTextBox);
            this.RemoteGroupBox.Controls.Add(this.AuthenticationRequiredCheckBox);
            this.RemoteGroupBox.Controls.Add(this.PasswordLabel);
            this.RemoteGroupBox.Controls.Add(this.UsernameLabel);
            this.RemoteGroupBox.Controls.Add(this.PortLabel);
            this.RemoteGroupBox.Controls.Add(this.HostLabel);
            this.RemoteGroupBox.Controls.Add(this.PasswordTextBox);
            this.RemoteGroupBox.Controls.Add(this.UsernameTextBox);
            this.RemoteGroupBox.Controls.Add(this.PortUpDown);
            this.RemoteGroupBox.Controls.Add(this.HostTextBox);
            this.RemoteGroupBox.Location = new System.Drawing.Point(18, 18);
            this.RemoteGroupBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemoteGroupBox.Name = "RemoteGroupBox";
            this.RemoteGroupBox.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemoteGroupBox.Size = new System.Drawing.Size(315, 315);
            this.RemoteGroupBox.TabIndex = 4;
            this.RemoteGroupBox.TabStop = false;
            this.RemoteGroupBox.Text = "Session settings";
            // 
            // RPCPathLabel
            // 
            this.RPCPathLabel.AutoSize = true;
            this.RPCPathLabel.Location = new System.Drawing.Point(9, 75);
            this.RPCPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RPCPathLabel.Name = "RPCPathLabel";
            this.RPCPathLabel.Size = new System.Drawing.Size(85, 23);
            this.RPCPathLabel.TabIndex = 10;
            this.RPCPathLabel.Text = "RPC path:";
            // 
            // RPCPathTextBox
            // 
            this.RPCPathTextBox.Location = new System.Drawing.Point(102, 72);
            this.RPCPathTextBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RPCPathTextBox.Name = "RPCPathTextBox";
            this.RPCPathTextBox.Size = new System.Drawing.Size(202, 29);
            this.RPCPathTextBox.TabIndex = 1;
            this.RPCPathTextBox.Text = "/transmission/rpc";
            this.RPCPathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCtrlKeyBack);
            // 
            // AuthenticationRequiredCheckBox
            // 
            this.AuthenticationRequiredCheckBox.AutoSize = true;
            this.AuthenticationRequiredCheckBox.Location = new System.Drawing.Point(14, 199);
            this.AuthenticationRequiredCheckBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AuthenticationRequiredCheckBox.Name = "AuthenticationRequiredCheckBox";
            this.AuthenticationRequiredCheckBox.Size = new System.Drawing.Size(218, 27);
            this.AuthenticationRequiredCheckBox.TabIndex = 3;
            this.AuthenticationRequiredCheckBox.Text = "Authentication required";
            this.AuthenticationRequiredCheckBox.UseVisualStyleBackColor = true;
            this.AuthenticationRequiredCheckBox.CheckedChanged += new System.EventHandler(this.AuthenticationRequiredCheckBoxCheckedChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Enabled = false;
            this.PasswordLabel.Location = new System.Drawing.Point(9, 277);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(84, 23);
            this.PasswordLabel.TabIndex = 7;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Enabled = false;
            this.UsernameLabel.Location = new System.Drawing.Point(9, 238);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(91, 23);
            this.UsernameLabel.TabIndex = 6;
            this.UsernameLabel.Text = "Username:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(9, 114);
            this.PortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(45, 23);
            this.PortLabel.TabIndex = 5;
            this.PortLabel.Text = "Port:";
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Location = new System.Drawing.Point(9, 31);
            this.HostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(49, 23);
            this.HostLabel.TabIndex = 4;
            this.HostLabel.Text = "Host:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Enabled = false;
            this.PasswordTextBox.Location = new System.Drawing.Point(102, 274);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '●';
            this.PasswordTextBox.Size = new System.Drawing.Size(202, 29);
            this.PasswordTextBox.TabIndex = 5;
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCtrlKeyBack);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Enabled = false;
            this.UsernameTextBox.Location = new System.Drawing.Point(102, 234);
            this.UsernameTextBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(202, 29);
            this.UsernameTextBox.TabIndex = 4;
            this.UsernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCtrlKeyBack);
            // 
            // PortUpDown
            // 
            this.PortUpDown.Location = new System.Drawing.Point(102, 112);
            this.PortUpDown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PortUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortUpDown.Name = "PortUpDown";
            this.PortUpDown.Size = new System.Drawing.Size(204, 29);
            this.PortUpDown.TabIndex = 2;
            this.PortUpDown.Value = new decimal(new int[] {
            9091,
            0,
            0,
            0});
            this.PortUpDown.Enter += new System.EventHandler(this.PortUpDown_Enter);
            // 
            // HostTextBox
            // 
            this.HostTextBox.Location = new System.Drawing.Point(102, 28);
            this.HostTextBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(202, 29);
            this.HostTextBox.TabIndex = 0;
            this.HostTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCtrlKeyBack);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(18, 345);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(147, 34);
            this.ConnectButton.TabIndex = 6;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButtonClicked);
            // 
            // CloseCancelButton
            // 
            this.CloseCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseCancelButton.Location = new System.Drawing.Point(186, 345);
            this.CloseCancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CloseCancelButton.Name = "CloseCancelButton";
            this.CloseCancelButton.Size = new System.Drawing.Size(147, 34);
            this.CloseCancelButton.TabIndex = 7;
            this.CloseCancelButton.Text = "Close";
            this.CloseCancelButton.UseVisualStyleBackColor = true;
            this.CloseCancelButton.Click += new System.EventHandler(this.CloseCancelButtonPressed);
            // 
            // TimeOutTimer
            // 
            this.TimeOutTimer.Interval = 1000;
            this.TimeOutTimer.Tag = "";
            this.TimeOutTimer.Tick += new System.EventHandler(this.TimeOutTimerTick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Timeout:";
            // 
            // MaxRequestDurationUpDown
            // 
            this.MaxRequestDurationUpDown.Location = new System.Drawing.Point(102, 153);
            this.MaxRequestDurationUpDown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaxRequestDurationUpDown.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.MaxRequestDurationUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxRequestDurationUpDown.Name = "MaxRequestDurationUpDown";
            this.MaxRequestDurationUpDown.Size = new System.Drawing.Size(204, 29);
            this.MaxRequestDurationUpDown.TabIndex = 11;
            this.MaxRequestDurationUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.MaxRequestDurationUpDown.Enter += new System.EventHandler(this.MaxRequestDurationUpDown_Enter);
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.ConnectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.CloseCancelButton;
            this.ClientSize = new System.Drawing.Size(351, 394);
            this.Controls.Add(this.CloseCancelButton);
            this.Controls.Add(this.RemoteGroupBox);
            this.Controls.Add(this.ConnectButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to session";
            this.RemoteGroupBox.ResumeLayout(false);
            this.RemoteGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRequestDurationUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RemoteGroupBox;
        private System.Windows.Forms.Label RPCPathLabel;
        private System.Windows.Forms.TextBox RPCPathTextBox;
        private System.Windows.Forms.CheckBox AuthenticationRequiredCheckBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.NumericUpDown PortUpDown;
        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button CloseCancelButton;
        private System.Windows.Forms.Timer TimeOutTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MaxRequestDurationUpDown;
    }
}

