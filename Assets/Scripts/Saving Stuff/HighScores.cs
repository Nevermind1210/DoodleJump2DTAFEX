﻿using UnityEngine;


namespace Saving_Stuff
{
    [System.Serializable]
    public class HighScores // the list
    {
        public int score;
        public string name;

        public HighScores(UIScoreHandler _score) // setting the score for the list to grab!
        {
            score = UIScoreHandler.score;
            name = _score.TheName;
        }
    }
}