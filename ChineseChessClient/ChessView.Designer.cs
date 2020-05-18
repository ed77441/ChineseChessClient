namespace ChineseChessClient
{
    partial class ChessView
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
            this.label5 = new System.Windows.Forms.Label();
            this.whosTurnLabel = new System.Windows.Forms.Label();
            this.surrenderButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.yourColorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectedBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(469, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "Selected：";
            // 
            // whosTurnLabel
            // 
            this.whosTurnLabel.AutoSize = true;
            this.whosTurnLabel.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whosTurnLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.whosTurnLabel.Location = new System.Drawing.Point(235, 15);
            this.whosTurnLabel.Name = "whosTurnLabel";
            this.whosTurnLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.whosTurnLabel.Size = new System.Drawing.Size(199, 30);
            this.whosTurnLabel.TabIndex = 13;
            this.whosTurnLabel.Text = "Status will show here";
            this.whosTurnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // surrenderButton
            // 
            this.surrenderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.surrenderButton.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surrenderButton.ForeColor = System.Drawing.Color.White;
            this.surrenderButton.Location = new System.Drawing.Point(670, 10);
            this.surrenderButton.Name = "surrenderButton";
            this.surrenderButton.Size = new System.Drawing.Size(101, 40);
            this.surrenderButton.TabIndex = 12;
            this.surrenderButton.Text = "Forfeit";
            this.surrenderButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(154, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "Status：";
            // 
            // yourColorLabel
            // 
            this.yourColorLabel.AutoSize = true;
            this.yourColorLabel.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourColorLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.yourColorLabel.Location = new System.Drawing.Point(76, 15);
            this.yourColorLabel.Name = "yourColorLabel";
            this.yourColorLabel.Size = new System.Drawing.Size(40, 30);
            this.yourColorLabel.TabIndex = 10;
            this.yourColorLabel.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "Color：";
            // 
            // SelectedBox
            // 
            this.SelectedBox.Location = new System.Drawing.Point(577, 1);
            this.SelectedBox.Name = "SelectedBox";
            this.SelectedBox.Size = new System.Drawing.Size(60, 60);
            this.SelectedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SelectedBox.TabIndex = 15;
            this.SelectedBox.TabStop = false;
            // 
            // ChessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 434);
            this.Controls.Add(this.SelectedBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.whosTurnLabel);
            this.Controls.Add(this.surrenderButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yourColorLabel);
            this.Controls.Add(this.label1);
            this.Name = "ChessView";
            this.Text = "ChessView";
            ((System.ComponentModel.ISupportInitialize)(this.SelectedBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SelectedBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label whosTurnLabel;
        private System.Windows.Forms.Button surrenderButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label yourColorLabel;
        private System.Windows.Forms.Label label1;
    }
}