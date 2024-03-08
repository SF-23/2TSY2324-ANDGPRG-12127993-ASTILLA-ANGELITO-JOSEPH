using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildController : MonoBehaviour
{
    [SerializeField] float buildableOffsetY = 2;
    Ray ray; // shoots a line from your origin to the end point of your trajectory
    [SerializeField] RaycastHit hit;// which object that is being hit
    [SerializeField] RaycastHit[] allObject;

    [SerializeField] GameObject[] prefabTowers; // list of prefab tower that can build in your game
    [SerializeField] GameObject draggableTower; // this temp until you a build tower
    [SerializeField] Tower tempTower;

    public void SpawnArcherTwr()
    {
        GameObject twrArcher = (GameObject)Instantiate(prefabTowers[0]);
        draggableTower = twrArcher;
        tempTower = twrArcher.GetComponent<Tower>();
    }

    public void SpawnCannon()
    {
        GameObject twrCannon = (GameObject)Instantiate(prefabTowers[1]);
        draggableTower = twrCannon;
        tempTower = twrCannon.GetComponent<Tower>();
    }

    public void SpawnIceTwr()
    {
        GameObject twrIce = (GameObject)Instantiate(prefabTowers[2]);
        draggableTower = twrIce;
        tempTower = twrIce.GetComponent<Tower>();
    }

    public void SpawnFireTwr()
    {
        GameObject twrFire = (GameObject)Instantiate(prefabTowers[3]);
        draggableTower = twrFire;
        tempTower = twrFire.GetComponent<Tower>();
    }

    Vector3 SnapToGrid(Vector3 towerPos)
    {
        return new Vector3(Mathf.Round(towerPos.x),         //x
                                towerPos.y,                 //y
                                Mathf.Round(towerPos.z));   //z
    }

    void Update()
    {
        MouseTowerInput();
    }

    void MouseTowerInput()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        allObject = Physics.RaycastAll(ray);   // all object

        if (draggableTower != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                draggableTower.transform.position = SnapToGrid(hit.point);
                tempTower.GetComponent<TowerAimShoot>().enabled = false;
                if (hit.point.y > buildableOffsetY)
                {
                    tempTower.Buildable();
                    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                    {
                        BuildTower();
                        tempTower.GetComponent<TowerAimShoot>().enabled = true;
                        draggableTower = null;
                    }
                }
                else
                {
                    tempTower.NonBuildable();
                }
            }
        }
    }

    void BuildTower()
    {
        if(CanPlayerBuyTower())
        {
            StartCoroutine(CoroutineBuildTower());
        }
        else
        {
            Debug.Log("Not Enough Credits");
        }
    }

    IEnumerator CoroutineBuildTower()
    {
        float startTime = Time.time;

        GameManager.instance.SpendGold(tempTower.towerPrice);
        
        tempTower.Building();
        
        while (Time.time < startTime + tempTower.buildTimer)
        {
            tempTower.GetComponent<TowerAimShoot>().enabled = false;
            yield return new WaitForSeconds(tempTower.buildTimer);
        }
        tempTower.Build();
    }

    public bool CanPlayerBuyTower()
    {
        return GameManager.instance.playerGold >= tempTower.towerPrice;
    }
}
