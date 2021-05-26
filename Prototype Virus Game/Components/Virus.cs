using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    public class Virus : PictureBox
    { 
        public Virus()
        {
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackColor = System.Drawing.Color.White;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = global::Prototype_Virus_Game.Properties.Resources.Hilde;
            Location = new System.Drawing.Point(800, 600);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbCharacter";
            Size = new System.Drawing.Size(100, 76);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
        }
    }
}
