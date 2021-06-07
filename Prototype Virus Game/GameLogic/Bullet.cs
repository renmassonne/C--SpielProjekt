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


            bullet.BackColor = Color.Transparent;
            bullet.Parent = Game.instance.pbBackGround;

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



        private void RemoveBullet()
        {
            bulletTimer.Stop();
            bulletTimer.Dispose();
            bulletTimer = null;

            bullet.Dispose();
            bullet = null;
        }





        public void bulletTimerTick(object sender, EventArgs e)
        {



            if (bullet.Location.X > Game.instance.pbCharacterBounds.Location.X)
            {
                if (bullet.Left < Game.instance.pbBackGround.Width)
                {
                    bullet.Left += 20;
                }
                else
                {
                    RemoveBullet();
                }
            }
            else if (bullet.Location.X < Game.instance.pbCharacterBounds.Location.X)
            {
                if (bullet.Left > 0)
                {
                    bullet.Left -= 20;
                }

                else
                {
                    RemoveBullet();
                }

            }

            if (bullet != null)
            {
                foreach (var virus in UiComponents.Viruses)
                {
                    if (virus.Bounds.IntersectsWith(bullet.Bounds))
                    {
                        GameState.VirusHit = true;
                        virus.VirusHealth -= 1;

                        RemoveBullet();

                       if (virus.VirusHealth == 1  && virus is ShieldedVirus)
                       {
                            virus.Image = Properties.Resources.VirusDick;
                       }

                        if (virus.VirusHealth == 0)
                        {
                            Game.instance.Controls.Remove(virus);
                            virus.Dispose();
                            virus.Dead = true;

                            GameState.HighScore = GameState.HighScore + 5;
                            Game.instance.lblScore.Text = "Score: " + Convert.ToString(GameState.HighScore);

                            break;
                        }
                        break;

                    }
                    else
                    {
                        GameState.VirusHit = false;
                    }
                }
            }

            if (GameState.VirusHit == true)
            {

                UiComponents.Viruses.RemoveAll(item => item.Dead == true);
            }

        }
    }
}
