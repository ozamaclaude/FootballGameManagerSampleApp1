using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismSampleApp1.Commons
{
    public class PlayerData : Player
    {
        public PlayerData(Player p) 
        {
            PlayerName = p.PlayerName;
            Gender = p.Gender;
            Grade = p.Grade;
            Position = p.Position;
        }
        public PlayerData(PlayerData p)
        {
            PlayerName = p.PlayerName;
            Gender = p.Gender;
            Grade = p.Grade;
            Position = p.Position;
            Score = p.Score;
            IsStartingMember = p.IsStartingMember;
            ChangingTime = p.ChangingTime;
        }
        public int Score { get; set; }
        public bool IsStartingMember { get; set; }

        public string ChangingTime { get; set; }

    }
}
