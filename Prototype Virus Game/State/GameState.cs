using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    public static class GameState
    {
        public static int GameBoardWidth { get; set; }
        public static int GameBoardHeight { get; set; }

        public static bool Jump { get; set; }
        public static bool RunRight { get; set; }
        public static bool RunLeft { get; set; }
        public static bool TurnPlayer { get; set; }
        public static bool PlayerLookingLeft { get; set; }
        public static bool PlayerLookingRight { get; set; }


        public static bool OnPlatform { get; set; }
        public static bool JumpDown { get; set; }

        public static bool Fullscreen { get; set; }
        public static int GroundLevel { get; set; }
        public static bool PlayerGotHit {get; set;}
        public static bool VirusHit { get; set; }     
        public static int playerHealth { get; set; } = 3;
        public static int HighScore { get; set; }

        static GameState()
        {
            PlayerLookingRight = true;
        }
    }
}
