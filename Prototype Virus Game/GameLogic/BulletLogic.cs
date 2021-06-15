using Prototype_Virus_Game.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    class BulletLogic
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
            bulletTimer.Tick += new EventHandler(bulletLogic);
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





        public void bulletLogic(object sender, EventArgs e)
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
                            virus.Size = new Size(140, 95);
                            virus.Location = new Point(virus.Location.X+20, virus.Location.Y + 20);
                       }                      
                       if (virus is BossVirus)
                       {
                            Game.instance.pbBossHealthBar.Value -= 2;
                       }
                       if (virus.VirusHealth == 0)
                       {   
                            
                            Game.instance.Controls.Remove(virus);
                            virus.Dispose();
                            virus.Dead = true;

                            if (virus is MutatedVirus)
                            {                               
                               LevelProgressItems.DropLPItem(virus);   
                               
                            }                           
                            GameState.Score = GameState.Score + virus.Points;
                            GameState.VirusKillCount++;

                            if (GameState.VirusKillCount == GameState.HeartDroppingCounter)
                            {
                                Components.Hearts.DropHeart(virus);
                                GameState.HeartDroppingCounter += 10;
                            }
                            Game.instance.lblScore.Text = "Score: " + Convert.ToString(GameState.Score);

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

