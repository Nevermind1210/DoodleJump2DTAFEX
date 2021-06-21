using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Saving_Stuff;

public class UIScoreHandler : MonoBehaviour
{
    public string TheName;
    [SerializeField] private TMP_InputField nameInput;

    [Header("Score")] 
    public static int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScore;

    public static List<HighScore> highScores = new List<HighScore>();
    public HighScore scoring;
    
    private void Start()
    {
        score = 0; // this allows fresh scores to be saved.
    }

    private void Update() 
    {
        scoreText.text = "Score: " + score; // Dynamically shows the score
        finalScore.text = "You made it to: " + score + " platforms"; 

        TheName = nameInput.text; // this is when we can store the values of whatever the player typed out!
    }

    public void SetHighScore() // this gets called once things are being set inside the list and inputs are made.
    {
        scoring.name = TheName;
        scoring.score = score;
        
        highScores.Add(scoring);
    }
}
