using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    float score;
    float scoreMultiplier;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] TMP_Text plateTextR;
    [SerializeField] TMP_Text plateTextL;
    [SerializeField] TMP_Text plateTextU;
    [SerializeField] TMP_Text plateTextD;
    float currentStreak;
    float addedScore;
    NoteSpawner noteSpawner;

    public Image powerUp;
    const int powerUpIndicatorSize = 105;

    public 


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
    }

    public void AddToScore(AccuracyEnum accuracyEnum, DirectionEnum directionEnum)
    {
        if (accuracyEnum != AccuracyEnum.Miss)
        {
            if (accuracyEnum == AccuracyEnum.Nice)
            {
                #region
                if (directionEnum == DirectionEnum.Up) {noteSpawner.upEmitter.startColor = Color.green; plateTextU.gameObject.SetActive(true); plateTextU.text = "Nice!"; }
                if (directionEnum == DirectionEnum.Left) {noteSpawner.leftEmitter.startColor = Color.green; plateTextL.gameObject.SetActive(true); plateTextL.text = "Nice!"; }
                if (directionEnum == DirectionEnum.Right) {noteSpawner.rightEmitter.startColor = Color.green; plateTextR.gameObject.SetActive(true); plateTextR.text = "Nice!"; }
                if (directionEnum == DirectionEnum.Down) {noteSpawner.downEmitter.startColor = Color.green; plateTextD.gameObject.SetActive(true); plateTextD.text = "Nice!"; }
                #endregion
                addedScore += 100;
            }
            if (accuracyEnum == AccuracyEnum.Cool)
            {
                if (directionEnum == DirectionEnum.Up) { noteSpawner.upEmitter.startColor = Color.cyan; plateTextU.gameObject.SetActive(true); plateTextU.text = "Cool!"; }
                if (directionEnum == DirectionEnum.Left) { noteSpawner.leftEmitter.startColor = Color.cyan; plateTextL.gameObject.SetActive(true); plateTextL.text = "Cool!"; }
                if (directionEnum == DirectionEnum.Right) { noteSpawner.rightEmitter.startColor = Color.cyan; plateTextR.gameObject.SetActive(true); plateTextR.text = "Cool!"; }
                if (directionEnum == DirectionEnum.Down) { noteSpawner.downEmitter.startColor = Color.cyan; plateTextD.gameObject.SetActive(true); plateTextD.text = "Cool!"; }
                addedScore += 200;
            }
            if (accuracyEnum == AccuracyEnum.Perfect)
            {
                if (directionEnum == DirectionEnum.Up) { noteSpawner.upEmitter.startColor = Color.magenta; plateTextU.gameObject.SetActive(true); plateTextU.text = "Perfect!"; }
                if (directionEnum == DirectionEnum.Left) {noteSpawner.leftEmitter.startColor = Color.magenta; plateTextL.gameObject.SetActive(true); plateTextL.text = "Perfect!"; }
                if (directionEnum == DirectionEnum.Right) {noteSpawner.rightEmitter.startColor = Color.magenta; plateTextR.gameObject.SetActive(true); plateTextR.text = "Perfect!"; }
                if (directionEnum == DirectionEnum.Down) {noteSpawner.downEmitter.startColor = Color.magenta; plateTextD.gameObject.SetActive(true); plateTextD.text = "Perfect!"; }
                addedScore += 500;
            }
            addedScore *= scoreMultiplier;
            score += addedScore;
            currentStreak += 1;
            addedScore = 0;
        }
        else if (accuracyEnum == AccuracyEnum.Miss)
        {
            if (directionEnum == DirectionEnum.Up) { noteSpawner.upEmitter.startColor = Color.black; plateTextU.gameObject.SetActive(true); plateTextU.text = "Miss!"; }
            if (directionEnum == DirectionEnum.Left) { noteSpawner.leftEmitter.startColor = Color.black; plateTextL.gameObject.SetActive(true); plateTextL.text = "Miss!"; }
            if (directionEnum == DirectionEnum.Right) { noteSpawner.rightEmitter.startColor = Color.black; plateTextR.gameObject.SetActive(true); plateTextR.text = "Miss!"; }
            if (directionEnum == DirectionEnum.Down) { noteSpawner.downEmitter.startColor = Color.black; plateTextL.gameObject.SetActive(true); plateTextD.text = "Miss!"; }
            currentStreak = 0;
        }
    }
}
