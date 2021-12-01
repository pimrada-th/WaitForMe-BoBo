using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class EnemyTrigger : MonoBehaviour
{
    AudioSource rockSound;
    GameObject HeartAtkEffect;
    public AudioSource heartBreakSound;

    private void Start()
    {
        rockSound = GetComponent<AudioSource>();
        HeartAtkEffect = GameObject.Find("HeartAtkEffect");
        HeartAtkEffect.GetComponent<Image>().enabled = false;
        GetComponent<Rigidbody>().AddForce(-transform.forward*500,ForceMode.Acceleration);
        rockSound.Play();
        Destroy(gameObject, 3.2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Water")
            Destroy(gameObject);
        if(other.tag == "Player")
        {
            Debug.Log("Trgg");
            GetComponent<Collider>().enabled = false;
            CountHeart.heartsSize--;
            heartBreakSound.Play();
            StartCoroutine(PlayHeartAtkEffect());
        }
    }

    IEnumerator PlayHeartAtkEffect()
    {
        Debug.Log("work");
        HeartAtkEffect.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(2);
        HeartAtkEffect.GetComponent<Image>().enabled = false;
        if(!HeartAtkEffect.GetComponent<Image>().IsActive())
            Destroy(gameObject);
    }
}
