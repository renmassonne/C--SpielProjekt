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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
