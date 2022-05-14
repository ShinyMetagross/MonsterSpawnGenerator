using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MonsterSpawnGenerator
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

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
                this.altGameList.Enabled = true;
                this.addAltGame.Enabled = true;
                if (this.altGameList.Items.Count > 0)
                    this.altGameList.SelectedIndex = 0;

                populateMonsterList();
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

        private void defaultProperties()
        {
            this.health1.Text = "0";
            this.health2.Text = "0";
            this.health3.Text = "0";
            this.health4.Text = "0";
            this.health5.Text = "0";
            this.speed1.Text = "0";
            this.speed2.Text = "0";
            this.speed3.Text = "0";
            this.speed4.Text = "0";
            this.speed5.Text = "0";
            this.token1.Text = "0";
            this.token2.Text = "0";
            this.token3.Text = "0";
            this.token4.Text = "0";
            this.token5.Text = "0";
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

            sb.Append("int monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][6] = \n{");
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
                    sb.Append("\n\t}" + (gameCounter == this.gameList.Items.Count ? "" : ","));
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
                    if(!fileContent.Contains("int monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][6] ="))
                    {
                        MessageBox.Show("This text file is invalid, please select another.");
                    }
                    else
                    {
                        dissectFile(fileContent);
                    }
                }
            }
        }

        private void dissectFile(string file)
        {
            string virtualString = file.Replace("\t", String.Empty);

            int startPosition = virtualString.IndexOf("int monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][6] =") + "int monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][6] =".Length;
            virtualString = virtualString.Substring(startPosition);

            StringReader stringReader = new StringReader(virtualString);

            //Done twice to consume the remaining line and move onto next
            string line;
            int character;
            int lineNumber = 1;
            bool breaknext = false;
            line = stringReader.ReadLine();
            line = stringReader.ReadLine();

            if (line == "{")
            {
                while((line = stringReader.ReadLine()) != null)
                {
                    lineNumber++;
                    //MessageBox.Show("Line Number: " + lineNumber.ToString() + " - " + line + " - Loop " + 1);
                    if (line.StartsWith("{//"))
                    {
                        String gameName = line.Substring(3);
                        game thisGame = new game(gameName);
                        this.gameList.Items.Add(thisGame);
                        while ((line = stringReader.ReadLine()) != null)
                        {
                            lineNumber++;
                            //MessageBox.Show("Line Number: " + lineNumber.ToString() + " - " + line + " - Loop " + 2);
                            if (line.StartsWith("{//"))
                            {
                                String altGameName = line.Substring(3);
                                altGame thisAltGame = new altGame(altGameName);
                                thisGame.gameAdd(thisAltGame);
                                generateMonsterSlots(thisAltGame);
                                while ((line = stringReader.ReadLine()) != null)
                                {
                                    lineNumber++;
                                    //MessageBox.Show("Line Number: " + lineNumber.ToString() + " - " + line + " - Loop " + 3);
                                    if (line.StartsWith("{//"))
                                    {
                                        String monsterSlotName = line.Substring(3);
                                        foreach(monsterSlot mSlot in thisAltGame.monsterslots)
                                        {
                                            if(mSlot.ToString() == monsterSlotName)
                                            {   
                                                while ((line = stringReader.ReadLine()) != null)
                                                {
                                                    lineNumber++;
                                                    //MessageBox.Show("Line Number: " + lineNumber.ToString() + " - " + line + " - Loop " + 4);
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
    }
}
