using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float xPos;
    [SerializeField] float spawnInterval;

    private bool isSpawning = true;


    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        WaitForSeconds wait =  new WaitForSeconds(spawnInterval);

        while (isSpawning) 
        {
            xPos = Random.Range(-3.65f, 3.66f);

            Vector3 spawnPos = new Vector3(xPos, 15, 0);

            yield return wait;

            GameObject enemyToSpawn = Instantiate(enemyPrefab, spawnPos, spawnPoint.rotation) as GameObject;   
        }
    }
}
