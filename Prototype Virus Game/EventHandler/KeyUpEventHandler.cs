using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    public class KeyUpEventHandler
    {
        public void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                GameState.Jump = false;
            }
            if (e.KeyCode == Keys.D)
            {

                GameState.RunRight = false;

            }
            if (e.KeyCode == Keys.A)
            {

                GameState.RunLeft = false;

            }
        }
    }
}
