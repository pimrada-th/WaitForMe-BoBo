using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredSecondLine : MonoBehaviour
{
    public GameObject player;
    public GameObject secondSpawner;

    AudioSource warningSound;
    
    private void Start()
    {
        warningSound = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            warningSound.Play();
            StartCoroutine(StartSpawner());
            
        }
    }
    IEnumerator StartSpawner()
    {
        yield return new WaitForSeconds(2);
        secondSpawner.GetComponent<TimedSpawn>().enabled = true;
        Destroy(gameObject, 3f);
    }
    
}
