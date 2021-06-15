using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Virus_Game
{
    class ItemLogic
    {
        public void Logic(object sender, EventArgs e)
        {

            
            // regelt ob Character auf Item drauf läuft
            for (int i = Components.Items.ItemList.Count - 1; i >= 0; i--)
            {
                var item = Components.Items.ItemList[i];

                if (Game.instance.pbCharacterBounds.Bounds.IntersectsWith(item.Bounds))
                {
                    if (item is Components.Hearts)
                    {
                        if (GameState.PlayerHealth < 3)
                        {
                            if (GameState.PlayerHealth < 3)
                            {
                                GameState.PlayerHealth += 1;
                                Game.instance.DisplayHealth();
                            }                           
                        }
                        Components.Items.ItemList.Remove(item);
                        item.Dispose();
                        item = null;
                    }
                    if (item is Components.PointObjects)
                    {
                        GameState.Score += 20;
                        Game.instance.lblScore.Text = "Score: " + Convert.ToString(GameState.Score);
                        Components.Items.ItemList.Remove(item);
                        item.Dispose();
                        item = null;
                    }
                    if (item is Components.LevelProgressItems)
                    {
                        /* noch entwerfen dass aufheben eine anzeige 1/3 o.ä macht und level erst zuende wenn alle drei eingesammelt, könnte zb nur von teleportern
                         * oder mutierten dropbar sein also drei teleporter in lvl 1 und 2*/
                        Components.Items.ItemList.Remove(item);
                        item.Dispose();
                        item = null;
                    }

                }
                if (item is Components.LevelProgressItems || item is Components.Hearts)
                {
                    int ground = GameState.GroundLevel + Game.instance.pbCharacterBounds.Height - item.Height;

                    int itemBottom = item.Location.Y + item.Height;

                    foreach (var platform in Game.instance.GamePlatformsBounds)
                    {

                        if (item.Bounds.IntersectsWith(platform))
                        {
                            if (itemBottom > platform.Top - 5 && itemBottom < platform.Top + 5)
                            {

                                item.Location = new Point(item.Location.X, platform.Top - item.Height);

                                item.OnSurface = true;
                            }
                        }
                    }
                    if (item.Bounds.Y > ground - 5 && item.Bounds.Y < ground + 5)
                    {
                        item.Location = new Point(item.Location.X, GameState.GroundLevel + Game.instance.pbCharacterBounds.Height - item.Height);
                        item.OnSurface = true;
                    }
                    if (item.OnSurface == false)
                    {
                        item.Top += 7;
                    }
                }
            }




            if (DateTime.Now >= Game.instance.PointObjectTimer)
            {
                Components.PointObjects.SpawnPointObject();
                Game.instance.PointObjectTimer = Game.instance.PointObjectTimer.AddSeconds(10);

            }

        }
    }
}
