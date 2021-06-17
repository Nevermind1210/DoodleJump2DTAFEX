using System;
using TMPro;
using UnityEngine;
using Saving_Stuff;

public class UIScoreHandler : MonoBehaviour
{
    [SerializeField] private HighScoreSystem _highScoreSystem;
    // this all relied on PlayerPref... I'm going to keep this... mostly to show the score
    public GameObject finalScore;
    public GameObject scoreText;
    public GameObject highScore;
    public GameObject player;
    public string charName;
    public TextMeshProUGUI nameContainer;
    public static int score;
    SaveData dataSaving;
    SaveData dataLoading;
    private void Start()
    {
        dataLoading = _highScoreSystem.LoadGame();
        score = 0;
        //highScore.GetComponent<TextMeshProUGUI>().text = "Platforms Climbed: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScore.GetComponent<TextMeshProUGUI>().text = "Highest Platform climbed: " + dataLoading.savedHighScore;
    }

    private void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        finalScore.GetComponent<TextMeshProUGUI>().text = "You made it to: " + score + " platforms";
        nameContainer.text = charName;

        if (score > dataLoading.savedHighScore)
        {
            dataSaving.savedHighScore = score;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Highest Platform climbed: " + dataSaving.savedHighScore;
        }

        if (!nameContainer)
        {
            dataSaving.savedPName = charName;
        }
        else
        {
            Debug.LogError("PUT A DAMN NAME IN");
            dataSaving.savedPName = null;
        }
    }

    public void CharacterName(string name)
    {
        charName = name;
    }
}
