using System;
using TMPro;
using UnityEngine;

public class UIScoreHandler : MonoBehaviour
{
    public GameObject finalScore;
    public GameObject scoreText;
    public GameObject highScore;
    public GameObject player;
    public static int score;

    private void Start()
    {
        highScore.GetComponent<TextMeshProUGUI>().text = "Platforms Climbed: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        finalScore.GetComponent<TextMeshProUGUI>().text = "You made it to: " + score + " platforms";

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.GetComponent<TextMeshProUGUI>().text = "Platforms Climbed: " + PlayerPrefs.GetInt("HighScore", score).ToString();
        }
    }
}
