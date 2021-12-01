using System.Collections;
using UnityEngine;
public class CountHeart : MonoBehaviour
{
    public int heart;
    
    public GameObject player;
    public GameObject stopWatchAndPoints;
    public GameObject treeCollider;
    public static int heartsSize;
    GameObject leftHeart;
    GameObject centerHeart;
    GameObject rightHeart;

    private void Start()
    {
        heartsSize = heart;

    }

    void Update()
    {
        if(leftHeart == null)
            leftHeart = GameObject.Find("Heart1");
        if(centerHeart == null)
            centerHeart = GameObject.Find("Heart2");
        if(rightHeart == null)
            rightHeart = GameObject.Find("Heart3");

        
        //check heart all set
        if(leftHeart!=null && rightHeart != null && centerHeart!= null)
        {
            if (heartsSize == 2)
            {
                var changeHeartColor1 = leftHeart.GetComponent<MeshRenderer>();
                changeHeartColor1.material.SetColor("_Color", Color.gray);
            }
            if (heartsSize == 1)
            {
                var changeHeartColor1 = leftHeart.GetComponent<MeshRenderer>();
                changeHeartColor1.material.SetColor("_Color", Color.gray);
                var changeHeartColor2 = centerHeart.GetComponent<MeshRenderer>();
                changeHeartColor2.material.SetColor("_Color", Color.gray);

            }
            if (heartsSize <= 0)
            {
                var changeHeartColor1 = leftHeart.GetComponent<MeshRenderer>();
                changeHeartColor1.material.SetColor("_Color", Color.gray);
                var changeHeartColor2 = rightHeart.GetComponent<MeshRenderer>();
                changeHeartColor2.material.SetColor("_Color", Color.gray);
                var changeHeartColor3 = centerHeart.GetComponent<MeshRenderer>();
                changeHeartColor3.material.SetColor("_Color", Color.gray);
                treeCollider.SetActive(true);
                StartCoroutine(NoHeart());
            }
        }
    }

    IEnumerator NoHeart()
    {
        yield return new WaitForSeconds(1.5f);
        stopWatchAndPoints.GetComponent<StopWatchAndPoints>().GameOver();
        yield return new WaitForSeconds(1.5f);
        TriggeredWinLine.DestroySpawnerAndSpawnee();

    }

}
