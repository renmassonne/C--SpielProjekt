using System;

namespace Prototype_Virus_Game
{
    [Serializable]
    public class HighScoreEntry
    {
        public string Username{ get; set; }

        public TimeSpan PlayerTime { get; set; }

        public string GetLeaderBoardEntry()
        {
            return PlayerTime + "\t" + Username;
        }
        
    }
}