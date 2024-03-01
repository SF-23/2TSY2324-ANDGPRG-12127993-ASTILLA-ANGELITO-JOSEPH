using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterType
{
    Flying,
    Ground,
}

public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] MonsterType type;
    public MonsterType MonsterType { get { return type; } }

    [SerializeField] Transform target;

    [SerializeField] public int health;

    [SerializeField] public int gold;

    [SerializeField] public int[] goldLvl;  //array to set worth of gold for each wave for each enemy
    [SerializeField] public int[] healthLvl; //array to set worth of gold for each wave for each enemy

    // Start is called before the first frame update
    void Awake()
    {
        this.agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        GoldHealthUpdate();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
		this.agent.SetDestination(target.position);
        Debug.Log(this.agent.pathStatus);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("CrystalCore"))
        {
            SpawnerController.instance.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    void GoldHealthUpdate()
    {
        int waveCounter = SpawnerController.instance.waveCounter - 1;
      
        gold = goldLvl[waveCounter];
        health = healthLvl[waveCounter];
    }
}
