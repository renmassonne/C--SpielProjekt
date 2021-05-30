using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    public class Character : PictureBox
    {
        public Character()
        {
            Anchor = System.Windows.Forms.AnchorStyles.None;
            BackColor = System.Drawing.Color.White;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Image = global::Prototype_Virus_Game.Properties.Resources.richtiges_bild;
            Location = new System.Drawing.Point(157, 439);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "pbCharacter";
            Size = new System.Drawing.Size(103, 167);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabIndex = 3;
            TabStop = false;
            
        }
    }
}
