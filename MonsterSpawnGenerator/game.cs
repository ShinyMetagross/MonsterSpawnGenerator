using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterSpawnGenerator
{
    internal class game
    {
        private string gameName = "Unknown";
        public List<altGame> altGames = new List<altGame>();

        public game(string name)
        {
            this.gameName = name;
        }

        public void gameAdd(altGame newAltGame)
        {
            altGames.Add(newAltGame);
        }

        public void setGameName(string name)
        {
            gameName = name;
        }

        public override string ToString()
        {
            return gameName;
        }
    }
}
