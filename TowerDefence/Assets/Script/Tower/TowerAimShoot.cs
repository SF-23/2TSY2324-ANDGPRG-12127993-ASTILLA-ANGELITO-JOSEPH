using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class UpgradeTower
{
    public int teir;
    public int _price;
    public float _damage;
    public float _range;
    public float _fireRate;
    public float _blastRadius;
    public float _dotEffect;
}

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

    [SerializeField] public List<UpgradeTower> upgradeTowers = new List<UpgradeTower>();

    //[SerializeField] TextMeshProUGUI upgradePrice;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //upgradePrice.text = 100.ToString();
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

    /*
    void txtUpgrade(int tier)
    {
        upgradePrice.text = upgradeTowers[tier]._price.ToString();
    }
    */

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

    public void ClickUpgradeButton(int tier)
    {
        //txtUpgrade(tier);
        if(GameManager.instance.playerGold >= upgradeTowers[tier]._price) 
        {
            GameManager.instance.playerGold -= upgradeTowers[tier]._price;
            towerUpgrade(tier);
        }

        tier += 1;
        Debug.Log(tier);
    }

    void towerUpgrade(int tier)
    {
        damage += upgradeTowers[tier]._damage;
        range += upgradeTowers[tier]._range;
        rateFire += upgradeTowers[tier]._fireRate;

        if(bulletPrefab.GetComponent<Arrow>().sphereCollider == true)
        {
            bulletPrefab.GetComponent<Arrow>().sphereCollider.radius += upgradeTowers[tier]._blastRadius;
        }

        if(bulletPrefab.name == "FireBall" || bulletPrefab.name == "IceBall" &&
            bulletPrefab.GetComponent<Arrow>().target.GetComponent<Enemy>() == target.GetComponent<Enemy>())
        {
            target.GetComponent<Enemy>().iceDebuffTime += bulletPrefab.GetComponent<Arrow>().debuffTime;
            target.GetComponent<Enemy>().fireDebuffTime += bulletPrefab.GetComponent<Arrow>().debuffTime;
        }
    }
}
