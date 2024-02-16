using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource playerDeathSfx;
    [SerializeField] AudioSource enemyDeathSfx;
    [SerializeField] AudioSource bgmSfx;
    [SerializeField] AudioSource gameOverSfx;
    [SerializeField] AudioSource newStageSfx;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        bgmSfx.Play();
    }

    public void PlayPlayerDeath()
    {
        playerDeathSfx.Play();

        gameOverSfx.Play();
    }

    public void PlayEnemyDeath()
    { 
        enemyDeathSfx.Play(); 
    }

    public void PlayNewWave()
    {
        newStageSfx.Play();
    }

    public void PauseBGM()
    {
        bgmSfx.Pause();
    }
       
    
   
 
}
