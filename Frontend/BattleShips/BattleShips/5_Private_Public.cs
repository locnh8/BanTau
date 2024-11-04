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
using Battleships;

namespace BattleShips
{
    public partial class Private_Public : Form
    {
        public Private_Public()
        {
            InitializeComponent();
            Network.private_public = this;
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

        // Người dùng chọn tạo phòng private
        private void button1_Click(object sender, EventArgs e)
        {

            if (Network.Instance.tcpClient != null && Network.Instance.tcpClient.Connected)
            {
                Network.Instance.SendMsg(1, Game.me.cName, "0");
            }
            else
            {
                MessageBox.Show("Connection to the server has been lost.");
            }
        }

        // Người dùng chọn tạo phòng public
        private void button2_Click(object sender, EventArgs e)
            {
            if (Network.Instance.tcpClient != null && Network.Instance.tcpClient.Connected)
            {
                Network.Instance.SendMsg(1, Game.me.cName, "1");
            }
            else
            {
                MessageBox.Show("Connection to the server has been lost.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Network.create.Show();
            this.Close();
        }
    }
}