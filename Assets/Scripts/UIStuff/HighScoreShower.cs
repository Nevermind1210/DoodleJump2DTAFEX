using System;
using System.Collections.Generic;
using UnityEngine;
using Saving_Stuff;
using TMPro;

namespace UIStuff
{
    public class HighScoreShower : MonoBehaviour
    {
        private HighScoreSystem system;
        private GameObject position;
        private GameObject score;
        private GameObject name;

        private void Start()
        {
            TextMeshProUGUI positionText = position.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI scoreText = score.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI nameText = name.GetComponent<TextMeshProUGUI>();

            system.dataToSave.Sort();

            foreach (var saveData in system.dataToSave)
            {
                positionText.text = saveData.savedPosition.ToString();
                scoreText.text = saveData.savedHighScore.ToString();
                nameText.text = saveData.savedPName;
            }

            /*for (var i = 0; i < system.dataToSave.Count; i++)
            {
                Instantiate() // Instantiate the row.
            }*/
        }
    }
}