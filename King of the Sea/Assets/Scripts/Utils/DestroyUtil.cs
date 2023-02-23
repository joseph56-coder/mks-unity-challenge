using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyUtil : MonoBehaviour
{
    //instanciando objeto
    [SerializeField]
    TextMeshProUGUI scoreText;
    public GameObject gameOver;

    public GameManeger gameManeger;
    private GameObject hand;

    void Start()
    {
        hand = GameObject.Find("EventSystem");
        gameManeger = hand.GetComponent<GameManeger>();
    }

    //destroi o inimigo e da a pontuacao
    public void DestryHelper()
    {
        gameManeger.score += 100;
        Destroy(transform.parent.gameObject);
    }

    //para destruir as bolas de canhoes
    public void destryBulletHelper()
    {
        Destroy(transform.gameObject);
    }

    //para destruir o player e chamar a tela de game over
    public void DestryplayerHelper()
    {
        GameOver();
        Destroy(transform.parent.gameObject);
    }

    //ativa a tela de game over
    public void GameOver()
    {
        scoreText.text = "HighScore: " + gameManeger.score;
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}