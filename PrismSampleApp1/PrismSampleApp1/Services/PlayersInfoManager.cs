using PrismSampleApp1.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismSampleApp1.Services
{
    interface IPlayersInfoManager
    {
        void AddPlayer(Player p);
        void Save();
    }

    class PlayersInfoManager : IPlayersInfoManager
    {
        public List<Player> Players { get; set; }

        public void AddPlayer(Player p) { Players.Add(p); }

        public void Save()
        {
            var path = Properties.Settings.Default.PlayerFilePath;
            using (var fileStream = new StreamWriter(path, true))
            {
                Players.ForEach(x => Write(fileStream, x));
            }
        }
        private void Write(StreamWriter fs, Player pl)
        {
            fs.WriteLine("{0},{1},{2}", pl.PlayerName, pl.Gender, pl.Grade);
        }
    }
}
