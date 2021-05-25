using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    public class CharacterLogic
    {
        public void Logic(object sender, EventArgs e)
        {
            if (GameState.Jump)
            {
                UiComponents.Character.Top -= 13;
            }
            else if (GameState.Jump == false)
            {
                if (GameState.OnPlatform == false)
                {
                    if (UiComponents.Character.Location.Y < GameState.GroundLevel)
                        UiComponents.Character.Top += 10;
                }
            }

            if (GameState.RunRight)
            {
                if (UiComponents.Character.Location.X < UiComponents.BackGround.ClientSize.Width - 100)
                {
                    UiComponents.Character.Left += 13;
                }
            }

            if (GameState.RunLeft)
            {
                if (UiComponents.Character.Location.X > 0)
                    UiComponents.Character.Left -= 13;
            }

            if (GameState.TurnPlayer)
            {
                if (GameState.RunLeft && GameState.PlayerLookingRight)
                {
                    UiComponents.Character.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    GameState.PlayerLookingRight = false;
                    GameState.PlayerLookingLeft = true;
                }
                else if (GameState.RunRight && GameState.PlayerLookingLeft)
                {
                    UiComponents.Character.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    GameState.PlayerLookingLeft = false;
                    GameState.PlayerLookingRight = true;
                }
            }

            foreach (PictureBox uiComponent in UiComponents.Components)
            {
                if (uiComponent == UiComponents.Platform)
                {
                    if (UiComponents.Character.Bounds.IntersectsWith(uiComponent.Bounds))
                    {
                        if (UiComponents.Character.Bottom > UiComponents.Platform.Top - 10 && UiComponents.Character.Bottom < UiComponents.Platform.Top + 10)
                        {
                            GameState.OnPlatform = true;
                        }
                    }
                    else
                    {
                        GameState.OnPlatform = false;
                    }
                }
            }
        }
    }
}
