using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPref : MonoBehaviour
{

    public void ResetPlayerPrefOnBuild()
    {
        PlayerPrefs.DeleteAll();
    }
}
