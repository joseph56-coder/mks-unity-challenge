using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    private bool isPause;

    void Start()
    {
        pause.SetActive(false);
        isPause = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                GameReturn();
            }
            else
            {
                GamePause();
            }
        }
    }

    public void GamePause()
    {
        pause.SetActive(true);
        isPause = true;
        Time.timeScale = 0;
    }

    public void GameReturn()
    {
        pause.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
    }
}
