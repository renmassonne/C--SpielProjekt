using System;
using System.Drawing;


namespace Prototype_Virus_Game
{
    public class VirusLogic
    {
        Random randomizer = new Random();

        public void Logic(object sender, EventArgs e)
        {
            foreach (var virus in UiComponents.Viruses)
            {
                MoveVirusToTargetPosition(virus);
                if(virus.IsTargetPositionReached())
                {
                    virus.RecalculateTargetPosition();
                }
            }
        }

        private void MoveVirusToTargetPosition(Virus virus)
        {
            int Schrittweite = 1;
            var orignalLocation = new Point(virus.Location.X, virus.Location.Y);

            if (virus.TargetPosition.X > virus.Location.X)
                virus.Location = new Point(virus.Location.X + Schrittweite, virus.Location.Y);
            else if (virus.TargetPosition.X < virus.Location.X)
                virus.Location = new Point(virus.Location.X - Schrittweite, virus.Location.Y);
            if (virus.TargetPosition.Y > virus.Location.Y)
                virus.Location = new Point(virus.Location.X, virus.Location.Y + Schrittweite);
            else if (virus.TargetPosition.Y < virus.Location.Y)
                virus.Location = new Point(virus.Location.X, virus.Location.Y - Schrittweite);

            if(IntersectsWithNonPlayerUiComponent(virus))
            {
                virus.Location = orignalLocation;
                virus.RecalculateTargetPosition();
            }
        }

        private bool IntersectsWithNonPlayerUiComponent(Virus virus)
        {
            foreach (var uiCompontent in UiComponents.Viruses)
            {
                if (virus.Bounds.IntersectsWith(uiCompontent.Bounds)
                    && uiCompontent != UiComponents.BackGround
                    && uiCompontent != virus)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
