using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class testInteract : MonoBehaviour
{
    public GameObject startBar;
    public GameObject testObj;
    public XRNode inputSource;
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        var changeColor = testObj.GetComponent<MeshRenderer>();
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startBar.SetActive(false);
        }*/

        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool primaryButton))
        {
            changeColor.material.SetColor("_Color", Color.green);
        }
        //startBar.SetActive(false);
    }
}
