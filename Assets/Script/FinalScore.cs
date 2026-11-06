using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text bestComboText;
    [SerializeField] TMP_Text precentage;
    [SerializeField] TMP_Text rankText;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject teto;
    //[SerializeField] GameObject playerNameobj;
    ScoreManager scoreManager;
    //[SerializeField]ScoreInfo scoreToPublish;
    //public string playerName;
    //public TMP_Text playerInput;
    //public string songName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetPrecantage()
    {
        return Mathf.FloorToInt((100 * (scoreManager.score / scoreManager.maxPoints)));
    }

    public string GetRank()
    {
        if(GetPrecantage() < 20)
        {
            return new string("E");
        }
        if (GetPrecantage() < 40)
        {
            return new string("D");
        }
        if (GetPrecantage() < 60)
        {
            return new string("C");
        }
        if (GetPrecantage() < 80)
        {
            return new string("B");
        }
        if (GetPrecantage() < 100)
        {
            return new string("A");
        }
        if (GetPrecantage() >= 100)
        {
            return new string("S");
        }
        else
        {
            return new string("Rank Missing");
        }
    }

    public IEnumerator AnimateResults()
    {
        winText.gameObject.SetActive(false);
        bestComboText.gameObject.SetActive(false);
        precentage.gameObject.SetActive(false);
        rankText.gameObject.SetActive(false);
        mainMenuButton.SetActive(false);
        teto.SetActive(false);
        

        winText.text = "Final Score: " + scoreManager.score.ToString();
        bestComboText.text = new string("Longest combo was: " + scoreManager.bestStreak.ToString());
        precentage.text = new string("Precentage: " + GetPrecantage().ToString()) + "% out of " + scoreManager.maxPoints.ToString();
        rankText.text = new string("Rank: " + GetRank());

        yield return new WaitForSecondsRealtime(1);
        winText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        bestComboText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        precentage.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        rankText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        mainMenuButton.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        teto.SetActive(true);



    }

    /*public void PublishScoreToLeaderBoard()
    {
        scoreToPublish.playerName = playerInput.text;
        scoreToPublish.longeststreak = scoreManager.bestStreak;
        scoreToPublish.song = songName;
        scoreToPublish.Score = Mathf.FloorToInt(scoreManager.score);
        LeaderBoardLogic.UpdateLeaderBoard(scoreToPublish);
    }*/
}
