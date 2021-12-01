using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ShowPointsAndTime : MonoBehaviour
{
    
    public TextMeshPro showPointsText;
    public TextMeshPro showRankText;
    public TextMeshPro showTimeText;
    public TextMeshPro showTimeBonusText;
    public TextMeshPro showCountStarText;
    public TextMeshPro showStarBonusText;
    public AudioSource countScoreSFX;
    public AudioSource resultSFX;
    public AudioSource BGM;
    public float waitingLoadPoint = 1;
    GameObject rank;
    GameObject rankPOS;
    int pointBegin = 0;
    int pointResult = StopWatchAndPoints.point;

    private void Start()
    {
        showPointsText.text = "";
        showRankText.text = "";
        showTimeText.text = StopWatchAndPoints.timeStr;
        showCountStarText.text = ""+StopWatchAndPoints.starCount;
        if (pointResult != 0)
        {
            countScoreSFX.PlayDelayed(2);
            if (StopWatchAndPoints.timeBonus > 0)
            {
                showTimeBonusText.text = "+ " + StopWatchAndPoints.timeBonus;
            }
            else
            {
                showTimeBonusText.text = "";
            }
            if (StopWatchAndPoints.starCount > 0)
            {
                showStarBonusText.text = "+ " + StopWatchAndPoints.starBonus;
            }
            else
            {
                showStarBonusText.text = "";
            }
        }
    }
    private void Update()
    {
        StartCoroutine(countScore());
    }
    IEnumerator countScore()
    {
        yield return new WaitForSeconds(waitingLoadPoint);
        if (pointBegin < pointResult)
        {
            if ((pointResult - pointBegin) > 100)
            {
                pointBegin += 100;
                showPointsText.text = pointBegin.ToString();
            }

            if ((pointResult - pointBegin) <= 100)
            {
                pointBegin += 1;
                showPointsText.text = pointBegin.ToString();
            }

            if (pointBegin == pointResult)
            {
                BGM.volume = 0.3f;
                countScoreSFX.Pause();
                resultSFX.PlayDelayed(0.5f);
                //showTimeText.text = StopWatchAndPoints.timeStr;
                yield return new WaitForSeconds(0.5f);
                BGM.volume = 0.7f;
                //resultSFX.PlayDelayed(0.3f);
                if (ScoreRank.scores.Contains(pointResult))
                {
                    if (pointResult == ScoreRank.scores[0])
                    {
                        showRankText.text = "1st";

                        BlinkRankText(1);
                    }
                    if (pointResult == ScoreRank.scores[1])
                    {
                        showRankText.text = "2nd";
                        BlinkRankText(2);
                    }
                    if (pointResult == ScoreRank.scores[2])
                    {
                        showRankText.text = "3nd";
                        BlinkRankText(3);
                    }
                    if (pointResult == ScoreRank.scores[3])
                    {
                        showRankText.text = "4th";
                        BlinkRankText(4);
                    }
                    if (pointResult == ScoreRank.scores[4])
                    {
                        showRankText.text = "5th";
                        BlinkRankText(5);
                    }
                    if (pointResult == ScoreRank.scores[5])
                    {
                        showRankText.text = "6th";
                        BlinkRankText(6);
                    }
                    if (pointResult == ScoreRank.scores[6])
                    {
                        showRankText.text = "7th";
                        BlinkRankText(7);
                    }
                    if (pointResult == ScoreRank.scores[7])
                    {
                        showRankText.text = "8th";
                        BlinkRankText(8);
                    }
                    if (pointResult == ScoreRank.scores[8])
                    {
                        showRankText.text = "9th";
                        BlinkRankText(9);
                    }

                    if (pointResult == ScoreRank.scores[9])
                    {
                        showRankText.text = "10th";
                        BlinkRankText(10);
                    }

                }
            }
        }
    }

    void BlinkRankText(int rankNo)
    {
        rank = GameObject.Find(""+rankNo);
        rankPOS = GameObject.Find(rankNo+"/"+"Text Pos");
        rank.GetComponent<Animator>().enabled = true;
        rankPOS.GetComponent<Animator>().enabled = true;
        /*yield return new WaitForSeconds(10);
        rank.GetComponent<Animator>().enabled = false;
        rank.GetComponent<TextMeshPro>().alpha = 1;
        rankPOS.GetComponent<Animator>().enabled = false;
        rankPOS.GetComponent<TextMeshPro>().alpha = 1;
        */
    }
}
