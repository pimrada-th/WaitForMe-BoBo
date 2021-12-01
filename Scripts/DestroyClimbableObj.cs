using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClimbableObj : MonoBehaviour
{
    float time = 0;
    public void DestroyClimbableObjAfterTouched()
    {
        Debug.Log("sdsd");
        StartCoroutine(Blink(2.0f));
        //InvokeRepeating("BlinkObj", 1, 0.02f);
        //InvokeRepeating("BlinkObj2", 1, 0.02f);
    }
    

    IEnumerator Blink(float waitTime)
    {
        var endTime = Time.time + waitTime;
        
        //Debug.Log(time+Time.deltaTime);
        yield return null;
        
        while (time < waitTime)
        {
            Debug.Log("trueeeee");
            GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.4f);
            GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.4f);
            time += 0.1f;
        }
        //if(time == waitTime)
        Destroy(gameObject);
        
    }

}
