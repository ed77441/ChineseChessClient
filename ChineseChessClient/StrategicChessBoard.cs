using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChineseChessClient.Properties;

namespace ChineseChessClient
{
    public partial class StrategicChessBoard : ChessView
    {
        readonly PictureBox[] pictureBoxes = new PictureBox[90];

        public PictureBox[] GetChessBoardGrids()
        {
            return pictureBoxes;
        }

        public StrategicChessBoard()
        {
            InitializeComponent();
            float y = 26, x = 28 ;

            for (int i = 0; i < 90; ++i)
            {
                PictureBox pictureBox = new PictureBox();

                int scalerX = i % 9;
                int scalerY = i / 9;

                pictureBox.Location = new Point((int)(x + scalerX * 66), (int)(y + scalerY * 68.5));

                pictureBox.TabIndex = i;
                pictureBox.Size = new Size(48, 48);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.BackColor = Color.Transparent;
                pictureBox.Parent = chessBoardBox;
                pictureBoxes[i] = pictureBox;
            }
        }

        public void ResetChessBoardImage(String myColor)
        {
            int[] lastRow = new int[9] {
                3,  2, 4, 5, 6, 5, 4, 2, 3
            };/*0*/

            int[] secondRow = new int[9] {
                -1,  1, -1, -1, -1, -1, -1, 1, -1
            };/*2*/

            int[] firstRow = new int[9] {
                0,  -1, 0, -1, 0, -1, 0, -1, 0
            };/*3*/

            foreach (PictureBox box in pictureBoxes) {
                box.Image = null;
            }

            String opColor = myColor == "RED" ? "BLACK" : "RED";

            SetPiecePosition(0, lastRow, opColor, myColor);
            SetPiecePosition(9 * 2, secondRow, opColor, myColor);
            SetPiecePosition(9 * 3, firstRow, opColor, myColor);
        }

        private void SetPiecePosition(int startPos, int []pieces, String opColor, String myColor) {
            String imageName;
            for (int i = 0; i < 9; ++i)
            {
                imageName = opColor + '_' + pieces[i];
                pictureBoxes[startPos + i].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);

                imageName = myColor + '_' + pieces[i];
                pictureBoxes[89 - startPos - i].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
            }
        }
        
        override
        public void SetColorLabel(String color) {
            ResetChessBoardImage(color);
            base.SetColorLabel(color);
        }

        override
        public void FlipChessPiece(int pos, String imageName) { }
        override
        public void MoveChessPiece(int src, int dest)
        {
            Invoke((MethodInvoker)delegate
            {
                pictureBoxes[dest].Image = pictureBoxes[src].Image;
                pictureBoxes[src].Image = null;
            });
        }
    }
}
