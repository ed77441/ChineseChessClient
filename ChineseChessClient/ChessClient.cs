using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ChineseChessClient
{
    public partial class ChessClient
    {
        static ChessClient() {
            Application.EnableVisualStyles() ;
            Application.SetCompatibleTextRenderingDefault(false);
        }

        private readonly Login login = new Login();
        private readonly Lobby lobby = new Lobby();
        private readonly BlindChessBoard halfChessBoard = new BlindChessBoard();
        private readonly StrategicChessBoard fullChessBoard = new StrategicChessBoard();
        private ChessView chessBoard = null;
        private String playerNameStr, playerIDStr;
        private Socket clientSocket = null;
        private readonly byte[] buffer = new byte[1024];
        private readonly CompletedMSGQueue messageQueue = new CompletedMSGQueue();

        [STAThread]
        static void Main()
        {

           ChessClient client = new ChessClient();
           client.SetUpClient();
           client.DisconnectFromSever();
        }

        private void CloseSocket() {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

        void SetUpClient() {
            login.GetConnectButton().Click += ConnectToServer;
            lobby.GetPlayerListView().CellContentClick += CellContentClick;
            lobby.GetLeaveButton().Click += LeaveClick;
            halfChessBoard.GetSurrenderButton().Click += SurrenderClick;
            fullChessBoard.GetSurrenderButton().Click += SurrenderClick;

            lobby.FormClosed += (s, args) => login.Close();
            halfChessBoard.FormClosed += ChessBoardClosed;
            fullChessBoard.FormClosed += ChessBoardClosed;



            PictureBox[] grids = halfChessBoard.GetChessBoardGrids();

            foreach (PictureBox grid in grids)
            {
                grid.MouseDown += GridClick;
            }

            grids = fullChessBoard.GetChessBoardGrids();

            foreach (PictureBox grid in grids)
            {
                grid.MouseDown += GridClick;
            }

            Application.Run(login);
        }

        private void DisconnectFromSever() {
            if (clientSocket != null &&
                clientSocket.Connected) {
                SendMessage("DISCONNECT", playerIDStr);
                CloseSocket();
            }
        }

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }

        private bool ValidateUserName(String userName) {
            return Regex.IsMatch(userName, @"^[a-zA-Z0-9]+$") && userName.Length <= 15;
        }


        void StartReceiveMessage() {
            clientSocket.BeginReceive(buffer, 0, buffer.Length,
                    SocketFlags.None, new AsyncCallback(ReceiveMessage), null);
        }

        void ReceiveMessage(IAsyncResult result) {
            try
            {
                int receiveLength = clientSocket.EndReceive(result);
                byte[] data = new byte[receiveLength];
                Array.Copy(buffer, data, receiveLength);
                String arrived = Encoding.ASCII.GetString(data);

                bool serverIsUp = true;
                messageQueue.Handle(arrived);

                while (messageQueue.Count != 0 && serverIsUp) {
                    serverIsUp = HandleServerEvent(messageQueue.Dequeue());
                }

                if (serverIsUp)
                    StartReceiveMessage();
            }
            catch (ObjectDisposedException) {/*Form closed!*/}
        }

        public void SendMessage(String type, String payload) {
            byte[] byteFormData = Encoding.ASCII.GetBytes(type + ':' + payload + '\0');
            try
            {
                clientSocket.Send(byteFormData);
            }
            catch (Exception) {
                MessageBox.Show(login, "Server is down.\nMessage cannot be sent!", "Sever Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
