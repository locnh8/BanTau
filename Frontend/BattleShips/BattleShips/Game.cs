using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Battleships;

namespace BattleShips
{
    public class Game
    {
        // Ship lengths.
        public static int[] shipLengths = new int[5] { 2, 3, 3, 4, 5 };

        // [true]  my turn 
        // [false] player's turn
        public static bool isMyTurn;

        // Players
        public static Player me;
        public static Player player;

        public static int mapSize = 10;

        // True if the ship can place at cellX and cellY, else False
        // Check by first cell's location of ship
        static public bool CanThereBeShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] shipSet)
        {
            // Is the index of the most upper-left cell within the bounds.
            if (cellX < 0 || cellY < 0)
            {
                return false;
            }

            // Horizontal Ship
            if (isHorizontal)
            {
                if (cellX + shipLengths[currentShip] - 1 < mapSize)
                {
                    for (int i = cellX; i < cellX + shipLengths[currentShip]; i++)
                    {
                        if (shipSet[i, cellY] != -1)
                        {
                            // Invalid layout
                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    // Out of the bounds
                    return false;
                }
            }
            // Vertical Ship
            else
            {
                if (cellY + shipLengths[currentShip] - 1 < mapSize)
                {
                    for (int i = cellY; i < cellY + shipLengths[currentShip]; i++)
                    {
                        if (shipSet[cellX, i] != -1)
                        {
                            // Invalid layout
                            return false;
                        }
                    }
                    if (shipSet[cellX, cellY] != -1)
                    {
                        // Invalid layout
                        return false;
                    }

                    return true;
                }
                else
                {
                    // Out of the bounds
                    return false;
                }
            }
        }

        // Deploy a ship
        static public void DeployShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] shipSet)
        {
            if (isHorizontal)
            {
                for (int i = 0; i < shipLengths[currentShip]; i++)
                {
                    shipSet[cellX + i, cellY] = currentShip;
                }
            }
            else
            {
                for (int i = 0; i < shipLengths[currentShip]; i++)
                {
                    shipSet[cellX, cellY + i] = currentShip;
                }
            }

            //Console.WriteLine();
            //for (int y = 0; y < 10; y++)
            //{
            //    for (int x = 0; x < 10; x++)
            //    {
            //        if (shipSet[x, y] != -1)
            //        {
            //            Console.Write("+" + shipSet[x, y] + " ");
            //        }
            //        else
            //        {
            //            Console.Write(shipSet[x, y] + " ");
            //        }
            //    }
            //    Console.WriteLine();
            //}
        }

        public static bool CanAttackAt(int x, int y)
        {
            return !player.RevealedCells[x, y];
        }

        public static int RandomAttack()
        {
            Random random = new Random();
            return random.Next(0, 9);
        }
    }
}
