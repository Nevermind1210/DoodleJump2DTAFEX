using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Saving_Stuff
{
    [System.Serializable]
    public class SaveData
    {
        public static SaveData theSaveData;
        public List<HighScore> highScores = new List<HighScore>(); // this is the main save for the data
        
        public SaveData(List<HighScore> _highScores) // we overload the function 
        {
            highScores = _highScores; // and set the list from itself...
        }

        public void Sort()
        {
            highScores = highScores.OrderBy(_score => _score.score).ToList(); // and then sort the list...
        }
    }
}