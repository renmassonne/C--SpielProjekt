﻿using System;
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
                GameState.RunRight = false;

                if (GameState.PlayerLookingRight == true)
                {
                    GameState.TurnPlayer = true;
                }

            }

            if (e.KeyCode == Keys.D)
            {
                GameState.RunRight = true;
                GameState.RunLeft = false;

                if (GameState.PlayerLookingLeft == true)
                {
                    GameState.TurnPlayer = true;
                }

            }


            if (e.KeyCode == Keys.S)
            {
                GameState.JumpDown = true;             
            }


            if (e.KeyCode == Keys.Space)
            {               
               
                GameState.Jump = true;          
            }

            if (e.KeyCode == Keys.Escape)
            {
                Game_Menu gm = new Game_Menu();
                Game.instance.PlayTime.Stop();
                Game.instance.virusTimer.Stop();
                Game.instance.gameTimer.Stop();
                gm.Show();
                
            }            
        }
    }
}
