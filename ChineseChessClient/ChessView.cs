using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChessClient
{
    public partial class ChessView : Form
    {
        public ChessView()
        {
            InitializeComponent();
        }

        public Button GetSurrenderButton()
        {
            return surrenderButton;
        }

        protected void ResetGameStateView() {
            Invoke((MethodInvoker)delegate
            {
                yourColorLabel.Text = "???";
                yourColorLabel.ForeColor = Color.FromName("ControlDarkDark");
                whosTurnLabel.Text = "???";
                SelectedBox.Image = null;
            });
        }

        public virtual void SetColorLabel(String color)
        {
            Invoke((MethodInvoker)delegate
            {
                if (color == "RED")
                {
                    yourColorLabel.ForeColor = Color.Red;
                }
                else
                {
                    yourColorLabel.ForeColor = Color.Black;

                }
                yourColorLabel.Text = color;
            });
        }

        public void SetTurnLabel(String name)
        {
            Invoke((MethodInvoker)delegate
            {
                whosTurnLabel.Text = name;
            });
        }

        public void SetSelectedPiece(String imageName)
        {
            Invoke((MethodInvoker)delegate
            {
                SelectedBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
            });
        }

        public virtual void FlipChessPiece(int pos, String imageName) { }
        public virtual void MoveChessPiece(int src, int dest) { }
        
    }
}
