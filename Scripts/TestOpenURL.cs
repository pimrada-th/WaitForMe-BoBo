using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOpenURL : MonoBehaviour
{


    public void testOpenURL()
    {
        var changeColor = GetComponent<MeshRenderer>();
        changeColor.material.SetColor("_Color", Color.green);
        Application.OpenURL("http://unity3d.com/");
    }

}
