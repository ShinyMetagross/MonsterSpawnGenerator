using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterSpawnGenerator
{
    internal class AltGame
    {
        private string altGameName = "Unknown";
        public List<MonsterSlot> monsterslots = new List<MonsterSlot>();

        public AltGame(string name)
        {
            this.altGameName = name;
        }

        public void monsterSlotAdd(MonsterSlot newMonSlot)
        {
            monsterslots.Add(newMonSlot);
        }

        public void monsterSlotRemove(MonsterSlot newMonSlot)
        {
            monsterslots.Remove(newMonSlot);
        }

        public void setAltGameName(string name)
        {
            altGameName = name;
        }

        public MonsterSlot containsMonsterSlot(string name)
        {
            foreach(MonsterSlot monsterSlot in monsterslots)
            {
                if (monsterSlot.ToString() == name)
                    return monsterSlot;
            }
            return null;
        }

        public override string ToString()
        {
            return altGameName;
        }
    }
}
