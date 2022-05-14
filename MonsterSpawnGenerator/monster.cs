using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterSpawnGenerator
{
    internal class monster
    {
        private string monsterName = "Unknown";
        string[] healthMod = new string[5];
        string[] speedMod = new string[5];
        string[] difficultyToken = new string[5];

        public monster(string name)
        {
            this.monsterName = name;
        }

        public override string ToString()
        {
            return monsterName;
        }

        public void setMonsterName(string name)
        {
            monsterName = name;
        }

        public void setMonsterHealthByDifficulty(string health, int index)
        {
            if (health == null) health = "0";
            healthMod[index] = health;
        }

        public string getMonsterHealthByDifficulty(int index)
        {
            return healthMod[index];
        }
    }
}
