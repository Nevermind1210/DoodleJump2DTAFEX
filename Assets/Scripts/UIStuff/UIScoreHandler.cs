using System;
using TMPro;
using UnityEngine;
using Saving_Stuff;

public class UIScoreHandler : MonoBehaviour
{
    private HighScoreSystem _highScoreSystem;
    // this all relied on PlayerPref... I'm going to keep this... mostly to show the score
    public GameObject finalScore;
    public GameObject scoreText;
    public GameObject highScore;
    public GameObject player;
    public string charName;
    public TextMeshProUGUI nameContainer;
    public static int score;

    private void Start()
    {
        score = 0;
        //highScore.GetComponent<TextMeshProUGUI>().text = "Platforms Climbed: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        SaveData data = _highScoreSystem.LoadGame();
        highScore.GetComponent<TextMeshProUGUI>().text = "Platforms currently Climbed: " + data.savedHighScore;
    }

    private void Update()
    {
        SaveData data = _highScoreSystem.SaveGame();
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        finalScore.GetComponent<TextMeshProUGUI>().text = "You made it to: " + score + " platforms";

        nameContainer.text = charName;

        //if (score > PlayerPrefs.GetInt("HighScore", 0))
        //{
        //    PlayerPrefs.SetInt("HighScore", score);
        //    highScore.GetComponent<TextMeshProUGUI>().text = "Platforms Climbed: " + PlayerPrefs.GetInt("HighScore", score).ToString();
        //}

        if (score > data.savedHighScore)
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = " Highest Platform Climbed: " + data.savedHighScore;
        }
    }

    public void CharacterName(string name)
    {
        charName = name;
    }
}
