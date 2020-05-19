namespace ChineseChessClient
{
    partial class Login
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
            this.connectButton = new System.Windows.Forms.Button();
            this.serverIPLabel = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.playerName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.ForeColor = System.Drawing.SystemColors.Control;
            this.connectButton.Location = new System.Drawing.Point(29, 348);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(220, 49);
            this.connectButton.TabIndex = 13;
            this.connectButton.Text = "CONNECT";
            this.connectButton.UseCompatibleTextRendering = true;
            this.connectButton.UseVisualStyleBackColor = false;
            // 
            // serverIPLabel
            // 
            this.serverIPLabel.AutoSize = true;
            this.serverIPLabel.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIPLabel.Location = new System.Drawing.Point(37, 259);
            this.serverIPLabel.Name = "serverIPLabel";
            this.serverIPLabel.Size = new System.Drawing.Size(81, 35);
            this.serverIPLabel.TabIndex = 11;
            this.serverIPLabel.Text = "ServerIP";
            this.serverIPLabel.UseCompatibleTextRendering = true;
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel.Location = new System.Drawing.Point(37, 188);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(97, 35);
            this.playerNameLabel.TabIndex = 10;
            this.playerNameLabel.Text = "UserName";
            this.playerNameLabel.UseCompatibleTextRendering = true;
            // 
            // serverIP
            // 
            this.serverIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverIP.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIP.Location = new System.Drawing.Point(37, 300);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(205, 27);
            this.serverIP.TabIndex = 9;
            this.serverIP.Text = "127.0.0.1:5555";
            // 
            // playerName
            // 
            this.playerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerName.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerName.Location = new System.Drawing.Point(37, 226);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(205, 27);
            this.playerName.TabIndex = 8;
            this.playerName.Text = "DefaultUserName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::ChineseChessClient.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(54, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(285, 425);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.serverIPLabel);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.playerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label serverIPLabel;
        private System.Windows.Forms.Label playerNameLabel;
        public System.Windows.Forms.TextBox serverIP;
        public System.Windows.Forms.TextBox playerName;
    }
}