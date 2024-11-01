using Battleships;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace BattleShips
{
    public partial class PlayForm : Form
    {
        int avtColorCounter = 0;
        bool isEndGame = false;
        int mouseCellX = -1;
        int mouseCellY = -1;
        public PlayForm()
        {
            InitializeComponent();
            CenterToScreen();
            lbMyName.Text = Game.me.cName;
            lbEnemyName.Text = Game.player.cName;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You will lose the game and return to the main menu. Are you sure?", "Surrender and Exit?", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (!isEndGame)
                {
                    // send code 7
                    Network.Instance.SendMsg(7, Game.me.roomID, Game.me.cName);
                }

                this.Hide();
                this.Dispose();

                Network.DeployShip.Dispose();
                Network.create.Show();
            }
        }

        private void pBoxDeskEnemy_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Game.me.isMyTurn)
            {
                return;
            }

            int CoorX = GraphicContext.GetCoor(e, 0);
            int CoorY = GraphicContext.GetCoor(e, 1);

            if (CoorX != -1 && CoorY != -1)
            {
                if (GraphicContext.GetCell(CoorX) != mouseCellX || GraphicContext.GetCell(CoorY) != mouseCellY)
                {
                    mouseCellX = GraphicContext.GetCell(CoorX);
                    mouseCellY = GraphicContext.GetCell(CoorY);

                    pBoxDeskEnemy.Refresh();

                    if (mouseCellX < Game.mapSize && mouseCellY < Game.mapSize && Game.CanAttackAt(mouseCellX, mouseCellY))
                    {
                        GraphicContext.DrawScope(mouseCellX, mouseCellY, pBoxDeskEnemy);
                    }
                }
            }
            else
            {
                pBoxDeskEnemy.Refresh();
            }
        }

        private void pBoxDeskEnemy_Click(object sender, EventArgs e)
        {
            if (!Game.me.isMyTurn)
            {
                return;
            }

            if (mouseCellX < Game.mapSize && mouseCellY < Game.mapSize)
            {
                if (Game.CanAttackAt(mouseCellX, mouseCellY))
                {
                    Network.Instance.SendMove(3, Game.me.roomID, Game.me.cName, mouseCellX, mouseCellY);
                    Game.me.isMyTurn = false;
                }

                pBoxDeskEnemy.Refresh();
            }
        }
        public void PerformAttacked(string attackedFrom, int x, int y, int shipSet)
        {
            if (attackedFrom == Game.me.cName)
            {
                Game.player.RevealedCells[x, y] = true;

                if (shipSet != -1)
                {
                    Game.player.ShipSet[x, y] = shipSet;
                    Game.player.ShipLeftCells[shipSet]--;
                }
            }
            else
            {
                Game.me.RevealedCells[x, y] = true;

                if (shipSet != -1)
                {
                    Game.me.ShipSet[x, y] = shipSet;
                    Game.me.ShipLeftCells[shipSet]--;
                }
            }

            UpdateDesk(pBoxDeskEnemy);
            UpdateDesk(pBoxDeskMe);
            UpdateProgress(meProgress);
            UpdateProgress(enemyprogress);
        }

        private delegate void SafeUpdateDesk(PictureBox picture);
        private void UpdateDesk(PictureBox picture)
        {
            if (picture.InvokeRequired)
            {
                var d = new SafeUpdateDesk(UpdateDesk);
                picture.Invoke(d, new object[] { picture });
            }
            else
            {
                picture.Refresh();
            }
        }
        private delegate void SafeUpdateProgress(ProgressBar pg);
        private void UpdateProgress(ProgressBar pg)
        {
            if (pg.InvokeRequired)
            {
                var d = new SafeUpdateProgress(UpdateProgress);
                pg.Invoke(d, new object[] { pg });
            }
            else
            {
                pg.Value = 0;
            }
        }

        private void pBoxDeskMe_Paint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawShipSet(Game.me, e);
            GraphicContext.DrawDeckStatus(Game.me.RevealedCells, Game.me.ShipSet, e);
        }

        private void pBoxDeskEnemy_Paint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawSunkenShips(Game.player.ShipSet, Game.player.ShipLeftCells, e);

            if (Game.player != null)
            {
                GraphicContext.DrawDeckStatus(Game.player.RevealedCells, Game.player.ShipSet, e);
            }
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
            lbMyName.Location = new Point(pBoxMe.Location.X + pBoxMe.Width + 6, pBoxMe.Location.Y + 12);
            lbEnemyName.Location = new Point(pBoxEnemy.Location.X - pBoxEnemy.Width - 6, pBoxMe.Location.Y + 12);

            afkTimer.Start();

            this.CenterToParent();
        }

        private void afkTimer_Tick(object sender, EventArgs e)
        {
            avtTimer.Start();

            if (Game.me.isMyTurn)
            {
                meProgress.Value++;

                if (meProgress.Value >= 60)
                {
                    int x = Game.RandomAttack();
                    int y = Game.RandomAttack();

                    while (!Game.CanAttackAt(x, y))
                    {
                        x = Game.RandomAttack();
                        y = Game.RandomAttack();
                    }

                    Network.Instance.SendMove(3, Game.me.roomID, Game.me.cName, x, y);
                    meProgress.Value = 0;
                }
            }
            else
            {
                if (enemyprogress.Value < 60)
                {
                    enemyprogress.Value++;
                }
            }
        }

        private void avtTimer_Tick(object sender, EventArgs e)
        {
            if (avtColorCounter < 7)
            {
                avtColorCounter++;
            }
            else
            {
                avtColorCounter = 0;
            }

            if (Game.me.isMyTurn)
            {
                pBoxEnemy.BackColor = Color.Black;
                pBoxMe.BackColor = GraphicContext.colors[avtColorCounter];
            }
            else
            {
                pBoxMe.BackColor = Color.Black;
                pBoxEnemy.BackColor = GraphicContext.colors[avtColorCounter];
            }
        }
        private delegate void SafeUpdateWinLost(string winUser, Form form);
        public void PerformWin(string winUser, Form form)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeUpdateWinLost(PerformWin);
                this.Invoke(d, new object[] { winUser, form });
            }
            else
            {
                this.afkTimer.Stop();
                this.avtTimer.Stop();

                this.pBoxDeskEnemy.Enabled = false;
                this.pBoxDeskMe.Enabled = false;

                this.meProgress.Value = 0;
                this.enemyprogress.Value = 0;

                this.winlostPBox.BringToFront();

                if (Game.me.cName == winUser)
                {
                    // im winner
                    this.winlostPBox.Image = Properties.Resources.victory;
                }
                else
                {
                    // im loser
                    this.winlostPBox.Image = Properties.Resources.defeat;
                }

                isEndGame = true;
            }
        }
    }
}
