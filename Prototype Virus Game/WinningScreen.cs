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
    public partial class WinningScreen : Form
    {
      
        public WinningScreen()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            tbSpielerName.Focus();

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           if (tbSpielerName.Text != String.Empty)
           {
              HighScoreLogic.Save(tbSpielerName.Text);
                lblGespeichert.Visible = true;
           }        
        }

        private void btnNeustart_Click(object sender, EventArgs e)
        {
            if (NoNameEntry() == false)
            {
                Application.Restart();
            }
            
            
        }

        private void btnBeenden_Click(object sender, EventArgs e)
        {
            if (NoNameEntry() == false)
            {
               Game.instance.Close();
            }
        }
          
           
        private bool NoNameEntry()
        {
            
                if (tbSpielerName.Text != String.Empty)
                {
                return false;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bist du sicher das du deinen Score nicht speichern willst?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {                    
                        return false;
                    }
                    else 
                    {
                        tbSpielerName.Focus();
                        return true;
                    }                
                }
               
               
        }
    }
}
