using UnityEngine;

namespace Saving_Stuff
{
    [System.Serializable]
    public class HighScores : MonoBehaviour
    {
        public int score;
        public string name;

        public HighScores(UIScoreHandler _score)
        {
            score = UIScoreHandler.score;
            name = _score.TheName;
        }
    }
}