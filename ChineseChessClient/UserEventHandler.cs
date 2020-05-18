using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChessClient
{
    partial class ChessClient
    {
        private void ConnectToServer(object sender, EventArgs e)
        {
            String playerName = login.playerName.Text;
            String serverIP = login.serverIP.Text;

            int colonPos = serverIP.LastIndexOf(':');
            String ip = ""; int port = 0;
            if (colonPos != -1)
            {
                ip = serverIP.Substring(0, colonPos);
                port = Int32.Parse(serverIP.Substring(colonPos + 1));
            }

            if (!string.IsNullOrWhiteSpace(playerName) &&
                ValidateUserName(playerName) &&
                !string.IsNullOrWhiteSpace(serverIP) &&
                    colonPos != -1 && ValidateIPv4(ip))
            {
                IPAddress ipAddr = IPAddress.Parse(ip);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

                clientSocket = new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    clientSocket.Connect(localEndPoint);
                    playerNameStr = playerName;

                    login.Hide();
                    lobby.Show();

                    SendMessage("CONNECT", playerName);
                    StartReceiveMessage();
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message, "SocketException",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unexpected exception",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Textfileds cannot be empty.\n " +
                    "Also, please enter valid ip and port.\n" +
                    "Ex: '127.0.0.1:11111'", "Warning",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0) {
                String opponentID = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                String opponentStatus = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (opponentStatus == "Idle") {
                    if (e.ColumnIndex == 3)
                    {
                        SendMessage("CHALLENGE", playerIDStr + ' ' + opponentID + " BLIND");
                        lobby.Enabled = false;
                    }
                    else {
                        SendMessage("CHALLENGE", playerIDStr + ' ' + opponentID + " STRATEGIC");
                        lobby.Enabled = false;
                    }
                }
            }
        }

        private void GridClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            SendMessage("CLICK", playerIDStr + ' ' + pictureBox.TabIndex);
        }

        private void LeaveClick(object sender, EventArgs e)
        {
            lobby.Hide();
            login.Show();
            DisconnectFromSever();
        }

        private void SurrenderClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(chessBoard, "Do you readlly want to surrender ?", "Surrender comfirmation"
                 , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                SendMessage("SURRENDER", playerIDStr);
            }
        }

        private void ChessBoardClosed(object sender, EventArgs e) { 
             SendMessage("QUITGAME", playerIDStr);
            login.Close();
        }
    }
}
