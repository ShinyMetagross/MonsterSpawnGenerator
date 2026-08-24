using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterSpawnGenerator
{
    internal class MonsterSlot
    {
        private string monsterSlotName = "Unknown";
        public List<Monster> monsters = new List<Monster>();

        public MonsterSlot(string name)
        {
            this.monsterSlotName = name;
        }

        public void renameMonster(string name)
        {
            this.monsterSlotName = name;
        }

        public void monsterAdd(Monster newMon)
        {
            monsters.Add(newMon);
        }

        public void monsterRemove(Monster oldMon)
        {
            monsters.Remove(oldMon);
        }

        public override string ToString()
        {
            return monsterSlotName;
        }
    }
}
