using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManeger : MonoBehaviour
{
    //instanciando objeto
    public int score;

    public float time = 100;
    public bool timeIsRunning = false;
    [SerializeField]
    TextMeshProUGUI timeText;
    public DestroyUtil destroyUtil;
    private void Start()
    {
        // impedindo de quando reiniciar ele ficar com oo jogo parad
        Time.timeScale = 1;
        timeIsRunning = true;
        //impedindo de se o tempo nao for selecionado ele colocar como padrao 1 minuto
        if (PlayerPrefs.HasKey("Time"))
        {
            time = PlayerPrefs.GetFloat("Time");
        }
        else
        {
            time = 60;
        }
    }

    //verifica se o tempo acabou a cada frame, se acabou ele manda a tela de game over
    void Update()
    {
        if (timeIsRunning)
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
    //setar o modo de display do tempo como um relogio normal
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
