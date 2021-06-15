using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Prototype_Virus_Game
{
    public class Virus : PictureBox
    {
        public static Random randomizer = new Random();

        public static List<string> VirusSpawnOrder = new List<string>();
        public static int SpawnOrderIteration = 0;

        public Point TargetPosition { get; set; }
        public bool Dead { get; set; }
        public string AIType { get; set; }
        public int VirusHealth { get; set; }
        public Size VirusSize { get; set; }
        public int VirusSpeed { get; set; }
        public int Points { get; set; }


        public DateTime timerEnd;
        public bool virusAction;


        public static void SpawnVirus()
        {
            string type = "";

            if (UiComponents.Viruses.Count < 9)
            {
                type = VirusSpawnOrder[SpawnOrderIteration];
                SpawnOrderIteration++;
                if (SpawnOrderIteration > VirusSpawnOrder.Count - 1)
                {
                    SpawnOrderIteration = 0;
                }

            }

            if (type.Equals("nv"))
            {
                var normalV = new NormalVirus();
            }

            if (type.Equals("sv"))
            {

                var shieldedV = new ShieldedVirus();


                ((ISupportInitialize)(shieldedV)).BeginInit();
                shieldedV.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
                shieldedV.BackColor = Color.Transparent;
                shieldedV.Parent = Game.instance.pbBackGround;
                shieldedV.DoubleBuffered = true;
                UiComponents.AddVirus(shieldedV);
                ((ISupportInitialize)(shieldedV)).EndInit();

            }
            if (type.Equals("av"))
            {

                var aggroV = new AggroVirus();


                ((ISupportInitialize)(aggroV)).BeginInit();
                aggroV.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
                aggroV.BackColor = Color.Transparent;
                aggroV.Parent = Game.instance.pbBackGround;
                aggroV.DoubleBuffered = true;
                UiComponents.AddVirus(aggroV);
                ((ISupportInitialize)(aggroV)).EndInit();

            }
            if (type.Equals("tv"))
            {

                var teleporterV = new TeleporterVirus();


                ((ISupportInitialize)(teleporterV)).BeginInit();
                teleporterV.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
                teleporterV.BackColor = Color.Transparent;
                teleporterV.Parent = Game.instance.pbBackGround;
                teleporterV.DoubleBuffered = true;
                UiComponents.AddVirus(teleporterV);
                ((ISupportInitialize)(teleporterV)).EndInit();

            }
            if (DateTime.Now >= Game.instance.MutatedVirusSpawnTimer)
            {

                var mutatedV = new MutatedVirus();


                ((ISupportInitialize)(mutatedV)).BeginInit();
                mutatedV.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
                mutatedV.BackColor = Color.Transparent;
                mutatedV.Parent = Game.instance.pbBackGround;
                mutatedV.DoubleBuffered = true;
                UiComponents.AddVirus(mutatedV);
                ((ISupportInitialize)(mutatedV)).EndInit();

                Game.instance.MutatedVirusSpawnTimer = Game.instance.MutatedVirusSpawnTimer.AddSeconds(25);

            }
            if (type.Equals("dv"))
            {

                var dividerV = new DividerVirus();


                ((ISupportInitialize)(dividerV)).BeginInit();
                dividerV.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
                dividerV.BackColor = Color.Transparent;
                dividerV.Parent = Game.instance.pbBackGround;
                dividerV.DoubleBuffered = true;
                UiComponents.AddVirus(dividerV);
                ((ISupportInitialize)(dividerV)).EndInit();

            }
        }



        public void PositionVirus()
        {
            if (GameState.BossFight == false)
            {

                do
                {
                    Point spawn;
                    int side = randomizer.Next(1, 4);

                    if (side == 1) //über Spielfeld
                    {
                        int x = randomizer.Next(0, GameState.GameBoardWidth);
                        int y = 0 - VirusSize.Height;
                        spawn = new Point(x, y);
                    }
                    else if (side == 2) //linke Seite
                    {
                        int x = 0 - VirusSize.Width;
                        int y = randomizer.Next(0, GameState.GameBoardHeight - 350);
                        spawn = new Point(x, y);
                    }
                    else // rechte Seite
                    {
                        int x = GameState.GameBoardWidth;
                        int y = randomizer.Next(0, GameState.GameBoardHeight - 350);
                        spawn = new Point(x, y);
                    }

                    Location = spawn;
                } while (IntersectsWithNonPlayerUiComponent());
            }
            else
            {              
                do
                {
                    Point spawn;                   
                    int x = 1546 - VirusSize.Width/2;
                    int y = randomizer.Next(0, GameState.GameBoardHeight - 100 - VirusSize.Height);
                    spawn = new Point(x, y);                  

                    Location = spawn;
                } while (IntersectsWithNonPlayerUiComponent());
            }
        }

        public Point CalculateRandomPosition()
        {

            int x = randomizer.Next(0, GameState.GameBoardWidth - 100);
            int y = randomizer.Next(0, GameState.GroundLevel);
            var position = new Point(x, y);
            return position;
        }


        internal void RecalculateTargetPosition()
        {
            TargetPosition = CalculateRandomPosition();
        }

        internal Point CalculateRandomPositionBoss()
        {

            int x = GameState.GameBoardWidth - Bounds.Width - 50;
            int y = randomizer.Next(100, GameState.GroundLevel - Height);
            var position = new Point(x, y);
            return position;
        }

        internal void RecalculateRandomPositionBoss()
        {
            TargetPosition = CalculateRandomPositionBoss();
        }

        internal bool IsTargetPositionReached()
        {
            return Location.X == TargetPosition.X && Location.Y == TargetPosition.Y;
        }



        public void TeleportVirus(Virus virus, int ChaX, int ChaY)
        {
            Rectangle playerSafeZone = new Rectangle(ChaX - Game.instance.pbCharacterBounds.Width, ChaY - Game.instance.pbCharacterBounds.Height, Game.instance.pbCharacterBounds.Width * 3, Game.instance.pbCharacterBounds.Height * 3);
            Rectangle r;
            Point newLocation;
            int x;
            int y;
            do
            {
                x = randomizer.Next(0, GameState.GameBoardWidth - virus.Width);
                y = randomizer.Next(0, GameState.GroundLevel);
                newLocation = new Point(x, y);

                r = new Rectangle(x, y, virus.Width, virus.Height);

            } while (IsThisAFreeSpace(r) == false || r.IntersectsWith(playerSafeZone));

            virus.Location = newLocation;

            DateTime timerStart = DateTime.Now;
            timerEnd = timerStart.AddSeconds(5);
        }


        public void DivideAction(Virus virus)
        {
            DividerVirus dvKlein1 = new DividerVirus();
            DividerVirus dvKlein2 = new DividerVirus();

            ((ISupportInitialize)(dvKlein1)).BeginInit();
            dvKlein1.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
            dvKlein1.BackColor = Color.Transparent;
            dvKlein1.Parent = Game.instance.pbBackGround;

            // evtl noch einen Killswitch einbauen, sodass es in seltenen Fällen, bei denen absoulut kein Platz in der randomZone ist es zu keinem loop kommt
            Rectangle r;
            Point newLocation;
            int x;
            int y;
            do
            {
                x = randomizer.Next(virus.Bounds.X - virus.Bounds.Width, virus.Bounds.X + virus.Bounds.Width * 2);
                y = randomizer.Next(virus.Bounds.Y - virus.Bounds.Height, virus.Bounds.Y + virus.Bounds.Width * 2);
                newLocation = new Point(x, y);


                r = new Rectangle(x, y, 70, 50);
            } while (IsThisAFreeSpace(r) == false);

            dvKlein1.VirusHealth = 1;
            dvKlein1.Location = newLocation;
            dvKlein1.Size = new Size(70, 50);
            dvKlein1.DoubleBuffered = true;
            dvKlein1.Points = 1;
            UiComponents.AddVirus(dvKlein1);
            ((ISupportInitialize)(dvKlein1)).EndInit();

            ((ISupportInitialize)(dvKlein2)).BeginInit();
            dvKlein2.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
            dvKlein2.BackColor = Color.Transparent;
            dvKlein2.Parent = Game.instance.pbBackGround;
            // evtl noch einen Killswitch einbauen, sodass es in seltenen Fällen, bei denen absoulut kein Platz in der randomZone ist es zu keinem loop kommt
            do
            {
                x = randomizer.Next(virus.Bounds.X - virus.Bounds.Width, virus.Bounds.X + virus.Bounds.Width * 2);
                y = randomizer.Next(virus.Bounds.Y - virus.Bounds.Height, virus.Bounds.Y + virus.Bounds.Width * 2);
                newLocation = new Point(x, y);

                r = new Rectangle(x, y, 70, 50);
            } while (IsThisAFreeSpace(r) == false);
            dvKlein2.Location = newLocation;

            dvKlein2.Size = new Size(70, 50);
            dvKlein2.DoubleBuffered = true;
            dvKlein2.VirusHealth = 1;
            dvKlein2.Points = 1;
            UiComponents.AddVirus(dvKlein2);
            ((ISupportInitialize)(dvKlein2)).EndInit();

            dvKlein1.RecalculateTargetPosition();
            dvKlein2.RecalculateTargetPosition();

            Game.instance.Controls.Remove(virus);
            UiComponents.Viruses.Remove(virus);
            virus.Dispose();
        }

        public static void StartBossLevel()
        {

            for (int i = 0; i < 4; i++)
            {
                var normalV = new NormalVirus();

                ((ISupportInitialize)(normalV)).BeginInit();
                normalV.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
                normalV.BackColor = Color.Transparent;
                normalV.Parent = Game.instance.pbBackGround;
                normalV.DoubleBuffered = true;
                UiComponents.AddVirus(normalV);
                ((ISupportInitialize)(normalV)).EndInit();
            }

            var shieldedV = new ShieldedVirus();

            ((ISupportInitialize)(shieldedV)).BeginInit();
            shieldedV.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
            shieldedV.BackColor = Color.Transparent;
            shieldedV.Parent = Game.instance.pbBackGround;
            shieldedV.DoubleBuffered = true;
            UiComponents.AddVirus(shieldedV);
            ((ISupportInitialize)(shieldedV)).EndInit();

        }


        public static void BossFight()
        {

            BossVirus bV = new BossVirus();
            ((ISupportInitialize)(bV)).BeginInit();
            bV.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
            bV.BackColor = Color.Transparent;
            bV.Parent = Game.instance.pbBackGround;
            bV.DoubleBuffered = true;
            bV.Location = new Point(GameState.GameBoardWidth + 20, 200);
            UiComponents.AddVirus(bV);
            ((ISupportInitialize)(bV)).EndInit();

            Game.instance.pbBossHealthBar.Parent = Game.instance.pbBackGround;
            Game.instance.pbBossHealthBar.Value = 100;
            Game.instance.pbBossHealthBar.BringToFront();


            GameState.BossFight = true;

        }


        public static bool IsThisAFreeSpace(Rectangle check)
        {
            foreach (var virus in UiComponents.Viruses)
            {
                if (virus.Bounds.IntersectsWith(check))
                {
                    return false;
                }

            }
            return true;
        }

        public Point ChasePlayer()
        {
            int x = Game.instance.pbCharacterBounds.Location.X;
            int y = Game.instance.pbCharacterBounds.Location.Y + 60;
            var position = new Point(x, y);
            return position;
        }

        private bool IntersectsWithNonPlayerUiComponent()
        {
            foreach (var uiCompontent in UiComponents.Components)
            {
                if (Bounds.IntersectsWith(uiCompontent.Bounds)
                    && uiCompontent != UiComponents.BackGround)
                {
                    return true;
                }
            }
            return false;
        }



        public Bitmap ScaleImage(Bitmap graphic, Size s)
        {
            Bitmap scaledGraphics = new Bitmap(s.Width, s.Height);
            using (Graphics graphics = Graphics.FromImage(scaledGraphics))
            {
                graphics.DrawImage(graphic, 0, 0, s.Width, s.Height);
            }
            return scaledGraphics;
        }

    }


    //--------------------------------------------------------VirenKlassen--------------------------------------------------------------------
    public class NormalVirus : Virus
    {

        public NormalVirus()
        {

            VirusSize = new Size(100, 85);

            Size = VirusSize;
            Anchor = AnchorStyles.None;
            BackgroundImageLayout = ImageLayout.Stretch;
            Image = ScaleImage(Properties.Resources.VirusNormal, VirusSize);
            Margin = new Padding(3, 2, 3, 2);
            Name = "pbVirus";
            SizeMode = PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 1;
            VirusSpeed = 1;
            AIType = "passive";
            Points = 1;


            BackColor = Color.Transparent;
            Parent = Game.instance.pbBackGround;
            DoubleBuffered = true;


            PositionVirus();
            TargetPosition = CalculateRandomPosition();
            MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
            UiComponents.AddVirus(this);

            ((ISupportInitialize)(this)).BeginInit();
            ((ISupportInitialize)(this)).EndInit();
        }


    }

    public class ShieldedVirus : Virus
    {
        public ShieldedVirus()
        {
            VirusSize = new Size(160, 142);

            Size = VirusSize;
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.VirusDickSchild, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 3;
            VirusSpeed = 1;
            AIType = "passive";
            Points = 2;

            PositionVirus();
            TargetPosition = CalculateRandomPosition();
        }

    }
    public class AggroVirus : Virus
    {
        public AggroVirus()
        {
            VirusSize = new Size(100, 76);

            Size = VirusSize;
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.AggresiverVirus, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 1;
            VirusSpeed = 2;
            AIType = "aggressive";
            Points = 3;

            PositionVirus();
            TargetPosition = ChasePlayer();
        }
    }
    public class TeleporterVirus : Virus
    {

        public TeleporterVirus()
        {
            VirusSize = new Size(100, 76);


            Size = VirusSize;
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.VirusTeleporter, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 1;
            VirusSpeed = 1;
            AIType = "passive";
            Points = 3;


            DateTime timerStart = DateTime.Now;
            timerEnd = timerStart.AddSeconds(5);

            PositionVirus();
            TargetPosition = CalculateRandomPosition();
        }

    }
    public class MutatedVirus : Virus
    {
        public MutatedVirus()
        {
            VirusSize = new Size(100, 76);

            Size = VirusSize;
            Anchor = AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(Properties.Resources.MutierterVirus, VirusSize);
            Margin = new Padding(3, 2, 3, 2);
            Name = "pbVirus";
            SizeMode = PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 2;
            VirusSpeed = 2;
            AIType = "aggressive";
            Points = 5;


            PositionVirus();
            TargetPosition = CalculateRandomPosition();
        }
    }
    public class DividerVirus : Virus
    {
        public DividerVirus()
        {
            VirusSize = new Size(100, 76);

            Size = VirusSize;
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.Virus_Teiler, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 2;
            VirusSpeed = 1;
            AIType = "passive";
            Points = 2;

            DateTime timerStart = DateTime.Now;
            timerEnd = timerStart.AddSeconds(5);

            PositionVirus();
            TargetPosition = CalculateRandomPosition();
        }
    }
    public class BossVirus : Virus
    {
        public BossVirus()
        {
            VirusSize = new Size(649, 514);

            Size = VirusSize;
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.Virus_Boss, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 50;
            AIType = "boss";

            DateTime timerStart = DateTime.Now;
            timerEnd = timerStart.AddSeconds(5);

            TargetPosition = CalculateRandomPositionBoss();
        }
        public static void MoveBoss(Virus virus)
        {
            if (virus.Bounds.X > GameState.GameBoardWidth - virus.Bounds.Width - 50)
            {
                virus.Left -= 1;
            }
            else
            {
                if (virus.Bounds.Y > virus.TargetPosition.Y)
                {
                    virus.Top -= 1;
                }
                else
                {
                    virus.Top += 1;
                }
                if (virus.Bounds.Y == virus.TargetPosition.Y)
                {
                    virus.RecalculateRandomPositionBoss();
                }
            }
        }

        public static void BossAttackMove(Virus virus)
        {           
            //for (int i = 0; i < 5; i++)
            //{
            //    NormalVirus nv = new NormalVirus();
            //}
            //virus.timerEnd = DateTime.Now.AddSeconds(10);

            //// erste Attacke 5 Viren von jedem Typ außer mutiert einen Spawnen unter und über (wenn mögliche Stelle) Boss
            //// zweite Attacke 3 aggressive Viren spawnen auf selbe weise? 
            //// dritte Attacke große rote Kugel in richtung Spieler schießen

            //// nie mehr als 8 viren gleichzeitig im level?


        }

    }


}
