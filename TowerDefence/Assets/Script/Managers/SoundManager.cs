using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource bgmSfx;
    [SerializeField] AudioSource gameOverSfx;
    [SerializeField] AudioSource ArcherSfx;
    [SerializeField] AudioSource CannonSfx;
    [SerializeField] AudioSource FireSfx;
    [SerializeField] AudioSource IceSfx;
    [SerializeField] AudioSource NoMoneySfx;


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
        bgmSfx.Play();
    }

    public void DoGameOverSfx()
    {
        gameOverSfx.Play();
    }

    public void DoArcherSfx()
    {
        ArcherSfx.Play();
    }

    public void DoCannonSfx()
    {
        CannonSfx.Play();
    }
    public void DoFireSfx()
    {
        FireSfx.Play();
    }
    public void DoIceSfx()
    {
        IceSfx.Play();
    }

    public void DoNoMoneySfx() 
    {
        NoMoneySfx.Play();
    }
}
