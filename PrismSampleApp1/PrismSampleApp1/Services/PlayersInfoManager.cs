using PrismSampleApp1.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismSampleApp1.Services
{
    interface IPlayersInfoManager
    {
        void AddPlayer(Player p);
    }

    class PlayersInfoManager : IPlayersInfoManager
    {
        public List<Player> Players { get; set; }

        public void AddPlayer(Player p) { Players.Add(p); }
    }
}
