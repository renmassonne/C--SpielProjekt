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
   
    public class Items : PictureBox
    {
        public static List<Items> ItemList;
       public DateTime TimerEnd { get; set; }

        public bool OnSurface { get; set; }
    }
    class LevelProgressItems : Items
    {
           public LevelProgressItems() 
           {
            Location = new System.Drawing.Point(208, 251);
            Name = "item";
            Size = new System.Drawing.Size(80, 20);
            TabIndex = 14;
            TabStop = false;
            Image = Properties.Resources.Mundschutz;
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        }
        public static void DropLPItem(Virus virus)
        {
            var lpItem = new LevelProgressItems();

            ((ISupportInitialize)(lpItem)).BeginInit();
            lpItem.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
            lpItem.BackColor = Color.Transparent;
            lpItem.Parent = Game.instance.pbBackGround;
            lpItem.DoubleBuffered = true;
            lpItem.Location = new Point((virus.Location.X + virus.Width / 2 - lpItem.Width / 2), (virus.Location.Y + virus.Height / 2 - lpItem.Width / 2));
            ItemList.Add(lpItem);
            ((ISupportInitialize)(lpItem)).EndInit();
        }

    }
    class Hearts : Items
    {
        public Hearts()
        {
            Location = new System.Drawing.Point(208, 251);
            Name = "item";
            Size = new System.Drawing.Size(40, 32);
            TabIndex = 14;
            TabStop = false;
            Image = Properties.Resources.Heart;
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

        }
        public static void DropHeart(Virus virus)
        {
            var heart = new Hearts();

            ((ISupportInitialize)(heart)).BeginInit();
            heart.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);           
            heart.BackColor = Color.Transparent;
            heart.Parent = Game.instance.pbBackGround;           
            heart.DoubleBuffered = true;            
            heart.Location = new Point((virus.Location.X + virus.Width / 2 - heart.Width / 2), (virus.Location.Y + virus.Height / 2 - heart.Width / 2));
            ItemList.Add(heart);
            ((ISupportInitialize)(heart)).EndInit();
        }
    }
    class PointObjects : Items
    {
        public PointObjects()
        {
            
            Name = "item";
            Size = new System.Drawing.Size(60, 62);
            TabIndex = 14;
            TabStop = false;
            Image = Properties.Resources.klopapier1;
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
           

            Location = PlaceItem();

        }
        public Point PlaceItem()
        {
            Random r = new Random();
            int whichPlatform = r.Next(0, Game.instance.GamePlatformsBounds.Count);

            int whereOnPlatform = r.Next(Game.instance.GamePlatformsBounds[whichPlatform].X + 10, Game.instance.GamePlatformsBounds[whichPlatform].X + Game.instance.GamePlatformsBounds[whichPlatform].Width - 70);

            Point location = new Point(whereOnPlatform, Game.instance.GamePlatformsBounds[whichPlatform].Y - 48);         
                                     
            return location;
        }
        public static void SpawnPointObject()
        {
            var pointObj = new PointObjects();

            ((ISupportInitialize)(pointObj)).BeginInit();
            pointObj.MouseClick += new MouseEventHandler(Game.instance.MouseClickShootBullet);
            pointObj.BackColor = Color.Transparent;          
            pointObj.Parent = Game.instance.pbBackGround;
            pointObj.DoubleBuffered = true;            
            ItemList.Add(pointObj);
            ((ISupportInitialize)(pointObj)).EndInit();
        }
    }
    class VirusBuffer : Items
    {
        public VirusBuffer()
        {
            Location = new System.Drawing.Point(208, 251);
            Name = "item";
            Size = new System.Drawing.Size(100, 50);
            TabIndex = 14;
            TabStop = false;
        }
    }
    class WeaponBuffer : Items
    {
        public WeaponBuffer()
        {
            Location = new System.Drawing.Point(208, 251);
            Name = "item";
            Size = new System.Drawing.Size(100, 50);
            TabIndex = 14;
            TabStop = false;
        }
    }
}
