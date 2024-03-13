using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class TowerData
{
    public string _name;
    public GameObject _towerPrefab;
    public float _damage;
    public float _fireRate;
    public float _range;
    public float _rotSpeed;
    public float _price;
}

[System.Serializable]
public class UpgradeTower
{
    public float _damage;
    public float _fireRate;
    public float _range;
    public float _price;
    public float _blastRadius;
}



public class BuildController : MonoBehaviour
{
    public static BuildController instance;

    [SerializeField] float buildableOffsetY = 2;
    Ray ray; // shoots a line from your origin to the end point of your trajectory
    [SerializeField] RaycastHit hit;// which object that is being hit
    [SerializeField] RaycastHit[] allObject;

    [SerializeField] GameObject[] prefabTowers; // list of prefab tower that can build in your game
    [SerializeField] GameObject draggableTower; // this temp until you a build tower
    [SerializeField] Tower tempTower;

    [SerializeField] Tower builtTower;

    [SerializeField] public List<TowerData> towerData = new List<TowerData>();


    private void Awake()
    {
        instance = this;
    }

    public void ClickButton(int index)
    {
        if (GameManager.instance.playerGold >= towerData[index]._price)
        {
            SpawnTwr(index);
        }
    }

    void SpawnTwr(int index)
    {
        GameObject twrArcher = (GameObject)Instantiate(prefabTowers[index]);
        draggableTower = twrArcher;
        tempTower = twrArcher.GetComponent<Tower>();
        tempTower.GetComponent<TowerAimShoot>().SetAttributes(towerData[index]);
        builtTower = null;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(builtTower != null)
        {
            SelectTower(builtTower);
        }
    }

    void SelectTower(Tower tower)
    {
        builtTower = tower;
        tempTower = null;
    }

    Vector3 SnapToGrid(Vector3 towerPos)
    {
        return new Vector3(Mathf.Round(towerPos.x),         //x
                                towerPos.y,                 //y
                                Mathf.Round(towerPos.z));   //z
    }

    void Update()
    {
       TowerCreation();
    }

    void TowerCreation()
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
                        tempTower.BuildTower();
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
}
