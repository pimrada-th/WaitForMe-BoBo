using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public GameObject fadeIMG;
    public GameObject UI;
    public Slider slider;
    public TextMeshPro progressText;
    public int sceneIndex;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        _ = StartCoroutine(LoadSceneAsync(sceneIndex));
    }


    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        UI.SetActive(false);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = Mathf.RoundToInt(progress * 100f) + "%";

            if (operation.progress >= 0.9f)
            {
                Debug.Log("work");
                fadeIMG.SetActive(true);
                yield return new WaitForSeconds(3);
                operation.allowSceneActivation = true;
            }
            yield return null;
        }


    }
}