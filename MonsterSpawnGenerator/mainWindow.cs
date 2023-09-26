using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

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
            "Pig"
        };

        public mainWindow()
        {
            InitializeComponent();
            designSpec = designSpec.Append("");
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }

        private void isThisNumeric(object sender, KeyPressEventArgs e)
        {
            string keyPress = e.KeyChar.ToString();
            if (!(char.IsControl(e.KeyChar) || int.TryParse(keyPress, out _) || keyPress == "."))
            {
                MessageBox.Show("Please type a number or decimal point.");
                e.Handled = true;
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
                gameList.Items.Add(new game(gameList.Text));
                gameList.Text = null;
            }
        }

        private void removeGame(object sender, EventArgs e)
        {
            gameList.Items.Remove(gameList.SelectedItem);
        }
        
        private void changeGame(object sender, EventArgs e)
        {
            if (isListItemSelected(gameList.SelectedItem, typeof(game)))
            {
                game thisGame = (game)gameList.SelectedItem;
                altGameList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (altGame anAltGame in thisGame.altGames)
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
            if (isListItemSelected(gameList.SelectedItem, typeof(game)))
            {
                game thisGame = (game)gameList.SelectedItem;
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
            if (isListItemSelected(gameList.SelectedItem, typeof(game)))
            {
                game thisGame = (game)gameList.SelectedItem;
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
                if (isListItemSelected(gameList.SelectedItem, typeof(game)))
                {
                    game thisGame = (game)gameList.SelectedItem;
                    altGame newAltGame = new altGame(altGameList.Text);
                    generateMonsterSlots(newAltGame);

                    thisGame.gameAdd(newAltGame);

                    altGameList.Items.Clear();
                    foreach (altGame anAltGame in thisGame.altGames)
                    {
                        altGameList.Items.Add(anAltGame);
                    }

                    altGameList.Text = null;
                }
            }
        }

        private void removeAltGame(object sender, EventArgs e)
        {
            game thisGame = (game)gameList.SelectedItem;
            thisGame.altGames.Remove((altGame)altGameList.SelectedItem);
            altGameList.Items.Remove(altGameList.SelectedItem);
        }

        private void generateMonsterSlots(altGame thisAltGame)
        {
            monsterSlotList.Items.Clear();
            foreach (monsterSlot mSlot in globalSlotListView.Items)
            {
                thisAltGame.monsterSlotAdd(mSlot);
                monsterSlotList.Items.Add(mSlot);
            }
        }

        private void changeAltGame(object sender, EventArgs e)
        {
            if (isListItemSelected(altGameList.SelectedItem, typeof(altGame)))
            {
                altGame thisAltGame = (altGame)altGameList.SelectedItem;
                monsterSlotList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (monsterSlot aMonsterSlot in thisAltGame.monsterslots)
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
            if (isListItemSelected(monsterSlotList.SelectedItem, typeof(monsterSlot)))
            {
                monsterSlot thisMonsterSlot = (monsterSlot)monsterSlotList.SelectedItem;
                monsterList.Items.Clear();

                //We add the items from the selected game's alt games, to give it an actual attachment versus just what's on screen.
                foreach (monster aMonster in thisMonsterSlot.monsters)
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
                monsterList.Items.Add(new monster(monsterName.Text));

                if (isListItemSelected(monsterSlotList.SelectedItem, typeof(monsterSlot)))
                {
                    monsterSlot thisMonsterSlot = (monsterSlot)monsterSlotList.SelectedItem;
                    thisMonsterSlot.monsterAdd(new monster(monsterName.Text));
                }
            }
        }

        private void removeMonsterFromList(object sender, EventArgs e)
        {
            if (isListItemSelected(monsterSlotList.SelectedItem, typeof(monsterSlot)))
            {
                monsterSlot thisMonsterSlot = (monsterSlot)monsterSlotList.SelectedItem;
                thisMonsterSlot.monsterRemove((monster)monsterList.SelectedItem);
            }
            monsterList.Items.Remove(monsterList.SelectedItem);
        }

        private void changeMonster(object sender, EventArgs e)
        {
            if (isListItemSelected(monsterList.SelectedItem, typeof(monster)))
            {
                monster thisMonster = (monster)monsterList.SelectedItem;
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
            if (isListItemSelected(altGameList.SelectedItem, typeof(altGame)))
            {
                if (isListItemSelected(monsterSlotList.SelectedItem, typeof(monsterSlot)))
                {
                    monsterSlot thisMonsterSlot = (monsterSlot)monsterSlotList.SelectedItem;
                    foreach (monster aMonster in thisMonsterSlot.monsters)
                    {
                        monsterList.Items.Add(aMonster);
                    }
                }
            }
        }

        private void setMonsterStat(object sender, Action<monster, string> changeFunc)
        {
            if (isListItemSelected(monsterList.SelectedItem, typeof(monster)))
            {
                monster selectedMonster = (monster) monsterList.SelectedItem;
                TextBox input = (TextBox) sender;

                changeFunc(selectedMonster, input.Text);
            }
        }

        private void health1Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 0));
        }
        private void health2Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 1));
        }
        private void health3Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 2));
        }
        private void health4Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 3));
        }
        private void health5Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterHealthByDifficulty(value, 4));
        }
        private void token1Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 0));
        }
        private void token2Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 1));
        }
        private void token3Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 2));
        }
        private void token4Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 3));
        }
        private void token5Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterTokenByDifficulty(value, 4));
        }
        private void speed1Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 0));
        }
        private void speed2Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 1));
        }
        private void speed3Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 2));
        }
        private void speed4Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 3));
        }
        private void speed5Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterSpeedByDifficulty(value, 4));
        }
        private void weight1Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 0));
        }
        private void weight2Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 1));
        }
        private void weight3Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 2));
        }
        private void weight4Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 3));
        }
        private void weight5Change(object sender, EventArgs e)
        {
            setMonsterStat(sender, (monster selectedMonster, string value) => selectedMonster.setMonsterWeightByDifficulty(value, 4));
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
                    sb.Append((altGameCounter > 0 ? "\n\t" : "") + "}" + (gameCounter < gameList.Items.Count ? "," : ""));
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
                    sb.Append((thisGame.altGames.Count > 0 ? "\n\t" : "") + "}" + (gameCounter < gameList.Items.Count ? "," : ""));
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
                    fileContent = reader.ReadToEnd();

                    StringReader stringReader = new StringReader(fileContent);
                    string line = string.Empty;

                    while ((line = stringReader.ReadLine()) != null)
                    {
                        designSpec = designSpec.AppendLine(line);
                        if (line.Contains("*/"))
                            break;
                    }

                    if (!fileContent.Contains("str monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_STRING_ITEMS] =") || !fileContent.Contains("int monsterSelectStat[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][MAX_ITEMS] ="))
                    {
                        MessageBox.Show("This text file is invalid, please select another.");
                    }
                    else
                    {
                        gameList.Items.Clear();
                        dissectStrings(fileContent);
                        dissectValues(fileContent);
                        gameList.SelectedIndex = 0;
                        bool drawnGlobalList = false;
                        foreach (game game in gameList.Items)
                        {
                            foreach (altGame altGame in game.altGames)
                            {
                                altGame sortedAltGame = new altGame(altGame.ToString());
                                for (int i = 0; i < defaultMonsters.Length; i++)
                                {
                                    monsterSlot newMonster = altGame.containsMonsterSlot(defaultMonsters[i]);
                                    if (newMonster != null)
                                        sortedAltGame.monsterSlotAdd(altGame.containsMonsterSlot(defaultMonsters[i]));
                                }
                                altGame.monsterslots = sortedAltGame.monsterslots;
                                if(drawnGlobalList == false)
                                {
                                    globalSlotListView.Items.Clear();
                                    foreach (monsterSlot monSlot in altGame.monsterslots)
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
                            gameList.Items.Add(thisGame);
                            continue;
                        }
                        else if (line.EndsWith("},"))
                        {
                            gameName = line.Substring(3, gameName.Length - 2);
                            thisGame = new game(gameName);
                            gameList.Items.Add(thisGame);
                            continue;
                        }

                        thisGame = new game(gameName);
                        gameList.Items.Add(thisGame);

                        while ((line = stringReader.ReadLine()) != null)
                        {
                            if (line.StartsWith("{//"))
                            {
                                String altGameName = line.Substring(3);
                                altGame thisAltGame = new altGame(altGameName);
                                while ((line = stringReader.ReadLine()) != null)
                                {
                                    if (line.StartsWith("{//"))
                                    {
                                        String monsterSlotName = line.Substring(3);
                                        if (line.Substring(3) == monsterSlotName)
                                        {
                                            monsterSlot newMonsterSlot = new monsterSlot(monsterSlotName);

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
                                                    newMonsterSlot.monsterAdd(newMonster);
                                                }
                                                if ((line.StartsWith("}") && !line.EndsWith(",")) || breaknext)
                                                {
                                                    breaknext = false;
                                                    break;
                                                }
                                            }
                                            thisAltGame.monsterSlotAdd(newMonsterSlot);
                                        }
                                    }
                                    else if (line.StartsWith("}") && !line.EndsWith(","))
                                        break;
                                }
                                thisGame.gameAdd(thisAltGame);
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
            string virtualString = file.Substring(startPosition).Replace("\t", "");

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
                    if (line.StartsWith("{"))
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
                            game thisGameObject = (game)gameList.Items[thisGame];
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
                                        altGame thisAltGameObject = thisGameObject.altGames[thisAltGame];
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
                                                    monsterSlot thisMonsterSlotObject = thisAltGameObject.monsterslots[thisMonsterSlot];
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

                                                            monster thisMonsterObject = thisMonsterSlotObject.monsters[thisMonster];

                                                            while ((character = monsterLine.Read()) != -1)
                                                            {
                                                                if (character == '}')
                                                                {
                                                                    switch (statIncrement % 3)
                                                                    {
                                                                        case 0:
                                                                            thisMonsterObject.setMonsterSpeedByDifficulty(monsterValue, statIncrement / 3);
                                                                            break;
                                                                        case 1:
                                                                            thisMonsterObject.setMonsterHealthByDifficulty(monsterValue, statIncrement / 3);
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
                                                                    switch (statIncrement % 3)
                                                                    {
                                                                        case 0:
                                                                            thisMonsterObject.setMonsterSpeedByDifficulty(monsterValue, statIncrement / 3);
                                                                            break;
                                                                        case 1:
                                                                            thisMonsterObject.setMonsterHealthByDifficulty(monsterValue, statIncrement / 3);
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

        private void addGlobalMonsterSlot(object sender, EventArgs e)
        {
            monsterSlot newMonsterSlot = new monsterSlot(globalSlotBox.Text);
            globalSlotListView.Items.Add(newMonsterSlot);
            foreach(game game in gameList.Items)
            {
                foreach (altGame altGame in game.altGames)
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
                foreach (game game in gameList.Items)
                {
                    foreach (altGame altGame in game.altGames)
                    {
                        monsterSlot removalMonsterSlot = new monsterSlot("null");
                        foreach (monsterSlot monsterSlot in altGame.monsterslots)
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
                monsterSlot newMonsterSlot = new monsterSlot(globalSlotListView.SelectedItem.ToString());
                newMonsterSlot.renameMonster(globalSlotBox.Text);
                globalSlotListView.Items.Add(newMonsterSlot);

                foreach (game game in gameList.Items)
                {
                    foreach (altGame altGame in game.altGames)
                    {
                        foreach (monsterSlot monsterSlot in altGame.monsterslots)
                        {
                            if (monsterSlot.ToString() == globalSlotListView.SelectedItem.ToString())
                            {
                                monsterSlot copiedMonsterSlot = new monsterSlot(monsterSlot.ToString());
                                foreach (monster monster in monsterSlot.monsters)
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
                globalSlotListView.Items.Add(new monsterSlot(monsterName));
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
