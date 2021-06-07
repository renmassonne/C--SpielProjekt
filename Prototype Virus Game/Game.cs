using Prototype_Virus_Game.GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prototype_Virus_Game
{

    public partial class Game : Form
    {
        public static Game instance;

        private Bitmap hinterbmp;
        private Bitmap hinterbmp1;
        private Bitmap anzeige;
        private Bitmap platform;

        public Bitmap characterRight;
        public Bitmap characterLeft;
        public Bitmap character;


        public int chaHeight;
        public int chaWidth;

        Size gameSize = new Size(1920, 1080);

        public Rectangle backgroundRec = new Rectangle(0, 0, 1920, 1080);

        private static int platformHöhe = 50;
        public Rectangle platform1Rec = new Rectangle(50, 400, 326, platformHöhe);
        public Rectangle platform2Rec = new Rectangle(200, 800, 326, platformHöhe);
        public Rectangle platform3Rec = new Rectangle(350, 650, 326, platformHöhe);
        public Rectangle platform4Rec = new Rectangle(500, 400, 326, platformHöhe);
        public Rectangle platform5Rec = new Rectangle(750, 220, 326, platformHöhe);
        public Rectangle platform6Rec = new Rectangle(1300, 200, 326, platformHöhe);
        public Rectangle platform7Rec = new Rectangle(1250, 500, 326, platformHöhe);
        public Rectangle platform8Rec = new Rectangle(1500, 700, 326, platformHöhe);
        public Rectangle platform9Rec = new Rectangle(750, 600, 326, platformHöhe);
        public Rectangle platform10Rec = new Rectangle(250, 200, 326, platformHöhe);

        public List<Rectangle> GamePlatformsBounds;


        public Game()
        {
            InitializeComponent();

            #region Allgemeines  

            instance = this;

            ClientSize = new Size(gameSize.Width, gameSize.Height);
            GameState.GroundLevel = 820;  //lvl2:745 (falsch) lvl3: auch ca 750
            FormBorderStyle = FormBorderStyle.None;

            chaHeight = 167;
            chaWidth = 103;

            GameState.GameBoardWidth = 1920;
            GameState.GameBoardHeight = 1080;

            hinterbmp = new Bitmap(Properties.Resources.lvl1);

            hinterbmp1 = new Bitmap(hinterbmp, gameSize);

            anzeige = new Bitmap(gameSize.Width, gameSize.Height);

            platform = new Bitmap(Properties.Resources.lvl1_plattform);

            DoubleBuffered = true;
            #endregion
        }


        private void Game_Load(object sender, EventArgs e)
        {
            #region DesignerKram 

            pbBackGround.Size = gameSize;
            pbBackGround.Visible = true;
            pbBackGround.BringToFront();

            pbCharacterBounds.Size = new Size(chaWidth, chaHeight);
            pbCharacterBounds.Location = new Point(100, GameState.GroundLevel);
            pbCharacterBounds.Visible = true;
            pbCharacterBounds.BringToFront();
            pbCharacterBounds.Image = Properties.Resources.characterRight;
            pbCharacterBounds.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCharacterBounds.BackColor = Color.Transparent;
            pbCharacterBounds.Parent = pbBackGround;


            lblScore.Parent = pbBackGround;
            lblScore.BringToFront();
            lblScore.Location = new Point(gameSize.Width / 2 - lblScore.Width, 20);

            lblLevelDisplay.BringToFront();

            //To Display Health
            pbHealth.Parent = pbBackGround;
            pbHealth.Location = new Point(1840, 20);
            pbHealth.BringToFront();

            pbHealth1.Parent = pbBackGround;
            pbHealth1.Location = new Point(1780, 20);
            pbHealth1.BringToFront();

            pbHealth2.Parent = pbBackGround;
            pbHealth2.Location = new Point(1720, 20);
            pbHealth2.BringToFront();

            GamePlatformsBounds = new List<Rectangle>();

            GamePlatformsBounds.Add(platform1Rec);
            GamePlatformsBounds.Add(platform2Rec);
            GamePlatformsBounds.Add(platform3Rec);
            GamePlatformsBounds.Add(platform4Rec);
            GamePlatformsBounds.Add(platform5Rec);
            GamePlatformsBounds.Add(platform6Rec);
            GamePlatformsBounds.Add(platform7Rec);
            GamePlatformsBounds.Add(platform8Rec);
            GamePlatformsBounds.Add(platform9Rec);
            GamePlatformsBounds.Add(platform10Rec);



            foreach (var platformBound in GamePlatformsBounds)
            {
                Components.GamePlatform platform = new Components.GamePlatform(platformBound);

                ((ISupportInitialize)(platform)).BeginInit();
                Controls.Add(platform);
                ((ISupportInitialize)(platform)).EndInit();
            }

            DrawGameAssets(1);

           

            UiComponents.Components = new List<PictureBox>();
            UiComponents.Viruses = new List<Virus>();
            UiComponents.Character = pbCharacter;
            UiComponents.BackGround = pbBackGround;

            this.gameTimer.Tick += new EventHandler(new CharacterLogic().Logic);
            this.virusTimer.Tick += new EventHandler(new VirusLogic().Logic);


            this.pbCharacterBounds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickShootBullet);



            #endregion
        }

        #region Methoden

        //Methode um Schuss abzufeuern
        private void MouseClickShootBullet(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bullet bullet = new Bullet();
                bullet.CreateProjectile();
            }
        }

        // Methode um Hintergrund und Plattformen zu zeichen und als Hintergrund festzulegen
        public void DrawGameAssets(int level)
        {
            if (level == 1)
            {

                Graphics gb = Graphics.FromImage(hinterbmp1);

                gb.DrawImage(hinterbmp1, backgroundRec);
                Font f = new Font("Arial", 10);

                int i = 1;
                foreach (var platformBounds in GamePlatformsBounds)
                {
                    gb.DrawImage(platform, platformBounds);
                    gb.DrawString(Convert.ToString(i), f, Brushes.Gray, platformBounds.X, platformBounds.Y);
                    i++;
                }

                gb.Dispose();

                pbBackGround.Image = hinterbmp1;
            }

            if (level == 2)
            {
                hinterbmp = new Bitmap(Properties.Resources.lvl2);

                hinterbmp1 = new Bitmap(hinterbmp, gameSize);

                platform = new Bitmap(Properties.Resources.lvl2_plattform);
               


                Graphics gb = Graphics.FromImage(hinterbmp1);

                gb.DrawImage(hinterbmp1, backgroundRec);
                Font f = new Font("Arial", 10);

                int i = 1;
                foreach (var platformBounds in GamePlatformsBounds)
                {
                    gb.DrawImage(platform, platformBounds);
                    gb.DrawString(Convert.ToString(i), f, Brushes.Gray, platformBounds.X, platformBounds.Y);
                    i++;
                }

                gb.Dispose();

                pbBackGround.Image = hinterbmp1;

                GameState.GroundLevel = 750;
                lblLevelDisplay.Text = "Level 2";

            }
            if (level == 3)
            {
                hinterbmp = new Bitmap(Properties.Resources.lvl3);

                hinterbmp1 = new Bitmap(hinterbmp, gameSize);

                platform = new Bitmap(Properties.Resources.lvl3_plattform);


                Graphics gb = Graphics.FromImage(hinterbmp1);

                gb.DrawImage(hinterbmp1, backgroundRec);
                Font f = new Font("Arial", 10);

                int i = 1;
                platformHöhe = 100;
                foreach (var platformBounds in GamePlatformsBounds)
                {
                    gb.DrawImage(platform, platformBounds);
                    gb.DrawString(Convert.ToString(i), f, Brushes.Gray, platformBounds.X, platformBounds.Y);
                    i++;
                }

                gb.Dispose();

                pbBackGround.Image = hinterbmp1;

                GameState.GroundLevel = 750;
                lblLevelDisplay.Text = "Level 3";
            }
            StartLevel();
            
        }


 //Methode um VerliererForm bei 0 Leben anzuzeigen und Spiel anhalten
        public void GameOver()
        {
            GameOver go = new GameOver();
            virusTimer.Enabled = false;
            gameTimer.Enabled = false;

            go.Show();
        }

//Methode zur Abziehung eines Lebens bei Kollision mit Virus
        public void PlayerGotHit()
        {
            if (GameState.PlayerGotHit)
            {
                GameState.playerHealth--;
            }

            if (GameState.playerHealth == 3)
            {
                pbHealth.Visible = true;
                pbHealth1.Visible = true;
                pbHealth2.Visible = true;
            }
            else if (GameState.playerHealth == 2)
            {
                pbHealth.Visible = false;
                pbHealth1.Visible = true;
                pbHealth2.Visible = true;
            }
            else if (GameState.playerHealth == 1)
            {
                pbHealth.Visible = false;
                pbHealth1.Visible = false;
                pbHealth2.Visible = true;
            }
            else
            {
                pbHealth.Visible = false;
                pbHealth1.Visible = false;
                pbHealth2.Visible = false;

               GameOver();
            }

            UiComponents.Viruses.RemoveAll(item => item.Dead == true);
            GameState.PlayerGotHit = false;
        }

//Methode um "hineingehen" in Level zu simulieren und Level zu starten
        private void StartLevel()
        {
            pbCharacterBounds.Location = new Point(-100, GameState.GroundLevel);

            System.Windows.Forms.Timer start = new System.Windows.Forms.Timer();
            start.Enabled = true;
            start.Interval = 20;
            start.Tick += new EventHandler(MoveFirstSteps);
            GameState.HighScore = 0;

            virusTimer.Enabled = true;
            gameTimer.Enabled = true;

            void MoveFirstSteps(object sender, EventArgs e)
            {
                if (pbCharacterBounds.Location.X < 100)
                {
                    pbCharacterBounds.Left += 3;
                }
                else
                {
                    start.Enabled = false;

                    for (int i = 0; i < 8; i++)
                    {
                        var virusNormal = new NormalVirus();

                        UiComponents.AddVirus(virusNormal);
                        ((ISupportInitialize)(virusNormal)).BeginInit();
                        virusNormal.MouseClick += new MouseEventHandler(this.MouseClickShootBullet);
                        this.Controls.Add(virusNormal);
                        ((ISupportInitialize)(virusNormal)).EndInit();
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        var virusDick = new ShieldedVirus();

                        UiComponents.AddVirus(virusDick);
                        ((ISupportInitialize)(virusDick)).BeginInit();
                        virusDick.MouseClick += new MouseEventHandler(this.MouseClickShootBullet);
                        this.Controls.Add(virusDick);
                        ((ISupportInitialize)(virusDick)).EndInit();
                    }

                    foreach (var virus in UiComponents.Viruses)
                    {
                        virus.BackColor = Color.Transparent;
                        virus.Parent = pbBackGround;
                        DoubleBuffered = true;
                    }

                    this.KeyDown += new KeyEventHandler(new KeyDownEventHandler().Game_KeyDown);
                    this.KeyUp += new KeyEventHandler(new KeyUpEventHandler().Game_KeyUp);
                }
            }
        }






//nicht mehr benötigte Methode um neues Bild mit eingefügten Plattformen neu zu speichern 

        public void DrawNewBackGroundImage()
        {
            hinterbmp = new Bitmap("lvl1.bmp");
            hinterbmp1 = new Bitmap(hinterbmp, gameSize);


            anzeige = new Bitmap(gameSize.Width, gameSize.Height);

            platform = new Bitmap("platform.png");

            pbBackGround.ClientSize = hinterbmp1.Size;

            Graphics gb = Graphics.FromImage(anzeige);

            gb.DrawImage(hinterbmp1, backgroundRec);

            foreach (var platformBounds in GamePlatformsBounds)
            {
                gb.DrawImage(platform, platformBounds);
            }

            gb.Dispose();

            int i;
            string path = @"../NeueBilder";
            if (!(Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            }

            int alreadyInFolder;

            alreadyInFolder = Directory.GetFiles(path, "*.png").Length;

            if (alreadyInFolder > 0)
            {
                i = alreadyInFolder + 1;
            }
            else
            {
                i = 1;
            }

            string name = $"NeuerBackground{i}.png";
            anzeige.Save($@"{path}\{name}", ImageFormat.Png);
            MessageBox.Show("Bild gespeichert!");
        }



        #endregion


    }
}
