using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAimShoot : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] Transform target;
    [SerializeField] MonsterType monsterType;
    [SerializeField] bool isSelectTarget;

    [Header("Base Tower Stats")]
    [SerializeField] float range;
    [SerializeField] float rateFire;
    [SerializeField] Transform rotationPart;
    [SerializeField] float damage;
    [SerializeField] float rotSpeed;

    [Header("Bullet Spawner")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float reloadTime;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    public void SetAttributes(TowerData towerData)
    {
        range = towerData._range;
        rateFire = towerData._fireRate;
        damage = towerData._damage;
        rotSpeed = towerData._rotSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Rotate();

        
        if(reloadTime <= 0f)
        {
            Shoot();
            reloadTime = 1f / rateFire;
        }
       
        reloadTime -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject nearestEnemy = null;
        float shortestDist = Mathf.Infinity;

        foreach (GameObject enemy in SpawnerController.instance.enemyList)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDist && (enemy.GetComponent<Enemy>().MonsterType == monsterType || !isSelectTarget))
            {
                shortestDist = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDist <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

   
    void Shoot()
    {
        GameObject bullet = (GameObject) Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Arrow arrow = bullet.GetComponent<Arrow>();
        arrow.target = target.transform;
        arrow.damage = damage;
    }

   
    void Rotate()
    {
        Vector3 dir = target.position - rotationPart.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, lookRotation, Time.deltaTime * rotSpeed).eulerAngles;
        rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
