using TMPro;
using UnityEngine;

public class UIScoreHandler : MonoBehaviour
{
    public GameObject finalScore;
    public GameObject scoreText;
    public GameObject player;
    public static int score;

    private void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        finalScore.GetComponent<TextMeshProUGUI>().text = "You made it to: " + score + " platforms";
    }
}
