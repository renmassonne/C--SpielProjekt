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
        public int x;
        public int y;
        int pause = 0;

        public void Logic(object sender, EventArgs e)
        {
            x = Game.instance.pbCharacterBounds.Location.X;
            y = Game.instance.pbCharacterBounds.Location.Y;

            if (GameState.Jump)
            {    
                //if (pause < 3)
                {
                    if (!(Game.instance.pbCharacterBounds.Location.Y < GameState.GroundLevel) || GameState.OnPlatform)
                    {
                    //Game.instance.DrawGameAssets(x, y - 50);
                    
                    Game.instance.pbCharacterBounds.Top -= 200;

                        GameState.Jump = false;

                        //pause++;
                        
                    }

                }
            }

            if (GameState.OnPlatform == false)
            {
                //if (pause == 2)
                {
                    if (Game.instance.pbCharacterBounds.Location.Y < GameState.GroundLevel)
                    {
                        //Game.instance.DrawGameAssets(x, y + 10);

                        Game.instance.pbCharacterBounds.Top += 10;
                        //pause = 0;
                    }
                }
            }
                




            if (GameState.RunRight)
            {
                if (Game.instance.pbCharacterBounds.Location.X < UiComponents.BackGround.ClientSize.Width - 105)
                {


                    //Game.instance.DrawGameAssets(x+13, y);


                    Game.instance.pbCharacterBounds.Left += 13;


                }
            }

            if (GameState.RunLeft)
            {
                if (Game.instance.pbCharacterBounds.Location.X > 9)
                {

                    //Game.instance.DrawGameAssets(x - 13, y);

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

            foreach (var virus in UiComponents.Viruses)
            {

                if (virus.Bounds.IntersectsWith(Game.instance.pbCharacterBounds.Bounds))
                {
                    GameState.PlayerGotHit = true;
                    virus.Dead = true;                               
                    Game.instance.Controls.Remove(virus);
                    virus.Dispose();
                }              
            }
            Game.instance.PlayerGotHit();


            foreach (var platform in Game.instance.GamePlatformsBounds)
            {
                if (Game.instance.pbCharacterBounds.Bounds.IntersectsWith(platform))
                {
                    int playerFeet = y + Game.instance.chaHeight;

                    if (playerFeet > platform.Top - 5 && playerFeet < platform.Top + 5)
                    {
                        //Game.instance.DrawGameAssets(x, platform.Top - Game.instance.chaHeight);
                        

                        Game.instance.pbCharacterBounds.Location = new Point(x, platform.Top - Game.instance.chaHeight);
                        y = platform.Top - Game.instance.chaHeight;

                        GameState.OnPlatform = true;
                    }                     
                }               
            }
            int all = 0;

            foreach (var platform in Game.instance.GamePlatformsBounds)
            {
               
                if (x + Game.instance.chaWidth <= platform.Left || x  >= platform.Right || y + Game.instance.chaHeight < platform.Top || y + Game.instance.chaHeight > platform.Top)
                {
                    all += 1;
                }
            }
            if (all == Game.instance.GamePlatformsBounds.Count)
                GameState.OnPlatform = false;

        }

       
    }
}

