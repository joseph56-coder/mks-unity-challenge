using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    //instanciando objeto
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        //verifica se o Spawn foi setado nas configuraçoes, se naoo, ira colocar o valor padrao
        if (PlayerPrefs.HasKey("Spawn"))
        {
            time = PlayerPrefs.GetFloat("Spawn");
        }
        else
        {
            time = 3;
        }
        Debug.Log(time);
        StartCoroutine(SpawnerTime());
    }

    //Spawna um inimigo aleatorio num ponto de spawn aleatorio
    private void Spawner()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawns = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawns].position, transform.rotation);
    }

    //faz esperar para spawnar o inimigo
    private IEnumerator SpawnerTime()
    {
        yield return new WaitForSeconds(time);
        Spawner();
        StartCoroutine(SpawnerTime());
    }
}