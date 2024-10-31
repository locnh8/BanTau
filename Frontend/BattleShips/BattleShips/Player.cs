using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{

    [Serializable]
    public class Player
    {
        public string cName = string.Empty;
        public string roomID = string.Empty;

        public bool isMyTurn;

        // Locations of the players' ships.
        public int[,] ShipSet { get; set; }

        public List<Ship> ShipSetImg { get; set; }

        // Revealed cells
        public bool[,] RevealedCells { get; set; }

        // Last revealed cells.
        public int[] LastRevealedCells { get; set; }

        // Ships cells left.
        public int[] ShipLeftCells { get; set; }

        // Ships left count.
        public int ShipsLeft { get; set; }

        public Player(string cName)
        {
            this.cName = cName;
            isMyTurn = false;
            ShipLeftCells = new int[] { 2, 3, 3, 4, 5 };
            ShipsLeft = 5;
            ShipSet = new int[10, 10];
            ShipSetImg = new List<Ship>();
            RevealedCells = new bool[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ShipSet[i, j] = -1;
                    RevealedCells[i, j] = false;
                }
            }

            LastRevealedCells = new int[2];
            LastRevealedCells[0] = -1;
            LastRevealedCells[1] = -1;
        }
    }
}
