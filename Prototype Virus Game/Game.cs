using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prototype_Virus_Game
{

    public partial class Game : Form
    {
        public static Game instance;
        Point SpawnPoint;

        public Game()
        {
            InitializeComponent();
            instance = this;
            StartLevel();           
        }

        private void Game_Load(object sender, EventArgs e)
        {
            pbCharacter.BackColor = Color.Transparent;
            pbCharacter.Parent = pbBackGround;
            pbCharacter.Location = SpawnPoint;
            pbPlatform.BringToFront();
            pbCharacter.BringToFront();
            pbPlatform.BackColor = Color.Transparent;
            pbPlatform.Location = new Point(350, 450);
        }

        private void StartLevel()
        {
            ClientSize = new Size(1280, 720);
            GameState.GroundLevel = 515;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SpawnPoint = new Point(100, 515);
        }

        public void ChangeResolution()
        {
            (int, int) currentLocation = (pbCharacter.Location.X, pbCharacter.Location.Y);
            if (GameState.Fullscreen == false)
            {

                instance.ClientSize = new Size(1920, 1080);
                instance.WindowState = FormWindowState.Normal;
                instance.CenterToScreen();
                GameState.GroundLevel = 850;
                GameState.Fullscreen = true;
                pbCharacter.Location = new Point((int)Math.Round(currentLocation.Item1 * 1.5), GameState.GroundLevel);

            }
            else
            {
                instance.ClientSize = new Size(1280, 720);
                instance.WindowState = FormWindowState.Normal;
                instance.CenterToScreen();
                GameState.GroundLevel = 515;
                GameState.Fullscreen = false;
                pbCharacter.Location = new Point((int)Math.Round(currentLocation.Item1 / 1.5), GameState.GroundLevel);
            }
        }
    }
}
