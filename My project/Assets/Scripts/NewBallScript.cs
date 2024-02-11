using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewBallScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float ballSpd;

    [SerializeField] private float minNum;
    [SerializeField] private float maxNum;

    [SerializeField] private float xPos;
    [SerializeField] private float yPos;

    void DeleteBall()
    {
        Destroy(gameObject);
    }

    void BallMovement()
    {
        Vector3 direction = new Vector3(xPos, yPos, 0);

       rb.AddForce(direction * ballSpd * Time.deltaTime);

       rb.velocity = direction * ballSpd * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            xPos = Random.Range(minNum, maxNum);
            yPos = 1;
            rb.useGravity = false;
        }
        if (collision.gameObject.name.Contains("Bricks"))
        {
            xPos = Random.Range(minNum, maxNum);
            yPos = -1;
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
        BallMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("BottomWall"))
        {
            DeleteBall();
        }
    }

}
