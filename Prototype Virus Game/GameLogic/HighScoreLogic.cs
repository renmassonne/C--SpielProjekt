using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Virus_Game
{
    public class HighScoreLogic
    {
        public void Save()
        {
            var entry = new HighScoreEntry();
            entry.Score = 1234;
            entry.Username = Environment.UserName;
            GameState.HighScoreList.Add(entry);

            using (Stream stream = File.Open("data.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, GameState.HighScoreList);
            }
        }

        public void Load ()
        {
            if(File.Exists("data.bin"))
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    GameState.HighScoreList = (List<HighScoreEntry>)bin.Deserialize(stream);
                }
            }
            else
            {
                GameState.HighScoreList = new List<HighScoreEntry>();
            }
        }
    }
}
