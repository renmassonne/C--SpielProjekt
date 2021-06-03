using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game.GameLogic
{
    class Bullet
    {

        PictureBox bullet;
        Timer bulletTimer = new Timer();

        public void CreateProjectile()
        {
            bullet = new PictureBox();
            bullet.Size = new Size(15, 15);
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.Image = global::Prototype_Virus_Game.Properties.Resources.BlueDot;
            Game.instance.Controls.Add(bullet);

            bullet.BringToFront();






            if (GameState.PlayerLookingRight)
            {

                bullet.Location = new Point(Game.instance.pbCharacterBounds.Location.X + Game.instance.chaWidth + 10, Game.instance.pbCharacterBounds.Location.Y + 95);
            }
            else
            {
                bullet.Location = new Point(Game.instance.pbCharacterBounds.Location.X - 20, Game.instance.pbCharacterBounds.Location.Y + 95);
            }
            bulletTimer.Interval = 20;
            bulletTimer.Tick += new EventHandler(bulletTimerTick);
            bulletTimer.Start();
        }

        public void bulletTimerTick(object sender, EventArgs e)
        {


            if (bullet.Location.X > Game.instance.pbCharacterBounds.Location.X)
            {
                if (!(bullet.Left > Game.instance.pbBackGround.Width))
                    bullet.Left += 20;
                else
                {
                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    Game.instance.Controls.Remove(bullet);
                    bullet.Dispose();
                    bulletTimer = null;
                    bullet = null;

                }
            }
            else if (bullet.Location.X < Game.instance.pbCharacterBounds.Location.X)
            {
                if (bullet.Left > 0)
                    bullet.Left -= 20;
                else
                {
                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    Game.instance.Controls.Remove(bullet);
                    bullet.Dispose();
                    bulletTimer = null;
                    bullet = null;


                }

            }

        }
    }
}
