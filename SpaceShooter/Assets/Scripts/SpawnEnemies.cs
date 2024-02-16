using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float xPos;
    [SerializeField] public float spawnInterval;

    public bool isSpawning = true;


    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (isSpawning) 
        {
            xPos = Random.Range(-3.65f, 3.66f);

            Vector3 spawnPos = new Vector3(xPos, 15, 0);

            yield return new WaitForSeconds(spawnInterval);

            GameObject enemyToSpawn = Instantiate(enemyPrefab, spawnPos, spawnPoint.rotation) as GameObject;   
        }
    }
}
