using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] float currEnemyHp = 20;
    [SerializeField] float maxEnemyHp = 20;
    //[SerializeField] int currentDirectionTimer = 0;
    //[SerializeField] int defaultDirectionTimer = 3000;
    //[SerializeField] float distance = 5f;

    //private Vector3 initialPosition;
    private bool isMoveRight;

    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //initialPosition = this.transform.position;
        this.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        //SideMovement();
    }

    void UpdateHealth()
    {
        healthText.text = currEnemyHp + "/" + maxEnemyHp;
    }

    void TakeDamage()
    {
        currEnemyHp -= 10;
        UpdateHealth();
        if(currEnemyHp <= 0)
        {
            EnemyDeath();
        }

    }

    void EnemyDeath()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage();
        }
    }

    /*
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
        
    }
    */
}
