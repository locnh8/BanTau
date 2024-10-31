using Battleships;
using Microsoft.VisualBasic.Devices;
using System.Net.Sockets;
using System.Text;

namespace BattleShips
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            bool isConnected = Battleships.Network.Instance.Connect();

            if (isConnected)
            {
                Application.Run(new MenuForm());
            }
        }
    }
}