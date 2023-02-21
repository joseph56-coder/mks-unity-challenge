using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyUtil : MonoBehaviour
{
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
    public void DestryHelper()
    {
        gameManeger.score++;
        Destroy(transform.parent.gameObject);
    }

    public void destryBulletHelper()
    {
        Destroy(transform.gameObject);
    }

    public void DestryplayerHelper()
    {
        GameOver();
        Destroy(transform.parent.gameObject);
    }

    public void GameOver()
    {
        scoreText.text = "HighScore: " + gameManeger.score;
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}