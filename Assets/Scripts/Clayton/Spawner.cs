using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Unity;

public class Spawner : MonoBehaviour
{
    //private float spawnTimerAI;

    //public GameObject enemy;

    // Start is called before the first frame update
    private void Start()
    {
       NetworkManager.Instance.InstantiatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //if (spawnTimerAI > 2f)
        //{
        //    GameObject spawnedEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
        //    spawnTimerAI = 0f;
        //}
        //else
        //    spawnTimerAI += 1f * Time.deltaTime;
    }
}
