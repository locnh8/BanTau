namespace Server
{
    public class Room
    {
        public string RoomID { get; private set; } // ID của phòng

        public Dictionary<string, Player> Players { get; } // Thay đổi tên thành Players cho rõ ràng

        public string CurrentTurn { get; private set; } // Người chơi hiện tại

        public bool isFull { get; set; }
        
        public string isPublic { get; set; }

        public List<bool> isPlaying { get; set; }

        public Room(string id, string userName, string isPublic)
        {
            this.RoomID = id;
            this.Players = new Dictionary<string, Player>();
            Players.Add(userName, new Player(userName)); // Thêm người chơi vào phòng
            isPlaying = new List<bool> { false, false }; // Trạng thái chơi ban đầu
            CurrentTurn = userName; // Người chơi đầu tiên là người tạo phòng
            this.isPublic = isPublic;
        }

        public void AddPlayer(string playerName, Player player)
        {
            if (Players.ContainsKey(playerName))
            {
                Players[playerName] = player; // Cập nhật nếu người chơi đã tồn tại
            }
            else
            {
                Players.Add(playerName, new  Player(playerName)); // Thêm người chơi mới
            }

            if (Players.Count == 2)
            {
                isFull = true; // Phòng đã đủ người chơi
            }
        }

        public void RemovePlayer(string playerName)
        {
            if (Players.ContainsKey(playerName))
            {
                Players.Remove(playerName); // Xóa người chơi
            }
            isFull = false;
        }

        public void ChangePlayerTurn(string lastTurn, int hit)
        {
            // Nếu không có cú đánh, chuyển lượt cho người khác
            if (hit == -1)
            {
                foreach (string playerName in Players.Keys)
                {
                    if (playerName != lastTurn)
                    {
                        CurrentTurn = playerName; // Chuyển lượt cho người chơi còn lại
                    }
                }
            }
            else
            {
                // Nếu có cú đánh, giữ nguyên lượt
                CurrentTurn = lastTurn;
            }
        }
    }
}
