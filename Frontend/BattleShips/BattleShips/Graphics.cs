using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public static class GraphicContext
    {
        // Correct Shot Image
        static private readonly Bitmap hitImage = new Bitmap(Properties.Resources.png_transparent_explosions_explosion_gunpowder_war_thumbnail);

        // Missed Shot Image
        static private readonly Bitmap splashImage = new Bitmap(Properties.Resources.screenshot_1653541900);

        // Targeting Image 
        static private readonly Bitmap targetImage = new Bitmap(Properties.Resources.Scope);

        public static readonly Image[] shipImg = new Image[5]
        {
            new Bitmap(Properties.Resources.Ship1_OroJackson),
            new Bitmap(Properties.Resources.Ship2_merymery),
            new Bitmap(Properties.Resources.Ship3_Roger),
            new Bitmap(Properties.Resources.Ship4_thousandSunny),
            new Bitmap(Properties.Resources.Ship5_whireBear),
        };

        // Opacity settings.
        private static int generalOpacity = 150;
        private static int spacialOpacity = 200;

        public static readonly Brush[] brushs = new SolidBrush[8]
        {
            new SolidBrush(Color.FromArgb(generalOpacity, 255, 255, 0)),   // [0] Yellow
            new SolidBrush(Color.FromArgb(generalOpacity, 255, 0, 0)),     // [1] Red
            new SolidBrush(Color.FromArgb(generalOpacity, 0, 255, 0)),     // [2] Green
            new SolidBrush(Color.FromArgb(generalOpacity, 0, 0, 255)),     // [3] Blue
            new SolidBrush(Color.FromArgb(generalOpacity, 150, 0, 200)),   // [4] Violet
            new SolidBrush(Color.FromArgb(spacialOpacity, 255, 255, 255)), // [5] White
            new SolidBrush(Color.FromArgb(spacialOpacity, 0, 255, 255)),   // [6] Azure
            new SolidBrush(Color.FromArgb(spacialOpacity, 255, 0, 140))    // [7] Magenta
        };

        public static readonly Color[] colors = new Color[8]
        {
            Color.FromArgb(generalOpacity, 255, 255, 0),   // [0] Yellow
            Color.FromArgb(generalOpacity, 255, 0, 0),     // [1] Red
            Color.FromArgb(generalOpacity, 0, 255, 0),     // [2] Green
            Color.FromArgb(generalOpacity, 0, 0, 255),     // [3] Blue
            Color.FromArgb(generalOpacity, 150, 0, 200),   // [4] Violet
            Color.FromArgb(spacialOpacity, 255, 255, 255), // [5] White
            Color.FromArgb(spacialOpacity, 0, 255, 255),   // [6] Azure
            Color.FromArgb(spacialOpacity, 255, 0, 140)    // [7] Magenta
        };

        // 0 is get corrX, 1 is get corrY
        static public int GetCoor(MouseEventArgs e, int iCase)
        {
            int coor;

            if (iCase == 0)
            {
                coor = e.X;
                return (coor < 3 || coor > 516) ? -1 : coor;
            }
            else
            {
                coor = e.Y;
                return (coor < 3 || coor > 434) ? -1 : coor;
            }

            return (coor < 34 || coor > 366) ? -1 : coor;
        }

        // return a index of current cell 
        static public int GetCell(int coor)
        {
            return (coor - 33) / 33;
        }

        // PictureBox paint event handler for drawing a sunken cell.
        static public void DrawSunkenCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brushs[color], (cellX + 1) * 33 + 1, (cellY + 1) * 33 + 1, 33, 33);
        }

        // PictureBox paint event handler for drawing a hit cell.
        static public void DrawHitCell(int cellX, int cellY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hitImage, (cellX + 1) * 33 + 1, (cellY + 1) * 33 + 1, 33, 33);
        }

        // PictureBox paint event handler for drawing a splash cell.
        static public void DrawSplashCell(int cellX, int cellY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(splashImage, (cellX + 1) * 33 + 1, (cellY + 1) * 33 + 1, 33, 33);
        }

        // PictureBox paint event handler for drawing target position.
        static public void DrawScope(int cellX, int cellY, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            g.DrawImage(targetImage, (cellX + 1) * 33, (cellY + 1) * 33, 33, 33);
        }

        // PictureBox paint event handler for drawing colored cells on a deck.
        static public void DrawColoredCell(int cellX, int cellY, int color, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            g.FillRectangle(brushs[color], (cellX + 1) * 33 + 1, (cellY + 1) * 33 + 1, 33, 33);
        }

        // PictureBox paint event handler for drawing a ship set on a deck.
      
        static public void DrawShipSet(Player player, PaintEventArgs e)
        {
            foreach (Ship ship in player.ShipSetImg)
            {
                if (ship != null)
                {
                    ship.DrawMe(e);
                }
            }
        }

        // PictureBox paint event handler for drawing a deck status of all the cells.
        static public void DrawDeckStatus(bool[,] deckStatus, int[,] shipSet, PaintEventArgs e)
        {
            for (int x = 0; x < Game.mapSize; x++)
            {
                for (int y = 0; y < Game.mapSize; y++)
                {
                    if (deckStatus[x, y])
                    {
                        if (shipSet[x, y] != -1)
                        {
                            DrawHitCell(x, y, e);
                        }
                        else
                        {
                            DrawSplashCell(x, y, e);
                        }
                    }
                }
            }
        }

        // PictureBox paint event handler for drawing sunken ships.
        static public void DrawSunkenShips(int[,] shipSet, int[] ShipLeftCells, PaintEventArgs e)
        {
            for (int currentShip = 0; currentShip < 5; currentShip++)
            {
                // Console.WriteLine($"{currentShip}:{ShipLeftCells[currentShip]}");
                if (ShipLeftCells[currentShip] == 0)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (shipSet[x, y] == currentShip)
                            {
                                DrawSunkenCell(x, y, currentShip, e);
                            }
                        }
                    }
                }
            }
        }
    }
}
