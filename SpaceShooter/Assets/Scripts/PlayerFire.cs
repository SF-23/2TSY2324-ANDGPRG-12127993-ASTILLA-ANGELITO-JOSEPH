using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform spawnPointTwo;
    [SerializeField] Transform spawnPointThree;
    [SerializeField] Transform spawnPointFour;
    [SerializeField] Transform spawnPointFive;

    int firingMode;

    // Update is called once per frame
    void Update()
    {
        SwitchFirePattern();
        PlayerShoot();
    }

    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(firingMode)
            {
                case 0:                             
                    SpawnBullet(spawnPoint);                    //Nose of ship
                    break;
                case 1:
                    SpawnBullet(spawnPointTwo);                //Left Wing
                    SpawnBullet(spawnPointThree);              //Right Wing
                    break;
                case 2:
                    SpawnBullet(spawnPoint);                   
                    SpawnBullet(spawnPointTwo);
                    SpawnBullet(spawnPointThree);
                    break;
                case 3:
                    SpawnBullet(spawnPoint);
                    SpawnBullet(spawnPointFour);               //Angled Left Wing
                    SpawnBullet(spawnPointFive);               //Angled Right Wing
                    break;
                default:
                    Debug.LogError("Error Firing not Firing");
                    break;
            }
            
            //SwitchFirePattern();
            //if (firingMode == 0 )
            //GameObject bulletObj = Instantiate(bulletPrefab) as GameObject;
            //SpawnBullet(spawnPoint)
            //Destroy(bulletObj, 4);
        }
    }

    void SwitchFirePattern()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
           firingMode = 0;
        }

        if(Input.GetKey(KeyCode.Alpha2))
        {
            firingMode = 1;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            firingMode = 2;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            firingMode = 3;
        }
    }


    void SpawnBullet(Transform mspawnPoint)
    {
        GameObject bulletObj = Instantiate(bulletPrefab, mspawnPoint.transform.position, Quaternion.identity) as GameObject;

        Destroy(bulletObj, 4);
    }
}
