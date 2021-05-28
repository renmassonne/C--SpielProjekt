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

        public Virus()
        {
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackColor = System.Drawing.Color.White;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = ScaleImage(global::Prototype_Virus_Game.Properties.Resources.Hilde,100, 76);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbVirus";
            Size = new System.Drawing.Size(100, 76);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;

            PositionVirus();
            TargetPosition = CalculateRandomPosition();
        }

        internal bool IsTargetPositionReached()
        {
            return Location.X == TargetPosition.X && Location.Y == TargetPosition.Y;
        }

        private void PositionVirus()
        {
            do
            {
                Location = CalculateRandomPosition();
            } while (IntersectsWithNonPlayerUiComponent());
        }

        private Point CalculateRandomPosition()
        {
            int x = randomizer.Next(0, GameState.GameBoardWidth);
            int y = randomizer.Next(0, GameState.GameBoardHeight);
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

        public Bitmap ScaleImage(Bitmap graphic, int breite, int höhe)
        {
            Bitmap scaledGraphics = new Bitmap(breite, höhe);
            using (Graphics graphics = Graphics.FromImage(scaledGraphics))
            {
                graphics.DrawImage(graphic, 0, 0, breite, höhe);
            }
            return scaledGraphics;
        }
    }
}
