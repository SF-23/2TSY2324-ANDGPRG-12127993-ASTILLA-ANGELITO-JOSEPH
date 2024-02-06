using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] float currHP;
    [SerializeField] float maxHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BrickDeath()
    {
        if(currHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void TakeDmg()
    {
        if (currHP > maxHP)
        {
            currHP -= 1;
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
            BrickDeath();
        }
    }




   

}
