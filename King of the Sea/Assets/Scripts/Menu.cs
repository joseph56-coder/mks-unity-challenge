using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject config;
    void Start()
    {
        config.SetActive(false);
    }
    public void TimeDropDown(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetFloat("Time", 60);
        }
        if (val == 1)
        {
            PlayerPrefs.SetFloat("Time", 120);
        }
        if (val == 2)
        {
            PlayerPrefs.SetFloat("Time", 180);
        }
    }

    public void SpawnTimeDropDown(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetFloat("Spawn", 3);
        }
        if (val == 1)
        {
            PlayerPrefs.SetFloat("Spawn", 5);
        }
        if (val == 2)
        {
            PlayerPrefs.SetFloat("Spawn", 7);
        }
    }

    public void close()
    {
        config.SetActive(false);
    }

    public void open()
    {
        config.SetActive(true);
    }

    public void play()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu_Principal");
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
