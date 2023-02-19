using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(5);
        Spawner();
        StartCoroutine(SpawnerTime());
    }
}