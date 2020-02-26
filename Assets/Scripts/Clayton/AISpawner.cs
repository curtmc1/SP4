using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;

public class AISpawner : MonoBehaviour
{
    public Wave[] waves;

    [System.Serializable]
    public class Wave //Allows for customizing amount of wave, enemy and spawn time
    {
        public bool infinite;
        public int enemyCount;
        public float timeBetweenSpawns;
    }

    Wave currentWave;
    int currentWaveNumber;
    int enemiesRemainingAlive;
    int enemiesRemainingToSpawn;
    float nextsSpawnTime;

    public event System.Action<int> OnNewWave;

    // Start is called before the first frame update
    void Start()
    {
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkManager.Instance.IsServer) //Server controls the spawner and AI
        {
            if ((enemiesRemainingToSpawn > 0 || currentWave.infinite) && Time.time > nextsSpawnTime)
            {
                enemiesRemainingToSpawn--;
                nextsSpawnTime = Time.time + currentWave.timeBetweenSpawns;
                StartCoroutine("SpawnEnemy");
            }
        }
    }

    void SpawnEnemy()
    {
        AIBehavior aib;
        int temp = currentWaveNumber - 1;
        aib = NetworkManager.Instance.InstantiateAI(temp, transform.position, transform.rotation, true);
        aib.GetComponentInChildren<EnemyStates>().OnDeath += OnEnemyDeath;
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;

        if (enemiesRemainingAlive == 0)
            NextWave();
    }

    void NextWave()
    {
        currentWaveNumber++;

        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;

            OnNewWave?.Invoke(currentWaveNumber);
        }
    }
}
