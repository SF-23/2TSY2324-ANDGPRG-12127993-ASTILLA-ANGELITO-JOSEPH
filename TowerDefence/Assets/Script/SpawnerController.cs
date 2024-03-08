using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerController : MonoBehaviour
{
	public static SpawnerController instance;
	[SerializeField] Transform spawnPoint;
	[SerializeField] GameObject[] enemyPrefab;
	[SerializeField] GameObject bossPrefab;

	[SerializeField] public List<GameObject> enemyList;

	[SerializeField] float spawnDelay;
	[SerializeField] int maxEnemisToSpawn;
	[SerializeField] public int enemiesToSpawn;
	[SerializeField] public int waveCounter;
	[SerializeField] public int maxWaves;
    private int enemyIdx = 0;

	[SerializeField] TextMeshProUGUI waveTxt;
	

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		waveCounter = 1;
		WaveTxtUpdate(waveCounter);
		StartCoroutine(StartSpawnWave()); 
	}

    private void Update()
    {
        if(enemyList.Count <= 0 && waveCounter <= maxWaves)
		{
			waveCounter+= 1;
            WaveTxtUpdate(waveCounter);
            maxEnemisToSpawn += 2;
            enemiesToSpawn += maxEnemisToSpawn;
            StartCoroutine(StartSpawnWave());

            if (waveCounter % 5 == 0)
            {
                SpawnBoss();
            }
        }
    }

	void WaveTxtUpdate(int _waveCounter)
	{
		waveTxt.text = "Wave: " + _waveCounter;
    }

    IEnumerator StartSpawnWave()
	{
		while (enemiesToSpawn > 0) 
		{
            SpawnEnemy(enemyIdx);

            yield return new WaitForSeconds(spawnDelay);
          
            enemiesToSpawn--;

            enemyIdx = (enemyIdx + 1) % enemyPrefab.Length;
        }
    }
	

	private void SpawnEnemy(int enemyIdx)
	{
		GameObject enemyObj = (GameObject)Instantiate(enemyPrefab[enemyIdx], spawnPoint.position, Quaternion.identity);
	
		enemyObj.GetComponent<Enemy>().SetTarget(GameManager.instance.Crystal);
		enemyList.Add(enemyObj);

		Debug.Log(enemyList.Count);
	}

    public void SpawnBoss()
    {
        GameObject bossObj = Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
        bossObj.GetComponent<Enemy>().SetTarget(GameManager.instance.Crystal);
        enemyList.Add(bossObj);
    }

    public void RemoveEnemy(GameObject obj)
	{
		enemyList.Remove(obj);
	}
	
	
	
}
