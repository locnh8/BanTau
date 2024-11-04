using Battleships;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace BattleShips
{
    public partial class RoomWaiting : Form
    {
        private string roomId = null;
        public RoomWaiting(string roomId)
        {
            InitializeComponent();
            this.roomId = roomId;
            Network.roomWaiting = this;
            LbMe.Text = Game.me.cName; // Hiển thị tên người chơi hiện tại
            LbEnemy.Text = "Đang chờ..."; // Để trống hoặc hiển thị thông báo chờ

            // Cập nhật label Room ID
            label1.Text ="RoomID: " + roomId;

        }
        //Tin hieu roi phong
        private void btnBack_Click(object sender, EventArgs e)
        {
            Network.create.Show();
            this.Close();
            Network.Instance.SendMsg(1, Game.me.cName,"", roomId);
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (Game.me != null && Game.player != null)
            {
                Network.Instance.SendMsg(4, Game.me.roomID);
            }
            else
            {
                btnReady.Enabled = false;
                MessageBox.Show("Not enough");
            }
        }

        private delegate void SafeUpdateForm(int code, string roomID, string otherPlayer);
        public void UpdateForm(int code, string roomID, string otherPlayer)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeUpdateForm(UpdateForm);
                this.Invoke(d, new object[] { code, roomID, otherPlayer });
            }
            else
            {
                if (code == 1)
                {
                        LbEnemy.Text = Game.player.cName;
                }             
            }         
        }
        
        
        public void NotifyPlayerLeft(string roomID) 
        {

        }
    }
}
