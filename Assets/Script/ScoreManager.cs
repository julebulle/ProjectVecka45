using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score;
    float scoreMultiplier;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] TMP_Text plateTextR;
    [SerializeField] TMP_Text plateTextL;
    [SerializeField] TMP_Text plateTextU;
    [SerializeField] TMP_Text plateTextD;
    int currentStreak;
    int bestStreak;
    int maxStreak;
    public TMP_Text streakText;
    float addedScore;
    NoteSpawner noteSpawner;

    public Image powerUp;
    const int powerUpIndicatorSize = 105;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plateTextR.gameObject.SetActive(false);
        plateTextL.gameObject.SetActive(false);
        plateTextU.gameObject.SetActive(false);
        plateTextD.gameObject.SetActive(false);
        score = 0;
        scoreMultiplier = 1;
        currentStreak = 0;
        noteSpawner = FindAnyObjectByType<NoteSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score;
        scoreMultiplier = currentStreak/10 + 1;

        if (streakText != null)
        {
            streakText.text = new string(currentStreak.ToString() + "                       Best Streak" + bestStreak.ToString());

        }
        
    }

    public void AddToScore(AccuracyEnum accuracyEnum, DirectionEnum directionEnum)
    {
        if (accuracyEnum != AccuracyEnum.Miss)
        {
            if(currentStreak > bestStreak)
            {
                bestStreak = currentStreak;
            }
            if (accuracyEnum == AccuracyEnum.Nice)
            {
                SetEffects(directionEnum, Color.green, "Nice!");
                addedScore += 100;
            }
            if (accuracyEnum == AccuracyEnum.Cool)
            {
                SetEffects(directionEnum, Color.cyan, "Cool!");
                addedScore += 200;
            }
            if (accuracyEnum == AccuracyEnum.Perfect)
            {
                SetEffects(directionEnum, Color.magenta, "Perfect!");
                addedScore += 500;
            }
            addedScore *= scoreMultiplier;
            score += addedScore;
            currentStreak += 1;
            addedScore = 0;
        }
        else if (accuracyEnum == AccuracyEnum.Miss)
        {
            SetEffects(directionEnum, Color.black, "Miss!");
            currentStreak = 0;
        }
    }

    public void SetEffects(DirectionEnum directionEnum, Color effectcolor, string text)
    {
        if (directionEnum == DirectionEnum.Up) { noteSpawner.upEmitter.startColor = effectcolor; plateTextU.gameObject.SetActive(true); plateTextU.text = text; }
        if (directionEnum == DirectionEnum.Left) { noteSpawner.leftEmitter.startColor = effectcolor; plateTextL.gameObject.SetActive(true); plateTextL.text = text; }
        if (directionEnum == DirectionEnum.Right) { noteSpawner.rightEmitter.startColor = effectcolor; plateTextR.gameObject.SetActive(true); plateTextR.text = text; }
        if (directionEnum == DirectionEnum.Down) { noteSpawner.downEmitter.startColor = effectcolor; plateTextD.gameObject.SetActive(true); plateTextD.text = text; }
    }
}
