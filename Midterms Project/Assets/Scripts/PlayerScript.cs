using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int maxBalls;
    [SerializeField] int currnetBallCount;
    [SerializeField] public int startBallCount;
    [SerializeField] TextMeshProUGUI ballCount;
   


    // Update is called once per frame
    void Update()
    {
        Movement();
        //ReloadBall();
        UpdateTriesText();
        
    }

    void Movement()
    {
        Vector3 position = this.transform.position;
        position.x = Mathf.Clamp(position.x, -10f, 10f);
        transform.position = position;

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    public void ReloadBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currnetBallCount < maxBalls)
        {
            SpawnBall(spawnPoint);
            currnetBallCount++;
            startBallCount--;
        }
    }

    public int GetCurrentBallCount()
    {
        return currnetBallCount;
    }

    public int GetMaxBallCount()
    { 
        return maxBalls; 
    }

    void UpdateTriesText()
    {
        ballCount.text = "Tries left: " + startBallCount;
    }

    void SpawnBall(Transform mspawnPoint) 
    { 
        GameObject ballObject = Instantiate(ballPrefab, mspawnPoint.transform.position, Quaternion.identity) as GameObject;
    }

}
