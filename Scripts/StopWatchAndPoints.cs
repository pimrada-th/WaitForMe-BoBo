using System.Collections;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class StopWatchAndPoints : MonoBehaviour
{

    [Header("Game object assigns")]
    public GameObject player;
    public GameObject fadeIn;
    public AudioSource BGM;
    [Header("Stop watch and Point settings")]
    public float pointMultiplier = 100;
    public bool stopWatchActive = false;

    
    float maxYaxis;
    float nowYaxis;
    float currentTime;
    TimeSpan time;

    //public to another scene
    public static string timeStr;
    public static int point = 0;
    public static int starCount = 0;
    public static int starBonus = 0;
    public static int timeBonus = 0;

    void Start()
    {
        currentTime = 0;
        point = 0;
        starCount = 0;
        starBonus = 0;
        timeBonus = 0;
        maxYaxis = player.transform.position.y;
        
    }

    private void FixedUpdate()
    {

        nowYaxis = player.transform.position.y;
        if (stopWatchActive == true)
            currentTime = currentTime + Time.fixedDeltaTime;
        if (nowYaxis > maxYaxis)
            maxYaxis = nowYaxis;
    }

    public void StartStopWatch()
    {
        stopWatchActive = true;
    }
    public void GameOver()
    {
        StartCoroutine(CalLoseGame());

    }

    public void WinGame()
    {

        StartCoroutine(CalWinGame());
    }

    IEnumerator CalWinGame()
    {
        CalTimeBonus();
        stopWatchActive = false;
        time = TimeSpan.FromSeconds(currentTime);
        timeStr = time.ToString(@"mm\:ss");
        pointMultiplier *= 1.5f; //if win multipier increase 50%
        point = Mathf.RoundToInt((maxYaxis * pointMultiplier) + (currentTime * pointMultiplier) + (CountHeart.heartsSize * 10 *pointMultiplier)+starBonus+timeBonus);
        yield return new WaitForSeconds(4);
        fadeIn.SetActive(true);
        for (float i = BGM.volume; i > 0; i--)
        {
            BGM.volume = i;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);

    }
    IEnumerator CalLoseGame()
    {
        stopWatchActive = false;
        time = TimeSpan.FromSeconds(currentTime);
        timeStr = time.ToString(@"mm\:ss");
        point = Mathf.RoundToInt((maxYaxis * pointMultiplier) + (currentTime * pointMultiplier)+starBonus);
        yield return new WaitForSeconds(3);
        fadeIn.SetActive(true);
        for (float i = BGM.volume; i == 0; i-=0.1f)
        {
            BGM.volume = i;
            yield return null;
            Debug.Log(i);
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
    
    void CalTimeBonus()
    {
        //if win in <= 60 sec
        if (currentTime > 0 && currentTime <= 60)
            timeBonus = Mathf.RoundToInt(5 * 10 * pointMultiplier);
        //if win in 1 min 1 sec and <= 1 min 30 sec 
        else if (currentTime > 60 && currentTime <= 90)
            timeBonus = Mathf.RoundToInt(3 * 10 * pointMultiplier);
        //if win in 1 min 31 sec and <= 2 min
        else if (currentTime > 90 && currentTime <= 120)
            timeBonus = Mathf.RoundToInt(1.5f * 10 * pointMultiplier);
        else
            timeBonus = 0;
    }

}

