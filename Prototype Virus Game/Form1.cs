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
    public partial class Form1 : Form
    {

        bool mJump ;
        bool mRunRight;
        bool mRunLeft;
        bool mTurnPlayer;
        bool mPlayerLookingLeft;
        bool mPlayerLookingRight = true;
        bool mOnPlatform;
        bool mSmallResolution = true;
        int groundLevel;
        Point startpoint;






        public Form1()
        {
            
            InitializeComponent();

            if (mSmallResolution == false)
            {
                this.ClientSize = new Size(1920, 1080);
                WindowState = FormWindowState.Maximized;
                startpoint = new Point(150, 350);
            }

            this.FormBorderStyle = FormBorderStyle.None;

            groundLevel = Convert.ToInt32(Math.Round(ClientSize.Height * 0.86));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            
           

            pbCharacter.BackColor = Color.Transparent;
            pbCharacter.Parent = pbBackGround;
            pbCharacter.Location = startpoint;

            pbPlatform.BackColor = Color.Transparent;
            pbPlatform.Parent = pbBackGround;
            pbPlatform.Location = new Point(350, 450);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Space)
            {

                mJump = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           if (mJump)
           {
                
                pbCharacter.Top -= 15;

           }
           else if (mJump == false  )
           {
                if (mOnPlatform == false)
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
                    pbCharacter.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    mPlayerLookingRight = false;
                    mPlayerLookingLeft = true;
                    
                }
                else if (mRunRight && mPlayerLookingLeft)
                {
                    pbCharacter.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    mPlayerLookingLeft = false;
                    mPlayerLookingRight = true;
                }
            }
            foreach (Control x in this.Controls)
            {
               
                if (x is PictureBox && x.Tag == "platform")
                {

                    if (pbCharacter.Bounds.IntersectsWith(x.Bounds))
                    {
                        mOnPlatform = true;
                    }
                    else
                        mOnPlatform = false;
                }              
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
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

    }

}
