using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterSpawnGenerator
{
    internal class altGame
    {
        private string altGameName = "Unknown";
        public List<monsterSlot> monsterslots = new List<monsterSlot>();

        public altGame(string name)
        {
            this.altGameName = name;
        }

        public void monsterSlotAdd(monsterSlot newMonSlot)
        {
            monsterslots.Add(newMonSlot);
        }

        public void monsterSlotRemove(monsterSlot newMonSlot)
        {
            monsterslots.Remove(newMonSlot);
        }

        public void setAltGameName(string name)
        {
            altGameName = name;
        }

        public override string ToString()
        {
            return altGameName;
        }
    }
}
