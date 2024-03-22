using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterType
{
    Flying,
    Ground,
    Boss,
}

public class Enemy : MonoBehaviour
{
    [Header("Navmesh Variables")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float mainSpeed;
   

    [Header("Enemy Variables")]
    [SerializeField] MonsterType type;
    public MonsterType MonsterType { get { return type; } }

    [SerializeField] Transform target;

    [SerializeField] public float health;
    [SerializeField] public int gold;

    [SerializeField] public int[] goldLvl;  //array to set worth of gold for each wave for each enemy
    [SerializeField] public int[] healthLvl; //array to set worth of gold for each wave for each enemy

    [Header("Timers")]
    [SerializeField] public float fireDebuffTime;      //Duration of debuff
    [SerializeField] public float iceDebuffTime;
    [SerializeField] float currentIceTime;      //current time of debuff
    [SerializeField] float currentFireTime;

    [Header("Debuff Values")]
    [SerializeField] float speedDebuff;
    [SerializeField] float burnDmg;

    // Start is called before the first frame update
    void Awake()
    {
        this.agent = GetComponent<NavMeshAgent>();
        agent.speed = mainSpeed;
        
    }

    private void Start()
    {
        GoldHealthUpdate();   //To update the health of enemy at the start of the wave
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
		this.agent.SetDestination(target.position);
        Debug.Log(this.agent.pathStatus);
	}

    void DoEnemyDeath()
    {
        if(health <= 0)
        {
            GameManager.instance.playerGold += gold;
            SpawnerController.instance.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Arrow projectileDmg = GetComponent<Arrow>();

        if (other.gameObject.name.Contains("CrystalCore"))
        {
            SpawnerController.instance.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);

            GameManager.instance.playerHealth -= Random.Range(2, 5);

            if (MonsterType.Equals(3))
            {
                GameManager.instance.playerHealth -= 50;
            }
        }

        if(other.gameObject.GetComponent<Arrow>())
        {
            health -= other.gameObject.GetComponent<Arrow>().damage;
            
            if (other.gameObject.name.Contains("IceBall"))
            {
                DebuffEffect(0);
            }
            if(other.gameObject.name.Contains("FireBall"))
            {
                DebuffEffect(1);
            }
            Destroy(other.gameObject);
            DoEnemyDeath();
        }
    }

    void DebuffEffect(int effect)
    {
        switch (effect) 
        {
            case 0:

                if(Time.time - currentIceTime >= iceDebuffTime)
                {
                    agent.speed = mainSpeed;
                }
                else
                {
                    agent.speed = speedDebuff;
                }
               
                break;
            case 1:

                if (Time.time - currentFireTime >= fireDebuffTime)
                {
                    health -= burnDmg;
                }
                break;
        }
    }

    public void GoldHealthUpdate()
    {
        int waveCounter = SpawnerController.instance.waveCounter - 1;
      
        gold = goldLvl[waveCounter];
        health = healthLvl[waveCounter];
    }
}
