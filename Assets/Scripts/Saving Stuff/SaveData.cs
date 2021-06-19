using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Saving_Stuff
{
    [System.Serializable]
    public class SaveData
    {
        public List<HighScores> highScores = new List<HighScores>(); // this is the main save for the data
        
        public SaveData(List<HighScores> _highScore) // we overload the function 
        {
            highScores = _highScore; // and set the list from itself...
        }

        public void Sort()
        {
            highScores = highScores.OrderBy(_score => _score.score).ToList(); // and then sort the list...
        }
    }
}