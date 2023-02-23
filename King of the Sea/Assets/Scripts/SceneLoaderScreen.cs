using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoaderScreen : MonoBehaviour
{
    public GameObject LoaderUI, barProgress, Text;
    public Slider progressBar;

    public void LoadScene()
    {
        StartCoroutine(LoadScene_Coroutine());
    }

    public IEnumerator LoadScene_Coroutine()
    {
        progressBar.value = 0;
        LoaderUI.SetActive(true);
        Text.SetActive(false);
        barProgress.SetActive(true);
        

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;
        while (!asyncOperation.isDone)
        {
            Debug.Log("carregando");
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressBar.value = progress;
            Debug.Log(progress);
            if (progress >= 0.9f)
            {
                progressBar.value = 1;
                barProgress.SetActive(false);
                Text.SetActive(true);
                if (Input.anyKeyDown)
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}