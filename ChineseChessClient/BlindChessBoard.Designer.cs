namespace ChineseChessClient
{
    partial class BlindChessBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlindChessBoard));
            this.chessBoardBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chessBoardBox
            // 
            this.chessBoardBox.BackColor = System.Drawing.Color.White;
            this.chessBoardBox.Image = ((System.Drawing.Image)(resources.GetObject("chessBoardBox.Image")));
            this.chessBoardBox.Location = new System.Drawing.Point(53, 83);
            this.chessBoardBox.Name = "chessBoardBox";
            this.chessBoardBox.Size = new System.Drawing.Size(671, 339);
            this.chessBoardBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chessBoardBox.TabIndex = 0;
            this.chessBoardBox.TabStop = false;
            // 
            // BlindChessBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(783, 453);
            this.Controls.Add(this.chessBoardBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BlindChessBoard";
            this.Text = "Blind Chess Game";
            this.Controls.SetChildIndex(this.chessBoardBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chessBoardBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox chessBoardBox;
    }
}