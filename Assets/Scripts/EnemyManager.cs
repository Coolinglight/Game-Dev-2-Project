using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public Transform[] spawnPoint;
    public string[] playerNames;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;
    public int spawnCount = 10;
    public float spawnDelay = 3;

    void Start()
    {
        StartCoroutine(SpawnEnemyDelayed());
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnEnemy();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            KillAllEnemies();
        }
    }

    void SpawnEnemy()
    {
        int enemyNumber = Random.Range(0, enemyTypes.Length);
        int spawnPoints = Random.Range(0, spawnPoint.Length);
        GameObject enemy = Instantiate(enemyTypes[enemyNumber], spawnPoint[spawnPoints].position, spawnPoint[spawnPoints].rotation, transform);
        enemies.Add(enemy);
    }

    void KillAllEnemies()
    {
        if (enemies.Count == 0)
            return;
        for(int i = 0; i < enemies.Count; i++)
        {
            Destroy(enemies[i]);
        }
        enemies.Clear();
    }

    IEnumerator SpawnEnemyDelayed()
    {
        for(int i = 0; i < spawnPoint.Length; i++)
        {
            int rndEnemy = Random.Range(0, enemyTypes.Length);
            GameObject enemy = Instantiate(enemyTypes[rndEnemy], spawnPoint[i].position, spawnPoint[i].rotation);
            enemies.Add(enemy);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoint[Random.Range(0, spawnPoint.Length)];
    }
}
