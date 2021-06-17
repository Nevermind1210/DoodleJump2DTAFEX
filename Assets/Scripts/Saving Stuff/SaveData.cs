using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Saving_Stuff
{
    [System.Serializable]
    public class SaveData
    {
        public List<HighScores> highScores = new List<HighScores>();
        
        public SaveData(List<HighScores> _highScore)
        {
            highScores = _highScore;
        }

        public void Sort()
        {
            highScores = highScores.OrderBy(_score => _score.score).ToList();
        }
    }
}