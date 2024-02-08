using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewBallScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float ballSpd;

    [SerializeField] private float minNum;
    [SerializeField] private float maxNum;

    [SerializeField] private float xPos;
    [SerializeField] private float yPos;

    void BallMovement()
    {
        Vector3 direction = new Vector3(xPos, yPos, 0);

        rb.AddForce(direction * ballSpd * Time.deltaTime);

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
            xPos = UnityEngine.Random.RandomRange(minNum, maxNum);
            yPos = 1;
        }
        

        BallMovement();

        rb.useGravity = false;
    }
    
}
