using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TriggeredFirstLine : MonoBehaviour
{
    public GameObject waterWorking;
    public GameObject stopWatchAndPoints;

    public GameObject startBar;
    public AudioSource rockCrackingSound;
    public GameObject brokenRockEffect;

    public AudioSource warningWaterWorkingSound;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            waterWorking.GetComponent<WaterWorking>().enabled = true;
            stopWatchAndPoints.GetComponent<StopWatchAndPoints>().StartStopWatch();
            StartCoroutine(DestroyBar());
           
        }
    }

    IEnumerator DestroyBar()
    {

        warningWaterWorkingSound.Play();
        yield return new WaitForSeconds(3);
        rockCrackingSound.Play();
        brokenRockEffect.SetActive(true);
        Destroy(startBar);
        Destroy(gameObject);
    }

    
}
