using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManeger : MonoBehaviour
{
    public int score;

    public float time = 100;
    public bool timeIsRunning = false;
    [SerializeField]
    TextMeshProUGUI timeText;
    public DestroyUtil destroyUtil;
    private void Start()
    {
        timeIsRunning = true;
        if (PlayerPrefs.HasKey("Time"))
        {
            time = PlayerPrefs.GetFloat("Time");
        }
    }

    void Update()
    {
        if(timeIsRunning)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                DisplayTime(time);
            }
            else
            {
                UnityEngine.Debug.Log("acabou o tempo");
                time = 0;
                timeIsRunning = false;
                destroyUtil.GameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
