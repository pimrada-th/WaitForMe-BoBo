using UnityEngine;

public class WaterWorking : MonoBehaviour
{
    Vector3 newPOS;
    private void FixedUpdate()
    {
        newPOS = new Vector3(transform.position.x, transform.position.y + 0.003f, transform.position.z) ;
        transform.position = newPOS;
    }
}
