using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    public class KeyDownEventHandler
    {
        public void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                GameState.RunLeft = true;
                GameState.KeyPressA = true;

                if (GameState.PlayerLookingRight == true)
                {
                    if (GameState.KeyPressD)
                    {
                        GameState.TurnPlayer = false;
                    }
                    else
                    {
                       GameState.TurnPlayer = true;
                    }
                }
               
            }

            if (e.KeyCode == Keys.D)
            {
                GameState.RunRight = true;
                GameState.KeyPressD = true;

                if (GameState.PlayerLookingLeft == true)
                {
                    if (GameState.KeyPressA)
                    {
                        GameState.TurnPlayer = false;
                    }
                    else
                    {
                        GameState.TurnPlayer = true;
                    }
                }
               
            }

          
            if (e.KeyCode == Keys.Space)
            {
                GameState.Jump = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                Game_Menu gm = new Game_Menu();
                gm.Show();
            }

        }
    }
}
