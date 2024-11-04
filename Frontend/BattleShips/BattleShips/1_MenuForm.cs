using Battleships;
using System.Net.NetworkInformation;

namespace BattleShips
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Network.namingForm == null)
            {
                NamingForm nameForm = new NamingForm();
                nameForm.Show();
                this.Hide();
            }
            else
            {
                Network.create.Show();
                this.Hide();
            }
        }

        private void BtnLuat_Click(object sender, EventArgs e)
        {
            GuideForm luatForm = new GuideForm(); 
            luatForm.Show();
            this.Hide();
        }
        
    }
}
