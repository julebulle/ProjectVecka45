using UnityEngine;
using UnityEngine.Rendering;

public class ScoreManager : MonoBehaviour
{
    int score;
    int scoreMultiplier;

    int currentStreak;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreMultiplier = 0;
        currentStreak = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int Score)
    {

    }
}
