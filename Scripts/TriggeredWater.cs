using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggeredWater : MonoBehaviour
{
    public GameObject player;
    public AudioSource BGM;
    public float distanceBetweenOceanAndPlayer = 20;
    public GameObject stopWatchAndPoints;

    public GameObject waterSlashWhenTriggeredWaterEffect;
    public AudioSource waterSlashSoundEffect;
    
    public AudioSource dangerOceanWarningSound;
    
    AudioSource loseSound;

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < distanceBetweenOceanAndPlayer)
            dangerOceanWarningSound.volume = 1f;
        else
            dangerOceanWarningSound.volume = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawner" || other.tag =="Climbable" || other.tag == "Spawnee")
            Destroy(other.gameObject);
        if (other.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            CountHeart.heartsSize = 0;
            TriggeredWinLine.DestroySpawnerAndSpawnee();
            waterSlashSoundEffect.Play();
            waterSlashWhenTriggeredWaterEffect.SetActive(true);
            
            loseSound = GetComponent<AudioSource>();
            
            loseSound.PlayDelayed(1);
            if(loseSound.isPlaying)
                BGM.volume = 0.7f;
            
            Destroy(gameObject,3);
        }

        
            
    }

}
