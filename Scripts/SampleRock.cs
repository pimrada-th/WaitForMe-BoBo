using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class SampleRock : MonoBehaviour
{
    public GameObject GrabText;
    public GameObject GoodJobtext;
    public GameObject ClimbUpText;
    public GameObject copySampleRock;
    // Start is called before the first frame update
    public void StopAnimWhenGrab()
    {
        
        
        if (gameObject.activeSelf == false)
        {
            StopAllCoroutines();
            //Debug.Log(gameObject.activeSelf);
        }
        else
        {
            StartCoroutine(StopAnimProcess());
        }
            
    }

    IEnumerator StopAnimProcess()
    {
        GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        GrabText.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GoodJobtext.SetActive(true);
        yield return new WaitForSeconds(2f);
        GoodJobtext.SetActive(false);
        copySampleRock.SetActive(true);
        ClimbUpText.SetActive(true);
        Destroy(ClimbUpText,6);
        gameObject.SetActive(false);
        
        
    }
}
