using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterSpawnGenerator
{
    internal class monsterSlot
    {
        private string monsterSlotName = "Unknown";
        public List<monster> monsters = new List<monster>();

        public monsterSlot(string name)
        {
            this.monsterSlotName = name;
        }

        public void monsterAdd(monster newMon)
        {
            monsters.Add(newMon);
        }

        public void monsterRemove(monster oldMon)
        {
            monsters.Remove(oldMon);
        }

        public override string ToString()
        {
            return monsterSlotName;
        }
    }
}
