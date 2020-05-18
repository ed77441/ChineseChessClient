using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ChineseChessClient
{
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();
            SetButtonStyle();
            playerInfo.SelectionChanged += Datagridview_SelectionChanged;
        }

        private void SetButtonStyle() {
            DataGridViewButtonColumn c3 = (DataGridViewButtonColumn)playerInfo.Columns[3];

            c3.FlatStyle = FlatStyle.Flat;

            c3.CellTemplate.Style.ForeColor = Color.White;
            c3.CellTemplate.Style.BackColor = Color.FromArgb(64, 64, 64);
            c3.CellTemplate.Style.SelectionBackColor = Color.Yellow;

           DataGridViewButtonColumn c4 = (DataGridViewButtonColumn)playerInfo.Columns[4];

            c4.FlatStyle = FlatStyle.Flat;
            c4.CellTemplate.Style.ForeColor = Color.White;
            c4.CellTemplate.Style.BackColor = Color.FromArgb(220, 0, 0);
        }

        public DataGridView GetPlayerListView() {
            return playerInfo;
        }

        public void UpdatePlayerInfoList(string listOfInfo, string selfID) {
            Invoke((MethodInvoker)delegate
            {
                playerInfo.Rows.Clear();
                String[] rows = listOfInfo.Split(',');

                foreach (String row in rows)
                {
                    String[] cells = row.Split('.');
                    if (selfID != cells[1])
                    { /*Exclude yourself!*/
                        playerInfo.Rows.Add(cells[0], cells[1], cells[2], "Blind", "Strategic");
                    }
                }


                for (int i = 0; i < playerInfo.Rows.Count; i++)
                {
                    var row = playerInfo.Rows[i];
                    row.DefaultCellStyle.BackColor =
                        (i % 2 == 1) ? Color.FromArgb(242, 242, 242) : Color.White;

                    var c2cell = row.Cells[2];

                    switch (c2cell.Value) {
                        case "Idle":
                            c2cell.Style.ForeColor = Color.FromArgb(0, 204, 0);
                            break;
                        case "Playing":
                            c2cell.Style.ForeColor = Color.FromArgb(204, 204, 0);
                            break;
                        default:
                            c2cell.Style.ForeColor = Color.Blue;
                            break;
                    }
                }
            });
        }

        private void Datagridview_SelectionChanged(object sender, EventArgs e)
        {
            playerInfo.ClearSelection();
        }

        public void SetUserNameAndID(String name, String id) {
            Invoke((MethodInvoker)delegate
            {
                userNameLabel.Text = name;
                userIDLabel.Text = id;
            });
        }

        public Button GetLeaveButton() {
            return leaveButton;
        }
    }
}
