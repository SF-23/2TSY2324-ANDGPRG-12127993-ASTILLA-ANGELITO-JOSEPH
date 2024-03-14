using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMouseInput : MonoBehaviour
{
    [SerializeField] Tower selectedTower;
    Ray ray; // shoots a line from your origin to the end point of your trajectory
    [SerializeField] RaycastHit hit;// which object that is being hit
    [SerializeField] RaycastHit[] allObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TowerSelect();
    }

    void TowerSelect()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        allObject = Physics.RaycastAll(ray);   // all object

        if(Physics.Raycast(ray, out hit)) 
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                selectedTower = hit.collider.gameObject.GetComponent<Tower>();
               
                if(selectedTower != null) 
                {
                  selectedTower.nodeUI.SetActive(true);
                }
            }
        }
    }
}
