using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public Transform player;
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public float xMinLength;
    public float xMaxLength;
    public float depthOfspawner = 4.8f;
    float x;
    Vector3 pos;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x,player.position.y+12,player.transform.position.z+depthOfspawner);
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawning)
            CancelInvoke("SpawnObject");

    }

    void RandomSpawnerPOS()
    {
        x = Random.Range(xMinLength, xMaxLength);
        pos = new Vector3(x, transform.position.y, transform.position.z);
        transform.position = pos;
    }
    private void OnEnable()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        InvokeRepeating("RandomSpawnerPOS", 1, 2);
    }
    private void OnDisable()
    {
        CancelInvoke("SpawnObject");
        CancelInvoke("RandomSpawnerPOS");
    }

}
