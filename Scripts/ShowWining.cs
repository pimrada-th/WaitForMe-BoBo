using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TriggeredWinLine : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem firework;
    public GameObject stopWatchAndPoints;
    public GameObject checkGripping;
    public GameObject WonText;
    AudioSource winSound;
    
    //private GameObject[] spawners;
    private void Start()
    {
        winSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (CountHeart.heartsSize <= 0)
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player" && CountHeart.heartsSize > 0)
        {
            GetComponent<BoxCollider>().enabled=false;
            transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            checkGripping.GetComponent<CheckGripping>().enabled = false;
            DestroySpawnerAndSpawnee();

            WonText.SetActive(true);
            player.GetComponent<RockMoving>().enabled = true;
            firework.Play();
            Destroy(WonText,3);
            
            winSound.Play();
            
            stopWatchAndPoints.GetComponent<StopWatchAndPoints>().WinGame();
        }
            
    }

    public static void DestroySpawnerAndSpawnee()
    {
        Destroy(GameObject.FindGameObjectWithTag("Spawner"));

        foreach (GameObject spawnee in GameObject.FindGameObjectsWithTag("Spawnee"))
            Destroy(spawnee);
    }
}
