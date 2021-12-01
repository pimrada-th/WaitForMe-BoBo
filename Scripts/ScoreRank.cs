using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Bindings;
public class ScoreRank : MonoBehaviour
{
    //PlayerPrefs.Set

    //int rank1; int rank2; int rank3;

    //int[] scores = new int[10];
    public static List<int> scores = new List<int>();
    int currentPoint;
    string rankNo;
    public int showRankList = 10;
    
    public List<TextMeshPro> rankTxt = new List<TextMeshPro>();
    
    /*
    public TextMeshPro txtRank1;
    public TextMeshPro txtRank2;
    public TextMeshPro txtRank3;
    */
    

    private void Awake()
    {
        currentPoint = StopWatchAndPoints.point;
        //set rank list from player playerpref to list
        for (int i = 0; i < showRankList; i++)
        {
            rankNo = "rank" + (i + 1);
            scores.Add(PlayerPrefs.GetInt(rankNo));
            //PlayerPrefs.SetInt(rankNo, 0);
        }




        
    }

    private void Start()
    {
        //Debug.Log("count "+scores.Count);


        for (int i = 0; i < showRankList; i++)
        {
            rankNo = "rank" + (i + 1);
            if (!scores.Contains(currentPoint))
            {
                //Debug.Log("workkkkk");
                if (currentPoint > scores[i])
                {
                    scores.Insert(i, currentPoint);

                    saveScoresInPlayerPref();
                }
            }



        }
        Ranking();
    }

    void saveScoresInPlayerPref()
    {
        //PlayerPrefs.SetInt(rankNo, currentPoint);
       for(int i = 0; i < showRankList; i++)
       {
            PlayerPrefs.SetInt("rank"+(i+1),scores[i]);
       }

       
    }

    public void Ranking()
    {
        
        for (int i = 0; i < showRankList; i++)
        {
            rankNo = "rank" + (i + 1);
            //Debug.Log(rankNo+" "+ PlayerPrefs.GetInt(rankNo));
            rankTxt[i].text = ""+PlayerPrefs.GetInt(rankNo);
        }
        
    }

}
