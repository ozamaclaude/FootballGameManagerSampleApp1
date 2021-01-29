using PrismSampleApp1.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        void FlushContents();

        List<Player> ReadFile();
    }

    class PlayersInfoManager : IPlayersInfoManager
    {
        public List<Player> Players { get; set; }

        public void AddPlayer(Player p) { Players.Add(p); }

        public PlayersInfoManager()
        {
            Players = new List<Player>();
        }

        public void Save()
        {
            var path = Properties.Settings.Default.PlayerFilePath;
            using (var fileStream = new StreamWriter(path, true))
            {
                Players.ForEach(x => Write(fileStream, x));
            }
        }

        public List<Player> ReadFile()
        {
            var path = Properties.Settings.Default.PlayerFilePath;
            if (File.Exists(path) == false)
            {
                Debug.WriteLine("file not found");
                return null;
            }
            var lines = File.ReadAllLines(path);

            var players = new List<Player>();

            foreach (var l in lines)
            {
                var splitted = l.Split(',');
                var cnt = splitted.Length;
                //if (splitted.Length < 3) { continue; }
                players.Add(new Player
                {
                    PlayerName = splitted[0],
                    Gender = splitted[1],
                    Grade = splitted[2],
                    Position = splitted[3]
                });
            }

            return players;
        }

        public void FlushContents()
        {
            var path = Properties.Settings.Default.PlayerFilePath;
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                // ファイルサイズを0に設定
                fileStream.SetLength(0);
            }
        }

        private void Write(StreamWriter fs, Player pl)
        {
            fs.WriteLine("{0},{1},{2},{3}", pl.PlayerName, pl.Gender, pl.Grade, pl.Position);
        }
    }
}
