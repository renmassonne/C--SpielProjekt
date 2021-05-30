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
        int x =100;
        int y=495;
        public void Logic(object sender, EventArgs e)
        {
            if (GameState.Jump)
            {
                if (!(Game.instance.pbCharacterBounds.Location.Y < GameState.GroundLevel) || GameState.OnPlatform)
                {
                    Graphics gb = Graphics.FromImage(Game.instance.anzeige);  
                gb.DrawImage(Game.instance.hinterbmp1, 0, 0, Game.instance.hinterbmp1.Width, Game.instance.hinterbmp1.Height); 
                gb.DrawImage(Game.instance.platform, Game.instance.x, Game.instance.y, 326, 95);
                gb.DrawImage(Game.instance.platform, 550, 350, 326, 95);  
                gb.DrawImage(Game.instance.character, x, y-160, 103, 167);
                gb.Dispose();                       
                Game.instance.pbBackGround.Image = Game.instance.anzeige;

                Game.instance.pbCharacterBounds.Top -= 160;
                y -= 160;

                }

            }

            if (GameState.OnPlatform == false)
            {
                if (Game.instance.pbCharacterBounds.Location.Y < GameState.GroundLevel)
                {
                    Graphics gb = Graphics.FromImage(Game.instance.anzeige);
                    gb.DrawImage(Game.instance.hinterbmp1, 0, 0, Game.instance.hinterbmp1.Width, Game.instance.hinterbmp1.Height);
                    gb.DrawImage(Game.instance.platform, Game.instance.x, Game.instance.y, 326, 95);
                    gb.DrawImage(Game.instance.platform, 550, 350, 326, 95);
                    gb.DrawImage(Game.instance.character, x, y + 10, 103, 167);
                    gb.Dispose();
                    Game.instance.pbBackGround.Image = Game.instance.anzeige;

                    Game.instance.pbCharacterBounds.Top += 10;
                    y += 10;

                }
            }




            if (GameState.RunRight)
            {
                if (Game.instance.pbCharacterBounds.Location.X < UiComponents.BackGround.ClientSize.Width - 105)
                {
                   

                    Graphics gb = Graphics.FromImage(Game.instance.anzeige);  
                    gb.DrawImage(Game.instance.hinterbmp1, 0, 0, Game.instance.hinterbmp1.Width, Game.instance.hinterbmp1.Height); 
                    gb.DrawImage(Game.instance.platform, Game.instance.x, Game.instance.y, 326, 95);
                    gb.DrawImage(Game.instance.platform, 550, 350, 326, 95);
                    gb.DrawImage(Game.instance.character, x+13,y, 103, 167);
                    gb.Dispose(); 
                    Game.instance.pbBackGround.Image = Game.instance.anzeige;
                    

                    Game.instance.pbCharacterBounds.Left += 13;
                    x += 13;

                }
            }

            if (GameState.RunLeft)
            {
                if (Game.instance.pbCharacterBounds.Location.X  > 0)
                {

                Graphics gb = Graphics.FromImage(Game.instance.anzeige);  
                gb.DrawImage(Game.instance.hinterbmp1, 0, 0, Game.instance.hinterbmp1.Width, Game.instance.hinterbmp1.Height); 
                gb.DrawImage(Game.instance.platform, Game.instance.x, Game.instance.y, 326, 95);
                gb.DrawImage(Game.instance.platform, 550, 350, 326, 95);
                gb.DrawImage(Game.instance.character, x - 13, y, 103, 167);
                gb.Dispose();                            
                Game.instance.pbBackGround.Image = Game.instance.anzeige;

                Game.instance.pbCharacterBounds.Left -= 13;
                x -= 13;
                }
                    

               

            }

            if (GameState.TurnPlayer)
            {
                if (GameState.RunLeft && GameState.PlayerLookingRight)
                {
                    Game.instance.character = Game.instance.characterLeft;
                    GameState.PlayerLookingRight = false;
                    GameState.PlayerLookingLeft = true;
                }
                else if (GameState.RunRight && GameState.PlayerLookingLeft)
                {
                    Game.instance.character = Game.instance.characterRight;
                    GameState.PlayerLookingLeft = false;
                    GameState.PlayerLookingRight = true;
                }
            }


            if (Game.instance.pbCharacterBounds.Bounds.IntersectsWith(Game.instance.pbPlatform1.Bounds))
            {
                int playerFeet = Game.instance.pbCharacterBounds.Location.Y + Game.instance.pbCharacterBounds.Height;

                if (playerFeet > Game.instance.pbPlatform1.Bounds.Top - 5 && playerFeet < Game.instance.pbPlatform1.Bounds.Top + 5)
                {
                    Graphics gb = Graphics.FromImage(Game.instance.anzeige);
                    gb.DrawImage(Game.instance.hinterbmp1, 0, 0, Game.instance.hinterbmp1.Width, Game.instance.hinterbmp1.Height);
                    gb.DrawImage(Game.instance.platform, Game.instance.x, Game.instance.y, 326, 95);
                    gb.DrawImage(Game.instance.platform, 550, 350, 326, 95);
                    gb.DrawImage(Game.instance.character, Game.instance.pbCharacterBounds.Location.X, Game.instance.pbPlatform1.Top- 163, 103, 167);
                    gb.Dispose();
                    Game.instance.pbBackGround.Image = Game.instance.anzeige;

                    GameState.OnPlatform = true;
                }
            }
            else
            {
                GameState.OnPlatform = false;
            }

            //if (Game.instance.pbCharacterBounds.Bounds.IntersectsWith(Game.instance.pbPlatform2.Bounds))
            //{
            //    int playerFeet = Game.instance.pbCharacterBounds.Location.Y + Game.instance.pbCharacterBounds.Height;

            //    if (playerFeet > Game.instance.pbPlatform2.Bounds.Top - 5 && playerFeet < Game.instance.pbPlatform2.Bounds.Top + 5)
            //    {
            //        Graphics gb = Graphics.FromImage(Game.instance.anzeige);
            //        gb.DrawImage(Game.instance.hinterbmp1, 0, 0, Game.instance.hinterbmp1.Width, Game.instance.hinterbmp1.Height);
            //        gb.DrawImage(Game.instance.platform, Game.instance.x, Game.instance.y, 326, 95);
            //        gb.DrawImage(Game.instance.platform, 550, 350, 326, 95);
            //        gb.DrawImage(Game.instance.character, Game.instance.pbCharacterBounds.Location.X, Game.instance.pbPlatform2.Top - 163, 103, 167);
            //        gb.Dispose();
            //        Game.instance.pbBackGround.Image = Game.instance.anzeige;

            //        GameState.OnPlatform = true;
            //    }
            //}
            //else
            //{
            //    GameState.OnPlatform = false;
            //}

        }
    }
}
