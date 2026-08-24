using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MonsterSpawnGenerator
{

    public partial class mainWindow : Form
    {
        StringBuilder designSpec = new StringBuilder();
        readonly string[] defaultMonsters = {
            "Zombieman",
            "Shotgun Guy",
            "Imp",
            "Chaingun Guy",
            "Super Shotgun Guy",
            "Demon",
            "Dark Imp",
            "Spectre",
            "Blood Demon",
            "Lost Soul",
            "Cacodemon",
            "Revenant",
            "Cacolantern",
            "Pain Elemental",
            "Hell Knight",
            "Arachnotron",
            "Mancubus",
            "Abaddon",
            "Arch-vile",
            "Baron of Hell",
            "Hectebus",
            "Belphegor",
            "Spider Mastermind",
            "Cyberdemon",
            "Wolfenstein SS",
            "Flemoidus Commonus",
            "Flemoidus Bipedicus",
            "Armored Flemoidus Bipedicus",
            "Flemoidus Stridicus",
            "Larva",
            "Flem Mine",
            "Flemoidus Cycloptis Commonus",
            "Super Cycloptis",
            "Quadrumpus",
            "Flemoidus Maximus",
            "Flembrane",
            "Flembomination",
            "Snotfolus",
            "Gargoyle",
            "Fire Gargoyle",
            "Golem",
            "Golem Ghost",
            "Nitrogolem",
            "Nitrogolem Ghost",
            "Disciple of D'Sparil",
            "Undead Warrior",
            "Undead Warrior Ghost",
            "Sabreclaw",
            "Ophidian",
            "Weredragon",
            "Iron Lich",
            "Maulotaur",
            "D'Sparil",
            "Chicken",
            "Ettin",
            "Afrit",
            "Dark Bishop",
            "Centaur",
            "Slaughtaur",
            "Green Chaos Serpent",
            "Stalker",
            "Stalker Boss",
            "Wendigo",
            "Reiver",
            "Reiver (Buried)",
            "Brown Chaos Serpent",
            "Traductus",
            "Zedek",
            "Menelkir",
            "Death Wyvern",
            "Heresiarch",
            "Korax",
            "Pig",
            "Stalker (Strife)",
            "Sentinel",
            "Reaver",
            "Crusader",
            "Inquisitor",
            "Ghoul",
            "Banshee",
            "Shocktrooper",
            "Mindweaver",
            "Vassago",
            "Tyrant"
        };

        public mainWindow()
        {
            InitializeComponent();
            designSpec = designSpec.Append("");
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }

        private void handleKeyPressError(KeyPressEventArgs e, string message)
        {
            MessageBox.Show(message);
            e.Handled = true;
        }

        private void isThisNumeric(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Contains("-") && !textBox.SelectedText.Contains("-") &&
                (textBox.SelectionStart == 0 || (e.KeyChar == '-' && textBox.SelectionStart > 0)))
            {
                handleKeyPressError(e, "Only 1 negative sign allowed at start.");
            }
            if (!char.IsControl(e.KeyChar) && !int.TryParse(e.KeyChar.ToString(), out _) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                handleKeyPressError(e, "Only numbers, negative signs, and decimal points allowed.");
            }
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                handleKeyPressError(e, "Only 1 decimal point allowed.");
            }
        }

        private bool isListItemSelected(object selectedItem, Type itemType)
        {
            return selectedItem != null && selectedItem.GetType() == itemType;
        }

        private void addGameDialogue(object sender, EventArgs e)
        {
            if (gameList.Text.Length == 0)
                MessageBox.Show("Please type a game name.");
            else if (gameList.FindStringExact(gameList.Text) >= 0)
            {
                MessageBox.Show("This item already exists.");
            }
            else
            {
                gameList.Items.Add(new Game(gameList.Text));
                gameList.Text = null;
            }
        }

        private void removeGame(object sender, EventArgs e)
        {
            gameList.Items.Remove(gameList.SelectedItem);
        }
        
        private void changeGame(object sender, EventArgs e)
        {
            if (isListItemSelected(gameList.SelectedItem, typeof(Game)))
            {
                Game thisGame = (Game)gameList.SelectedItem;
                altGameList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (AltGame anAltGame in thisGame.altGames)
                {
                    altGameList.Items.Add(anAltGame);
                }

                //Empty the field to show it's been added, and enable adding alt games
                altGameList.Text = null;
                removeAltGameButton.Enabled = true;
                altGameList.Enabled = true;
                addAltGame.Enabled = true;
                if (altGameList.Items.Count > 0)
                    altGameList.SelectedIndex = 0;

                populateMonsterList();
            }
        }

        private void moveGameUp(object sender, EventArgs e)
        {
            if (isListItemSelected(gameList.SelectedItem, typeof(Game)))
            {
                Game thisGame = (Game)gameList.SelectedItem;
                int gameIndex = gameList.SelectedIndex;

                if (gameIndex > 0)
                {
                    gameList.Items.Remove(thisGame);
                    gameList.Items.Insert(gameIndex - 1, thisGame);
                    gameList.SelectedItem = thisGame;
                }
            }
        }

        private void moveGameDown(object sender, EventArgs e)
        {
            if (isListItemSelected(gameList.SelectedItem, typeof(Game)))
            {
                Game thisGame = (Game)gameList.SelectedItem;
                int gameIndex = gameList.SelectedIndex;

                if (gameIndex < gameList.Items.Count - 1)
                {
                    gameList.Items.Remove(thisGame);
                    gameList.Items.Insert(gameIndex + 1, thisGame);
                    gameList.SelectedItem = thisGame;
                }
            }
        }

        private void addAltGameDialogue(object sender, EventArgs e)
        {
            if (altGameList.Text.Length == 0)
                MessageBox.Show("Please type an alt game name.");
            else if (altGameList.FindStringExact(altGameList.Text) >= 0)
            {
                MessageBox.Show("This item already exists.");
            }
            else
            {
                if (isListItemSelected(gameList.SelectedItem, typeof(Game)))
                {
                    Game thisGame = (Game)gameList.SelectedItem;
                    AltGame newAltGame = new AltGame(altGameList.Text);
                    generateMonsterSlots(newAltGame);

                    thisGame.gameAdd(newAltGame);

                    altGameList.Items.Clear();
                    foreach (AltGame anAltGame in thisGame.altGames)
                    {
                        altGameList.Items.Add(anAltGame);
                    }

                    altGameList.Text = null;
                }
            }
        }

        private void removeAltGame(object sender, EventArgs e)
        {
            Game thisGame = (Game)gameList.SelectedItem;
            thisGame.altGames.Remove((AltGame)altGameList.SelectedItem);
            altGameList.Items.Remove(altGameList.SelectedItem);
        }

        private void generateMonsterSlots(AltGame thisAltGame)
        {
            monsterSlotList.Items.Clear();
            foreach (MonsterSlot mSlot in globalSlotListView.Items)
            {
                thisAltGame.monsterSlotAdd(mSlot);
                monsterSlotList.Items.Add(mSlot);
            }
        }

        private void changeAltGame(object sender, EventArgs e)
        {
            if (isListItemSelected(altGameList.SelectedItem, typeof(AltGame)))
            {
                AltGame thisAltGame = (AltGame)altGameList.SelectedItem;
                monsterSlotList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (MonsterSlot aMonsterSlot in thisAltGame.monsterslots)
                {
                    monsterSlotList.Items.Add(aMonsterSlot);
                }

                //Empty the field to show it's been added, and enable adding alt games
                monsterSlotList.Text = null;
                monsterSlotList.Enabled = true;
                if (monsterSlotList.Items.Count > 0)
                    monsterSlotList.SelectedIndex = 0;

                populateMonsterList();
            }
        }

        private void changeMonsterSlot(object sender, EventArgs e)
        {
            if (isListItemSelected(monsterSlotList.SelectedItem, typeof(MonsterSlot)))
            {
                MonsterSlot thisMonsterSlot = (MonsterSlot)monsterSlotList.SelectedItem;
                monsterList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (Monster aMonster in thisMonsterSlot.monsters)
                {
                    monsterList.Items.Add(aMonster);
                }

                //Empty the field to show it's been added, and enable adding alt games
                monsterName.Text = null;
                monsterName.Enabled = true;
                addMonster.Enabled = true;
                removeMonster.Enabled = true;

                if (monsterList.Items.Count > 0)
                    monsterList.SelectedIndex = 0;
            }
        }

        private void addMonsterToList(object sender, EventArgs e)
        {
            if (monsterName.Text.Length == 0)
                MessageBox.Show("Please type a monster name.");
            else
            {
                Monster newMonster = new Monster(monsterName.Text);
                monsterList.Items.Add(newMonster);

                if (isListItemSelected(monsterSlotList.SelectedItem, typeof(MonsterSlot)))
                {
                    MonsterSlot thisMonsterSlot = (MonsterSlot)monsterSlotList.SelectedItem;
                    thisMonsterSlot.monsterAdd(newMonster);
                }
            }
        }

        private void removeMonsterFromList(object sender, EventArgs e)
        {
            if (isListItemSelected(monsterSlotList.SelectedItem, typeof(MonsterSlot)))
            {
                MonsterSlot thisMonsterSlot = (MonsterSlot)monsterSlotList.SelectedItem;
                thisMonsterSlot.monsterRemove((Monster)monsterList.SelectedItem);
            }
            monsterList.Items.Remove(monsterList.SelectedItem);
        }

        private void changeMonster(object sender, EventArgs e)
        {
            if (isListItemSelected(monsterList.SelectedItem, typeof(Monster)))
            {
                Monster thisMonster = (Monster)monsterList.SelectedItem;
                health1.Text = thisMonster.getMonsterHealthByDifficulty(0);
                health2.Text = thisMonster.getMonsterHealthByDifficulty(1);
                health3.Text = thisMonster.getMonsterHealthByDifficulty(2);
                health4.Text = thisMonster.getMonsterHealthByDifficulty(3);
                health5.Text = thisMonster.getMonsterHealthByDifficulty(4);
                speed1.Text = thisMonster.getMonsterSpeedByDifficulty(0);
                speed2.Text = thisMonster.getMonsterSpeedByDifficulty(1);
                speed3.Text = thisMonster.getMonsterSpeedByDifficulty(2);
                speed4.Text = thisMonster.getMonsterSpeedByDifficulty(3);
                speed5.Text = thisMonster.getMonsterSpeedByDifficulty(4);
                weight1.Text = thisMonster.getMonsterWeightByDifficulty(0);
                weight2.Text = thisMonster.getMonsterWeightByDifficulty(1);
                weight3.Text = thisMonster.getMonsterWeightByDifficulty(2);
                weight4.Text = thisMonster.getMonsterWeightByDifficulty(3);
                weight5.Text = thisMonster.getMonsterWeightByDifficulty(4);
                token1.Text = thisMonster.getMonsterTokenByDifficulty(0);
                token2.Text = thisMonster.getMonsterTokenByDifficulty(1);
                token3.Text = thisMonster.getMonsterTokenByDifficulty(2);
                token4.Text = thisMonster.getMonsterTokenByDifficulty(3);
                token5.Text = thisMonster.getMonsterTokenByDifficulty(4);
            }
        }

        private void populateMonsterList()
        {
            monsterList.Items.Clear();
            if (isListItemSelected(altGameList.SelectedItem, typeof(AltGame)))
            {
                if (isListItemSelected(monsterSlotList.SelectedItem, typeof(MonsterSlot)))
                {
                    MonsterSlot thisMonsterSlot = (MonsterSlot)monsterSlotList.SelectedItem;

                    foreach (Monster aMonster in thisMonsterSlot.monsters)
                    {
                        monsterList.Items.Add(aMonster);
                    }
                }
            }
        }

        private void setMonsterStat(object sender, Action<Monster, string> changeFunc)
        {
            if (isListItemSelected(monsterList.SelectedItem, typeof(Monster)))
            {
                Monster selectedMonster = (Monster) monsterList.SelectedItem;
                TextBox input = (TextBox) sender;

                changeFunc(selectedMonster, input.Text);
            }
        }

        private void health1Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 0));
        }
        private void health2Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 1));
        }
        private void health3Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 2));
        }
        private void health4Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 3));
        }
        private void health5Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 4));
        }
        private void token1Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 0));
        }
        private void token2Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 1));
        }
        private void token3Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 2));
        }
        private void token4Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 3));
        }
        private void token5Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 4));
        }
        private void speed1Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 0));
        }
        private void speed2Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 1));
        }
        private void speed3Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 2));
        }
        private void speed4Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 3));
        }
        private void speed5Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 4));
        }
        private void weight1Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 0));
        }
        private void weight2Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 1));
        }
        private void weight3Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 2));
        }
        private void weight4Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 3));
        }
        private void weight5Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (Monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 4));
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
            foreach(Object item in gameList.Items)
            {
                gameCounter++;
                if (item.GetType() == typeof(Game))
                {
                    Game thisGame = (Game)item;
                    sb.Append("\n\t{");
                    sb.Append("//" + item.ToString());
                    altGameCounter = 0;
                    foreach (Object item2 in thisGame.altGames)
                    {
                        altGameCounter++;
                        AltGame thisAltGame = (AltGame)item2;
                        if (item2.GetType() == typeof(AltGame))
                        {
                            sb.Append("\n\t\t{");
                            sb.Append("//" + item2.ToString());
                            slotCounter = 0;
                            foreach (Object item3 in thisAltGame.monsterslots)
                            {
                                slotCounter++;
                                MonsterSlot thisMonsterSlot = (MonsterSlot)item3;
                                if (item3.GetType() == typeof(MonsterSlot))
                                {
                                    sb.Append("\n\t\t\t{");
                                    sb.Append("//" + item3.ToString());
                                    monsterCounter = 0;
                                    foreach (Object item4 in thisMonsterSlot.monsters)
                                    {
                                        monsterCounter++;
                                        Monster thisMonster = (Monster)item4;
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
                    sb.Append((altGameCounter > 0 ? "\n\t" : "\n\t") + "}" + (gameCounter < gameList.Items.Count ? "," : ""));
                }
            }
            sb.Append("\n};");
            sb.Append("\n\n");
            sb.Append("int monsterSelectStat[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_ITEMS] = \n{");
            gameCounter = 0;
            altGameCounter = 0;
            slotCounter = 0;
            monsterCounter = 0;
            foreach (Object item in gameList.Items)
            {
                if (item.GetType() == typeof(Game))
                {
                    gameCounter++;
                    Game thisGame = (Game)item;
                    sb.Append("\n\t{");
                    sb.Append("//" + item.ToString());
                    altGameCounter = 0;
                    foreach (Object item2 in thisGame.altGames)
                    {
                        altGameCounter++;
                        AltGame thisAltGame = (AltGame)item2;
                        if (item2.GetType() == typeof(AltGame))
                        {
                            sb.Append("\n\t\t{");
                            sb.Append("//" + item2.ToString());
                            slotCounter = 0;
                            foreach (Object item3 in thisAltGame.monsterslots)
                            {
                                slotCounter++;
                                MonsterSlot thisMonsterSlot = (MonsterSlot)item3;
                                if (item3.GetType() == typeof(MonsterSlot))
                                {
                                    sb.Append("\n\t\t\t{");
                                    sb.Append("//" + item3.ToString());
                                    monsterCounter = 0;
                                    foreach (Object item4 in thisMonsterSlot.monsters)
                                    {
                                        monsterCounter++;
                                        Monster thisMonster = (Monster)item4;
                                        sb.Append("\n\t\t\t\t{"
                                            + thisMonster.getMonsterSpeedByDifficulty(0) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(0) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(0) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(1) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(1) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(1) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(2) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(2) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(2) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(3) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(3) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(3) + ","
                                            + thisMonster.getMonsterSpeedByDifficulty(4) + ","
                                            + thisMonster.getMonsterHealthByDifficulty(4) + ","
                                            + thisMonster.getMonsterWeightByDifficulty(4)
                                            + "}" + (monsterCounter == thisMonsterSlot.monsters.Count ? "" : ","));
                                    }
                                    sb.Append("\n\t\t\t}" + (slotCounter == thisAltGame.monsterslots.Count ? "" : ","));
                                }
                            }
                            sb.Append("\n\t\t}" + (altGameCounter == thisGame.altGames.Count ? "" : ","));
                        }
                    }
                    sb.Append("\n\t}" + (gameCounter < gameList.Items.Count ? "," : ""));
                }
            }
            sb.Append("\n};");

            MessageBox.Show("Spawns successfully generated!");

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
                    string line = string.Empty;
                    gameList.Items.Clear();

                    bool stopSpec = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //If the spec has not stopped, keep appending the spec
                        if(!stopSpec)
                            designSpec = designSpec.AppendLine(line);
                        //Use this boolean to stop creating the spec
                        if (line.Contains("*/"))
                            stopSpec = true;

                        //Check if it's time to get strings
                        if(line == "str monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_STRING_ITEMS] = ")
                            dissectStrings(reader);

                        if (line == "int monsterSelectStat[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_ITEMS] = ")
                            dissectValues(reader);
                    }

                    gameList.SelectedIndex = 0;
                    bool drawnGlobalList = false;
                    foreach (Game game in gameList.Items)
                    {
                        foreach (AltGame altGame in game.altGames)
                        {
                            AltGame sortedAltGame = new AltGame(altGame.ToString());
                            for (int i = 0; i < defaultMonsters.Length; i++)
                            {
                                MonsterSlot newMonster = altGame.containsMonsterSlot(defaultMonsters[i]);
                                if (newMonster != null)
                                    sortedAltGame.monsterSlotAdd(altGame.containsMonsterSlot(defaultMonsters[i]));
                            }
                            altGame.monsterslots = sortedAltGame.monsterslots;
                            if (drawnGlobalList == false)
                            {
                                globalSlotListView.Items.Clear();
                                foreach (MonsterSlot monSlot in altGame.monsterslots)
                                {
                                    globalSlotListView.Items.Add(monSlot.ToString());
                                }
                                drawnGlobalList = true;
                            }
                        }
                    }
                    MessageBox.Show("Imported Spawns Successfully!");
                }
            }
        }

        /// <summary>
        /// Method that initializes nested reader for values
        /// </summary>
        /// <param name="reader"></param>
        private void dissectStrings(StreamReader reader, string line = "")
        {
            //Trim the line, as you keep going. We will nest functionality to read the strings
            while ((line = reader.ReadLine()) != null)
            {
                //Trim here
                line = line.Trim();

                //Check for game name
                if (line.StartsWith("{//"))
                    //Dissect the next sub-block, taking the name of the game, here
                    dissectStrings_Game(reader, line.Substring(3, line.Length - 3));
                else if (line.StartsWith("};"))
                    break;
            }
        }

        /// <summary>
        /// Method to attach game to the list as well as scan the current sub-block
        /// </summary>
        /// <param name="reader"></param>
        private void dissectStrings_Game(StreamReader reader, string gameName, string line = "")
        {
            //Get the name of the game
            Game newGame = new Game(gameName);
            while ((line = reader.ReadLine()) != null)
            {
                //Trim here
                line = line.Trim();

                //Check for alt game name
                if (line.StartsWith("{//"))
                {
                    //Do not add the alt game if it is null
                    AltGame newAltGame = dissectStrings_AltGame(reader, line.Substring(3, line.Length - 3));
                    if (newAltGame != null) newGame.altGames.Add(newAltGame);
                }
                else if (line.StartsWith("}")) break;
            }
            gameList.Items.Add(newGame);
        }

        /// <summary>
        /// Read the alt-game sub-block here
        /// </summary>
        /// <param name="reader"></param>
        private AltGame dissectStrings_AltGame(StreamReader reader, string altGameName, string line = "")
        {
            //Get the name of the alt game
            AltGame altGame = new AltGame(altGameName);
            while ((line = reader.ReadLine().Trim()) != null)
            {
                //Trim here
                line = line.Trim();

                try
                {
                    //Check for an alt game
                    if (line.StartsWith("{//"))
                    {
                        //Do not add the monster slot if it is null
                        MonsterSlot newSlot = dissectStrings_Slot(reader, line.Substring(3, line.Length - 3));
                        if(newSlot != null) altGame.monsterSlotAdd(newSlot);
                    }
                    else if (line.StartsWith("}")) break;
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return altGame;
        }

        /// <summary>
        /// Read the sub-block for the monster slot
        /// </summary>
        /// <param name="reader"></param>
        private MonsterSlot dissectStrings_Slot(StreamReader reader, string slotName, string line = "")
        {
            //If this slot doesn't exist in the master list, do not add this. You will break everything!
            if (!defaultMonsters.Contains(slotName)) return null;
            MonsterSlot slot = new MonsterSlot(slotName);
            while ((line = reader.ReadLine()) != null)
            {
                //Trim here
                line = line.Trim();

                if (line.StartsWith("{\""))
                {
                    //Get the string not including the first bit, so it's easier to extract everything before the next quote
                    line = line.Substring(2);
                    Monster monster = new Monster(line.Substring(0, line.IndexOf("\"")));

                    //Extract tokens here. Remove quotes then split the list by a delimiter
                    if (line.IndexOf(",\"") >= 0)
                    {
                        string dissection = line.Replace("\"", "");
                        dissection = dissection.Substring(dissection.IndexOf(",")+1);
                        dissection = dissection.Substring(0, dissection.LastIndexOf("}"));
                        List<string> tokens = dissection.Split(',').ToList();
                        for (int i = 0; i < tokens.Count; i++)
                            monster.setMonsterTokenByDifficulty(tokens[i], i);
                    }

                    if (monster != null) slot.monsters.Add(monster);
                }
                //This means you will find no more monsters afterward
                if (line.StartsWith("}")) break;

            }
            return slot;
        }

        /// <summary>
        /// This method dissects values from a monster, at a different point in the source file
        /// </summary>
        /// <param name="reader"></param>
        private void dissectValues(StreamReader reader, string line = "")
        {
            //Trim the line, as you keep going. We will nest functionality to read the strings
            while ((line = reader.ReadLine()) != null)
            {
                //Trim here
                line = line.Trim();

                //Check for game name
                if (line.StartsWith("{//"))
                {
                    //Get the game name, here, and attempt look up
                    string gameName = line.Substring(3, line.Length - 3);
                    Game game = gameList.Items.Cast<Game>().FirstOrDefault(item => item.ToString() == gameName);

                    //Perform the dissection if it returns a game
                    if (game != null) dissectValues_Game(reader, game);
                }
                else if (line.StartsWith("};"))
                    break;
            }
        }

        /// <summary>
        /// Method to attach game to the list as well as scan the current sub-block
        /// </summary>
        /// <param name="reader"></param>
        private void dissectValues_Game(StreamReader reader, Game currentGame, string line = "")
        {
            while ((line = reader.ReadLine()) != null)
            {
                //Trim here
                line = line.Trim();

                //Check for alt game name
                if (line.StartsWith("{//"))
                {
                    //Get the alt game name, here, and attempt look up
                    string altGameName = line.Substring(3, line.Length - 3);
                    AltGame altGame = currentGame.altGames.Cast<AltGame>().FirstOrDefault(item => item.ToString() == altGameName);

                    //Perform the dissection if it returns an alt game
                    if (altGame != null) dissectValues_AltGame(reader, altGame);
                }
                else if (line.StartsWith("}")) break;
            }
        }

        /// <summary>
        /// Read the alt-game sub-block here
        /// </summary>
        /// <param name="reader"></param>
        private void dissectValues_AltGame(StreamReader reader, AltGame altGame, string line = "")
        {
            while ((line = reader.ReadLine().Trim()) != null)
            {
                //Trim here
                line = line.Trim();

                try
                {
                    //Check for an alt game
                    if (line.StartsWith("{//"))
                    {
                        //Get the alt game name, here, and attempt look up
                        string slotName = line.Substring(3, line.Length - 3);
                        MonsterSlot monsterSlot = altGame.monsterslots.Cast<MonsterSlot>().FirstOrDefault(item => item.ToString() == slotName);

                        //Perform the dissection if it returns an alt game
                        if (monsterSlot != null) dissectValues_Slot(reader, monsterSlot);
                    }
                    else if (line.StartsWith("}")) break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Read the sub-block for the monster slot
        /// </summary>
        /// <param name="reader"></param>
        private void dissectValues_Slot(StreamReader reader, MonsterSlot slot, string line = "")
        {
            int monsterIndex = 0;
            while ((line = reader.ReadLine()) != null)
            {
                //Trim here
                line = line.Trim();

                if (line.StartsWith("{") && line.Length > 3 && monsterIndex < slot.monsters.Count)
                {
                    //Validate this is an actual entry
                    bool validLine = line.LastIndexOf("}") >= 0;
                    if (validLine)
                    {
                        //Populate values
                        string dissection = line.Substring(1, line.LastIndexOf("}") - 1);

                        List<string> tokens = dissection.Split(',').ToList();
                        if (slot.monsters[monsterIndex].ToString() == "Cultist")
                            Console.WriteLine(tokens.Count);
                        for (int i = 0; i < tokens.Count / 3; i++)
                        {
                            slot.monsters[monsterIndex].setMonsterSpeedByDifficulty(tokens[i * 3], i);
                            slot.monsters[monsterIndex].setMonsterHealthByDifficulty(tokens[i*3 + 1], i);
                            slot.monsters[monsterIndex].setMonsterWeightByDifficulty(tokens[i*3 + 2], i);
                        }
                        monsterIndex++;
                    }
                }
                //This means you will find no more monsters afterward
                else if (line.StartsWith("}")) break;

            }
        }

        private void addGlobalMonsterSlot(object sender, EventArgs e)
        {
            MonsterSlot newMonsterSlot = new MonsterSlot(globalSlotBox.Text);
            globalSlotListView.Items.Add(newMonsterSlot);
            foreach(Game game in gameList.Items)
            {
                foreach (AltGame altGame in game.altGames)
                {
                    altGame.monsterSlotAdd(newMonsterSlot);
                    monsterSlotList.Items.Add(newMonsterSlot);
                }
            }
        }

        private void removeGlobalMonsterSlot(object sender, EventArgs e)
        {
            if (globalSlotListView.SelectedItem != null)
            {
                foreach (Game game in gameList.Items)
                {
                    foreach (AltGame altGame in game.altGames)
                    {
                        MonsterSlot removalMonsterSlot = new MonsterSlot("null");
                        foreach (MonsterSlot monsterSlot in altGame.monsterslots)
                        {
                            if (globalSlotListView.SelectedItem.ToString() == monsterSlot.ToString())
                            {
                                removalMonsterSlot = monsterSlot;
                                monsterSlotList.Items.Remove(monsterSlot);
                            }
                        }
                        altGame.monsterSlotRemove(removalMonsterSlot);
                    }
                }
            }

            globalSlotListView.Items.Remove(globalSlotListView.SelectedItem);
        }

        private void copyMonsterSlot(object sender, EventArgs e)
        {
            bool cloned = false;
            if (globalSlotListView.SelectedItem == null)
            {
                MessageBox.Show("You need to select a monster to copy one.");
            }
            else
            {
                MonsterSlot newMonsterSlot = new MonsterSlot(globalSlotListView.SelectedItem.ToString());
                newMonsterSlot.renameMonster(globalSlotBox.Text);
                globalSlotListView.Items.Add(newMonsterSlot);

                foreach (Game game in gameList.Items)
                {
                    foreach (AltGame altGame in game.altGames)
                    {
                        foreach (MonsterSlot monsterSlot in altGame.monsterslots)
                        {
                            if (monsterSlot.ToString() == globalSlotListView.SelectedItem.ToString())
                            {
                                MonsterSlot copiedMonsterSlot = new MonsterSlot(monsterSlot.ToString());
                                foreach (Monster monster in monsterSlot.monsters)
                                {
                                    copiedMonsterSlot.monsterAdd(monster);
                                }
                                copiedMonsterSlot.renameMonster(newMonsterSlot.ToString());
                                altGame.monsterSlotAdd(copiedMonsterSlot);
                                if(!cloned) monsterSlotList.Items.Add(copiedMonsterSlot);
                                cloned = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void doGenerateSlots(object sender, EventArgs e)
        {
            globalSlotListView.Items.Clear();
            foreach (string monsterName in defaultMonsters)
            {
                globalSlotListView.Items.Add(new MonsterSlot(monsterName));
            }
        }

        private void generateSlots_Click(object sender, EventArgs e)
        {

        }

        private void globalSlotListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void generatorToolTip_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
