using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewBallScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float ballSpd;

    [SerializeField] private float xPos;
    [SerializeField] private float yPos;

    [SerializeField] private float minNum;
    [SerializeField] private float maxNum;


    // Start is called before the first frame update
    void Start()
    {
        xPos = UnityEngine.Random.RandomRange(minNum, maxNum);
        yPos = UnityEngine.Random.RandomRange(minNum, maxNum);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //BallMovement();
    }

    void BallMovement()
    {
        Vector3 direction = new Vector3(xPos, yPos, 0);

        //rb.AddForce(direction * ballSpd * Time.deltaTime);

        rb.velocity = direction * ballSpd * Time.deltaTime;
    }

    [Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bricks"))
        {
            xPos = UnityEngine.Random.RandomRange(minNum, maxNum);
            yPos = UnityEngine.Random.RandomRange(minNum, maxNum);
        }
        if (collision.gameObject.name.Contains("RightWall"))
        {
            xPos = -xPos;
        }
        if (collision.gameObject.name.Contains("LeftWall"))
        {
            xPos = xPos * -1;
        }
        if (collision.gameObject.name.Contains("TopWall"))
        {
            yPos = -yPos;
        }
        if(collision.gameObject.name.Contains("Player"))
        {
            xPos = 1;
            yPos = 1;
        }
        

        BallMovement();
    }
    
}
