using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeScene : MonoBehaviour
{
    public Image fadeIMG;
    void Start()
    {
        fadeIn();
    }

    void fadeIn()
    {
        fadeIMG.canvasRenderer.SetAlpha(0); //0 invisible, 1 visible
        fadeIMG.CrossFadeAlpha(1,3,false);//alpha, duration, using timescale or not
    }

    void fadeOut()
    {
        fadeIMG.canvasRenderer.SetAlpha(1); //0 invisible, 1 visible
        fadeIMG.CrossFadeAlpha(0,3, false);//alpha, duration, using timescale or not
    }
}
