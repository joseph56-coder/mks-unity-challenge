using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private float time = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Spawn"))
        {
            time = PlayerPrefs.GetFloat("Spawn");
        }
        Debug.Log(time);
        StartCoroutine(SpawnerTime());
    }

    private void Spawner()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawns = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawns].position, transform.rotation);
    }

    private IEnumerator SpawnerTime()
    {
        yield return new WaitForSeconds(time);
        Spawner();
        StartCoroutine(SpawnerTime());
    }
}