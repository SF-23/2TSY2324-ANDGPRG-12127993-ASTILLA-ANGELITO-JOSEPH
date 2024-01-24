using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] int currentDirectionTimer = 0;
    [SerializeField] int defaultDirectionTimer = 3000;
    //[SerializeField] float distance = 5f;

    //private Vector3 initialPosition;
    private bool isMoveRight;

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        //initialPosition = this.transform.position;
        //this.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        SideMovement();
    }

    void SideMovement()
    {
        if (currentDirectionTimer > 0)
        {
            currentDirectionTimer--;
        }

        if (currentDirectionTimer == 0)
        {
            isMoveRight = true;
            currentDirectionTimer = defaultDirectionTimer;
        }

        if(isMoveRight)
        {
           this.transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(-Vector3.right * enemySpeed * Time.deltaTime);
        }

        isMoveRight=false;
       



        /*
        if(isMoveRight) 
        {
            this.transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);    
        }
        else
        {
            this.transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
        }

        if (Vector3.Distance(initialPosition, transform.position) >= distance)
        {
            // Change direction
            isMoveRight = !isMoveRight;
            Debug.Log(Vector3.Distance(initialPosition, transform.position));
        }
        */
    }
}
