using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //instanciando objeto
    public GameObject config, creditos;
    void Start()
    {
        Time.timeScale = 1;
        //impedindo a tela de configuracoes ficar visivel quando inicia
        config.SetActive(false);
    }

    //setando o tempo de jogo
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

    //setando o tempo de spawn
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

    //para fechar a aba configuraçoes
    public void close()
    {
        config.SetActive(false);
    }

    //para abrir a aba configuraçoes
    public void open()
    {
        config.SetActive(true);
    }

    //abrir Tela Creditos
    public void Creditos()
    {
       creditos.SetActive(true);
    }

    //fechar tela creditos
    public void FecharCreditos()
    {
       creditos.SetActive(false);
    }

    //voltar para o menu principal na tela de game over
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu_Principal", LoadSceneMode.Single);
    }

    //reiniciar o jogo
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    //mudar de tela cheia para modo janela
    public void Fulllscreen(bool isFullScreen)
    {
        if (isFullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    //fechar jogo
    public void closeGame()
    {
        Application.Quit();
    }
}
