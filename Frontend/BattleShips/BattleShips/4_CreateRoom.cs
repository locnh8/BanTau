using Battleships;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShips
{
    public partial class CreateRoom : Form
    {
        public CreateRoom()
        {
            InitializeComponent();
            Network.create = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Private_Public formPhong = new Private_Public();
            formPhong.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string roomID = textBox1.Text.Trim();
            Network.Instance.SendMsg(9, Game.me.cName, roomID);
        }

        public void SafeInvoke(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        // Kiểm tra nếu roomID tồn tại trong bảng DataGridView
        private bool IsRoomIDInDataGridView(string roomID)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra nếu RoomID của hàng hiện tại trùng với roomID cần tìm
                if (row.Cells[0].Value?.ToString() == roomID)
                {
                    return true;
                }
            }
            return false;
        }

        private void RemoveFromGridView(string roomID)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra nếu giá trị của cột đầu tiên (RoomID) khớp với roomID cần xóa
                if (row.Cells[0].Value?.ToString() == roomID)
                {
                    dataGridView1.Rows.Remove(row); // Xóa hàng khỏi DataGridView
                    break; // Dừng vòng lặp sau khi xóa để tránh lỗi thay đổi kích thước
                }
            }
        }

        private void UpdatePlayerCount(string roomID, string flag)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra nếu giá trị của cột đầu tiên (RoomID) khớp với roomID
                if (row.Cells[0].Value?.ToString() == roomID)
                {
                    if (flag == "1")
                    {
                        row.Cells[1].Value = "1/2";
                        DataGridViewButtonCell joinButtonCell = row.Cells[2] as DataGridViewButtonCell;
                        if (joinButtonCell != null)
                        {
                            joinButtonCell.Value = "Join";
                            joinButtonCell.ReadOnly = false; // Cho phép người dùng bấm vào nút
                        }
                    }
                    else
                    {
                        row.Cells[1].Value = "2/2";
                        DataGridViewButtonCell joinButtonCell = row.Cells[2] as DataGridViewButtonCell;
                        if (joinButtonCell != null)
                        {
                            joinButtonCell.Value = "Join";
                            joinButtonCell.ReadOnly = true; // Cho phép người dùng bấm vào nút
                        }
                    }


                    break; // Thoát vòng lặp sau khi cập nhật xong
                }
            }
        }


        private delegate void SafeUpdateGridView(string roomID, string count);
        public void UpdateGridView(string roomID ,string count)
        {
            if (this.InvokeRequired)
            {
                SafeUpdateGridView safeUpdate = new SafeUpdateGridView(UpdateGridView);
                this.Invoke(safeUpdate, new object[] { roomID,count});
            }
            else
            {
                dataGridView1.Rows.Add(roomID, $"{count}/2", "Join");
            }
        }

        private delegate void SafeUpdateGridView1(string roomID, string flag);
        public void UpdateGridView1(string roomID, string flag)
        {
            if (this.InvokeRequired)
            {
                SafeUpdateGridView1 safeUpdate1 = new SafeUpdateGridView1(UpdateGridView1);
                this.Invoke(safeUpdate1, new object[] { roomID, flag });
            }
            else
            {
                //createRoom
                if (flag == "3")
                {
                    dataGridView1.Rows.Add(roomID, "1/2", "Join");
                }
                else if (IsRoomIDInDataGridView(roomID))
                {
                    //0/2
                    if (flag == "1")
                    {
                        RemoveFromGridView(roomID);
                    //1/2
                    } else if (flag == "2")
                    {
                        UpdatePlayerCount(roomID, "1");
                    }
                    //2/2
                    else
                    {
                        UpdatePlayerCount(roomID, "2");
                    }
                }
            } 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu là ButtonColumn
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Join"].Index)
            {
                Network.Instance.SendMsg(9, Game.me.cName, (dataGridView1.Rows[e.RowIndex].Cells["RoomID"].Value).ToString());
            }
        }
    }
}
