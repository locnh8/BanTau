using Battleships;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BattleShips
{
    public partial class NamingForm : Form
    {
        public NamingForm()
        {
            InitializeComponent();
            Network.namingForm = this;
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form hiện tại
            MenuForm menuForm = new MenuForm(); // Tạo instance MenuForm
            menuForm.Show(); // Hiển thị form Menu
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Hãy nhập tên của bạn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Network.Instance.SendMsg(0, txtName.Text);
            }
        }

        private delegate void SafeUpdateForm(string msg, string name);
        public void UpdateForm(string msg, string name)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeUpdateForm(UpdateForm);
                this.Invoke(d, new object[] { msg, name });
            }
            else
            {
                // Phần này sẽ được thực hiện trên luồng chính
                if (msg == "1")
                {
                    // Lưu ID và tên người chơi
                    Game.me = new Player(name);

                    // Chuyển sang form CreateRoom
                    CreateRoom formTaoPhong = new CreateRoom();
                    formTaoPhong.Show(); // Hiển thị form tạo phòng
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Received an unexpected status or error.");
                }
            }
        }
    }
}
