using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private float enemySpeed = 5f;
    [SerializeField] private float currEnemyHp = 20;
    [SerializeField] private float maxEnemyHp = 20;


    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    void UpdateHealth()
    {
        healthText.text = currEnemyHp + "/" + maxEnemyHp;
    }

    void TakeDamage()
    {
        currEnemyHp -= 5;
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

        if(other.gameObject.name.Contains("EnemyDeleteWall"))
        {
            EnemyDeath();
        }
    }


}
