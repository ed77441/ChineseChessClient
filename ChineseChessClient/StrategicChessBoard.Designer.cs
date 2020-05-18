﻿namespace ChineseChessClient
{
    partial class StrategicChessBoard
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
            this.chessBoardBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chessBoardBox
            // 
            this.chessBoardBox.Image = global::ChineseChessClient.Properties.Resources.fullChessboard;
            this.chessBoardBox.Location = new System.Drawing.Point(3, 69);
            this.chessBoardBox.Name = "chessBoardBox";
            this.chessBoardBox.Size = new System.Drawing.Size(829, 864);
            this.chessBoardBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chessBoardBox.TabIndex = 0;
            this.chessBoardBox.TabStop = false;
            // 
            // StrategicChessBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(836, 938);
            this.Controls.Add(this.chessBoardBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StrategicChessBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Strategic Chess Game";
            this.Controls.SetChildIndex(this.chessBoardBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox chessBoardBox;
    }
}