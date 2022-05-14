namespace MonsterSpawnGenerator
{
    partial class mainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monsterSlotList = new System.Windows.Forms.ComboBox();
            this.monsterList = new System.Windows.Forms.ListBox();
            this.addMonster = new System.Windows.Forms.Button();
            this.healthLabel = new System.Windows.Forms.Label();
            this.monsterName = new System.Windows.Forms.TextBox();
            this.monsterNameLabel = new System.Windows.Forms.Label();
            this.altGameList = new System.Windows.Forms.ComboBox();
            this.gameList = new System.Windows.Forms.ComboBox();
            this.addAltGame = new System.Windows.Forms.Button();
            this.addGame = new System.Windows.Forms.Button();
            this.gameLabel = new System.Windows.Forms.Label();
            this.altGameLabel = new System.Windows.Forms.Label();
            this.slotLabel = new System.Windows.Forms.Label();
            this.removeAltGame = new System.Windows.Forms.Button();
            this.removeGame = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.importSpawn = new System.Windows.Forms.Button();
            this.health1 = new System.Windows.Forms.TextBox();
            this.health2 = new System.Windows.Forms.TextBox();
            this.health3 = new System.Windows.Forms.TextBox();
            this.health4 = new System.Windows.Forms.TextBox();
            this.health5 = new System.Windows.Forms.TextBox();
            this.difficulty1 = new System.Windows.Forms.Label();
            this.difficulty2 = new System.Windows.Forms.Label();
            this.difficulty3 = new System.Windows.Forms.Label();
            this.difficulty4 = new System.Windows.Forms.Label();
            this.difficulty5 = new System.Windows.Forms.Label();
            this.speed5 = new System.Windows.Forms.TextBox();
            this.speed4 = new System.Windows.Forms.TextBox();
            this.speed3 = new System.Windows.Forms.TextBox();
            this.speed2 = new System.Windows.Forms.TextBox();
            this.speed1 = new System.Windows.Forms.TextBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.tokenLabel = new System.Windows.Forms.Label();
            this.token5 = new System.Windows.Forms.TextBox();
            this.token4 = new System.Windows.Forms.TextBox();
            this.token3 = new System.Windows.Forms.TextBox();
            this.token2 = new System.Windows.Forms.TextBox();
            this.token1 = new System.Windows.Forms.TextBox();
            this.monsterListItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // monsterSlotList
            // 
            this.monsterSlotList.Enabled = false;
            this.monsterSlotList.FormattingEnabled = true;
            this.monsterSlotList.Location = new System.Drawing.Point(61, 136);
            this.monsterSlotList.Name = "monsterSlotList";
            this.monsterSlotList.Size = new System.Drawing.Size(169, 21);
            this.monsterSlotList.TabIndex = 0;
            this.monsterSlotList.SelectedIndexChanged += new System.EventHandler(this.changeMonsterSlot);
            // 
            // monsterList
            // 
            this.monsterList.FormattingEnabled = true;
            this.monsterList.Location = new System.Drawing.Point(12, 174);
            this.monsterList.Name = "monsterList";
            this.monsterList.Size = new System.Drawing.Size(288, 277);
            this.monsterList.TabIndex = 2;
            this.monsterList.SelectedIndexChanged += new System.EventHandler(this.changeMonster);
            // 
            // addMonster
            // 
            this.addMonster.Enabled = false;
            this.addMonster.Location = new System.Drawing.Point(106, 480);
            this.addMonster.Name = "addMonster";
            this.addMonster.Size = new System.Drawing.Size(75, 23);
            this.addMonster.TabIndex = 3;
            this.addMonster.Text = "Add";
            this.addMonster.UseVisualStyleBackColor = true;
            this.addMonster.Click += new System.EventHandler(this.addMonsterToList);
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Location = new System.Drawing.Point(374, 334);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(41, 13);
            this.healthLabel.TabIndex = 4;
            this.healthLabel.Text = "Health:";
            // 
            // monsterName
            // 
            this.monsterName.Enabled = false;
            this.monsterName.Location = new System.Drawing.Point(93, 454);
            this.monsterName.Name = "monsterName";
            this.monsterName.Size = new System.Drawing.Size(207, 20);
            this.monsterName.TabIndex = 6;
            // 
            // monsterNameLabel
            // 
            this.monsterNameLabel.AutoSize = true;
            this.monsterNameLabel.Location = new System.Drawing.Point(11, 457);
            this.monsterNameLabel.Name = "monsterNameLabel";
            this.monsterNameLabel.Size = new System.Drawing.Size(79, 13);
            this.monsterNameLabel.TabIndex = 7;
            this.monsterNameLabel.Text = "Monster Name:";
            // 
            // altGameList
            // 
            this.altGameList.Enabled = false;
            this.altGameList.FormattingEnabled = true;
            this.altGameList.Location = new System.Drawing.Point(61, 76);
            this.altGameList.Name = "altGameList";
            this.altGameList.Size = new System.Drawing.Size(169, 21);
            this.altGameList.TabIndex = 8;
            this.altGameList.SelectedIndexChanged += new System.EventHandler(this.changeAltGame);
            // 
            // gameList
            // 
            this.gameList.FormattingEnabled = true;
            this.gameList.Location = new System.Drawing.Point(61, 16);
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(169, 21);
            this.gameList.TabIndex = 9;
            this.gameList.SelectedIndexChanged += new System.EventHandler(this.changeGame);
            // 
            // addAltGame
            // 
            this.addAltGame.Enabled = false;
            this.addAltGame.Location = new System.Drawing.Point(236, 61);
            this.addAltGame.Name = "addAltGame";
            this.addAltGame.Size = new System.Drawing.Size(64, 23);
            this.addAltGame.TabIndex = 10;
            this.addAltGame.Text = "Add";
            this.addAltGame.UseVisualStyleBackColor = true;
            this.addAltGame.Click += new System.EventHandler(this.addAltGameDialogue);
            // 
            // addGame
            // 
            this.addGame.Location = new System.Drawing.Point(236, 3);
            this.addGame.Name = "addGame";
            this.addGame.Size = new System.Drawing.Size(64, 23);
            this.addGame.TabIndex = 11;
            this.addGame.Text = "Add";
            this.addGame.UseVisualStyleBackColor = true;
            this.addGame.Click += new System.EventHandler(this.addGameDialogue);
            // 
            // gameLabel
            // 
            this.gameLabel.AutoSize = true;
            this.gameLabel.Location = new System.Drawing.Point(17, 19);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(38, 13);
            this.gameLabel.TabIndex = 12;
            this.gameLabel.Text = "Game:";
            // 
            // altGameLabel
            // 
            this.altGameLabel.AutoSize = true;
            this.altGameLabel.Location = new System.Drawing.Point(2, 81);
            this.altGameLabel.Name = "altGameLabel";
            this.altGameLabel.Size = new System.Drawing.Size(53, 13);
            this.altGameLabel.TabIndex = 13;
            this.altGameLabel.Text = "Alt Game:";
            // 
            // slotLabel
            // 
            this.slotLabel.AutoSize = true;
            this.slotLabel.Location = new System.Drawing.Point(27, 139);
            this.slotLabel.Name = "slotLabel";
            this.slotLabel.Size = new System.Drawing.Size(28, 13);
            this.slotLabel.TabIndex = 14;
            this.slotLabel.Text = "Slot:";
            // 
            // removeAltGame
            // 
            this.removeAltGame.Enabled = false;
            this.removeAltGame.Location = new System.Drawing.Point(236, 90);
            this.removeAltGame.Name = "removeAltGame";
            this.removeAltGame.Size = new System.Drawing.Size(64, 23);
            this.removeAltGame.TabIndex = 16;
            this.removeAltGame.Text = "Remove";
            this.removeAltGame.UseVisualStyleBackColor = true;
            // 
            // removeGame
            // 
            this.removeGame.Enabled = false;
            this.removeGame.Location = new System.Drawing.Point(236, 32);
            this.removeGame.Name = "removeGame";
            this.removeGame.Size = new System.Drawing.Size(64, 23);
            this.removeGame.TabIndex = 17;
            this.removeGame.Text = "Remove";
            this.removeGame.UseVisualStyleBackColor = true;
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Location = new System.Drawing.Point(274, 510);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(121, 40);
            this.generateButton.TabIndex = 18;
            this.generateButton.Text = "Generate!";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateSpawns);
            // 
            // importSpawn
            // 
            this.importSpawn.Location = new System.Drawing.Point(12, 521);
            this.importSpawn.Name = "importSpawn";
            this.importSpawn.Size = new System.Drawing.Size(90, 29);
            this.importSpawn.TabIndex = 19;
            this.importSpawn.Text = "Import Spawns";
            this.importSpawn.UseVisualStyleBackColor = true;
            this.importSpawn.Click += new System.EventHandler(this.importSpawns);
            // 
            // health1
            // 
            this.health1.Location = new System.Drawing.Point(371, 350);
            this.health1.Name = "health1";
            this.health1.Size = new System.Drawing.Size(47, 20);
            this.health1.TabIndex = 20;
            this.health1.Text = "0";
            this.health1.TextChanged += new System.EventHandler(this.savePropertiesInput);
            // 
            // health2
            // 
            this.health2.Location = new System.Drawing.Point(371, 376);
            this.health2.Name = "health2";
            this.health2.Size = new System.Drawing.Size(47, 20);
            this.health2.TabIndex = 21;
            this.health2.Text = "0";
            this.health2.TextChanged += new System.EventHandler(this.savePropertiesInput);
            // 
            // health3
            // 
            this.health3.Location = new System.Drawing.Point(371, 402);
            this.health3.Name = "health3";
            this.health3.Size = new System.Drawing.Size(47, 20);
            this.health3.TabIndex = 22;
            this.health3.Text = "0";
            this.health3.TextChanged += new System.EventHandler(this.savePropertiesInput);
            // 
            // health4
            // 
            this.health4.Location = new System.Drawing.Point(371, 428);
            this.health4.Name = "health4";
            this.health4.Size = new System.Drawing.Size(47, 20);
            this.health4.TabIndex = 23;
            this.health4.Text = "0";
            this.health4.TextChanged += new System.EventHandler(this.savePropertiesInput);
            // 
            // health5
            // 
            this.health5.Location = new System.Drawing.Point(371, 454);
            this.health5.Name = "health5";
            this.health5.Size = new System.Drawing.Size(47, 20);
            this.health5.TabIndex = 24;
            this.health5.Text = "0";
            this.health5.TextChanged += new System.EventHandler(this.savePropertiesInput);
            // 
            // difficulty1
            // 
            this.difficulty1.AutoSize = true;
            this.difficulty1.Location = new System.Drawing.Point(306, 353);
            this.difficulty1.Name = "difficulty1";
            this.difficulty1.Size = new System.Drawing.Size(59, 13);
            this.difficulty1.TabIndex = 25;
            this.difficulty1.Text = "Difficulty 1:";
            // 
            // difficulty2
            // 
            this.difficulty2.AutoSize = true;
            this.difficulty2.Location = new System.Drawing.Point(306, 379);
            this.difficulty2.Name = "difficulty2";
            this.difficulty2.Size = new System.Drawing.Size(59, 13);
            this.difficulty2.TabIndex = 26;
            this.difficulty2.Text = "Difficulty 2:";
            // 
            // difficulty3
            // 
            this.difficulty3.AutoSize = true;
            this.difficulty3.Location = new System.Drawing.Point(306, 405);
            this.difficulty3.Name = "difficulty3";
            this.difficulty3.Size = new System.Drawing.Size(59, 13);
            this.difficulty3.TabIndex = 27;
            this.difficulty3.Text = "Difficulty 3:";
            // 
            // difficulty4
            // 
            this.difficulty4.AutoSize = true;
            this.difficulty4.Location = new System.Drawing.Point(306, 431);
            this.difficulty4.Name = "difficulty4";
            this.difficulty4.Size = new System.Drawing.Size(59, 13);
            this.difficulty4.TabIndex = 28;
            this.difficulty4.Text = "Difficulty 4:";
            // 
            // difficulty5
            // 
            this.difficulty5.AutoSize = true;
            this.difficulty5.Location = new System.Drawing.Point(306, 457);
            this.difficulty5.Name = "difficulty5";
            this.difficulty5.Size = new System.Drawing.Size(59, 13);
            this.difficulty5.TabIndex = 29;
            this.difficulty5.Text = "Difficulty 5:";
            // 
            // speed5
            // 
            this.speed5.Location = new System.Drawing.Point(424, 454);
            this.speed5.Name = "speed5";
            this.speed5.Size = new System.Drawing.Size(47, 20);
            this.speed5.TabIndex = 35;
            this.speed5.Text = "0";
            // 
            // speed4
            // 
            this.speed4.Location = new System.Drawing.Point(424, 428);
            this.speed4.Name = "speed4";
            this.speed4.Size = new System.Drawing.Size(47, 20);
            this.speed4.TabIndex = 34;
            this.speed4.Text = "0";
            // 
            // speed3
            // 
            this.speed3.Location = new System.Drawing.Point(424, 402);
            this.speed3.Name = "speed3";
            this.speed3.Size = new System.Drawing.Size(47, 20);
            this.speed3.TabIndex = 33;
            this.speed3.Text = "0";
            // 
            // speed2
            // 
            this.speed2.Location = new System.Drawing.Point(424, 376);
            this.speed2.Name = "speed2";
            this.speed2.Size = new System.Drawing.Size(47, 20);
            this.speed2.TabIndex = 32;
            this.speed2.Text = "0";
            // 
            // speed1
            // 
            this.speed1.Location = new System.Drawing.Point(424, 350);
            this.speed1.Name = "speed1";
            this.speed1.Size = new System.Drawing.Size(47, 20);
            this.speed1.TabIndex = 31;
            this.speed1.Text = "0";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(427, 334);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(41, 13);
            this.speedLabel.TabIndex = 30;
            this.speedLabel.Text = "Speed:";
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Location = new System.Drawing.Point(474, 334);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(41, 13);
            this.tokenLabel.TabIndex = 36;
            this.tokenLabel.Text = "Token:";
            // 
            // token5
            // 
            this.token5.Location = new System.Drawing.Point(477, 454);
            this.token5.Name = "token5";
            this.token5.Size = new System.Drawing.Size(199, 20);
            this.token5.TabIndex = 41;
            // 
            // token4
            // 
            this.token4.Location = new System.Drawing.Point(477, 428);
            this.token4.Name = "token4";
            this.token4.Size = new System.Drawing.Size(199, 20);
            this.token4.TabIndex = 40;
            // 
            // token3
            // 
            this.token3.Location = new System.Drawing.Point(477, 402);
            this.token3.Name = "token3";
            this.token3.Size = new System.Drawing.Size(199, 20);
            this.token3.TabIndex = 39;
            // 
            // token2
            // 
            this.token2.Location = new System.Drawing.Point(477, 376);
            this.token2.Name = "token2";
            this.token2.Size = new System.Drawing.Size(199, 20);
            this.token2.TabIndex = 38;
            // 
            // token1
            // 
            this.token1.Location = new System.Drawing.Point(477, 350);
            this.token1.Name = "token1";
            this.token1.Size = new System.Drawing.Size(199, 20);
            this.token1.TabIndex = 37;
            // 
            // monsterListItems
            // 
            this.monsterListItems.FormattingEnabled = true;
            this.monsterListItems.Items.AddRange(new object[] {
            "Zombieman",
            "Shotgunguy",
            "Doom Imp",
            "Chaingunguy",
            "Demon",
            "Spectre",
            "Hell Knight",
            "Baron of Hell",
            "Arachnotron",
            "Mancubus",
            "Lost Soul",
            "Pain Elemental",
            "Cacodemon",
            "Revenant",
            "Archvile",
            "Cyberdemon",
            "Spider Mastermind",
            "Wolfenstein SS",
            "Super Shotgunguy",
            "Dark Imp",
            "Blood Demon",
            "Cacolantern",
            "Abbadon",
            "Hectebus",
            "Belphegor"});
            this.monsterListItems.Location = new System.Drawing.Point(313, 6);
            this.monsterListItems.Name = "monsterListItems";
            this.monsterListItems.Size = new System.Drawing.Size(154, 303);
            this.monsterListItems.TabIndex = 42;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 562);
            this.Controls.Add(this.monsterListItems);
            this.Controls.Add(this.token5);
            this.Controls.Add(this.token4);
            this.Controls.Add(this.token3);
            this.Controls.Add(this.token2);
            this.Controls.Add(this.token1);
            this.Controls.Add(this.tokenLabel);
            this.Controls.Add(this.speed5);
            this.Controls.Add(this.speed4);
            this.Controls.Add(this.speed3);
            this.Controls.Add(this.speed2);
            this.Controls.Add(this.speed1);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.difficulty5);
            this.Controls.Add(this.difficulty4);
            this.Controls.Add(this.difficulty3);
            this.Controls.Add(this.difficulty2);
            this.Controls.Add(this.difficulty1);
            this.Controls.Add(this.health5);
            this.Controls.Add(this.health4);
            this.Controls.Add(this.health3);
            this.Controls.Add(this.health2);
            this.Controls.Add(this.health1);
            this.Controls.Add(this.importSpawn);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.removeGame);
            this.Controls.Add(this.removeAltGame);
            this.Controls.Add(this.slotLabel);
            this.Controls.Add(this.altGameLabel);
            this.Controls.Add(this.gameLabel);
            this.Controls.Add(this.addGame);
            this.Controls.Add(this.addAltGame);
            this.Controls.Add(this.gameList);
            this.Controls.Add(this.altGameList);
            this.Controls.Add(this.monsterNameLabel);
            this.Controls.Add(this.monsterName);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.addMonster);
            this.Controls.Add(this.monsterList);
            this.Controls.Add(this.monsterSlotList);
            this.Name = "mainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox monsterSlotList;
        private System.Windows.Forms.ListBox monsterList;
        private System.Windows.Forms.Button addMonster;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.TextBox monsterName;
        private System.Windows.Forms.Label monsterNameLabel;
        private System.Windows.Forms.ComboBox altGameList;
        private System.Windows.Forms.ComboBox gameList;
        private System.Windows.Forms.Button addAltGame;
        private System.Windows.Forms.Button addGame;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.Label altGameLabel;
        private System.Windows.Forms.Label slotLabel;
        private System.Windows.Forms.Button removeAltGame;
        private System.Windows.Forms.Button removeGame;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button importSpawn;
        private System.Windows.Forms.TextBox health1;
        private System.Windows.Forms.TextBox health2;
        private System.Windows.Forms.TextBox health3;
        private System.Windows.Forms.TextBox health4;
        private System.Windows.Forms.TextBox health5;
        private System.Windows.Forms.Label difficulty1;
        private System.Windows.Forms.Label difficulty2;
        private System.Windows.Forms.Label difficulty3;
        private System.Windows.Forms.Label difficulty4;
        private System.Windows.Forms.Label difficulty5;
        private System.Windows.Forms.TextBox speed5;
        private System.Windows.Forms.TextBox speed4;
        private System.Windows.Forms.TextBox speed3;
        private System.Windows.Forms.TextBox speed2;
        private System.Windows.Forms.TextBox speed1;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label tokenLabel;
        private System.Windows.Forms.TextBox token5;
        private System.Windows.Forms.TextBox token4;
        private System.Windows.Forms.TextBox token3;
        private System.Windows.Forms.TextBox token2;
        private System.Windows.Forms.TextBox token1;
        private System.Windows.Forms.ListBox monsterListItems;
    }
}

