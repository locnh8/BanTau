using BattleShips;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Battleships
{
    public class Network
    {
        private static Network instance = null;
        private static readonly object padlock = new object();

        private IPAddress host;
        private int port;
        public TcpClient tcpClient;
        private StreamWriter sw = null;

        public static NamingForm namingForm = null;
        public static RoomWaiting roomWaiting = null;
        public static PlayForm playform = null;
        public static Private_Public private_public = null;
        public static ShipDeployment DeployShip = null;
        public static CreateRoom  create= null;


        private Network()
        {
            host = IPAddress.Parse("34.132.66.108");
            port = 8080;
        }

        public static Network Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Network();
                    }
                    return instance;
                }
            }
        }

        public bool Connect()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(host, port));
                sw = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true };

                Thread listen = new Thread(Run);
                listen.Start();

                return true;
            }
            catch
            {
                MessageBox.Show("Failed to connect to the server.");
                return false;
            }
        }

        private void Run()
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (tcpClient.Connected)
                {
                    string rawMsg = sr.ReadLine();
                    if (!string.IsNullOrEmpty(rawMsg))
                    {
                        ReceiveMsg(rawMsg);
                    }
                }
            }
            catch
            {
                tcpClient.Close();
                sr.Close();
            }
        }

        private void ReceiveMsg(string rawMsg)
        {
            try
            {
                string[] msgPayload = rawMsg.Split('|');
                int code = int.Parse(msgPayload[0]);

                // Code 0: Xử lý thông tin người chơi sau khi đặt tên
                if (code == 0)
                {
                    string playerName = msgPayload[1];
                    string status = msgPayload[2];

                    if (namingForm != null)
                    {
                        namingForm.UpdateForm(status, playerName);
                    }
                }
                // Code 1: Tạo phòng or Join
                else if (code == 1)
                {
                    string roomID = msgPayload[1];
                    string otherPlayer = msgPayload[2];

                    if (otherPlayer == "")
                    {
                        MessageBox.Show("This room is currently full!", $"Cannot join to room", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    else if (otherPlayer != Game.me.cName)
                    {
                        Game.player = new Player(otherPlayer);
                        Game.player.roomID = roomID;
                        create.SafeInvoke(() =>
                        {
                            if (roomWaiting == null || roomWaiting.IsDisposed)
                            {
                                roomWaiting = new RoomWaiting(roomID);
                                roomWaiting.Show();
                            }
                            //private_public.Hide();
                            create.Hide();
                        });
                        roomWaiting.UpdateForm(1, roomID, otherPlayer);
                    }
                    else
                    {
                        create.SafeInvoke(() =>
                       {
                           if (roomWaiting == null || roomWaiting.IsDisposed)
                           {
                               roomWaiting = new RoomWaiting(roomID);
                               roomWaiting.Show();
                           }

                           if (private_public != null)
                           {
                               private_public.Hide();
                           }
                           create.Hide();
                       });
                        roomWaiting.UpdateForm(2, roomID, "");
                    }

                    /* create.SafeInvoke(() =>
                     {
                         if (roomWaiting == null || roomWaiting.IsDisposed)
                         {
                             roomWaiting = new RoomWaiting(roomID);
                             roomWaiting.Show();
                         }
                         if (private_public != null)
                         {
                             private_public.Hide();
                         }
                         create.Hide();
                     });*/
                    ////roomWaiting.UpdateForm(1, roomID, otherPlayer);
                    Game.me.roomID = roomID;
                }

                // Code 2: Thông tin lượt chơi
                else if (code == 2)
                {
                    string currentTurn = msgPayload[2];
                    if (currentTurn == Game.me.cName)
                    {
                        Game.me.isMyTurn = true;
                    }
                    else
                    {
                        Game.me.isMyTurn = false;
                    }
                }
                // Code 3: Xử lý tấn công
                else if (code == 3)
                {
                    string from = msgPayload[1].Split(':')[1];
                    var coor = msgPayload[2].Split(':');
                    int x = int.Parse(coor[0]);
                    int y = int.Parse(coor[1]);
                    int length = int.Parse(coor[2]);
                    playform.PerformAttacked(from, x, y, length);
                }
                // Code 4: Kiểm tra trạng thái người chơi trong phòng chờ
                else if (code == 4)
                {
                    string roomID = msgPayload[1];
                    //string flag = msgPayload[2];
                    /*if (flag == "1")
                    {
                        // Cả hai người chơi đã sẵn sàng, chuyển sang form đặt thuyền*/
                        MessageBox.Show("Cả phòng đã sẵn sàng. Bắt đầu đặt thuyền!");
                        create.SafeInvoke(() =>
                        {
                            if (DeployShip == null || DeployShip.IsDisposed)
                            {
                                DeployShip = new ShipDeployment();
                                DeployShip.Show();
                                roomWaiting.Hide();
                            }
                        });
                    /*}
                    else
                    {
                        MessageBox.Show("Đang chờ người chơi khác sẵn sàng...");
                    }*/
                }
                // Code 5: Người chơi rời phòng
                else if (code == 5)
                {
                    string roomID = msgPayload[1];
                    string playerName = msgPayload[2];
                    if (Game.player != null && Game.player.cName == playerName)
                    {
                        Game.player = null;
                    }
                }
                else if (code == 6)
                {
                    DeployShip.startGame(DeployShip);
                }
           }
            catch (Exception ex)
            {
                MessageBox.Show("Error receiving message: " + ex.Message);
            }
        }

        // Gửi tin nhắn tới máy chủ
        public void SendMsg(int code, string msg = "", string msg1 = "", string msg2 = "")
        {
            string formattedMsg = $"{code}|{msg}|{msg1}|{msg2}";
            if (sw != null)
            {
                sw.WriteLine(formattedMsg);
            }
        }

        // Gửi thông tin tấn công
        public void SendMove(int code, string roomID, string from, int x, int y)
        {
            string formattedMsg = $"{code}|{roomID}:{from}|{x}:{y}";
            if (sw != null)
            {
                sw.WriteLine(formattedMsg);
            }
        }

        public void SendPlayerInfo(Player player, string roomID)
        {
            // Gửi thông điệp ban đầu
            SendMsg(2, Game.me.cName, roomID);

            // Chuyển đổi `player.ShipSet` sang chuỗi JSON
            int[][] jaggedArray = ConvertToJaggedArray(player.ShipSet);
            string jsonData = JsonSerializer.Serialize(jaggedArray);

            // Chuyển chuỗi JSON thành mảng byte
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);

            // Gửi kích thước của dữ liệu JSON trước
            tcpClient.GetStream().Write(BitConverter.GetBytes(jsonBytes.Length), 0, sizeof(int));

            // Gửi dữ liệu JSON qua stream
            tcpClient.GetStream().Write(jsonBytes, 0, jsonBytes.Length);
        }

        // Phương thức chuyển đổi từ int[,] sang int[][]
        public static int[][] ConvertToJaggedArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = array[i, j];
                }
            }
            return jaggedArray;
        }
    }
}
