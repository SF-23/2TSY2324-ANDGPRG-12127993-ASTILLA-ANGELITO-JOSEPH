using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject cubeBulletPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] TextMeshProUGUI currentFiremode;

    private int firingMode;

    void Start()
    {
        firingMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchFirePattern();
        PlayerShoot();
        UpdateFireModeText();
    }

    void PlayerShoot()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FiringMove();
        }

        if(Input.GetKeyUp(KeyCode.G))
        {
            SpawnCubeBullet(spawnPoints[0]);
        }
    }

    void FiringMove()
    {
        switch (firingMode)
        {
            case 1:
                SpawnBullet(spawnPoints[0]);                    //Nose of ship
                break;
            case 2:
                SpawnBullet(spawnPoints[1]);                //Left Wing
                SpawnBullet(spawnPoints[2]);              //Right Wing
                break;
            case 3:
                SpawnBullet(spawnPoints[0]);
                SpawnBullet(spawnPoints[1]);
                SpawnBullet(spawnPoints[2]);
                break;
            case 4:
                SpawnBullet(spawnPoints[0]);
                SpawnBullet(spawnPoints[3]);               //Angled Left Wing
                SpawnBullet(spawnPoints[4]);               //Angled Right Wing
                break;
            default:
                Debug.LogError("Error Firing not Firing");
                break;
        }
    }

    void SwitchFirePattern()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
           firingMode = 1;
        }

        if(Input.GetKey(KeyCode.Alpha2))
        {
            firingMode = 2;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            firingMode = 3;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            firingMode = 4;
        }
    }

    void UpdateFireModeText()
    {
        currentFiremode.text = firingMode.ToString();
    }


    void SpawnBullet(Transform mspawnPoint)
    {
        GameObject bulletObj = Instantiate(bulletPrefab, mspawnPoint.transform.position, mspawnPoint.rotation) as GameObject;

        Destroy(bulletObj, 5);
    }

    void SpawnCubeBullet(Transform mspawnPoint)
    {
        GameObject cubeBulletObj = Instantiate(cubeBulletPrefab, mspawnPoint.transform.position, Quaternion.identity) as GameObject;

        Destroy (cubeBulletObj, 5);
    }

    
}
