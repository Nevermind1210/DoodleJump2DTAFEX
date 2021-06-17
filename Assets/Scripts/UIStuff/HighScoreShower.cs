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
        [SerializeField] private GameObject arr;
        [SerializeField] private GameObject position;
        [SerializeField] private GameObject score;
        [SerializeField] private GameObject name;

        private void Start()
        {
            system = transform.GetComponentInParent<HighScoreSystem>();
            system.LoadGame();
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

            for (var i = 0; i < system.dataToSave.Count; i++)
            {
                Instantiate(arr); // Instantiate the row.
            }
        }
    }
}