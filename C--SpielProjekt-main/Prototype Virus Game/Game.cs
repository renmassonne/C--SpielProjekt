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

        bool mJump;
        bool mRunRight;
        bool mRunLeft;
        bool mTurnPlayer;
        bool mPlayerLookingLeft;
        bool mPlayerLookingRight = true;
        
        
        bool OnPlatform;
        
        public bool Fullscreen;

        int groundLevel;
        
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
            //pbCharacter.Parent = this;
            pbCharacter.Location = SpawnPoint;
            pbPlatform.BringToFront();
            pbCharacter.BringToFront();
            
            
            pbPlatform.BackColor = Color.Transparent;
           

            ////pbPlatform.Parent = pbBackGround;
            pbPlatform.Location = new Point(350, 450);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {

                mRunLeft = true;

                if (mPlayerLookingRight == true)
                    mTurnPlayer = true;


            }

            if (e.KeyCode == Keys.D)
            {

                mRunRight = true;


                if (mPlayerLookingLeft == true)
                {
             
                    mTurnPlayer = true;

                }
          
            }

            if (e.KeyCode == Keys.D && e.KeyCode == Keys.A)
            {
                mTurnPlayer = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                
                mJump = true;
                


            }
            if (e.KeyCode == Keys.Escape)
            {

                Game_Menu gm = new Game_Menu();
                gm.Show();
            }

        }

        private void Game_timer_Tick(object sender, EventArgs e)
        {
            

            if (mJump)
            {

                    pbCharacter.Top -= 13;

            }
            else if (mJump == false)
            {
                if (OnPlatform == false)
                {
                    if (pbCharacter.Location.Y < groundLevel)
                        pbCharacter.Top += 10;
                }


            }

            if (mRunRight)
            {
                if (pbCharacter.Location.X < pbBackGround.ClientSize.Width - 100)
                    pbCharacter.Left += 13;

            }

            if (mRunLeft)
            {
                if (pbCharacter.Location.X > 0)
                    pbCharacter.Left -= 13;
            }

            if (mTurnPlayer)
            {
                if (mRunLeft && mPlayerLookingRight)
                {
                    pbCharacter.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    mPlayerLookingRight = false;
                    mPlayerLookingLeft = true;

                }
                else if (mRunRight && mPlayerLookingLeft)
                {                   
                    pbCharacter.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    mPlayerLookingLeft = false;
                    mPlayerLookingRight = true;
                }
            }
            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "platform")
                {

                    if (pbCharacter.Bounds.IntersectsWith(x.Bounds))                       
                    {
                       if (pbCharacter.Bottom > pbPlatform.Top-10 && pbCharacter.Bottom < pbPlatform.Top + 10)
                            OnPlatform = true;
                    }
                    else
                        OnPlatform = false;
                    
                }
            }
                    
            //string a =   Convert.ToString(pbCharacter.Top+167);                    
            //string b = Convert.ToString(pbPlatform.Top);                      
            //label1.Text = a + b;

        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                mJump = false;
            }
            if (e.KeyCode == Keys.D)
            {

                mRunRight = false;

            }
            if (e.KeyCode == Keys.A)
            {
                mRunLeft = false;
            }
        }

        private void StartLevel()
        {
            ClientSize = new Size(1280, 720);          
            groundLevel = 515;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SpawnPoint = new Point(100, 515);
        }

        public void ChangeResolution()
        {
            (int, int) currentLocation = (pbCharacter.Location.X, pbCharacter.Location.Y);
            if (Fullscreen == false)
            {

                instance.ClientSize = new Size(1920, 1080);
                instance.WindowState = FormWindowState.Normal;
                instance.CenterToScreen();
                groundLevel = 850;
                Fullscreen = true;
                pbCharacter.Location = new Point((int)Math.Round(currentLocation.Item1 * 1.5), groundLevel);

            }
            else
            {
                instance.ClientSize = new Size(1280, 720);
                instance.WindowState = FormWindowState.Normal;
                instance.CenterToScreen();
                groundLevel = 515;
                Fullscreen = false;
                pbCharacter.Location = new Point((int)Math.Round(currentLocation.Item1 / 1.5), groundLevel);
            }

        }


    }

}
