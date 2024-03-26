using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Transform crystal;
    public Transform Crystal { get { return crystal; } }

    [Header("PLAYER Var")]
    [SerializeField] public int playerGold;
    [SerializeField] public float playerHealth;
    [SerializeField] int startGold;

    [Header("TEXT Var")]
    [SerializeField] TextMeshProUGUI goldCountTxt;
    [SerializeField] TextMeshProUGUI healthTxt;
    [SerializeField] TextMeshProUGUI winTxt;
    [SerializeField] TextMeshProUGUI loseTxt;

    [Header("PAUSE Var")]
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] static bool gameIsPause = false;

    [Header("Restart Var")]
    [SerializeField] GameObject restartMenu;

    private void Awake()
	{
		instance = this; 
	}

    private void OnDestroy()
    {
        instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerGold = startGold;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGoldTxt();
        UpdateHealthTxt();
        DoPause();
        if (playerHealth <= 0)
        {
            DoGameOver();
            SoundManager.instance.DoGameOverSfx();
        }
    }

    void UpdateGoldTxt()
    {
        goldCountTxt.text = "GOLD: " + playerGold;
    }

    void UpdateHealthTxt()
    {
        healthTxt.text = "HP: " + playerHealth; 
    }

    public void SpendGold(int towerPrice)
    {
        playerGold -= towerPrice;
    }

    void DoGameOver()
    {
       
        loseTxt.text = "LOSE";
        
        restartMenu.SetActive(true);
    }

    void DoWinScreen()
    {
        if(SpawnerController.instance.waveCounter == 10 && SpawnerController.instance.enemyList.Count <= 0)
        {
            winTxt.text = "WIN";
            Time.timeScale = 0f;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("MainStage");
        SpawnerController.instance.StartRound();
    }

    void DoPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;

        gameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        gameIsPause = true;
    }

    
}
