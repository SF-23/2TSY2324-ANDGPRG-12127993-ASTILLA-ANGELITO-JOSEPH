using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnerPrefab;
    [SerializeField] EnemyScript enemy;
    [SerializeField] SpawnEnemies spawner;

    [SerializeField] TextMeshProUGUI waveTxt;
    [SerializeField] TextMeshProUGUI gameOverTxt;

    [SerializeField] public int enemyCounter;
    [SerializeField] int totalEnemyForWave;
    [SerializeField] int waveCounter;

    public static GameManger Instance;

    // Start is called before the first frame update
    void Start()
    {
        spawner = spawnerPrefab.GetComponent<SpawnEnemies>();
        enemy = enemyPrefab.GetComponent<EnemyScript>();

        waveCounter = 1;

        enemy.maxEnemyHp = 20;

        enemy.currEnemyHp = enemy.maxEnemyHp;

        waveTxt.text = "Wave: " + waveCounter;
    }

    // Update is called once per frame
    void Update()
    {
        WaveSystem();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    void WaveSystem()
    {
        if (enemyCounter >= totalEnemyForWave)
        {
            waveCounter += 1;

            waveTxt.text = "Wave: " + waveCounter;

            enemy.maxEnemyHp += 5;

            enemy.currEnemyHp = enemy.maxEnemyHp;

            SoundManager.Instance.PlayNewWave();

            enemyCounter = 0;

            totalEnemyForWave += 5;
        }
    }

    public void ShowGameOver()
    {
        gameOverTxt.text = "GAME OVER";
    }


}
