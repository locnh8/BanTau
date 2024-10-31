using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace BattleShips
{
    [Serializable]
    public class Ship
    {
        private int cellX;
        private int cellY;

        public int Length;

        private bool isHorizontal;

        private Image horizontalImage;

        private Image verticalImage;

        public Ship(int x, int y, int l, bool _is)
        {
            this.cellX = x;
            this.cellY = y;

            this.Length = Game.shipLengths[l];
            this.isHorizontal = _is;

            if (this.isHorizontal)
            {
                this.horizontalImage = GraphicContext.shipImg[l];
            }
            else
            {
                this.verticalImage = GraphicContext.shipImg[l];
                this.verticalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        public void DrawMe(PaintEventArgs e)
        {
            if (this.isHorizontal)
            {
                e.Graphics.DrawImage(this.horizontalImage, (cellX + 1) * 33 + 1, (cellY + 1) * 33 + 1, 33 * Length, 32);
            }
            else
            {
                e.Graphics.DrawImage(this.verticalImage, (cellX + 1) * 33 + 1, (cellY + 1) * 33 + 1, 32, 33 * Length);
            }
        }
    }
}
