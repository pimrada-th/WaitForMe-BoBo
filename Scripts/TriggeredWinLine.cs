using UnityEngine;

public class TriggeredWinLine : MonoBehaviour
{
    public GameObject player;
    public GameObject triggeredWater;
    public ParticleSystem firework;
    public GameObject stopWatchAndPoints;
    public GameObject WonText;
    AudioSource winSound;
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
            GetComponent<Collider>().enabled=false;
            triggeredWater.SetActive(false);
            transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            DestroySpawnerAndSpawnee();
            WonText.SetActive(true);
            player.GetComponent<RockMoving>().enabled = true;
            firework.Play();
            //Destroy(WonText,3);
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
