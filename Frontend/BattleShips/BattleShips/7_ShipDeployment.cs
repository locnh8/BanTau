using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Battleships;
namespace BattleShips
{
    public partial class ShipDeployment : Form
    {
        private int mouseCellX = -1;
        private int mouseCellY = -1;
        private int currentShip = -1;
        private bool isHorizontal = true;
        public bool[] shipDeployed = new bool[5];
        public ShipDeployment()
        {
            InitializeComponent();
            CenterToParent();
            Network.DeployShip = this;
      
        }
      
        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to left?", "Left this room?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                MenuForm menuForm = new MenuForm();
                menuForm.Show();

                this.Close();
            }

        }

        private void btnReady_Click(object sender, EventArgs e)
        {
          
        }

        private void ShipDeployment_Paint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawShipSet(Game.me, e);
        }

        private void pBoxDesk_MouseMove(object sender, MouseEventArgs e)
        {
            int CoorX = GraphicContext.GetCoor(e, 0);
            int CoorY = GraphicContext.GetCoor(e, 1);

            if (currentShip != -1)
            {
                if (CoorX != -1 && CoorY != -1)
                {
                    if (GraphicContext.GetCell(CoorX) != mouseCellX || GraphicContext.GetCell(CoorY) != mouseCellY)
                    {
                        mouseCellX = GraphicContext.GetCell(CoorX);
                        mouseCellY = GraphicContext.GetCell(CoorY);

                        pBoxDesk.Refresh();

                        if (isHorizontal)
                        {
                            for (int i = mouseCellX; i < mouseCellX + Game.shipLengths[currentShip]; i++)
                            {
                                if (i <= 9 && mouseCellY <= 9)
                                {
                                    if (Game.CanThereBeShip(currentShip, mouseCellX, mouseCellY, isHorizontal, Game.me.ShipSet))
                                    {
                                        GraphicContext.DrawColoredCell(i, mouseCellY, currentShip, pBoxDesk);
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int i = mouseCellY; i < mouseCellY + Game.shipLengths[currentShip]; i++)
                            {
                                if (i <= 9 && mouseCellX <= 9)
                                {
                                    if (Game.CanThereBeShip(currentShip, mouseCellX, mouseCellY, isHorizontal, Game.me.ShipSet))
                                    {
                                        GraphicContext.DrawColoredCell(mouseCellX, i, currentShip, pBoxDesk);
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (mouseCellX != -1 || mouseCellY != -1)
                    {
                        mouseCellX = -1;
                        mouseCellY = -1;

                        pBoxDesk.Refresh();
                    }
                }
            }
        }

        private void pBoxDesk_Click(object sender, EventArgs e)
        {
            if (currentShip != -1 && mouseCellX != -1 && mouseCellY != -1)
            {
                if (Game.CanThereBeShip(currentShip, mouseCellX, mouseCellY, isHorizontal, Game.me.ShipSet))
                {
                    shipDeployed[currentShip] = true;

                    switch (currentShip)
                    {
                        case 0:
                            {
                                pBoxShip1.Enabled = false;
                                pBoxShip1.BackColor = Color.Transparent;
                                break;
                            }
                        case 1:
                            {
                                pBoxShip2.Enabled = false;
                                pBoxShip2.BackColor = Color.Transparent;
                                break;
                            }
                        case 2:
                            {
                                pBoxShip3.Enabled = false;
                                pBoxShip3.BackColor = Color.Transparent;
                                break;
                            }
                        case 3:
                            {
                                pBoxShip4.Enabled = false;
                                pBoxShip4.BackColor = Color.Transparent;
                                break;
                            }
                        case 4:
                            {
                                pBoxShip5.Enabled = false;
                                pBoxShip5.BackColor = Color.Transparent;
                                break;
                            }
                    }

                    //
                    Ship ship = new Ship(mouseCellX, mouseCellY, currentShip, isHorizontal);

                    Game.me.ShipSetImg.Add(ship);

                    Game.DeployShip(currentShip, mouseCellX, mouseCellY, isHorizontal, Game.me.ShipSet);
                    pBoxDesk.Refresh();
                    currentShip = -1;

                    // All ships are deployed
                    bool areAllShipsDeployed = true;

                    foreach (bool isDeployed in shipDeployed)
                    {
                        if (!isDeployed)
                        {
                            areAllShipsDeployed = false;
                        }
                    }

                    if (areAllShipsDeployed)
                    {
                        btnReady.Enabled = true;
                    }
                }
            }
        }

        private void btnRolate_Click(object sender, EventArgs e)
        {
            isHorizontal = !isHorizontal;
        }

        private void pBoxShip1_Click(object sender, EventArgs e)
        {
            currentShip = 0;
        }

        private void pBoxShip2_Click(object sender, EventArgs e)
        {
            currentShip = 1;
        }

        private void pBoxShip3_Click(object sender, EventArgs e)
        {
            currentShip = 2;
        }

        private void pBoxShip4_Click(object sender, EventArgs e)
        {
            currentShip = 3;
        }

        private void pBoxShip5_Click(object sender, EventArgs e)
        {
            currentShip = 4;
        }

        //public void UpdateRoomLabel(string text)
        //{
        //    roomIDLabel.Text = $"ID: {text}";
        //}
    }
}
