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

        public  Bitmap characterRight;
        public  Bitmap characterLeft;
        public  Bitmap character;
        
         
        public int chaHeight;
        public int chaWidth;

        Size gameSize = new Size(1920, 1080);

        public Rectangle backgroundRec = new Rectangle(0, 0, 1920, 1080);

        public Rectangle platform1Rec = new Rectangle(50, 400, 326, 95);
        public Rectangle platform2Rec = new Rectangle(200, 800, 326, 95);
        public Rectangle platform3Rec = new Rectangle(350, 650, 326, 95);
        public Rectangle platform4Rec = new Rectangle(500, 400 , 326, 95);
        public Rectangle platform5Rec = new Rectangle(750, 220, 326, 95);
        public Rectangle platform6Rec = new Rectangle(1300, 200, 326, 95);
        public Rectangle platform7Rec = new Rectangle(1250, 500, 326, 95);
        public Rectangle platform8Rec = new Rectangle(1500, 700, 326, 95);
        public Rectangle platform9Rec = new Rectangle(750, 600, 326, 95);
        public Rectangle platform10Rec = new Rectangle(250, 200, 326, 95);

        public List<Rectangle> GamePlatformsBounds;


        public Game()
        {
            InitializeComponent();

#region Allgemeines  
            
            instance = this;

            ClientSize = new Size(gameSize.Width, gameSize.Height);            
            GameState.GroundLevel = 820;
            FormBorderStyle = FormBorderStyle.None;
            
            chaHeight = 167;
            chaWidth = 103;

            GameState.GameBoardWidth = 1920;
            GameState.GameBoardHeight = 1080;
            
            hinterbmp = new Bitmap("lvl1.bmp");
            hinterbmp1 = new Bitmap(hinterbmp, gameSize);
         
            anzeige = new Bitmap(gameSize.Width, gameSize.Height);

            platform = new Bitmap("platform.png");

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
            pbCharacterBounds.Image = global::Prototype_Virus_Game.Properties.Resources.characterRight;
            pbCharacterBounds.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCharacterBounds.BackColor = Color.Transparent;
            pbCharacterBounds.Parent = pbBackGround;

           
            lblScore.Parent = pbBackGround;
            lblScore.BringToFront();
            lblScore.Location = new Point(gameSize.Width / 2 - lblScore.Width, 20);

            lblLevelDisplay.BringToFront();

            //To Display Health
            pbHealth.Parent = pbBackGround;
            pbHealth.Location = new Point(1840,20);
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
                   
            DrawGameAssets();

            StartLevel();

            UiComponents.Components = new List<PictureBox>();
            UiComponents.Viruses = new List<Virus>();
            UiComponents.Character = pbCharacter;
            UiComponents.BackGround = pbBackGround;

            this.gameTimer.Tick += new EventHandler(new CharacterLogic().Logic);
            this.virusTimer.Tick += new EventHandler(new VirusLogic().Logic);
            this.KeyDown += new KeyEventHandler(new KeyDownEventHandler().Game_KeyDown);
            this.KeyUp += new KeyEventHandler(new KeyUpEventHandler().Game_KeyUp);

            this.pbCharacterBounds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickShootBullet);
           
                      
       
            #endregion
        }

#region Methoden

        private void MouseClickShootBullet(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bullet bullet = new Bullet();
                bullet.CreateProjectile();
            }
        }


        public void DrawGameAssets()
        {
            Graphics gb = Graphics.FromImage(hinterbmp1);

            gb.DrawImage(hinterbmp1, backgroundRec);
            Font f = new Font("Arial", 10);           

            int i = 1;
            foreach (var platformBounds in GamePlatformsBounds)
            {               
                gb.DrawImage(platform, platformBounds);
                gb.DrawString(Convert.ToString(i),f, Brushes.Gray, platformBounds.X, platformBounds.Y);
                i++;
            }

            gb.Dispose();

            pbBackGround.Image = hinterbmp1;           
        }
        
      public void GameOver()
      {
            GameOver go = new GameOver();
            virusTimer.Enabled = false;
            gameTimer.Enabled = false;

            go.Show();          
      }

        public void PlayerGotHit()
        {                  
            if (GameState.PlayerGotHit)
            {
                GameState.playerHealth--;
            }
            

                if (GameState.playerHealth == 3)
                {
                    Game.instance.pbHealth.Visible = true;
                    Game.instance.pbHealth1.Visible = true;
                    Game.instance.pbHealth2.Visible = true;
                }
                else if (GameState.playerHealth == 2)
                {
                    Game.instance.pbHealth.Visible = false;
                    Game.instance.pbHealth1.Visible = true;
                    Game.instance.pbHealth2.Visible = true;
                }
                else if (GameState.playerHealth == 1)
                {
                    Game.instance.pbHealth.Visible = false;
                    Game.instance.pbHealth1.Visible = false;
                    Game.instance.pbHealth2.Visible = true;
                }
                else
                {
                    Game.instance.pbHealth.Visible = false;
                    Game.instance.pbHealth1.Visible = false;
                    Game.instance.pbHealth2.Visible = false;

                    Game.instance.GameOver();
                }

            UiComponents.Viruses.RemoveAll(item => item.Dead == true);
            GameState.PlayerGotHit = false;
        }

        private void StartLevel()
        {
            

            pbCharacterBounds.Location = new Point(-100, GameState.GroundLevel);

            System.Windows.Forms.Timer start = new System.Windows.Forms.Timer();
            start.Enabled = true;
            start.Interval = 20;
            start.Tick += new EventHandler(MoveFirstSteps);


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

                    for (int i = 0; i < 10; i++)
                    {
                        var virus = new Virus();

                        UiComponents.AddVirus(virus);
                        ((ISupportInitialize)(virus)).BeginInit();
                        virus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickShootBullet);
                        this.Controls.Add(virus);
                        ((ISupportInitialize)(virus)).EndInit();
                    }

                    foreach (var virus in UiComponents.Viruses)
                    {
                        virus.BackColor = Color.Transparent;
                        virus.Parent = pbBackGround;
                        DoubleBuffered = true;
                    }
                }
            }
        }
        

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

            alreadyInFolder = Directory.GetFiles(path,"*.png").Length;

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
