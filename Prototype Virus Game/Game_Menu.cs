using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    public partial class Game_Menu : Form
    {
        public Game_Menu()
        {
            InitializeComponent();        
        }

        private void btnWeiter_Click(object sender, EventArgs e)
        {
            Close();
            Game.instance.virusTimer.Start();
            Game.instance.gameTimer.Start();
        }

        private void btnVollbildToggle_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void btnBeenden_Click(object sender, EventArgs e)
        {
            Game.instance.Close();
        }

        private void btnLautstärke_Click(object sender, EventArgs e)
        {

        }

        private void btnAnleitung_Click(object sender, EventArgs e)
        {
            Anleitung gm = new Anleitung();
            gm.Show();
        }

        private void btnLeaderBoard_Click(object sender, EventArgs e)
        {
            LeaderBoard lb = new LeaderBoard();
            lb.Show();
        }
    }
}
