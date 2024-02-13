using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] TextMeshProUGUI pointsTxt;

    public static GameManger Instance;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = enemyPrefab.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

   
}
