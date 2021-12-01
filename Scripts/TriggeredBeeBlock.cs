using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredBeeBlock : MonoBehaviour
{
    public GameObject Bee;
    AudioSource warningSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            warningSound = GetComponent<AudioSource>();
            warningSound.Play();
            Bee.SetActive(true);
            Destroy(gameObject, 1);
        }
    }

}
