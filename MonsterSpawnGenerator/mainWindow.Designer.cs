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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
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
            this.removeAltGameButton = new System.Windows.Forms.Button();
            this.removeGameButton = new System.Windows.Forms.Button();
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
            this.removeMonster = new System.Windows.Forms.Button();
            this.weight5 = new System.Windows.Forms.TextBox();
            this.weight4 = new System.Windows.Forms.TextBox();
            this.weight3 = new System.Windows.Forms.TextBox();
            this.weight2 = new System.Windows.Forms.TextBox();
            this.weight1 = new System.Windows.Forms.TextBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.moveGameUpButton = new System.Windows.Forms.Button();
            this.moveGameDownButton = new System.Windows.Forms.Button();
            this.generatorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addMonsterSlotGlobal = new System.Windows.Forms.Button();
            this.removeMonsterSlotGlobal = new System.Windows.Forms.Button();
            this.copyMonsterSlotGlobal = new System.Windows.Forms.Button();
            this.generateSlots = new System.Windows.Forms.Button();
            this.globalSlotLabel = new System.Windows.Forms.Label();
            this.globalSlotListView = new System.Windows.Forms.ListBox();
            this.globalSlotBox = new System.Windows.Forms.TextBox();
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
            this.generatorToolTip.SetToolTip(this.addMonster, "Add monster");
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
            this.generatorToolTip.SetToolTip(this.healthLabel, "The health of a monster as a multiplier. Default is 0, which is the same as 1.0.");
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
            this.addAltGame.Image = ((System.Drawing.Image)(resources.GetObject("addAltGame.Image")));
            this.addAltGame.Location = new System.Drawing.Point(236, 74);
            this.addAltGame.Name = "addAltGame";
            this.addAltGame.Size = new System.Drawing.Size(26, 23);
            this.addAltGame.TabIndex = 10;
            this.generatorToolTip.SetToolTip(this.addAltGame, "Add alternative game");
            this.addAltGame.UseVisualStyleBackColor = true;
            this.addAltGame.Click += new System.EventHandler(this.addAltGameDialogue);
            // 
            // addGame
            // 
            this.addGame.Image = ((System.Drawing.Image)(resources.GetObject("addGame.Image")));
            this.addGame.Location = new System.Drawing.Point(236, 14);
            this.addGame.Name = "addGame";
            this.addGame.Size = new System.Drawing.Size(26, 23);
            this.addGame.TabIndex = 11;
            this.generatorToolTip.SetToolTip(this.addGame, "Add game");
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
            // removeAltGameButton
            // 
            this.removeAltGameButton.Enabled = false;
            this.removeAltGameButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAltGameButton.Image")));
            this.removeAltGameButton.Location = new System.Drawing.Point(268, 74);
            this.removeAltGameButton.Name = "removeAltGameButton";
            this.removeAltGameButton.Size = new System.Drawing.Size(26, 23);
            this.removeAltGameButton.TabIndex = 16;
            this.generatorToolTip.SetToolTip(this.removeAltGameButton, "Remove alternative game");
            this.removeAltGameButton.UseVisualStyleBackColor = true;
            this.removeAltGameButton.Click += new System.EventHandler(this.removeAltGame);
            // 
            // removeGameButton
            // 
            this.removeGameButton.Image = ((System.Drawing.Image)(resources.GetObject("removeGameButton.Image")));
            this.removeGameButton.Location = new System.Drawing.Point(268, 14);
            this.removeGameButton.Name = "removeGameButton";
            this.removeGameButton.Size = new System.Drawing.Size(26, 23);
            this.removeGameButton.TabIndex = 17;
            this.generatorToolTip.SetToolTip(this.removeGameButton, "Remove game");
            this.removeGameButton.UseVisualStyleBackColor = true;
            this.removeGameButton.Click += new System.EventHandler(this.removeGame);
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Location = new System.Drawing.Point(297, 510);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(121, 40);
            this.generateButton.TabIndex = 18;
            this.generateButton.Text = "Generate!";
            this.generatorToolTip.SetToolTip(this.generateButton, "Generate new Spawns.acs!");
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
            this.generatorToolTip.SetToolTip(this.importSpawn, "Import Spawns.acs");
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
            this.health1.TextChanged += new System.EventHandler(this.health1Change);
            this.health1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // health2
            // 
            this.health2.Location = new System.Drawing.Point(371, 376);
            this.health2.Name = "health2";
            this.health2.Size = new System.Drawing.Size(47, 20);
            this.health2.TabIndex = 21;
            this.health2.Text = "0";
            this.health2.TextChanged += new System.EventHandler(this.health2Change);
            this.health2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // health3
            // 
            this.health3.Location = new System.Drawing.Point(371, 402);
            this.health3.Name = "health3";
            this.health3.Size = new System.Drawing.Size(47, 20);
            this.health3.TabIndex = 22;
            this.health3.Text = "0";
            this.health3.TextChanged += new System.EventHandler(this.health3Change);
            this.health3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // health4
            // 
            this.health4.Location = new System.Drawing.Point(371, 428);
            this.health4.Name = "health4";
            this.health4.Size = new System.Drawing.Size(47, 20);
            this.health4.TabIndex = 23;
            this.health4.Text = "0";
            this.health4.TextChanged += new System.EventHandler(this.health4Change);
            this.health4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // health5
            // 
            this.health5.Location = new System.Drawing.Point(371, 454);
            this.health5.Name = "health5";
            this.health5.Size = new System.Drawing.Size(47, 20);
            this.health5.TabIndex = 24;
            this.health5.Text = "0";
            this.health5.TextChanged += new System.EventHandler(this.health5Change);
            this.health5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // difficulty1
            // 
            this.difficulty1.AutoSize = true;
            this.difficulty1.Location = new System.Drawing.Point(306, 353);
            this.difficulty1.Name = "difficulty1";
            this.difficulty1.Size = new System.Drawing.Size(59, 13);
            this.difficulty1.TabIndex = 25;
            this.difficulty1.Text = "Difficulty 1:";
            this.generatorToolTip.SetToolTip(this.difficulty1, "I\'m too young to die!");
            // 
            // difficulty2
            // 
            this.difficulty2.AutoSize = true;
            this.difficulty2.Location = new System.Drawing.Point(306, 379);
            this.difficulty2.Name = "difficulty2";
            this.difficulty2.Size = new System.Drawing.Size(59, 13);
            this.difficulty2.TabIndex = 26;
            this.difficulty2.Text = "Difficulty 2:";
            this.generatorToolTip.SetToolTip(this.difficulty2, "Hey, not too rough!");
            // 
            // difficulty3
            // 
            this.difficulty3.AutoSize = true;
            this.difficulty3.Location = new System.Drawing.Point(306, 405);
            this.difficulty3.Name = "difficulty3";
            this.difficulty3.Size = new System.Drawing.Size(59, 13);
            this.difficulty3.TabIndex = 27;
            this.difficulty3.Text = "Difficulty 3:";
            this.generatorToolTip.SetToolTip(this.difficulty3, "Hurt me Plenty");
            // 
            // difficulty4
            // 
            this.difficulty4.AutoSize = true;
            this.difficulty4.Location = new System.Drawing.Point(306, 431);
            this.difficulty4.Name = "difficulty4";
            this.difficulty4.Size = new System.Drawing.Size(59, 13);
            this.difficulty4.TabIndex = 28;
            this.difficulty4.Text = "Difficulty 4:";
            this.generatorToolTip.SetToolTip(this.difficulty4, "Ultra-Violence");
            // 
            // difficulty5
            // 
            this.difficulty5.AutoSize = true;
            this.difficulty5.Location = new System.Drawing.Point(306, 457);
            this.difficulty5.Name = "difficulty5";
            this.difficulty5.Size = new System.Drawing.Size(59, 13);
            this.difficulty5.TabIndex = 29;
            this.difficulty5.Text = "Difficulty 5:";
            this.generatorToolTip.SetToolTip(this.difficulty5, "Nightmare");
            // 
            // speed5
            // 
            this.speed5.Location = new System.Drawing.Point(424, 454);
            this.speed5.Name = "speed5";
            this.speed5.Size = new System.Drawing.Size(47, 20);
            this.speed5.TabIndex = 35;
            this.speed5.Text = "0";
            this.speed5.TextChanged += new System.EventHandler(this.speed5Change);
            this.speed5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // speed4
            // 
            this.speed4.Location = new System.Drawing.Point(424, 428);
            this.speed4.Name = "speed4";
            this.speed4.Size = new System.Drawing.Size(47, 20);
            this.speed4.TabIndex = 34;
            this.speed4.Text = "0";
            this.speed4.TextChanged += new System.EventHandler(this.speed4Change);
            this.speed4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // speed3
            // 
            this.speed3.Location = new System.Drawing.Point(424, 402);
            this.speed3.Name = "speed3";
            this.speed3.Size = new System.Drawing.Size(47, 20);
            this.speed3.TabIndex = 33;
            this.speed3.Text = "0";
            this.speed3.TextChanged += new System.EventHandler(this.speed3Change);
            this.speed3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // speed2
            // 
            this.speed2.Location = new System.Drawing.Point(424, 376);
            this.speed2.Name = "speed2";
            this.speed2.Size = new System.Drawing.Size(47, 20);
            this.speed2.TabIndex = 32;
            this.speed2.Text = "0";
            this.speed2.TextChanged += new System.EventHandler(this.speed2Change);
            this.speed2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // speed1
            // 
            this.speed1.Location = new System.Drawing.Point(424, 350);
            this.speed1.Name = "speed1";
            this.speed1.Size = new System.Drawing.Size(47, 20);
            this.speed1.TabIndex = 31;
            this.speed1.Text = "0";
            this.speed1.TextChanged += new System.EventHandler(this.speed1Change);
            this.speed1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(427, 334);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(41, 13);
            this.speedLabel.TabIndex = 30;
            this.speedLabel.Text = "Speed:";
            this.generatorToolTip.SetToolTip(this.speedLabel, "The speed of a monster as a multiplier. Default is 0, which is the same as 1.0.");
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Location = new System.Drawing.Point(524, 334);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(41, 13);
            this.tokenLabel.TabIndex = 36;
            this.tokenLabel.Text = "Token:";
            this.generatorToolTip.SetToolTip(this.tokenLabel, "Tokens are inventory actors that can be given to a monster on a set difficulty to" +
        " alter their behavior.");
            // 
            // token5
            // 
            this.token5.Location = new System.Drawing.Point(527, 454);
            this.token5.Name = "token5";
            this.token5.Size = new System.Drawing.Size(199, 20);
            this.token5.TabIndex = 41;
            this.token5.TextChanged += new System.EventHandler(this.token5Change);
            // 
            // token4
            // 
            this.token4.Location = new System.Drawing.Point(527, 428);
            this.token4.Name = "token4";
            this.token4.Size = new System.Drawing.Size(199, 20);
            this.token4.TabIndex = 40;
            this.token4.TextChanged += new System.EventHandler(this.token4Change);
            // 
            // token3
            // 
            this.token3.Location = new System.Drawing.Point(527, 402);
            this.token3.Name = "token3";
            this.token3.Size = new System.Drawing.Size(199, 20);
            this.token3.TabIndex = 39;
            this.token3.TextChanged += new System.EventHandler(this.token3Change);
            // 
            // token2
            // 
            this.token2.Location = new System.Drawing.Point(527, 376);
            this.token2.Name = "token2";
            this.token2.Size = new System.Drawing.Size(199, 20);
            this.token2.TabIndex = 38;
            this.token2.TextChanged += new System.EventHandler(this.token2Change);
            // 
            // token1
            // 
            this.token1.Location = new System.Drawing.Point(527, 350);
            this.token1.Name = "token1";
            this.token1.Size = new System.Drawing.Size(199, 20);
            this.token1.TabIndex = 37;
            this.token1.TextChanged += new System.EventHandler(this.token1Change);
            // 
            // removeMonster
            // 
            this.removeMonster.Enabled = false;
            this.removeMonster.Location = new System.Drawing.Point(212, 480);
            this.removeMonster.Name = "removeMonster";
            this.removeMonster.Size = new System.Drawing.Size(75, 23);
            this.removeMonster.TabIndex = 43;
            this.removeMonster.Text = "Remove";
            this.generatorToolTip.SetToolTip(this.removeMonster, "Remove selected monster");
            this.removeMonster.UseVisualStyleBackColor = true;
            this.removeMonster.Click += new System.EventHandler(this.removeMonsterFromList);
            // 
            // weight5
            // 
            this.weight5.Location = new System.Drawing.Point(477, 454);
            this.weight5.Name = "weight5";
            this.weight5.Size = new System.Drawing.Size(47, 20);
            this.weight5.TabIndex = 49;
            this.weight5.Text = "0";
            this.weight5.TextChanged += new System.EventHandler(this.weight5Change);
            this.weight5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // weight4
            // 
            this.weight4.Location = new System.Drawing.Point(477, 428);
            this.weight4.Name = "weight4";
            this.weight4.Size = new System.Drawing.Size(47, 20);
            this.weight4.TabIndex = 48;
            this.weight4.Text = "0";
            this.weight4.TextChanged += new System.EventHandler(this.weight4Change);
            this.weight4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // weight3
            // 
            this.weight3.Location = new System.Drawing.Point(477, 402);
            this.weight3.Name = "weight3";
            this.weight3.Size = new System.Drawing.Size(47, 20);
            this.weight3.TabIndex = 47;
            this.weight3.Text = "0";
            this.weight3.TextChanged += new System.EventHandler(this.weight3Change);
            this.weight3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // weight2
            // 
            this.weight2.Location = new System.Drawing.Point(477, 376);
            this.weight2.Name = "weight2";
            this.weight2.Size = new System.Drawing.Size(47, 20);
            this.weight2.TabIndex = 46;
            this.weight2.Text = "0";
            this.weight2.TextChanged += new System.EventHandler(this.weight2Change);
            this.weight2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // weight1
            // 
            this.weight1.Location = new System.Drawing.Point(477, 350);
            this.weight1.Name = "weight1";
            this.weight1.Size = new System.Drawing.Size(47, 20);
            this.weight1.TabIndex = 45;
            this.weight1.Text = "0";
            this.weight1.TextChanged += new System.EventHandler(this.weight1Change);
            this.weight1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isThisNumeric);
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(480, 334);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(44, 13);
            this.weightLabel.TabIndex = 44;
            this.weightLabel.Text = "Weight:";
            this.generatorToolTip.SetToolTip(this.weightLabel, resources.GetString("weightLabel.ToolTip"));
            // 
            // moveGameUpButton
            // 
            this.moveGameUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveGameUpButton.Image = ((System.Drawing.Image)(resources.GetObject("moveGameUpButton.Image")));
            this.moveGameUpButton.Location = new System.Drawing.Point(300, 3);
            this.moveGameUpButton.Name = "moveGameUpButton";
            this.moveGameUpButton.Size = new System.Drawing.Size(22, 23);
            this.moveGameUpButton.TabIndex = 51;
            this.moveGameUpButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.generatorToolTip.SetToolTip(this.moveGameUpButton, "Move game up");
            this.moveGameUpButton.UseVisualStyleBackColor = true;
            this.moveGameUpButton.Click += new System.EventHandler(this.moveGameUp);
            // 
            // moveGameDownButton
            // 
            this.moveGameDownButton.Image = ((System.Drawing.Image)(resources.GetObject("moveGameDownButton.Image")));
            this.moveGameDownButton.Location = new System.Drawing.Point(300, 32);
            this.moveGameDownButton.Name = "moveGameDownButton";
            this.moveGameDownButton.Size = new System.Drawing.Size(22, 23);
            this.moveGameDownButton.TabIndex = 52;
            this.moveGameDownButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.generatorToolTip.SetToolTip(this.moveGameDownButton, "Move game down");
            this.moveGameDownButton.UseVisualStyleBackColor = true;
            this.moveGameDownButton.Click += new System.EventHandler(this.moveGameDown);
            // 
            // addMonsterSlotGlobal
            // 
            this.addMonsterSlotGlobal.Image = ((System.Drawing.Image)(resources.GetObject("addMonsterSlotGlobal.Image")));
            this.addMonsterSlotGlobal.Location = new System.Drawing.Point(547, 290);
            this.addMonsterSlotGlobal.Name = "addMonsterSlotGlobal";
            this.addMonsterSlotGlobal.Size = new System.Drawing.Size(24, 24);
            this.addMonsterSlotGlobal.TabIndex = 57;
            this.generatorToolTip.SetToolTip(this.addMonsterSlotGlobal, "Add monster slot");
            this.addMonsterSlotGlobal.UseVisualStyleBackColor = true;
            this.addMonsterSlotGlobal.Click += new System.EventHandler(this.addGlobalMonsterSlot);
            // 
            // removeMonsterSlotGlobal
            // 
            this.removeMonsterSlotGlobal.Image = ((System.Drawing.Image)(resources.GetObject("removeMonsterSlotGlobal.Image")));
            this.removeMonsterSlotGlobal.Location = new System.Drawing.Point(547, 19);
            this.removeMonsterSlotGlobal.Name = "removeMonsterSlotGlobal";
            this.removeMonsterSlotGlobal.Size = new System.Drawing.Size(24, 24);
            this.removeMonsterSlotGlobal.TabIndex = 58;
            this.generatorToolTip.SetToolTip(this.removeMonsterSlotGlobal, "Remove monster slot");
            this.removeMonsterSlotGlobal.UseVisualStyleBackColor = true;
            this.removeMonsterSlotGlobal.Click += new System.EventHandler(this.removeGlobalMonsterSlot);
            // 
            // copyMonsterSlotGlobal
            // 
            this.copyMonsterSlotGlobal.Image = ((System.Drawing.Image)(resources.GetObject("copyMonsterSlotGlobal.Image")));
            this.copyMonsterSlotGlobal.Location = new System.Drawing.Point(577, 290);
            this.copyMonsterSlotGlobal.Name = "copyMonsterSlotGlobal";
            this.copyMonsterSlotGlobal.Size = new System.Drawing.Size(24, 24);
            this.copyMonsterSlotGlobal.TabIndex = 59;
            this.generatorToolTip.SetToolTip(this.copyMonsterSlotGlobal, "Copy Monster Slot");
            this.copyMonsterSlotGlobal.UseVisualStyleBackColor = true;
            this.copyMonsterSlotGlobal.Click += new System.EventHandler(this.copyMonsterSlot);
            // 
            // generateSlots
            // 
            this.generateSlots.Image = ((System.Drawing.Image)(resources.GetObject("generateSlots.Image")));
            this.generateSlots.Location = new System.Drawing.Point(547, 49);
            this.generateSlots.Name = "generateSlots";
            this.generateSlots.Size = new System.Drawing.Size(24, 24);
            this.generateSlots.TabIndex = 63;
            this.generatorToolTip.SetToolTip(this.generateSlots, "Generate default monster slots");
            this.generateSlots.UseVisualStyleBackColor = true;
            this.generateSlots.Click += new System.EventHandler(this.generateSlots_Click);
            this.generateSlots.MouseCaptureChanged += new System.EventHandler(this.doGenerateSlots);
            // 
            // globalSlotLabel
            // 
            this.globalSlotLabel.AutoSize = true;
            this.globalSlotLabel.Location = new System.Drawing.Point(315, 296);
            this.globalSlotLabel.Name = "globalSlotLabel";
            this.globalSlotLabel.Size = new System.Drawing.Size(74, 13);
            this.globalSlotLabel.TabIndex = 54;
            this.globalSlotLabel.Text = "Monster Slots:";
            // 
            // globalSlotListView
            // 
            this.globalSlotListView.FormattingEnabled = true;
            this.globalSlotListView.Location = new System.Drawing.Point(386, 19);
            this.globalSlotListView.Name = "globalSlotListView";
            this.globalSlotListView.Size = new System.Drawing.Size(155, 264);
            this.globalSlotListView.TabIndex = 61;
            // 
            // globalSlotBox
            // 
            this.globalSlotBox.Location = new System.Drawing.Point(386, 293);
            this.globalSlotBox.Name = "globalSlotBox";
            this.globalSlotBox.Size = new System.Drawing.Size(155, 20);
            this.globalSlotBox.TabIndex = 62;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 559);
            this.Controls.Add(this.generateSlots);
            this.Controls.Add(this.globalSlotBox);
            this.Controls.Add(this.globalSlotListView);
            this.Controls.Add(this.copyMonsterSlotGlobal);
            this.Controls.Add(this.removeMonsterSlotGlobal);
            this.Controls.Add(this.addMonsterSlotGlobal);
            this.Controls.Add(this.globalSlotLabel);
            this.Controls.Add(this.moveGameDownButton);
            this.Controls.Add(this.moveGameUpButton);
            this.Controls.Add(this.weight5);
            this.Controls.Add(this.weight4);
            this.Controls.Add(this.weight3);
            this.Controls.Add(this.weight2);
            this.Controls.Add(this.weight1);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.removeMonster);
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
            this.Controls.Add(this.removeGameButton);
            this.Controls.Add(this.removeAltGameButton);
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
            this.Text = "ReMixer Spawns Generator";
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
        private System.Windows.Forms.Button removeAltGameButton;
        private System.Windows.Forms.Button removeGameButton;
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
        private System.Windows.Forms.Button removeMonster;
        private System.Windows.Forms.TextBox weight5;
        private System.Windows.Forms.TextBox weight4;
        private System.Windows.Forms.TextBox weight3;
        private System.Windows.Forms.TextBox weight2;
        private System.Windows.Forms.TextBox weight1;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Button moveGameUpButton;
        private System.Windows.Forms.Button moveGameDownButton;
        private System.Windows.Forms.ToolTip generatorToolTip;
        private System.Windows.Forms.Label globalSlotLabel;
        private System.Windows.Forms.Button addMonsterSlotGlobal;
        private System.Windows.Forms.Button removeMonsterSlotGlobal;
        private System.Windows.Forms.Button copyMonsterSlotGlobal;
        private System.Windows.Forms.ListBox globalSlotListView;
        private System.Windows.Forms.TextBox globalSlotBox;
        private System.Windows.Forms.Button generateSlots;
    }
}

