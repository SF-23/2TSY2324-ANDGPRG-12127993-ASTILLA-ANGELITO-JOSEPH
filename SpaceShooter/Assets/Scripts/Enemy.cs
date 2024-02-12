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
