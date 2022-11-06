using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{


    public Transform[] spawnPoint;
    public string[] playerNames;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;
    public int spawnCount = 10;
    public float spawnDelay = 3;

    void Start()
    {
        ShuffleList(enemies);
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
        _UI.UpdateEnemyCount(enemies.Count);
    }

    public void KillEnemy(GameObject _enemy)
    {
        if (enemies.Count == 0)
            return;

        Destroy(_enemy.gameObject);
        enemies.Remove(_enemy.gameObject);
        _UI.UpdateEnemyCount(enemies.Count);
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
        yield return new WaitForSeconds(spawnDelay);
        if(_GM.gameState == GameState.Playing)
        {
            SpawnEnemy();
        }
        if(enemies.Count <= spawnCount)
        {
            StartCoroutine(SpawnEnemyDelayed());
        }
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoint[Random.Range(0, spawnPoint.Length)];
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDie += KillEnemy;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDie -= KillEnemy;
    }
}
