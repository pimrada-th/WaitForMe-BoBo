using UnityEngine;
public class ClimbableEvents : MonoBehaviour
{
    //XRController controller;
    Color originalColor;
    public static int countClimbed = 0;
    void Start()
    {
        
        originalColor = GetComponent<MeshRenderer>().material.GetColor("_Color");

    }


    public void EffectsWhenGrabbed()
    {

        countClimbed++;
        GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.86792f, 0.62261f, 0.2497329f, 1));

    }

    public void RemoveEffectWhenNotGrab()
    {
        countClimbed--;
        GetComponent<MeshRenderer>().material.SetColor("_Color", originalColor);
    }
}
