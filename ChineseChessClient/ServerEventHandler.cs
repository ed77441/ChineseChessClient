using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChessClient
{
    partial class ChessClient
    {
        private bool HandleServerEvent(String completedMessage) {
            int sepPos = completedMessage.IndexOf(':');
            String messageType = completedMessage.Substring(0, sepPos);
            String message = completedMessage.Substring(sepPos + 1);

            switch (messageType)
            {
                case "PLAYERID":
                    playerIDStr = message;
                    lobby.SetUserNameAndID(playerNameStr, playerIDStr);
                    break;
                case "PLAYERLIST":
                    lobby.UpdatePlayerInfoList(message, playerIDStr);
                    break;
                case "CHALLENGE":
                    HandleChallengeRequest(message);
                    break;
                case "CHALLENGEREPLY":
                    HandleChallengeReply(message);
                    break;
                case "GAMEEVENT":
                    HandleGameEvent(message);
                       break;
                case "SERVERSHUTDOWN":
                    CloseSocket();
                    BackToLogin();
                    break;
            }

            return messageType != "SERVERSHUTDOWN";
        }


        public void HandleGameEvent(String completedMessage)
        {
            int sepPos = completedMessage.IndexOf(':');
            String messageType = completedMessage.Substring(0, sepPos);
            String message = completedMessage.Substring(sepPos + 1);

            switch (messageType)
            {
                case "INITGAME":
                    OpenChessBoardView(message);
                    break;
                case "FLIP":
                    HandleChessPieceFilpEvent(message);
                    break;
                case "MOVE":
                    HandleChessPieceMoveEvent(message);
                    break;
                case "COLOR":
                    chessBoard.SetColorLabel(message);
                    break;
                case "TURN":
                    chessBoard.SetTurnLabel(message);
                    break;
                case "SELECTED":
                    chessBoard.SetSelectedPiece(message);
                    break;
                case "GAMEOVER":
                    PrintGameOverMessage(message);
                    break;
            }
        }

        /*Show messageBox based on server message and update some ui*/
        private void HandleChallengeRequest(String message)
        {
            Thread nonBlockingThread = new Thread(() => {
                lobby.Invoke((MethodInvoker)delegate
                {

                    System.Timers.Timer timer = new System.Timers.Timer(15000);
                    timer.Elapsed += (sender, args) =>
                    {
                        ClickMessageBox.ClickButtonLabeledNo("Chanllenge Request");
                    };
                    timer.Start();

                    int sepPos = message.IndexOf(' ');
                    String playerName = message.Substring(0, sepPos);
                    String gameType = message.Substring(sepPos + 1);

                    DialogResult dr = MessageBox.Show(lobby, "Do you want to challenge "
                    + playerName + " on " + gameType.ToLower() + " chess game?",
                    "Chanllenge Request", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    timer.Stop();

                    String reply = dr == DialogResult.Yes ? "YES" : "NO";
                    SendMessage("CHALLENGEREPLY", reply + ' ' + playerIDStr);
                });
            });
            nonBlockingThread.Start();
        }

        private void HandleChallengeReply(String message)
        {
            Thread nonBlockingThread = new Thread(() =>
            {
                lobby.Invoke((MethodInvoker)delegate
                {
                    lobby.Enabled = true;
                    MessageBox.Show(lobby, message, "Challenge Reply",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
            nonBlockingThread.Start();
        }

        private void OpenChessBoardView(String message)
        {
            lobby.Invoke((MethodInvoker)delegate
            {
                lobby.Hide();
                if (message == "BLIND") {
                    halfChessBoard.Show();
                    halfChessBoard.ResetChessBoardImage();
                    chessBoard = halfChessBoard;
                }
                else {
                    fullChessBoard.Show();
                    chessBoard = fullChessBoard;
                }
            });
        }

        private void BackToLogin()
        {
            if (lobby.Visible)
            {
                lobby.Invoke((MethodInvoker)delegate
                {
                    lobby.Hide();
                });
            }
            else
            {
                chessBoard.Invoke((MethodInvoker)delegate
                {
                    chessBoard.Hide();
                });
            }

            ShowLogin();
        }

        private void ShowLogin()
        {
            login.Invoke((MethodInvoker)delegate
            {
                login.Show();
                MessageBox.Show(login, "Server has been shut down!", "Sever Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void PrintGameOverMessage(String message)
        {

            Thread nonBlockingThread = new Thread(() =>
            {
                chessBoard.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(chessBoard, message, "Game Over",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chessBoard.Hide();
                    lobby.Show();
                    SendMessage("BACKTOLOBBY", playerIDStr);
                });
            });
            nonBlockingThread.Start();
        }

        private void HandleChessPieceFilpEvent(String message) {
            int sepPos = message.IndexOf(' ');
            String imageName = message.Substring(0, sepPos);
            int position = Int32.Parse(message.Substring(sepPos));
            chessBoard.FlipChessPiece(position, imageName);
        }

        private void HandleChessPieceMoveEvent(String message)
        {
            int sepPos = message.IndexOf('>');
            int srcPos = Int32.Parse(message.Substring(0, sepPos));
            int destPos = Int32.Parse(message.Substring(sepPos + 1));
            chessBoard.MoveChessPiece(srcPos, destPos);
        }
    }
}
