using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderBoardLogic : MonoBehaviour
{
    /*
    public static List<ScoreInfo> contenders = new List<ScoreInfo>(10);
    public List<LeaderBoardContendor> contenterText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < contenders.Count && i < contenterText.Count; i++)
        {
            if(contenders[i] != null)
            {
                contenterText[i].playerName.text = contenders[i].playerName;
                contenterText[i].score.text = contenders[i].Score.ToString();
                contenterText[i].streak.text = contenders[i].longeststreak.ToString();
                contenterText[i].song = contenders[i].song;
            }

        }
    }

    // Update is called once per frame
    public static void UpdateLeaderBoard(ScoreInfo scoreInfo)
    {
        for (int i = 0; i < contenders.Count; i++)
        {
            if (contenders[i] != null)
            {
                if (scoreInfo.Score > contenders[i].Score)
                {
                    contenders.Insert(i, scoreInfo);
                }
            }
            else
            {
                contenders.Insert(i, scoreInfo);
            }
            
        }
    }*/

}
