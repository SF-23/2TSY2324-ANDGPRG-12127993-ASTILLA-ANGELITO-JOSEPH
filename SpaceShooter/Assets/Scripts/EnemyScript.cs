using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] public float currEnemyHp;
    [SerializeField] public float maxEnemyHp;

    [SerializeField] GameObject powerUpPrefab;

    [SerializeField] float fixedNo;
    [SerializeField] float randomNo;
    
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
            SpawnPowerUp();
            EnemyDeath();
            GameManger.Instance.enemyCounter++;
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
            SoundManager.Instance.PlayEnemyDeath();
        }

        if(other.gameObject.name.Contains("DeleteWall"))
        {
            EnemyDeath();
        }
    }

    void SpawnPowerUp()
    {
        randomNo = Random.Range(0f, 1f);

        //Debug.Log(randomNo);

        if(randomNo < fixedNo)
        {
            GameObject powerUp = Instantiate(powerUpPrefab, this.transform.position, Quaternion.identity) as GameObject;
        }
    }


}
