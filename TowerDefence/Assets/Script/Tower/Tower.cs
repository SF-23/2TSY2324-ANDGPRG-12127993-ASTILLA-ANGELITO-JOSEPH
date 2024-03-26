using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    [SerializeField] Material towerMat;
    [SerializeField] public float buildTimer;
    [SerializeField] public int towerPrice;
    [SerializeField] public GameObject nodeUI;
    [SerializeField] public bool isBuilding;
 
    public void Buildable()
    {
        towerMat.color = Color.green;
        isBuilding = true;
    }
    public void NonBuildable()
    {
        towerMat.color = Color.red;
        isBuilding = true;
    }


    public void Build()
    {
        // animation 
        this.gameObject.GetComponent<TowerAimShoot>().enabled = true;
        towerMat.color = Color.white;
        isBuilding = false;
    }

    public void Building()
    {
        //nodeUI.SetActive(false);
        towerMat.color = Color.yellow;
        isBuilding = true;
    }

    public void BuildTower()
    {
        if(CanBuyTower() == true)
        {
            StartCoroutine(ConstructingTwr());
        }
        else
        {
            Debug.Log("YOU'RE POOR");
        }
    }

    IEnumerator ConstructingTwr()
    {
        float startTime = Time.time;

        GameManager.instance.SpendGold(towerPrice);

        Building();

        while(Time.time < startTime + buildTimer)
        {
            this.gameObject.GetComponent<TowerAimShoot>().enabled = false;
            yield return null;
        }
        
        Build();
    }

    public bool CanBuyTower()
    {
        return GameManager.instance.playerGold >= towerPrice;
    }

}
