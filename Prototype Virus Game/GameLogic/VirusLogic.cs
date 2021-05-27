using System;
using System.Drawing;

namespace Prototype_Virus_Game
{
    public class VirusLogic
    {
        public void Logic(object sender, EventArgs e)
        {
            ZuOrtBewegen(UiComponents.Character.Location);
        }

        //private bool IntersectsWithNonPlayerUiComponent()
        //{
        //    foreach(var uiCompontent in UiComponents.Components)
        //    {
        //        if (UiComponents.Virus.Bounds.IntersectsWith(uiCompontent.Bounds) 
        //            && uiCompontent != UiComponents.Virus
        //            && uiCompontent != UiComponents.BackGround)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private void ZuOrtBewegen(Point ziel)
        {
            int Schrittweite = 1;

            if (ziel.X > UiComponents.Virus.Location.X)
                UiComponents.Virus.Location = new Point(UiComponents.Virus.Location.X + Schrittweite, UiComponents.Virus.Location.Y);
            else if (ziel.X < UiComponents.Virus.Location.X)
                UiComponents.Virus.Location = new Point(UiComponents.Virus.Location.X - Schrittweite, UiComponents.Virus.Location.Y);
            if (ziel.Y > UiComponents.Virus.Location.Y)
                UiComponents.Virus.Location = new Point(UiComponents.Virus.Location.X, UiComponents.Virus.Location.Y + Schrittweite);
            else if (ziel.Y < UiComponents.Virus.Location.Y)
                UiComponents.Virus.Location = new Point(UiComponents.Virus.Location.X, UiComponents.Virus.Location.Y - Schrittweite);
        }
    }
}
