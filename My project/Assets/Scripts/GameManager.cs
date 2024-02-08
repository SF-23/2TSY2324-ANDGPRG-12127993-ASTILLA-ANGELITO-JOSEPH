using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stageText;
    public static GameManager Instance;      //Creates a static manager

    public int stage;

    private void Start()
    {
        stage = 1;
        stageText.text = "Stage: " + stage;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
        stage = 2;
    }

    void LoadStage3()
    {
        SceneManager.LoadScene("Stage3");
        stage = 3;
    }

    
}
