using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterSpawnGenerator
{
    internal class monster
    {
        private string monsterName = "Unknown";
        string[] weightMod = new string[5];
        string[] healthMod = new string[5];
        string[] speedMod = new string[5];
        string[] difficultyToken = new string[5];

        public monster(string name)
        {
            this.monsterName = name;
            this.healthMod[0] = "0";
            this.healthMod[1] = "0";
            this.healthMod[2] = "0";
            this.healthMod[3] = "0";
            this.healthMod[4] = "0";
            this.speedMod[0] = "0";
            this.speedMod[1] = "0";
            this.speedMod[2] = "0";
            this.speedMod[3] = "0";
            this.speedMod[4] = "0";
            this.weightMod[0] = "0";
            this.weightMod[1] = "0";
            this.weightMod[2] = "0";
            this.weightMod[3] = "0";
            this.weightMod[4] = "0";
            this.difficultyToken[0] = "";
            this.difficultyToken[1] = "";
            this.difficultyToken[2] = "";
            this.difficultyToken[3] = "";
            this.difficultyToken[4] = "";
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

        public void setMonsterSpeedByDifficulty(string speed, int index)
        {
            if (speed == null) speed = "0";
            speedMod[index] = speed;
        }

        public string getMonsterSpeedByDifficulty(int index)
        {
            return speedMod[index];
        }

        public void setMonsterWeightByDifficulty(string weight, int index)
        {
            if (weight == null) weight = "0";
            weightMod[index] = weight;
        }

        public string getMonsterWeightByDifficulty(int index)
        {
            return weightMod[index];
        }

        public void setMonsterTokenByDifficulty(string token, int index)
        {
            if (index < 5)
            {
                if (token == string.Empty) token = "";
                difficultyToken[index] = token;
            }
        }

        public string getMonsterTokenByDifficulty(int index)
        {
            return difficultyToken[index];
        }
    }
}
