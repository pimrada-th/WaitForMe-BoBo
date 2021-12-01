using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonScripts : MonoBehaviour
{
    public GameObject sceneLoader;
    /*
    private void Awake()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneIndex = 0;
        sceneLoader.SetActive(false);
    }
    */
    public void BackHome()
    {
        //SceneManager.LoadScene(0); // home
        sceneLoader.GetComponent<SceneLoader>().sceneIndex = 0;
        sceneLoader.SetActive(true);
    }
    public void EnterGame()
    {
        //SceneManager.LoadScene(1); //enter game
        sceneLoader.GetComponent<SceneLoader>().sceneIndex = 1;
        sceneLoader.SetActive(true);
    }
}

