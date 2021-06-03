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

            //if (GameState.Fullscreen == false)
            //    btnVollbildToggle.Text = "Vollbild: Aus";

            //else if (GameState.Fullscreen == true)
            //    btnVollbildToggle.Text = "Vollbild: An";
        }

        private void btnWeiter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVollbildToggle_Click(object sender, EventArgs e)
        {
            //Game.instance.ChangeResolution();
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
    }
}
