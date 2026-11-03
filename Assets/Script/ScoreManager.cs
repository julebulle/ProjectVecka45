using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    float score;
    float scoreMultiplier;
    TMP_Text scoreText;
    float currentStreak;
    float addedScore;

    const int powerUpIndicatorSize = 105;

    public 


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
        scoreMultiplier = currentStreak/10 + 1;
    }

    public void AddToScore(AccuracyEnum accuracyEnum)
    {
        if (accuracyEnum != AccuracyEnum.Miss)
        {
            if (accuracyEnum == AccuracyEnum.Nice)
            {
                addedScore += 100;
            }
            if (accuracyEnum == AccuracyEnum.Cool)
            {
                addedScore += 200;
            }
            if (accuracyEnum == AccuracyEnum.Perfect)
            {
                addedScore += 500;
            }
            addedScore *= scoreMultiplier;
            score += addedScore;
            currentStreak += 1;
            addedScore = 0;
        }
        else if (accuracyEnum == AccuracyEnum.Miss)
        {
            currentStreak = 0;
        }
    }
}
