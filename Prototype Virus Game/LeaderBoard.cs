using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Prototype_Virus_Game
{
    public partial class LeaderBoard : Form
    {
        public LeaderBoard()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            foreach(var highScoreEntry in GameState.HighScoreList)
            {
                lbScore.Items.Add(highScoreEntry.GetLeaderBoardEntry());
            }
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
