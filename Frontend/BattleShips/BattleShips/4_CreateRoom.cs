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
            NamingForm nameForm = new NamingForm();
            nameForm.Show();
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
    }
}
