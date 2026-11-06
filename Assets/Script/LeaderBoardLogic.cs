using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LeaderBoardLogic : MonoBehaviour
{//booooooi, codity var här
    public static ScoreInfo[] contenders = new ScoreInfo[5];
    public List<LeaderBoardContendor> contenterText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < contenders.Length; i++)
        {
            if(contenders[i] != null)
            {
                contenterText[i].playerName.text = contenders[i].playerName;
                contenterText[i].score.text = contenders[i].Score.ToString();
                contenterText[i].streak.text = contenders[i].longeststreak.ToString();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
