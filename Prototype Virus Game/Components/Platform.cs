using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game.Components
{
    public class GamePlatform : PictureBox
    {
       
        public GamePlatform(Rectangle bounds)
        {
            Name = "pbPlatform";
            TabIndex = 6;
            TabStop = false;
            Size = new Size(bounds.Width, bounds.Height);         
            Location = new Point(bounds.X, bounds.Y);
            Visible = false;            
            
        }

        
    }
}
