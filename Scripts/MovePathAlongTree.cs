using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePathAlongTree : MonoBehaviour
{
    public GameObject Player;
    public float treeMinY;
    public float treeMaxY;
    Vector3 nowPOS;

    private void Update()
    {
        if (Player.transform.position.y > treeMinY)
            treeMinY = Player.transform.position.y;
    }
    private void OnEnable()
    {
        InvokeRepeating("RandomPathPOS",4,8);
    }

    void RandomPathPOS()
    {
        transform.position = new Vector3(transform.position.x ,Random.Range(treeMinY, treeMaxY), transform.position.z );
    }
}
