using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text bestComboText;
    ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        winText.text = "Final Score: " + scoreManager.score.ToString();
        bestComboText.text = new string("Lingest combo was: " + scoreManager.bestStreak.ToString());
    }
}
