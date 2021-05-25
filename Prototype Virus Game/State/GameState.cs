using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Virus_Game
{
    public static class GameState
    {
        public static bool Jump { get; set; }
        public static bool RunRight { get; set; }
        public static bool RunLeft { get; set; }
        public static bool TurnPlayer { get; set; }
        public static bool PlayerLookingLeft { get; set; }
        public static bool PlayerLookingRight { get; set; }
        public static bool OnPlatform { get; set; }
        public static bool Fullscreen { get; set; }
        public static int GroundLevel { get; set; }

        static GameState()
        {
            PlayerLookingRight = true;
        }
    }
}
