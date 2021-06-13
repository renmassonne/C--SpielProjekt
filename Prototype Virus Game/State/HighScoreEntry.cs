using System;

namespace Prototype_Virus_Game
{
    [Serializable]
    public class HighScoreEntry
    {
        public string Username{ get; set; }

        public int Score { get; set; }

        public string GetLeaderBoardEntry()
        {
            return Score + "\t" + Username;
        }
        
    }
}