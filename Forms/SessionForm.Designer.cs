namespace transmission_renamer
{
    partial class SessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionForm));
            this.RemoteGroupBox = new System.Windows.Forms.GroupBox();
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
            this.RemoteGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // RemoteGroupBox
            // 
            this.RemoteGroupBox.Controls.Add(this.PasswordLabel);
            this.RemoteGroupBox.Controls.Add(this.UsernameLabel);
            this.RemoteGroupBox.Controls.Add(this.PortLabel);
            this.RemoteGroupBox.Controls.Add(this.HostLabel);
            this.RemoteGroupBox.Controls.Add(this.PasswordTextBox);
            this.RemoteGroupBox.Controls.Add(this.UsernameTextBox);
            this.RemoteGroupBox.Controls.Add(this.PortUpDown);
            this.RemoteGroupBox.Controls.Add(this.HostTextBox);
            this.RemoteGroupBox.Location = new System.Drawing.Point(12, 12);
            this.RemoteGroupBox.Name = "RemoteGroupBox";
            this.RemoteGroupBox.Size = new System.Drawing.Size(185, 141);
            this.RemoteGroupBox.TabIndex = 2;
            this.RemoteGroupBox.TabStop = false;
            this.RemoteGroupBox.Text = "Session settings";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(6, 118);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(59, 13);
            this.PasswordLabel.TabIndex = 7;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(6, 92);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(61, 13);
            this.UsernameLabel.TabIndex = 6;
            this.UsernameLabel.Text = "Username:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(6, 47);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(31, 13);
            this.PortLabel.TabIndex = 5;
            this.PortLabel.Text = "Port:";
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Location = new System.Drawing.Point(6, 22);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(34, 13);
            this.HostLabel.TabIndex = 4;
            this.HostLabel.Text = "Host:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(68, 115);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '●';
            this.PasswordTextBox.Size = new System.Drawing.Size(111, 22);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(68, 89);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(111, 22);
            this.UsernameTextBox.TabIndex = 2;
            // 
            // PortUpDown
            // 
            this.PortUpDown.Location = new System.Drawing.Point(68, 45);
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
            this.PortUpDown.Size = new System.Drawing.Size(111, 22);
            this.PortUpDown.TabIndex = 1;
            this.PortUpDown.Value = new decimal(new int[] {
            9091,
            0,
            0,
            0});
            // 
            // HostTextBox
            // 
            this.HostTextBox.Location = new System.Drawing.Point(68, 19);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(111, 22);
            this.HostTextBox.TabIndex = 0;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 159);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(85, 23);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButtonClicked);
            // 
            // CloseCancelButton
            // 
            this.CloseCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseCancelButton.Location = new System.Drawing.Point(112, 159);
            this.CloseCancelButton.Name = "CloseCancelButton";
            this.CloseCancelButton.Size = new System.Drawing.Size(85, 23);
            this.CloseCancelButton.TabIndex = 4;
            this.CloseCancelButton.Text = "Close";
            this.CloseCancelButton.UseVisualStyleBackColor = true;
            this.CloseCancelButton.Click += new System.EventHandler(this.CloseCancelButtonPressed);
            // 
            // TimeOutTimer
            // 
            this.TimeOutTimer.Interval = 1000;
            this.TimeOutTimer.Tag = "10";
            this.TimeOutTimer.Tick += new System.EventHandler(this.TimeOutTimerTick);
            // 
            // SessionForm
            // 
            this.AcceptButton = this.ConnectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.CloseCancelButton;
            this.ClientSize = new System.Drawing.Size(209, 194);
            this.Controls.Add(this.CloseCancelButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.RemoteGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to session";
            this.RemoteGroupBox.ResumeLayout(false);
            this.RemoteGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox RemoteGroupBox;
        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.NumericUpDown PortUpDown;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button CloseCancelButton;
        private System.Windows.Forms.Timer TimeOutTimer;
    }
}

