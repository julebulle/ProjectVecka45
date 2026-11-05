using NUnit.Framework.Constraints;
using System.Collections;
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
    [SerializeField] GameObject background;
    [SerializeField] GameObject salmon;
    [SerializeField] Sprite goodSalmon;
    [SerializeField] Sprite superSalmon;
    [SerializeField] Sprite perfectSalmon;
    int currentStreak;
    int realCurrentStreak;
    public int bestStreak;
    [SerializeField]int maxStreak;
    [SerializeField]int streakBarProgression;
    public TMP_Text streakText;
    public static bool streakRewardInProgress;
    float addedScore;
    NoteSpawner noteSpawner;
    public float maxPoints;

    public Image powerUp;
    float streakrewardCountdown = 500 / 15;

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

        
        if (!streakRewardInProgress)
        {
            powerUp.rectTransform.sizeDelta = new Vector2(100 * streakBarProgression, 100);
        }
        else
        {
            powerUp.rectTransform.sizeDelta -= new Vector2(streakrewardCountdown, 0) * Time.deltaTime;
        }
    }

    public void AddToScore(AccuracyEnum accuracyEnum, DirectionEnum directionEnum)
    {
        maxPoints += 500;
        if (accuracyEnum != AccuracyEnum.Miss)
        {
            if(realCurrentStreak > bestStreak)
            {
                bestStreak = realCurrentStreak;
            }
            if (accuracyEnum == AccuracyEnum.Nice)
            {
                SetEffects(directionEnum, Color.green, "Good!");
                addedScore += 100;
                salmon.GetComponent<SpriteRenderer>().sprite = goodSalmon;
            }
            if (accuracyEnum == AccuracyEnum.Cool)
            {
                SetEffects(directionEnum, Color.cyan, "Super!");
                addedScore += 200;
                salmon.GetComponent<SpriteRenderer>().sprite = superSalmon;
            }
            if (accuracyEnum == AccuracyEnum.Perfect)
            {
                SetEffects(directionEnum, Color.magenta, "Perfect!");
                addedScore += 500;
                salmon.GetComponent<SpriteRenderer>().sprite = perfectSalmon;
            }
            addedScore *= scoreMultiplier;
            score += addedScore;
            realCurrentStreak += 1;
            if (!streakRewardInProgress)
            {
                currentStreak += 1;
            }
            
            addedScore = 0;
        }
        else if (accuracyEnum == AccuracyEnum.Miss)
        {
            SetEffects(directionEnum, Color.black, "Miss!");
            currentStreak = 0;
            realCurrentStreak = 0;
            salmon.GetComponent<SpriteRenderer>().sprite = null;
        }

        

        
        if(streakBarProgression < maxStreak)
        {
            streakBarProgression = Mathf.FloorToInt(currentStreak * 0.2f);
        }
        if(streakBarProgression == 5 && !streakRewardInProgress)
        {
            StartCoroutine(EnablePlaceHolderMode());
        }
    }

    public IEnumerator EnablePlaceHolderMode()
    {
        Debug.Log("Start streak reward");
        powerUp.rectTransform.sizeDelta = new Vector2(500, 100);
        scoreMultiplier = 5;
        streakRewardInProgress = true;
        streakBarProgression = 0;
        currentStreak = 0;
        background.SetActive(false);
        yield return new WaitForSeconds(15);
        background.SetActive(true);
        streakRewardInProgress = false;
        scoreMultiplier = 1;
        Debug.Log("end streakReward");

    }

    public void SetEffects(DirectionEnum directionEnum, Color effectcolor, string text)
    {
        if (directionEnum == DirectionEnum.Up) { noteSpawner.upEmitter.startColor = effectcolor; plateTextU.gameObject.SetActive(true); plateTextU.text = text; }
        if (directionEnum == DirectionEnum.Left) { noteSpawner.leftEmitter.startColor = effectcolor; plateTextL.gameObject.SetActive(true); plateTextL.text = text; }
        if (directionEnum == DirectionEnum.Right) { noteSpawner.rightEmitter.startColor = effectcolor; plateTextR.gameObject.SetActive(true); plateTextR.text = text; }
        if (directionEnum == DirectionEnum.Down) { noteSpawner.downEmitter.startColor = effectcolor; plateTextD.gameObject.SetActive(true); plateTextD.text = text; }
    }

    private void OnLevelWasLoaded(int level)
    {
        streakRewardInProgress = false;
    }
}
