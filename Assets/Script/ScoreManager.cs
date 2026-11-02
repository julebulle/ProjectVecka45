using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreManager : MonoBehaviour
{
    int score;
    int scoreMultiplier;
    TMP_Text scoreText;
    int currentStreak;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreMultiplier = 1;
        currentStreak = 0;
        scoreText = FindAnyObjectByType<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score;
        if (Input.anyKeyDown)
        {
            AddToScore(10);
        }
    }

    public void AddToScore(int Score)
    {
        score *= scoreMultiplier;
        score += Score;
        currentStreak += 1;
        scoreMultiplier += 1;
    }
}
