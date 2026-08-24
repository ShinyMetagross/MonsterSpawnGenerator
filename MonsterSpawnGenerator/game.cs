using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterSpawnGenerator
{
    internal class Game
    {
        private string gameName = "Unknown";
        public List<AltGame> altGames = new List<AltGame>();

        public Game(string name)
        {
            this.gameName = name;
        }

        public void gameAdd(AltGame newAltGame)
        {
            altGames.Add(newAltGame);
        }

        public void gameRemove(AltGame oldAltGame)
        {
            altGames.Remove(oldAltGame);
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
