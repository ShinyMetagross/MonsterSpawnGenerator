using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MonsterSpawnGenerator
{

    public partial class mainWindow : Form
    {
        StringBuilder designSpec = new StringBuilder();

        public mainWindow()
        {
            InitializeComponent();
            designSpec =
                designSpec.Append("/*======================================================================================================================\n"
                + " 													Design Specs\n"
                + "o MAX_GAME_TYPES\n"
                + "	    - This corresponds to the game set, like Doom or Chex\n"
                + "o MAX_ALTS\n"
                + "	    - This corresponds to a game alt set, like Opposing Force\n"
                + "o MONSTER_SLOT\n"
                + "	    - This corresponds to the monster slot, like Zombieman. Slots are in this order:\n"
                + "										            0: 	Zombieman\n"
                + "										            1: 	Shotgunguy\n"
                + "										            2: 	Imp\n"
                + "										            3: 	Chaingunner\n"
                + "										            4: 	Demon\n"
                + "										            5: 	Spectre\n"
                + "										            6: 	Hellknight\n"
                + "										            7: 	Baron of Hell\n"
                + "										            8: 	Arachnotron\n"
                + "										            9: 	Mancubus\n"
                + "										            10: Lost Soul\n"
                + "										            11: Pain Elemental\n"
                + "										            12: Cacodemon\n"
                + "										            13: Revenant\n"
                + "										            14: Archvile\n"
                + "										            15: Cyberdemon\n"
                + "										            16: Spider Mastermind\n"
                + "										            17: Wolfenstein SS\n"
                + "										            18: Super Shotgunguy\n"
                + "										            19: Dark Imp\n"
                + "										            20: Blood Demon\n"
                + "										            21: Cacolantern\n"
                + "										            22: Abaddon\n"
                + "										            23: Hectebus\n"
                + "										            24: Belphegor\n"
                + "o MAXPERSLOT\n"
                + "     - This variable is the slot for a decision on the monster from the slot, like spawning a zombieman variant\n\n"
                + "													- Strings -\n"
                + "     o Monster name:\n"
                + "         - Name of the the monster\n"
                + "     o Token0-4:\n"
                + "         - These are inventory items that can be given to a monster for each difficulty, to alter their behavior\n\n"
                + "													- Stats -\n"
                + "     o Speed0-4:\n"
                + "         - These tokens work as a multiplier for monster speed. As such, you should never use numbers with no decimal\n"
                + "           point. Please use 2.0 instead of 2. If left alone, it will have no affect.\n"
                + "     o Health0-4:\n"
                + "         - A health multiplier. Same as speed, these are multipliers. If left alone, it will have no affect.\n"
                + "     o Weight0-4:\n"
                + "         - This is a spawn chance, which functions similarly to RandomSpawner. You can use whatever numbers you want,\n"
                + "           to define the chance of a monster spawning. The higher the weight compared to other monsters, the more likely\n"
                + "           it is to spawn, and vice versa. If left alone, will be treated as 1. If set to a negative value, however,\n"
                + "           that means the monster will not spawn at all on that difficulty.\n\n"
                + "======================================================================================================================*/\n"
                );
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void isThisNumeric(object sender, KeyPressEventArgs e)
        {
            int keyNumber;
            string keyPress = e.KeyChar.ToString();
            if (!(int.TryParse(keyPress, out keyNumber) || keyPress == "."))
            {
                MessageBox.Show("Please type a number or decimal point.");
                e.Handled = true;
            }
        }

        private void addGameDialogue(object sender, EventArgs e)
        {
            if (this.gameList.Text.Length == 0)
                MessageBox.Show("Please type a game name.");
            else if (this.gameList.FindStringExact(this.gameList.Text) >= 0)
            {
                MessageBox.Show("This item already exists.");
            }
            else
            {
                this.gameList.Items.Add(new game(this.gameList.Text));
                this.gameList.Text = null;
            }
        }

        private void removeGame(object sender, EventArgs e)
        {
            this.gameList.Items.Remove(this.gameList.SelectedItem);
        }
        
        private void changeGame(object sender, EventArgs e)
        {
            if (this.gameList.SelectedItem != null && this.gameList.SelectedItem.GetType() == typeof(game))
            {
                game thisGame = (game)this.gameList.SelectedItem;
                this.altGameList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (altGame anAltGame in thisGame.altGames)
                {
                    this.altGameList.Items.Add(anAltGame);
                }

                //Empty the field to show it's been added, and enable adding alt games
                this.altGameList.Text = null;
                this.removeAltGameButton.Enabled = true;
                this.altGameList.Enabled = true;
                this.addAltGame.Enabled = true;
                if (this.altGameList.Items.Count > 0)
                    this.altGameList.SelectedIndex = 0;

                populateMonsterList();
            }
        }

        private void moveGameUp(object sender, EventArgs e)
        {
            if (this.gameList.SelectedItem != null && this.gameList.SelectedItem.GetType() == typeof(game))
            {
                game thisGame = (game)this.gameList.SelectedItem;
                int gameIndex = this.gameList.SelectedIndex;

                if (gameIndex > 0)
                {
                    this.gameList.Items.Remove(thisGame);
                    this.gameList.Items.Insert(gameIndex - 1, thisGame);
                    this.gameList.SelectedItem = thisGame;
                }
            }
        }

        private void moveGameDown(object sender, EventArgs e)
        {
            if (this.gameList.SelectedItem != null && this.gameList.SelectedItem.GetType() == typeof(game))
            {
                game thisGame = (game)this.gameList.SelectedItem;
                int gameIndex = this.gameList.SelectedIndex;

                if (gameIndex < this.gameList.Items.Count - 1)
                {
                    this.gameList.Items.Remove(thisGame);
                    this.gameList.Items.Insert(gameIndex + 1, thisGame);
                    this.gameList.SelectedItem = thisGame;
                }
            }
        }

        private void addAltGameDialogue(object sender, EventArgs e)
        {
            if (this.altGameList.Text.Length == 0)
                MessageBox.Show("Please type an alt game name.");
            else if (this.altGameList.FindStringExact(this.altGameList.Text) >= 0)
            {
                MessageBox.Show("This item already exists.");
            }
            else
            {
                if (this.gameList.SelectedItem != null && this.gameList.SelectedItem.GetType() == typeof(game))
                {
                    game thisGame = (game)this.gameList.SelectedItem;
                    altGame newAltGame = new altGame(this.altGameList.Text);
                    generateMonsterSlots(newAltGame);

                    thisGame.gameAdd(newAltGame);

                    this.altGameList.Items.Clear();
                    foreach (altGame anAltGame in thisGame.altGames)
                    {
                        this.altGameList.Items.Add(anAltGame);
                    }

                    this.altGameList.Text = null;
                }
            }
        }

        private void removeAltGame(object sender, EventArgs e)
        {
            game thisGame = (game)this.gameList.SelectedItem;
            thisGame.altGames.Remove((altGame)this.altGameList.SelectedItem);
            this.altGameList.Items.Remove(this.altGameList.SelectedItem);
        }

        private void generateMonsterSlots(altGame thisAltGame)
        {
            this.monsterSlotList.Items.Clear();
            foreach (string str in this.monsterListItems.Items)
            {
                monsterSlot newMonsterSlot = new monsterSlot(str);
                thisAltGame.monsterSlotAdd(newMonsterSlot);
                this.monsterSlotList.Items.Add(newMonsterSlot);
            }
        }

        private void changeAltGame(object sender, EventArgs e)
        {
            if (this.altGameList.SelectedItem != null && this.altGameList.SelectedItem.GetType() == typeof(altGame))
            {
                altGame thisAltGame = (altGame)this.altGameList.SelectedItem;
                this.monsterSlotList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (monsterSlot aMonsterSlot in thisAltGame.monsterslots)
                {
                    this.monsterSlotList.Items.Add(aMonsterSlot);
                }

                //Empty the field to show it's been added, and enable adding alt games
                this.monsterSlotList.Text = null;
                this.monsterSlotList.Enabled = true;
                if (this.monsterSlotList.Items.Count > 0)
                    this.monsterSlotList.SelectedIndex = 0;

                populateMonsterList();
            }
        }

        private void changeMonsterSlot(object sender, EventArgs e)
        {
            if (this.monsterSlotList.SelectedItem != null && this.monsterSlotList.SelectedItem.GetType() == typeof(monsterSlot))
            {
                monsterSlot thisMonsterSlot = (monsterSlot)this.monsterSlotList.SelectedItem;
                this.monsterList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (monster aMonster in thisMonsterSlot.monsters)
                {
                    this.monsterList.Items.Add(aMonster);
                }

                //Empty the field to show it's been added, and enable adding alt games
                this.monsterName.Text = null;
                this.monsterName.Enabled = true;
                this.addMonster.Enabled = true;
                this.removeMonster.Enabled = true;

                if (this.monsterList.Items.Count > 0)
                    this.monsterList.SelectedIndex = 0;
            }
        }

        private void addMonsterToList(object sender, EventArgs e)
        {
            if (this.monsterName.Text.Length == 0)
                MessageBox.Show("Please type a monster name.");
            else
            {
                this.monsterList.Items.Add(new monster(this.monsterName.Text));
                if (this.monsterSlotList.SelectedItem != null && this.monsterSlotList.SelectedItem.GetType() == typeof(monsterSlot))
                {
                    monsterSlot thisMonsterSlot = (monsterSlot)this.monsterSlotList.SelectedItem;
                    thisMonsterSlot.monsterAdd(new monster(this.monsterName.Text));
                }
            }
        }

        private void removeMonsterFromList(object sender, EventArgs e)
        {
            if (this.monsterSlotList.SelectedItem != null && this.monsterSlotList.SelectedItem.GetType() == typeof(monsterSlot))
            {
                monsterSlot thisMonsterSlot = (monsterSlot)this.monsterSlotList.SelectedItem;
                thisMonsterSlot.monsterRemove((monster)this.monsterList.SelectedItem);
            }
            this.monsterList.Items.Remove(this.monsterList.SelectedItem);
        }

        private void changeMonster(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                this.health1.Text = thisMonster.getMonsterHealthByDifficulty(0);
                this.health2.Text = thisMonster.getMonsterHealthByDifficulty(1);
                this.health3.Text = thisMonster.getMonsterHealthByDifficulty(2);
                this.health4.Text = thisMonster.getMonsterHealthByDifficulty(3);
                this.health5.Text = thisMonster.getMonsterHealthByDifficulty(4);
                this.speed1.Text = thisMonster.getMonsterSpeedByDifficulty(0);
                this.speed2.Text = thisMonster.getMonsterSpeedByDifficulty(1);
                this.speed3.Text = thisMonster.getMonsterSpeedByDifficulty(2);
                this.speed4.Text = thisMonster.getMonsterSpeedByDifficulty(3);
                this.speed5.Text = thisMonster.getMonsterSpeedByDifficulty(4);
                this.weight1.Text = thisMonster.getMonsterWeightByDifficulty(0);
                this.weight2.Text = thisMonster.getMonsterWeightByDifficulty(1);
                this.weight3.Text = thisMonster.getMonsterWeightByDifficulty(2);
                this.weight4.Text = thisMonster.getMonsterWeightByDifficulty(3);
                this.weight5.Text = thisMonster.getMonsterWeightByDifficulty(4);
                this.token1.Text = thisMonster.getMonsterTokenByDifficulty(0);
                this.token2.Text = thisMonster.getMonsterTokenByDifficulty(1);
                this.token3.Text = thisMonster.getMonsterTokenByDifficulty(2);
                this.token4.Text = thisMonster.getMonsterTokenByDifficulty(3);
                this.token5.Text = thisMonster.getMonsterTokenByDifficulty(4);
            }
        }

        private void populateMonsterList()
        {
            this.monsterList.Items.Clear();
            if (this.altGameList.SelectedItem != null && this.altGameList.SelectedItem.GetType() == typeof(altGame))
            {
                if (this.monsterSlotList.SelectedItem != null && this.monsterSlotList.SelectedItem.GetType() == typeof(monsterSlot))
                {
                    monsterSlot thisMonsterSlot = (monsterSlot)this.monsterSlotList.SelectedItem;
                    foreach (monster aMonster in thisMonsterSlot.monsters)
                    {
                        this.monsterList.Items.Add(aMonster);
                    }
                }
            }
        }

        private void health1Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.health1.Text, 0);
            }
        }
        private void health2Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.health2.Text, 1);
            }
        }
        private void health3Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.health3.Text, 2);
            }
        }
        private void health4Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.health4.Text, 3);
            }
        }
        private void health5Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.health5.Text, 4);
            }
        }
        private void token1Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterTokenByDifficulty(this.token1.Text, 0);
            }
        }
        private void token2Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterTokenByDifficulty(this.token2.Text, 1);
            }
        }
        private void token3Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterTokenByDifficulty(this.token3.Text, 2);
            }
        }
        private void token4Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterTokenByDifficulty(this.token4.Text, 3);
            }
        }
        private void token5Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterTokenByDifficulty(this.token5.Text, 4);
            }
        }
        private void speed1Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.speed1.Text, 0);
            }
        }
        private void speed2Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.speed2.Text, 1);
            }
        }
        private void speed3Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.speed3.Text, 2);
            }
        }
        private void speed4Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.speed4.Text, 3);
            }
        }
        private void speed5Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.speed5.Text, 4);
            }
        }
        private void weight1Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterWeightByDifficulty(this.weight1.Text, 0);
            }
        }
        private void weight2Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterWeightByDifficulty(this.weight2.Text, 1);
            }
        }
        private void weight3Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterWeightByDifficulty(this.weight3.Text, 2);
            }
        }
        private void weight4Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterWeightByDifficulty(this.weight4.Text, 3);
            }
        }
        private void weight5Change(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterWeightByDifficulty(this.weight5.Text, 4);
            }
        }

        private void generateSpawns(object sender, EventArgs e)
        {
            string contents = assembleContents();
            var path = "Spawns.acs";
            File.WriteAllText(path, contents);
        }   

        private string assembleContents()
        {
            StringBuilder sb = new StringBuilder();
            int gameCounter = 0;
            int altGameCounter = 0;
            int slotCounter = 0;
            int monsterCounter = 0;

            sb.Append(designSpec.ToString() + "\n");
            sb.Append("str monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_STRING_ITEMS] = \n{");
            foreach(Object item in this.gameList.Items)
            {
                gameCounter++;
                if (item.GetType() == typeof(game))
                {
                    game thisGame = (game)item;
                    sb.Append("\n\t{");
                    sb.Append("//" + item.ToString());
                    altGameCounter = 0;
                    foreach (Object item2 in thisGame.altGames)
                    {
                        altGameCounter++;
                        altGame thisAltGame = (altGame)item2;
                        if (item2.GetType() == typeof(altGame))
                        {
                            sb.Append("\n\t\t{");
                            sb.Append("//" + item2.ToString());
                            slotCounter = 0;
                            foreach (Object item3 in thisAltGame.monsterslots)
                            {
                                slotCounter++;
                                monsterSlot thisMonsterSlot = (monsterSlot)item3;
                                if (item3.GetType() == typeof(monsterSlot))
                                {
                                    sb.Append("\n\t\t\t{");
                                    sb.Append("//" + item3.ToString());
                                    monsterCounter = 0;
                                    foreach (Object item4 in thisMonsterSlot.monsters)
                                    {
                                        monsterCounter++;
                                        monster thisMonster = (monster)item4;
                                        sb.Append("\n\t\t\t\t{\"" + thisMonster.ToString() + "\""
                                            + (thisMonster.getMonsterTokenByDifficulty(0) != string.Empty ? ",\"" + thisMonster.getMonsterTokenByDifficulty(0) + "\"" : thisMonster.getMonsterTokenByDifficulty(4) != string.Empty ? ",\"\"" : thisMonster.getMonsterTokenByDifficulty(3) != string.Empty ? ",\"\"" : thisMonster.getMonsterTokenByDifficulty(2) != string.Empty ? ",\"\"" : thisMonster.getMonsterTokenByDifficulty(1) != string.Empty ? ",\"\"" : "")
                                            + (thisMonster.getMonsterTokenByDifficulty(1) != string.Empty ? ",\"" + thisMonster.getMonsterTokenByDifficulty(1) + "\"" : thisMonster.getMonsterTokenByDifficulty(4) != string.Empty ? ",\"\"" : thisMonster.getMonsterTokenByDifficulty(3) != string.Empty ? ",\"\"" : thisMonster.getMonsterTokenByDifficulty(2) != string.Empty ? ",\"\"" : "")
                                            + (thisMonster.getMonsterTokenByDifficulty(2) != string.Empty ? ",\"" + thisMonster.getMonsterTokenByDifficulty(2) + "\"" : thisMonster.getMonsterTokenByDifficulty(4) != string.Empty ? ",\"\"" : thisMonster.getMonsterTokenByDifficulty(3) != string.Empty ? ",\"\"" : "")
                                            + (thisMonster.getMonsterTokenByDifficulty(3) != string.Empty ? ",\"" + thisMonster.getMonsterTokenByDifficulty(3) + "\"" : thisMonster.getMonsterTokenByDifficulty(4) != string.Empty ? ",\"\"" : "")
                                            + (thisMonster.getMonsterTokenByDifficulty(4) != string.Empty ? ",\"" + thisMonster.getMonsterTokenByDifficulty(4) + "\"": "")
                                            + "}" + (monsterCounter == thisMonsterSlot.monsters.Count ? "" : ","));
                                    }
                                    sb.Append("\n\t\t\t}" + (slotCounter == thisAltGame.monsterslots.Count ? "" : ","));
                                }
                            }
                            sb.Append("\n\t\t}" + (altGameCounter == thisGame.altGames.Count ? "" : ","));
                        }
                    }
                    sb.Append((altGameCounter > 0 ? "\n\t" : "") + "}" + (gameCounter < this.gameList.Items.Count ? "," : ""));
                }
            }
            sb.Append("\n};");
            sb.Append("\n\n");
            sb.Append("int monsterSelectStat[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_ITEMS] = \n{");
            gameCounter = 0;
            altGameCounter = 0;
            slotCounter = 0;
            monsterCounter = 0;
            foreach (Object item in this.gameList.Items)
            {
                if (item.GetType() == typeof(game))
                {
                    gameCounter++;
                    game thisGame = (game)item;
                    sb.Append("\n\t{");
                    sb.Append("//" + item.ToString());
                    altGameCounter = 0;
                    foreach (Object item2 in thisGame.altGames)
                    {
                        altGameCounter++;
                        altGame thisAltGame = (altGame)item2;
                        if (item2.GetType() == typeof(altGame))
                        {
                            sb.Append("\n\t\t{");
                            sb.Append("//" + item2.ToString());
                            slotCounter = 0;
                            foreach (Object item3 in thisAltGame.monsterslots)
                            {
                                slotCounter++;
                                monsterSlot thisMonsterSlot = (monsterSlot)item3;
                                if (item3.GetType() == typeof(monsterSlot))
                                {
                                    sb.Append("\n\t\t\t{");
                                    sb.Append("//" + item3.ToString());
                                    monsterCounter = 0;
                                    foreach (Object item4 in thisMonsterSlot.monsters)
                                    {
                                        monsterCounter++;
                                        monster thisMonster = (monster)item4;
                                        sb.Append("\n\t\t\t\t{"
                                            + thisMonster.getMonsterHealthByDifficulty(0) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(0) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(0) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(1) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(1) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(1) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(2) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(2) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(2) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(3) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(3) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(3) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(4) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(4) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(4)
                                            + "}" + (monsterCounter == thisMonsterSlot.monsters.Count ? "" : ","));
                                    }
                                    sb.Append("\n\t\t\t}" + (slotCounter == thisAltGame.monsterslots.Count ? "" : ","));
                                }
                            }
                            sb.Append("\n\t\t}" + (altGameCounter == thisGame.altGames.Count ? "" : ","));
                        }
                    }
                    sb.Append((thisGame.altGames.Count > 0 ? "\n\t" : "") + "}" + (gameCounter < this.gameList.Items.Count ? "," : ""));
                }
            }
            sb.Append("\n};");

            return sb.ToString();
        }

        private void importSpawns(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|acs files (*.acs)|*.acs";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                    if(!fileContent.Contains("str monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_STRING_ITEMS] =") || !fileContent.Contains("int monsterSelectStat[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_ITEMS] ="))
                    {
                        MessageBox.Show("This text file is invalid, please select another.");
                    }
                    else
                    {
                        this.gameList.Items.Clear();
                        dissectStrings(fileContent);
                        dissectValues(fileContent);
                        MessageBox.Show("Imported Spawns Successfully!");
                    }
                }
            }
        }

        private void dissectStrings(string file)
        {
            string virtualString = file.Replace("\t", String.Empty);

            int startPosition = virtualString.IndexOf("str monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_STRING_ITEMS] =") + "int monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_STRING_ITEMS] =".Length;
            virtualString = virtualString.Substring(startPosition);

            StringReader stringReader = new StringReader(virtualString);

            //Done twice to consume the remaining line and move onto next
            string line;
            int character;
            bool breaknext = false;
            line = stringReader.ReadLine();
            line = stringReader.ReadLine();

            if (line == "{")
            {
                while((line = stringReader.ReadLine()) != null)
                {
                    if (line.StartsWith("{//"))
                    { 
                        String gameName = line.Substring(3);
                        game thisGame;

                        if (line.EndsWith("}"))
                        {
                            gameName = line.Substring(3, gameName.Length - 1);
                            thisGame = new game(gameName);
                            this.gameList.Items.Add(thisGame);
                            continue;
                        }
                        else if (line.EndsWith("},"))
                        {
                            gameName = line.Substring(3, gameName.Length - 2);
                            thisGame = new game(gameName);
                            this.gameList.Items.Add(thisGame);
                            continue;
                        }

                        thisGame = new game(gameName);
                        this.gameList.Items.Add(thisGame);

                        while ((line = stringReader.ReadLine()) != null)
                        {
                            if (line.StartsWith("{//"))
                            {
                                String altGameName = line.Substring(3);
                                altGame thisAltGame = new altGame(altGameName);
                                thisGame.gameAdd(thisAltGame);
                                generateMonsterSlots(thisAltGame);
                                while ((line = stringReader.ReadLine()) != null)
                                {
                                    if (line.StartsWith("{//"))
                                    {
                                        String monsterSlotName = line.Substring(3);
                                        foreach (monsterSlot mSlot in thisAltGame.monsterslots)
                                        {
                                            if(mSlot.ToString() == monsterSlotName)
                                            {   
                                                while ((line = stringReader.ReadLine()) != null && line.StartsWith("{"))
                                                {
                                                    if (line.StartsWith("{"))
                                                    {
                                                        String lineFormat = line.Replace("\"", "");
                                                        lineFormat = lineFormat.Replace(" ", "");
                                                        if (line.EndsWith("}") || line.EndsWith("},"))
                                                            lineFormat = lineFormat.Substring(1);

                                                        StringReader monsterLine = new StringReader(lineFormat);
                                                        string monsterName = "";
                                                        string tokenName = "";
                                                        int tokenNumber = 0;
                                                        
                                                        while ((character = monsterLine.Read()) != -1)
                                                        {
                                                            if (character == '}')
                                                            {
                                                                if (monsterLine.Peek() != ',')
                                                                    breaknext = true;
                                                                break;
                                                            }
                                                            else if (character != ',')
                                                                monsterName += ((char)character).ToString();
                                                            else if (character == ',')
                                                                break;
                                                        }
                                                        monster newMonster = new monster(monsterName);

                                                        while ((character = monsterLine.Read()) != -1)
                                                        {
                                                            if (character == '}')
                                                            {
                                                                newMonster.setMonsterTokenByDifficulty(tokenName, tokenNumber);
                                                                tokenNumber++;
                                                                tokenName = "";
                                                                if (monsterLine.Peek() != ',')
                                                                    breaknext = true;
                                                                break;
                                                            }
                                                            else if (character == ',')
                                                            {
                                                                newMonster.setMonsterTokenByDifficulty(tokenName, tokenNumber);
                                                                tokenNumber++;
                                                                tokenName = "";
                                                            }
                                                            else if (character != ',' || character != ' ')
                                                                tokenName += ((char)character).ToString();  
                                                        }
                                                        mSlot.monsterAdd(newMonster);
                                                    }
                                                    if ((line.StartsWith("}") && !line.EndsWith(",")) || breaknext)
                                                    {
                                                        breaknext = false;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (line.StartsWith("}") && !line.EndsWith(","))
                                        break;
                                }
                            }
                            else if (line.StartsWith("}") && !line.EndsWith(","))
                                break;
                        }
                    }
                    else if (line.StartsWith("};"))
                        break;
                }
            }
        }

        private void dissectValues(string file)
        {
            int startPosition = file.IndexOf("int monsterSelectStat[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_ITEMS] =") + "int monsterSelectStat[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_ITEMS] =".Length;
            string virtualString = file.Substring(startPosition).Replace("\t","");

            StringReader stringReader = new StringReader(virtualString);

            //Done twice to consume the remaining line and move onto next
            string line;
            string monsterValue = "";
            line = stringReader.ReadLine();
            line = stringReader.ReadLine();

            int thisGame = 0;
            int thisAltGame = 0;
            int thisMonsterSlot = 0;
            int thisMonster = 0;
            int character = 0;
            int statIncrement = 0;

            if (line == "{")
            {
                while ((line = stringReader.ReadLine()) != null)
                {
                    if(line.StartsWith("{"))
                    {                       
                        if (line.EndsWith(","))
                        {
                            thisGame++;
                            continue;
                        }
                        else if (line.EndsWith("}"))
                            break;
                        else
                        {
                            game thisGameObject = (game)this.gameList.Items[thisGame];
                            thisAltGame = 0;
                            while ((line = stringReader.ReadLine()) != null)
                            {
                                if (line.StartsWith("{"))
                                {
                                    if (line.EndsWith(","))
                                    {
                                        thisAltGame++;
                                        continue;
                                    }
                                    else if (line.EndsWith("}"))
                                        break;
                                    else
                                    {
                                        altGame thisAltGameObject = (altGame)thisGameObject.altGames[thisAltGame];
                                        thisMonsterSlot = 0;
                                        while ((line = stringReader.ReadLine()) != null)
                                        {
                                            if (line.StartsWith("{"))
                                            {
                                                if (line.EndsWith(","))
                                                {
                                                    thisMonsterSlot++;
                                                    continue;
                                                }
                                                else if (line.EndsWith("}"))
                                                    break;
                                                else
                                                {
                                                    monsterSlot thisMonsterSlotObject = (monsterSlot)thisAltGameObject.monsterslots[thisMonsterSlot];
                                                    thisMonster = 0;
                                                    while ((line = stringReader.ReadLine()) != null)
                                                    {
                                                        if (line.StartsWith("{") && (line.EndsWith("}") || line.EndsWith(",")))
                                                        {
                                                            String lineFormat = line.Replace("\"", "");
                                                            lineFormat = lineFormat.Replace(" ", "");
                                                            if (line.EndsWith("}") || line.EndsWith("},"))
                                                                lineFormat = lineFormat.Substring(1);

                                                            StringReader monsterLine = new StringReader(lineFormat);

                                                            monster thisMonsterObject = (monster)thisMonsterSlotObject.monsters[thisMonster];

                                                            while ((character = monsterLine.Read()) != -1)
                                                            {
                                                                if (character == '}')
                                                                {
                                                                    switch (statIncrement % 3)
                                                                    {
                                                                        case 0:
                                                                            thisMonsterObject.setMonsterHealthByDifficulty(monsterValue, statIncrement / 3);
                                                                            break;
                                                                        case 1:
                                                                            thisMonsterObject.setMonsterSpeedByDifficulty(monsterValue, statIncrement / 3);
                                                                            break;
                                                                        case 2:
                                                                            thisMonsterObject.setMonsterWeightByDifficulty(monsterValue, statIncrement / 3);
                                                                            break;
                                                                    }
                                                                    statIncrement = 0;
                                                                    monsterValue = "";
                                                                    break;
                                                                }
                                                                else if (character == ',')
                                                                {
                                                                    switch (statIncrement%3)
                                                                    {
                                                                        case 0:
                                                                            thisMonsterObject.setMonsterHealthByDifficulty(monsterValue, statIncrement / 3);
                                                                            break;
                                                                        case 1:
                                                                            thisMonsterObject.setMonsterSpeedByDifficulty(monsterValue, statIncrement / 3);
                                                                            break;
                                                                        case 2:
                                                                            thisMonsterObject.setMonsterWeightByDifficulty(monsterValue, statIncrement / 3);
                                                                            break;
                                                                    }
                                                                    statIncrement++;
                                                                    monsterValue = "";
                                                                }
                                                                else
                                                                    monsterValue += ((char)character).ToString();
                                                            }

                                                            thisMonster++;
                                                        }
                                                        if (line.EndsWith("}"))
                                                            break;
                                                    }
                                                    thisMonsterSlot++;
                                                }
                                            }
                                            else if (line.EndsWith("}"))
                                                break;
                                        }
                                        thisAltGame++;
                                    }
                                }
                                else if (line.EndsWith("}"))
                                    break;
                            }
                            thisGame++;
                        }
                    }
                    else if (line.EndsWith("}"))
                        break;
                }
            }
        }
    }
}
