using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Prototype_Virus_Game
{
    public class Virus : PictureBox
    {
        private Random randomizer = new Random();

        public Point TargetPosition { get; set; }
        public bool Dead { get; set; }
        public string AIType { get; set; }     
        public int VirusHealth { get; set; }
        public Size VirusSize { get; set; }     
        
        


        internal bool IsTargetPositionReached()
        {
            return Location.X == TargetPosition.X && Location.Y == TargetPosition.Y;
        }

        public void PositionVirus()
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

        public Point CalculateRandomPosition()
        {
            int x = randomizer.Next(0, GameState.GameBoardWidth - 100);
            int y = randomizer.Next(0, GameState.GroundLevel);
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

        internal void RecalculateTargetPosition()
        {
            TargetPosition = CalculateRandomPosition();
        }

        public Bitmap ScaleImage(Bitmap graphic, Size s)
        {
            Bitmap scaledGraphics = new Bitmap(s.Width,s.Height);
            using (Graphics graphics = Graphics.FromImage(scaledGraphics))
            {
                graphics.DrawImage(graphic, 0, 0, s.Width, s.Height);
            }
            return scaledGraphics;
        }


    }
    public class NormalVirus : Virus
    {
        
        public NormalVirus()
        {
            VirusSize = new Size(100, 76);

            Size = VirusSize;
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;        
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.VirusNormal, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";           
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 1;

            PositionVirus();
            TargetPosition = CalculateRandomPosition();
        }
    }

    public class ShieldedVirus : Virus
    {      
        public ShieldedVirus()
        {
            VirusSize = new Size(130, 100);

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
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.HildeAggro, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 1;

            PositionVirus();
            TargetPosition = CalculateRandomPosition();
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
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.HildeTeleporter, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";          
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 1;

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
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.HildeMutiert, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";           
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 2;

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
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.HildeTeiler, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";           
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 2;

            PositionVirus();
            TargetPosition = CalculateRandomPosition();
        }
    }
    public class BossVirus : Virus
    {
        public BossVirus()
        {
            VirusSize = new Size(100, 76);

            Size = VirusSize;
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.boss, VirusSize);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";           
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            VirusHealth = 50;

            PositionVirus();
            TargetPosition = CalculateRandomPosition();
        }
    }

}
