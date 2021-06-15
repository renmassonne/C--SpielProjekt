using System;
using System.Drawing;


namespace Prototype_Virus_Game
{
    public class VirusLogic
    {
        Random randomizer = new Random();

        public void Logic(object sender, EventArgs e)
        {
            if (!Game.instance.lblLevelDisplay.Text.Equals("Level 3"))
            {
              Virus.SpawnVirus();
            }

            if (UiComponents.Viruses.Count == 0 && GameState.BossFight == false)
            {
                Virus.BossFight();
            }


            // regelt Bewegung der Viren
            foreach (var virus in UiComponents.Viruses)
            {

                MoveVirusToTargetPosition(virus);
                if (virus.IsTargetPositionReached())
                {                  
                    virus.RecalculateTargetPosition();
                }                
            }
          
            // regelt dass Teleporter und Divider zeitbasiertes Event ausführen
            for (int i = UiComponents.Viruses.Count - 1; i >= 0; i--)
            {
                var virus = UiComponents.Viruses[i];

                if (virus is DividerVirus)
                {
                    if (DateTime.Now >= virus.timerEnd && virus.Size.Width > 70)
                    {
                       virus.DivideAction(virus);
                    }
                }
                if (virus is TeleporterVirus)
                {
                    if (DateTime.Now >= virus.timerEnd)
                    {
                        virus.TeleportVirus(virus, CharacterLogic.chaLocX, CharacterLogic.chaLocY);
                    }                   
                }
                if (virus is BossVirus)
                {
                    if (DateTime.Now >= virus.timerEnd)
                    {                   
                        BossVirus.BossAttackMove(virus);
                    }
                }
              
            }


            // regelt Schaden bekommen wenn Spieler von Viren berührt wird
            for (int i = UiComponents.Viruses.Count - 1; i >= 0; i--)
            {

                if (UiComponents.Viruses[i].Bounds.IntersectsWith(Game.instance.pbCharacterBounds.Bounds))
                {
                    if (UiComponents.Viruses[i] is MutatedVirus)
                    {
                        GameState.PlayerHealth -= 3;
                    }
                    else
                    {
                        GameState.PlayerHealth -= 1;
                    }
                    
                    Game.instance.Controls.Remove(UiComponents.Viruses[i]);
                    UiComponents.Viruses[i].Dispose();
                    UiComponents.Viruses.Remove(UiComponents.Viruses[i]);                 

                    Game.instance.DisplayHealth();

                    
                }
            }

            
        }

        private void MoveVirusToTargetPosition(Virus virus)
        {
            int Schrittweite = virus.VirusSpeed;

            if (virus.AIType.Equals("passive"))
            {

                var orignalLocation = new Point(virus.Location.X, virus.Location.Y);

                if (virus.TargetPosition.X > virus.Location.X)
                    virus.Location = new Point(virus.Location.X + Schrittweite, virus.Location.Y);
                else if (virus.TargetPosition.X < virus.Location.X)
                    virus.Location = new Point(virus.Location.X - Schrittweite, virus.Location.Y);               
                if (virus.TargetPosition.Y > virus.Location.Y)
                    virus.Location = new Point(virus.Location.X, virus.Location.Y + Schrittweite);
                else if (virus.TargetPosition.Y < virus.Location.Y)
                    virus.Location = new Point(virus.Location.X, virus.Location.Y - Schrittweite);
                

                if (IntersectsWithNonPlayerUiComponent(virus))
                {
                    virus.Location = orignalLocation;
                    virus.RecalculateTargetPosition();
                }

            }
            else if (virus.AIType.Equals("aggressive"))
            {
                virus.TargetPosition = virus.ChasePlayer();


                if (virus.TargetPosition.X - 10 > virus.Location.X && virus.TargetPosition.X + 10 > virus.Location.X)
                    virus.Left += Schrittweite;
                else if (virus.TargetPosition.X-10 < virus.Location.X && virus.TargetPosition.X +10 < virus.Location.X)
                    virus.Left -= Schrittweite;              
                if (virus.TargetPosition.Y - 10 > virus.Location.Y && virus.TargetPosition.Y + 10 > virus.Location.Y)
                    virus.Top += Schrittweite;
                else if (virus.TargetPosition.Y - 10 < virus.Location.Y && virus.TargetPosition.Y + 10 < virus.Location.Y)
                    virus.Top -= Schrittweite;                       
            }
            else
            {
                BossVirus.MoveBoss(virus);
            }
        }

        //überprüft dass normal bewegende Viren nicht aufeinander laufen
        private bool IntersectsWithNonPlayerUiComponent(Virus virus)
        {
            foreach (var uiComponent in UiComponents.Viruses)
            {
                if (virus.Bounds.IntersectsWith(uiComponent.Bounds) && uiComponent != virus && !(uiComponent is AggroVirus) && !(uiComponent is MutatedVirus))
                {
                    return true;
                }
            }
            return false;
        }

        
       

    }
}
