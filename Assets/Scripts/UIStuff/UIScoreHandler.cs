using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Saving_Stuff;
using UnityEngine.SocialPlatforms.Impl;

public class UIScoreHandler : MonoBehaviour
{
    public string TheName;
    [SerializeField] private TMP_InputField nameInput;

    [Header("Score")] 
    public static int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScore;

    public static List<HighScores> highScores = new List<HighScores>();
    public HighScores scoring;
    
    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
        finalScore.text = "You made it to: " + score + " platforms";

        TheName = nameInput.text;
    }

    public void SetHighScore()
    {
        scoring.name = TheName;
        scoring.score = score;
        
        highScores.Add(scoring);
    }
}
