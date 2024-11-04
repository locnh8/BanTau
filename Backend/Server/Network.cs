using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server
{
    public class Network
    {
        private readonly int port = 8080; // Lắng nghe trên port 8080
        private TcpListener tcpListener = null;
        public bool IsListening { get; set; }

        public Network()
        {
            this.IsListening = true;
        }

        public void Run()
        {
            try
            {
                // Lắng nghe trên tất cả các địa chỉ IP và cổng 8080
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                Console.WriteLine($"Server đang lắng nghe trên cổng {port}...");

                while (IsListening)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => Listen(client))
                    {
                        IsBackground = true // Luồng client chạy nền
                    };
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server - run(): {ex.Message}");
            }
        }

        public void Listen(TcpClient client)
        {
            StreamReader sr = new StreamReader(client.GetStream());

            try
            {
                while (IsListening && client.Connected)
                {
                        string recvMsg = sr.ReadLine();

                        if (string.IsNullOrEmpty(recvMsg)) continue;

                        string[] msgPayload = recvMsg.Split('|');
                        int code = int.Parse(msgPayload[0]);

                        // Đặt tên
                        if (code == 0)
                        {
                            string userName = msgPayload[1];

                            Game.currentTCPs.Add(userName, client);
                            Game.currentUsers.Add(userName, new Player(userName));
                            sendMsg(0, userName, "1");
                        }
                        // Tạo phòng
                        else if (code == 1)
                        {
                            string playerName = msgPayload[1];
                            string Ispublic = msgPayload[2];
                            string roomID = msgPayload[3];

                        // Player left room
                        if (Game.rooms.ContainsKey(roomID) && Game.rooms[roomID].Players.ContainsKey(playerName))
                            {
                                Game.rooms[roomID].RemovePlayer(playerName);

                                if (Game.rooms[roomID].Players.Count == 0)
                                {
                                    Game.rooms.Remove(roomID);
                                    if (Ispublic == "1")
                                    {
                                        BroadcastToClient(11, roomID, "1");
                                    }
                                }
                                else
                                {
                                    sendToRoom(5, roomID, playerName);
                                    if (Ispublic == "1")
                                    {
                                        BroadcastToClient(11, roomID, "2");
                                    }
                                }
                            }

                            // Player create room
                            else if (string.IsNullOrEmpty(roomID) || !Game.rooms.ContainsKey(roomID))
                            {
                                if (string.IsNullOrEmpty(roomID))
                                {
                                    roomID = Game.RandomRoomID();
                                }

                                Room room = new Room(roomID, playerName, Ispublic);
                                Game.rooms.Add(roomID, room);
                                if (Ispublic == "1")
                                {
                                    BroadcastToClient(11, roomID, "3");
                                }
                            {

                            }
                            }

                            // Broadcast to all player in room
                            if (Game.rooms.ContainsKey(roomID))
                            {
                                foreach (string playername in Game.rooms[roomID].Players.Keys)
                                {
                                    sendToRoom(1, roomID, playername);
                                }
                            }
                        
                        }
                        // Lấy thông tin bản đồ người chơi
                        else if (code == 2)
                        {
                            string player = msgPayload[1];
                            string roomID = msgPayload[2];

                            getPlayer(player, roomID);
                            sendToRoom(2, roomID, Game.rooms[roomID].CurrentTurn);
                        }
                        // Xử lý tấn công
                        else if (code == 3)
                        {
                            string roomID = msgPayload[1].Split(':')[0];
                            string attacker = msgPayload[1].Split(':')[1];

                            var coor = msgPayload[2].Split(':');
                            int x = int.Parse(coor[0]);
                            int y = int.Parse(coor[1]);

                            int shipLength = Game.PerformAttack(x, y, roomID, attacker);
                            sendMove(3, attacker, roomID, x, y, shipLength);

                            Game.rooms[roomID].ChangePlayerTurn(attacker, shipLength);
                            sendToRoom(2, roomID, Game.rooms[roomID].CurrentTurn);

                            // one of the two players won 
                            if (Game.IsEndGame(roomID, attacker))
                            {
                                sendToRoom(7, roomID, attacker);
                            }
                        }
                        // Trạng thái người chơi trong phòng chờ
                        else if (code == 4)
                        {
                            string roomID = msgPayload[1];
                            Room room = Game.rooms[roomID];

                        sendToRoom(4, roomID);
                        }
                        // Người chơi rời phòng
                        else if (code == 5)
                        {
                            string roomID = msgPayload[1];
                            string player = msgPayload[2];

                            foreach (var user in Game.rooms[roomID].Players.Keys)
                            {
                                if (player != user)
                                {
                                    sendMsg(5, player, roomID);
                                }
                            }
                        }
                        else if (code == 6)
                        {
                            string roomID = msgPayload[1];
                            string user = msgPayload[2];

                            Room room = Game.rooms[roomID];
                            int index = room.Players.Keys.ToList().IndexOf(user);
                            room.isPlaying[index] = true;

                            if (!room.isPlaying.Contains(false))
                            {
                                sendToRoom(6, roomID);
                            }
                        }
                        else if (code == 8)
                        {
                            string roomID = msgPayload[1];
                            string player = msgPayload[2];
                            string message = player + ": " + msgPayload[3]; 
                            sendToRoom(8, roomID, message);
                        }
                        else if (code == 9)
                        {
                            string playerName = msgPayload[1];
                            string roomID = msgPayload[2];
                            if (!string.IsNullOrEmpty(roomID) && Game.rooms.ContainsKey(roomID))
                            {
                                if (!Game.rooms[roomID].isFull)
                                {
                                    Game.rooms[roomID].AddPlayer(playerName, Game.currentUsers[playerName]);
                                    BroadcastToClient(11, roomID, "4");
                                }
                                else
                                {
                                    sendMsg(1, playerName, "");
                                }
                                //Broadcast to all player in room
                                if (Game.rooms.ContainsKey(roomID))
                                {
                                    foreach (string playername in Game.rooms[roomID].Players.Keys)
                                    {
                                        sendToRoom(1, roomID, playername);
                                    }
                                }
                            }
                        }
                        else if (code == 10)
                        {
                            string playerName = msgPayload[1];
                            foreach (var room in Game.rooms.Values)
                            {
                                if (room.isPublic == "1")
                                {
                                    sendMsg(10, playerName, room.RoomID, (room.Players.Count()).ToString());
                                }
                            }
                        }
                }
            }
            catch
            {
                Console.WriteLine("Error at: Listen()");
                client.Close();
                sr.Close();
            }
            finally
            {
                // Đảm bảo tài nguyên của client được giải phóng khi kết thúc kết nối
                client.Close();
                sr.Close();
                if (Game.currentTCPs.ContainsValue(client))
                {
                    string username = Game.currentTCPs.FirstOrDefault(x => x.Value == client).Key;
                    Game.currentTCPs.Remove(username);
                    Game.currentUsers.Remove(username);
                }
            }
        }


        // Gửi tin nhắn tới một client
        private void sendMsg(int code, string player, string msg, string msg1 = "")
        {
            try
            {
                string formattedMsg = $"{code}|{player}|{msg}|{msg1}";

                if (Game.currentTCPs.ContainsKey(player))
                {
                    StreamWriter sw = new StreamWriter(Game.currentTCPs[player].GetStream()) { AutoFlush = true };
                    sw.WriteLine(formattedMsg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message to {player}: {ex.Message}");
            }
        }

        // Gửi kết quả tấn công cho cả phòng
        private void sendMove(int code, string from, string roomID, int x, int y, int length)
        {
            string formattedMsg = $"{x}:{y}:{length}";
            sendToRoom(code, $"{roomID}:{from}", formattedMsg);
        }

        // Gửi tin nhắn tới tất cả người chơi trong phòng
        private void sendToRoom(int code, string roomID_And_User, string msg = "")
        {
            string formattedMsg = $"{code}|{roomID_And_User}|{msg}";

            string roomID = roomID_And_User.Split(':')[0];

            if (Game.rooms.ContainsKey(roomID))
            {
                foreach (string playerName in Game.rooms[roomID].Players.Keys)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(Game.currentTCPs[playerName].GetStream()) { AutoFlush = true };
                        sw.WriteLine(formattedMsg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending message to {playerName} in room {roomID}: {ex.Message}");
                    }
                }
            }
        }

        private void BroadcastToClient(int code, string msg = "", string msg1 = "")
        {
            string formattedMsg = $"{code}|{msg}|{msg1}";

            foreach (var client in Game.currentTCPs)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(client.Value.GetStream()) { AutoFlush = true };
                    sw.WriteLine(formattedMsg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending message to {client.Key}: {ex.Message}");
                }
            }
        }

        private void SendPublicRoomsToClient(string player)
        {
            foreach (var room in Game.rooms.Values)
            {
                if (room.isPublic == "1")
                {
                    sendMsg(10, player, room.RoomID, (room.Players.Count()).ToString());
                }
            }
        }


        private void getPlayer(string username, string roomID)
        {
            try
            {
                // Lấy luồng mạng từ TCP Client
                NetworkStream ns = Game.currentTCPs[username].GetStream();

                // Đọc kích thước dữ liệu binary
                byte[] sizeBuffer = new byte[sizeof(int)];
                ns.Read(sizeBuffer, 0, sizeBuffer.Length);
                int dataSize = BitConverter.ToInt32(sizeBuffer, 0);

                // Đọc dữ liệu binary từ luồng
                byte[] dataBuffer = new byte[dataSize];
                ns.Read(dataBuffer, 0, dataBuffer.Length);

                // Giải mã dữ liệu binary thành `int[,]`
                using (MemoryStream ms = new MemoryStream(dataBuffer))
                {
                    using (BinaryReader reader = new BinaryReader(ms))
                    {
                        // Đọc số hàng và số cột của mảng
                        int rows = reader.ReadInt32();
                        int cols = reader.ReadInt32();

                        // Khởi tạo mảng hai chiều `playerShipSet`
                        int[,] playerShipSet = new int[rows, cols];

                        // Đọc từng phần tử của mảng
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                playerShipSet[i, j] = reader.ReadInt32();
                            }
                        }

                        // Lưu mảng vào đối tượng `Player` và `Room`
                        Player player = Game.currentUsers[username];
                        player.SetShipSet(playerShipSet);

                        Room room = Game.rooms[roomID];
                        room.AddPlayer(username, player);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting player information for {username}: {ex.Message}");
            }
        }
    }
}
