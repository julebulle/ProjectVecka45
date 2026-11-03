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
        if (Input.GetKeyDown("s"))
        {
            AddToScore(AccuracyEnum.Perfect);
        }
        scoreMultiplier = currentStreak + 1;
    }

    public void AddToScore(AccuracyEnum accuracyEnum)
    {
        score *= scoreMultiplier;
        currentStreak += 1;
    }
}
