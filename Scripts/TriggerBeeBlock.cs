using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBeeBlock : MonoBehaviour
{
    public GameObject Bee;
    AudioSource warningSound;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(DestroyTriggerBeeBlock());
        }
    }

    IEnumerator DestroyTriggerBeeBlock()
    {
        warningSound = GetComponent<AudioSource>();
        warningSound.Play();
        Bee.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
