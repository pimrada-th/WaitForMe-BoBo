using System.Collections;
using UnityEngine;
using PathCreation.Examples;
using UnityEngine.UI;
public class BeeTriggredPlayer : MonoBehaviour
{
    public Animator beeAnimator;
    public AudioSource heartBreakSound;
    public GameObject atkPOS;
    GameObject HeartAtkEffect;
    public Vector3 BeeRotation;
    //public XRNode centerFace;

    private void Start()
    {
        HeartAtkEffect = GameObject.Find("HeartAtkEffect");
    }

    private void Update()
    {
        if(!GetComponent<PathFollower>().isActiveAndEnabled)
            transform.position = atkPOS.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(BeeAtkPlayer());
        }
        
    }

    
    
    IEnumerator BeeAtkPlayer()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<PathFollower>().enabled = false;
        CountHeart.heartsSize--;
        HeartAtkEffect.GetComponent<Image>().enabled = true;
        transform.rotation = Quaternion.Euler(BeeRotation);

        beeAnimator.SetTrigger("Attack");
        
        heartBreakSound.PlayDelayed(0.5f);

        yield return new WaitForSeconds(2);
        HeartAtkEffect.GetComponent<Image>().enabled = false;
        GetComponent<PathFollower>().enabled = true;
        Destroy(gameObject, 2);
    }

}
