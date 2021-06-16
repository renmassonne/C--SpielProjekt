using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prototype_Virus_Game
{
    public class CharacterLogic
    {
        public static int chaLocX;
        public static int chaLocY;
        public static int pause = 0;
        static int once = 0;
        static DateTime WaitOneSec;

        public void Logic(object sender, EventArgs e)
        {
            chaLocX = Game.instance.pbCharacterBounds.Location.X;
            chaLocY = Game.instance.pbCharacterBounds.Location.Y;

            if (GameState.Jump)
            {
                if (pause < 4)
                {                 
                    Game.instance.pbCharacterBounds.Top -= 60;                  
                    pause++;
                }
            }


            if ((pause == 4 && GameState.OnPlatform == false) || (pause == 0 && GameState.JumpDown == true))
            {
                if (Game.instance.pbCharacterBounds.Location.Y < GameState.GroundLevel)
                {

                    Game.instance.pbCharacterBounds.Top += 10;
                    GameState.Jump = false;

                    if (GameState.OnPlatform || Game.instance.pbCharacterBounds.Location.Y == GameState.GroundLevel)
                    {
                        pause = 0;
                    }
                }
            }



            if (GameState.RunRight)
            {
                if (Game.instance.pbCharacterBounds.Location.X < UiComponents.BackGround.ClientSize.Width - 105)
                {
                    Game.instance.pbCharacterBounds.Left += 13;

                }
            }

            if (GameState.RunLeft)
            {
                if (Game.instance.pbCharacterBounds.Location.X > 9)
                {
                    Game.instance.pbCharacterBounds.Left -= 13;
                }

            }

            if (GameState.TurnPlayer)
            {
                if (GameState.RunLeft && GameState.PlayerLookingRight)
                {
                    Game.instance.pbCharacterBounds.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    GameState.PlayerLookingLeft = true;
                    GameState.PlayerLookingRight = false;
                }
                else if (GameState.RunRight && GameState.PlayerLookingLeft)
                {
                    Game.instance.pbCharacterBounds.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    GameState.PlayerLookingRight = true;
                    GameState.PlayerLookingLeft = false;
                }
                GameState.TurnPlayer = false;
            }

            // 

            foreach (var platform in Game.instance.GamePlatformsBounds)
            {
                if (Game.instance.pbCharacterBounds.Bounds.IntersectsWith(platform))
                {
                    int playerFeet = chaLocY + Game.instance.chaHeight;

                    if (playerFeet > platform.Top - 5 && playerFeet < platform.Top + 5)
                    {
                        if (GameState.JumpDown == false)
                        {

                            Game.instance.pbCharacterBounds.Location = new Point(chaLocX, platform.Top - Game.instance.chaHeight);
                            chaLocY = platform.Top - Game.instance.chaHeight;

                            GameState.OnPlatform = true;
                            pause = 0;
                        }
                    }
                }
            }


            // regelt ob character nach unten fällt wenn er plattformen verlässt
            int all = 0;

            foreach (var platform in Game.instance.GamePlatformsBounds)
            {

                if (chaLocX + Game.instance.chaWidth <= platform.Left || chaLocX >= platform.Right || chaLocY + Game.instance.chaHeight < platform.Top || chaLocY + Game.instance.chaHeight > platform.Top)
                {
                    all += 1;
                }
            }
            if (all == Game.instance.GamePlatformsBounds.Count)
            {
                GameState.OnPlatform = false;
                if (GameState.Jump == false)
                    pause = 4;
            }

            if (chaLocY > GameState.GroundLevel - 5 && chaLocY < GameState.GroundLevel + 5)
            {
                pause = 0;
            }

            
           
            //EndGame condition
            if (GameState.Score >= 0)
            {
                TransitionToNextLevel();
            }
        }
        




        void TransitionToNextLevel()
        {
            if (chaLocX > 1750 && chaLocY > GameState.GroundLevel - 10 && !Game.instance.lblLevelDisplay.Text.Equals("Level 3"))
            {
                if (once == 0)
                {
                    Game.instance.lblLevelDisplay.Visible = false;
                    Game.instance.pbHealth.Visible = false;
                    Game.instance.pbHealth1.Visible = false;
                    Game.instance.pbHealth2.Visible = false;
                    Game.instance.pbCharacterBounds.Visible = false;
                         
                    Virus.VirusSpawnOrder.Clear();
                    Virus.SpawnOrderIteration = 0;

                    Game.instance.virusTimer.Enabled = false;

                    Game.instance.pbBackGround.BackColor = Color.Black;
                    Game.instance.pbBackGround.Image = null;

                    for (int i = UiComponents.Viruses.Count - 1; i >= 0; i--)
                    {
                        var virus = UiComponents.Viruses[i];

                        virus.Dispose();
                        Game.instance.Controls.Remove(virus);

                    }
                    UiComponents.Viruses.Clear();

                    WaitOneSec = DateTime.Now.AddSeconds(1);
                    once++;
                }

                if (DateTime.Now >= WaitOneSec)
                {
                    if (Game.instance.lblLevelDisplay.Text.Equals("Level 1"))
                    {
                        Game.instance.DrawGameAssets(2);
                        once = 0;
                    }
                    else if (Game.instance.lblLevelDisplay.Text.Equals("Level 2"))
                    {
                        Game.instance.DrawGameAssets(3);
                        once = 0;
                    }
                }
            }
        }
    }
}

