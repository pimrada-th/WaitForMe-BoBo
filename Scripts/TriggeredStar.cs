using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredStar : MonoBehaviour
{
    AudioSource starSound;
    private void Start()
    {
        starSound = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(other+" triggered");
            Debug.Log(StopWatchAndPoints.starCount+ " before");
            GetComponent<Collider>().enabled = false;
            
            Debug.Log("colliderOff");
            StopWatchAndPoints.starCount++;
            Debug.Log(StopWatchAndPoints.starCount + " after");
            StopWatchAndPoints.starBonus += 500;
            starSound.Play();
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject,1);
        }
    }

}
