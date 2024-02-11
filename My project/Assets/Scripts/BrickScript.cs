using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] float currHP;
    [SerializeField] float maxHP;

    void Start()
    {
        ColorChange();
    }

    void BrickDeath()
    {
       Destroy(this.gameObject);
    }

    void TakeDmg()
    {
        currHP -= 1;

        if(currHP <= 0)
        {
            BrickDeath();
        }
        
    }
    void ColorChange()
    {
        if(currHP == 1)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (currHP == 2) 
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Ball"))
        {
            TakeDmg();
            ColorChange();
        }
    }




   

}
