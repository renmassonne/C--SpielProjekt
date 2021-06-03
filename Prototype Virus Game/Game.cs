using Prototype_Virus_Game.GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        private  Bitmap hinterbmp1;
        private  Bitmap anzeige;
        private Bitmap platform;

        public  Bitmap characterRight;
        public Bitmap characterLeft;
        public  Bitmap character;
        public Bitmap bullet;
       
   
        public int chaHeight;
        public int chaWidth;

        Size gameSize = new Size(1920, 1080);

        public RectangleF backgroundRec = new RectangleF(0, 0, 1920, 1080);
        public RectangleF platform1Rec = new RectangleF(350, 800, 326, 95);
        public RectangleF platform2Rec = new RectangleF(100, 900, 326, 95);
        public RectangleF platform3Rec = new RectangleF(400,550, 326, 95);
        public RectangleF platform4Rec = new RectangleF(1200, 700, 326, 95);


        public List<Rectangle> GamePlatforms;

        




        public Game()
        {
            InitializeComponent();
            instance = this;
            StartLevel();

            hinterbmp = new Bitmap("lvl1.bmp");
            hinterbmp1 = new Bitmap(hinterbmp, gameSize);

            Bitmap chaRight = new Bitmap("characterRight.png");
            characterRight = new Bitmap(chaRight, chaWidth, chaHeight);
            Bitmap chaLeft = new Bitmap("characterLeft.png");
            characterLeft = new Bitmap(chaLeft, chaWidth, chaHeight);
            bullet = new Bitmap(100, 100);

            anzeige = new Bitmap(gameSize.Width, gameSize.Height);

            platform = new Bitmap("platform.png");
            pbBackGround.ClientSize = hinterbmp1.Size;
            pbBackGround.Image = hinterbmp1;

            DoubleBuffered = true;

            character = characterRight;

            DrawGameAssets(100,GameState.GroundLevel);

            GamePlatforms = new List<Rectangle>();
           

            UiComponents.Components = new List<PictureBox>();
            UiComponents.Viruses = new List<Virus>();
            UiComponents.Character = this.pbCharacter;
            UiComponents.BackGround = this.pbBackGround;

            this.timer.Tick += new EventHandler(new CharacterLogic().Logic);
            this.timervirus.Tick += new EventHandler(new VirusLogic().Logic);
            this.KeyDown += new KeyEventHandler(new KeyDownEventHandler().Game_KeyDown);
            this.KeyUp += new KeyEventHandler(new KeyUpEventHandler().Game_KeyUp);
           

            GameState.GameBoardHeight = 1920;
            GameState.GameBoardWidth = 1080;
        }


        private void Game_Load(object sender, EventArgs e)
        {
            pbBackGround.Size = gameSize;

            pbCharacterBounds.Size = new Size(chaWidth, chaHeight);
            pbCharacterBounds.Location = new Point(100, GameState.GroundLevel);
            pbCharacterBounds.Visible = false;
            //pbCharacterBounds.BackColor = Color.Black;
            //pbCharacterBounds.BringToFront();


            pbPlatform1.Size = new Size(326, 95);
            pbPlatform1.Location = new Point((int)platform1Rec.X, (int)platform1Rec.Y);
            pbPlatform1.Visible = false;
            Rectangle platform1Bounds = pbPlatform1.Bounds;


            pbPlatform2.Size = new Size(326, 95);
            pbPlatform2.Location = new Point((int)platform2Rec.X, (int)platform2Rec.Y);
            pbPlatform2.Visible = false;
            Rectangle platform2Bounds = pbPlatform2.Bounds;

            pbPlatform3.Size = new Size(326, 95);
            pbPlatform3.Location = new Point((int)platform3Rec.X, (int)platform3Rec.Y);
            pbPlatform3.Visible = false;
            Rectangle platform3Bounds = pbPlatform3.Bounds;

            pbPlatform4.Size = new Size(326, 95);
            pbPlatform4.Location = new Point((int)platform4Rec.X, (int)platform4Rec.Y);
            pbPlatform4.Visible = false;
            Rectangle platform4Bounds = pbPlatform4.Bounds;


            pbBullet.BringToFront();
            pbBullet.Visible = false;
            pbBullet.BackColor = Color.Transparent;
            pbBullet.Parent = pbBackGround;


            GamePlatforms.Add(platform1Bounds);
            GamePlatforms.Add(platform2Bounds);
            GamePlatforms.Add(platform3Bounds);
            GamePlatforms.Add(platform4Bounds);

          

            for (int i = 0; i < 10; i++)
            {
                var virus = new Virus();
                UiComponents.AddVirus(virus);
                ((ISupportInitialize)(virus)).BeginInit();
                this.Controls.Add(virus);
                ((ISupportInitialize)(virus)).EndInit();
            }

            foreach (var virus in UiComponents.Viruses)
            {
                virus.BackColor = Color.Transparent;
                virus.Parent = pbBackGround;
            }


            //Graphics gb = Graphics.FromImage(anzeige);

            //gb.DrawImage(hinterbmp1, backgroundRec);
            //gb.DrawImage(platform, platform1Rec);
            //gb.DrawImage(platform, platform2Rec);
            //gb.DrawImage(platform, platform3Rec);
            //gb.DrawImage(platform, platform4Rec);



            //gb.Dispose();


          
           

        }

        private void StartLevel()
        {
            ClientSize = new Size(1920, 1080);
            GameState.GroundLevel = 820;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;

            chaHeight = 167;
            chaWidth = 103;

        }   
        
        public void DrawGameAssets(int x, int y)
        {
            Graphics gb = Graphics.FromImage(anzeige);

            gb.DrawImage(hinterbmp1, backgroundRec);
            gb.DrawImage(platform, platform1Rec);
            //gb.DrawImage(platform, platform2Rec);
            //gb.DrawImage(platform, platform3Rec);
            //gb.DrawImage(platform, platform4Rec);


            gb.DrawImage(character, x, y, chaWidth, chaHeight);
            gb.Dispose();

            pbBackGround.Image = anzeige;
        }

        private void MouseClickShootBullet(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bullet bullet = new Bullet();              
                bullet.CreateProjectile();

                
            }
        }
    }
}
