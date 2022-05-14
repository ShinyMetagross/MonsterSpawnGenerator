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

                //defaultProperties();
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

                defaultProperties();
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

                if(this.monsterList.Items.Count > 0)
                    this.monsterList.SelectedIndex = 0;

                //defaultProperties();
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

        private void changeMonster(object sender, EventArgs e)
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                //defaultProperties();

                monster thisMonster = (monster)this.monsterList.SelectedItem;
                this.health1.Text = thisMonster.getMonsterHealthByDifficulty(0);
                this.health2.Text = thisMonster.getMonsterHealthByDifficulty(1);
                this.health3.Text = thisMonster.getMonsterHealthByDifficulty(2);
                this.health4.Text = thisMonster.getMonsterHealthByDifficulty(3);
                this.health5.Text = thisMonster.getMonsterHealthByDifficulty(4);
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
        private void savePropertiesInput(object sender, EventArgs e)
        {
            saveProperties();
        }
        private void saveProperties()
        {
            if (this.monsterList.SelectedItem != null && this.monsterList.SelectedItem.GetType() == typeof(monster))
            {
                monster thisMonster = (monster)this.monsterList.SelectedItem;
                thisMonster.setMonsterHealthByDifficulty(this.health1.Text, 0);
                thisMonster.setMonsterHealthByDifficulty(this.health2.Text, 1);
                thisMonster.setMonsterHealthByDifficulty(this.health3.Text, 2);
                thisMonster.setMonsterHealthByDifficulty(this.health4.Text, 3);
                thisMonster.setMonsterHealthByDifficulty(this.health5.Text, 4);
            }
        }

        private void generateSpawns(object sender, EventArgs e)
        {
            string contents = assembleContents();
            var path = "output.txt";
            File.WriteAllText(path, contents);
        }   

        private string assembleContents()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("int monsterSelectStr[MAX_GAME_TYPES][MAX_ALTS][MONSTER_SLOT][MAXPERSLOT][6] = \n{");
            foreach(Object item in this.gameList.Items)
            {
                if (item.GetType() == typeof(game))
                {
                    game thisGame = (game)item;
                    sb.Append("\n\t{");
                    sb.Append("\\\\" + item.ToString());
                    foreach (Object item2 in thisGame.altGames)
                    {
                        altGame thisAltGame = (altGame)item2;
                        if (item2.GetType() == typeof(altGame))
                        {
                            sb.Append("\n\t\t{");
                            sb.Append("\\\\" + item2.ToString());
                            foreach (Object item3 in thisAltGame.monsterslots)
                            {
                                monsterSlot thisMonsterSlot = (monsterSlot)item3;
                                if (item3.GetType() == typeof(monsterSlot))
                                {
                                    sb.Append("\n\t\t\t{");
                                    sb.Append("\\\\" + item3.ToString());
                                    foreach (Object item4 in thisMonsterSlot.monsters)
                                    {
                                        monster thisMonster = (monster)item4;
                                        sb.Append("\n\t\t\t\t{");
                                        sb.Append("\n\t\t\t\t\t{\"" + thisMonster.ToString() + "\"},");
                                        sb.Append("\n\t\t\t\t},");
                                    }
                                    sb.Append("\n\t\t\t},");
                                }
                            }
                            sb.Append("\n\t\t},");
                        }
                    }
                    sb.Append("\n\t},");
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
                                                string monsterName = "";
                                                while ((line = stringReader.ReadLine()) != null)
                                                {
                                                    lineNumber++;
                                                    //MessageBox.Show("Line Number: " + lineNumber.ToString() + " - " + line + " - Loop " + 4);
                                                    if (line.StartsWith("{"))
                                                    {
                                                        String lineFormat = line.Replace("\"", "");
                                                        lineFormat = lineFormat.Replace(" ", "");
                                                        if (line.EndsWith("}"))
                                                            lineFormat = lineFormat.Substring(1);


                                                        StringReader monsterLine = new StringReader(lineFormat);

                                                        while ((character = monsterLine.Read()) != -1)
                                                        {
                                                            if (character == '}')
                                                            {
                                                                breaknext = true;
                                                                break;
                                                            }
                                                            else if (character != ',' || character != ' ')
                                                                monsterName += ((char)character).ToString();
                                                        }
                                                        mSlot.monsterAdd(new monster(monsterName));
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
