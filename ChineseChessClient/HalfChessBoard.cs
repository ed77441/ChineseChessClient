using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChessClient
{
    public partial class HalfChessBoard : ChessView
    {
        readonly PictureBox[] pictureBoxes = new PictureBox[32];

        public PictureBox [] GetChessBoardGrids() {
            return pictureBoxes;
        }

        public HalfChessBoard()
        {
            InitializeComponent();

            int y = 14, x = 12;

            for (int i = 0; i < 32 ; ++i)
            {
                PictureBox pictureBox = new PictureBox();

                int scalerX = i % 8;
                int scalerY = i / 8;

                pictureBox.Location = new Point((int)(x + scalerX * 61.5), (int)(y + scalerY * 65.5));

                pictureBox.TabIndex = i;
                pictureBox.Size = new Size(48, 48);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.BackColor = Color.Transparent;
                pictureBox.Parent = chessBoardBox;
                pictureBoxes[i] = pictureBox;
            }
        }

        public void ResetChessBoardImage() {
            ResetGameStateView();

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Image = Properties.Resources.pieceBackground;
            }
        }

        override
        public void FlipChessPiece(int pos, String imageName) {
            Invoke((MethodInvoker)delegate
            {
                PictureBox pictureBox = pictureBoxes[pos];
                pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
            });
        }

        override
        public void MoveChessPiece(int src, int dest) {
            Invoke((MethodInvoker)delegate
            {
                pictureBoxes[dest].Image = pictureBoxes[src].Image;
                pictureBoxes[src].Image = null;
            });
        }
    }
}
