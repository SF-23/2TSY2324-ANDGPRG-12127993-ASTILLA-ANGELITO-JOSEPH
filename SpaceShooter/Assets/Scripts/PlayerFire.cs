using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject cubeBulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform spawnPointTwo;
    [SerializeField] Transform spawnPointThree;
    [SerializeField] Transform spawnPointFour;
    [SerializeField] Transform spawnPointFive;
    [SerializeField] TextMeshProUGUI currentFiremode;

    int firingMode;

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
            switch(firingMode)
            {
                case 1:                             
                    SpawnBullet(spawnPoint);                    //Nose of ship
                    break;
                case 2:
                    SpawnBullet(spawnPointTwo);                //Left Wing
                    SpawnBullet(spawnPointThree);              //Right Wing
                    break;
                case 3:
                    SpawnBullet(spawnPoint);                   
                    SpawnBullet(spawnPointTwo);
                    SpawnBullet(spawnPointThree);
                    break;
                case 4:
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

        if(Input.GetKeyUp(KeyCode.G))
        {
            SpawnCubeBullet(spawnPoint);
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
        GameObject bulletObj = Instantiate(bulletPrefab, mspawnPoint.transform.position, Quaternion.identity) as GameObject;

        Destroy(bulletObj, 5);
    }

    void SpawnCubeBullet(Transform mspawnPoint)
    {
        GameObject cubeBulletObj = Instantiate(cubeBulletPrefab, mspawnPoint.transform.position, Quaternion.identity) as GameObject;

        Destroy (cubeBulletObj, 5);
    }
}
