using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Net.NetworkInformation;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stageText;
    [SerializeField] TextMeshProUGUI gameOverTxt;
    [SerializeField] TextMeshProUGUI winTxt;
    [SerializeField] TextMeshProUGUI spaceToReload;

    [SerializeField] string[] sceneNames;
    [SerializeField] GameObject player;
    [SerializeField] PlayerScript playerScript;

    public static GameManager Instance;      //Creates a static manager

    [SerializeField] int stageNumber;
    [SerializeField] int stageArrayIndex;

    private string currentSceneName;
    private bool isLastStage;
    

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        UpdateStageTxt(stageNumber);

        currentSceneName = SceneManager.GetActiveScene().name;

        isLastStage = currentSceneName.Equals("Stage3");

    }

    private void Update()
    {
        DoBallSpawn();


        if (GetBallOnScreen() == 0 && playerScript.startBallCount == 0)
        {
            DoNoBallGameOver();
        }
        else
        {
            PlayerReloadText();
        }

        if (GetBricksInGame() == 0)
        {
            //LoadNextStage(sceneNames[stageArrayIndex + 1]);

            if (stageArrayIndex < sceneNames.Length - 1)
            {
                LoadNextStage(sceneNames[stageArrayIndex + 1]);
            }
            else
            {
                DoWinGame();
            }

        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    int GetBallOnScreen()
    {
        int ballInPlay = GameObject.FindGameObjectsWithTag("Ball").Length;
    
        return ballInPlay;
    }

    void DoBallSpawn()
    {
        if(GetBallOnScreen() == 0)
        {
            playerScript.ReloadBall();
        }
    }

    int GetBricksInGame()
    {
        int bricksPresent = GameObject.FindGameObjectsWithTag("Bricks").Length;

        Debug.Log(bricksPresent);

        return bricksPresent;
    }

    void UpdateStageTxt(int stage)
    {
        stageText.text = "Stage: " + stage;
    }

    void LoadNextStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
    }

    void DoNoBallGameOver()
    {
        int currentBallCount = playerScript.GetCurrentBallCount();

        int maxBalls = playerScript.GetMaxBallCount();

        int ballOnScreen = GetBallOnScreen();

        if(currentBallCount == maxBalls && ballOnScreen == 0)
        {
            gameOverTxt.text = "GAME OVER";
            Debug.Log("GAME OVER");
        }
    }

    void DoWinGame()
    {
        int brickLeft = GetBricksInGame();

        if(isLastStage && brickLeft == 0)
        {
            winTxt.text = "YOU WIN";
            Debug.Log("Player WINS");
        }
    }

    void PlayerReloadText()
    {
        if(GetBallOnScreen() == 0) 
        {
            spaceToReload.text = "SPACEBAR";
        }
        else
        {
            spaceToReload.text = "";
        }
        
    }

}
