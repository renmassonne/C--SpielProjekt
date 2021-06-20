using Prototype_Virus_Game.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        DateTime GameTimer { get; set; }
        public Stopwatch PlayTime { get; set; }
        public DateTime PointObjectTimer { get; set; }
        public DateTime MutatedVirusSpawnTimer { get; set; }
        public ProgressBar BossHealthBar { get; set; }

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
                        
           
            pbBossHealthBar.Location = new Point(400, 1000);
            pbBossHealthBar.Size = new Size(800, 25);
            pbBossHealthBar.BackColor = Color.Red;            
            pbBossHealthBar.Value = 100;
            
            
         

            lblScore.Parent = pbBackGround;
            lblScore.BringToFront();
            lblScore.Location = new Point(gameSize.Width / 2 - lblScore.Width, 20);

            lblLevelDisplay.Text = "Level 1";
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

            Items.ItemList = new List<Items>();

            this.gameTimer.Tick += new EventHandler(new CharacterLogic().Logic);
            gameTimer.Tick += new EventHandler(new ItemLogic().Logic);
            this.virusTimer.Tick += new EventHandler(new VirusLogic().Logic);
            

            this.pbCharacterBounds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickShootBullet);

            PlayTime = new Stopwatch();
           
           HighScoreLogic.Load();

            #endregion
        }

        #region Methoden

        //Methode um Schuss abzufeuern
        public void MouseClickShootBullet(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BulletLogic bullet = new BulletLogic();
                bullet.CreateProjectile();
            }
        }

        // Methode um Hintergrund und Plattformen zu zeichen und als Hintergrund festzulegen
        public void DrawGameAssets(int level)
        {
            if (level == 1)
            {

                platform2Rec.Width = 500;

                Virus.VirusSpawnOrder.Add("nv");
                Virus.VirusSpawnOrder.Add("nv");
                Virus.VirusSpawnOrder.Add("sv");
                Virus.VirusSpawnOrder.Add("nv");
                Virus.VirusSpawnOrder.Add("sv");
                Virus.VirusSpawnOrder.Add("av");
                Virus.VirusSpawnOrder.Add("nv");
                Virus.VirusSpawnOrder.Add("dv");


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
                gameTimer.Enabled = false;
                virusTimer.Enabled = false;

                platform2Rec.Width = 2000;

                Virus.VirusSpawnOrder.Add("av");
                Virus.VirusSpawnOrder.Add("nv");
                Virus.VirusSpawnOrder.Add("sv");
                Virus.VirusSpawnOrder.Add("nv");
                Virus.VirusSpawnOrder.Add("sv");
                Virus.VirusSpawnOrder.Add("av");
                Virus.VirusSpawnOrder.Add("nv");
                Virus.VirusSpawnOrder.Add("tv");
                Virus.VirusSpawnOrder.Add("dv");


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
                gameTimer.Enabled = false;
                virusTimer.Enabled = false;

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
                lblLevelDisplay.Text ="Level 3";
                
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
        public void DisplayHealth()
        {           

            if (GameState.PlayerHealth == 3)
            {
                pbHealth.Visible = true;
                pbHealth1.Visible = true;
                pbHealth2.Visible = true;
            }
            else if (GameState.PlayerHealth == 2)
            {
                pbHealth.Visible = false;
                pbHealth1.Visible = true;
                pbHealth2.Visible = true;
            }
            else if (GameState.PlayerHealth == 1)
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
        }

//Methode um "hineingehen" in Level zu simulieren und Level zu starten
        private void StartLevel()
        {
            pbCharacterBounds.Location = new Point(-100, GameState.GroundLevel);

            pbCharacterBounds.Image = Properties.Resources.characterRight;
            pbCharacterBounds.Visible = true;
           
            System.Windows.Forms.Timer start = new System.Windows.Forms.Timer();
            start.Enabled = true;
            start.Interval = 20;
            start.Tick += new EventHandler(MoveFirstSteps);
            GameState.Score = 0;

          

            

            void MoveFirstSteps(object sender, EventArgs e)
            {
                if (pbCharacterBounds.Location.X < 100)
                {
                    pbCharacterBounds.Left += 3;
                }
                else
                {
                    start.Enabled = false;

                    if (GameState.PlayerHealth == 3)
                    {
                        pbHealth.Visible = true;
                        pbHealth1.Visible = true;
                        pbHealth2.Visible = true;
                    }
                    else if (GameState.PlayerHealth == 2)
                    {
                        pbHealth.Visible = false;
                        pbHealth1.Visible = true;
                        pbHealth2.Visible = true;
                    }
                    else if (GameState.PlayerHealth == 1)
                    {
                        pbHealth.Visible = false;
                        pbHealth1.Visible = false;
                        pbHealth2.Visible = true;
                    }
                    //pbHealth.Visible = true;
                    //pbHealth1.Visible = true;
                    //fpbHealth2.Visible = true;
                    lblLevelDisplay.Visible = true;
                    


                    virusTimer.Enabled = true;
                    gameTimer.Enabled = true;

                    if (lblLevelDisplay.Text.Equals("Level 1"))
                    {
                        PlayTime.Start();
                    }
                    if (lblLevelDisplay.Text.Equals("Level 3"))
                    {
                      Virus.StartBossLevel();
                    }
                    
                    

                   

                    GameTimer = DateTime.Now;
                    PointObjectTimer = GameTimer.AddSeconds(10);
                    MutatedVirusSpawnTimer = GameTimer.AddSeconds(25);



                    this.KeyDown += new KeyEventHandler(new KeyDownEventHandler().Game_KeyDown);
                    this.KeyUp += new KeyEventHandler(new KeyUpEventHandler().Game_KeyUp);

                    
                }
            }
        }
        #endregion


    }
}
