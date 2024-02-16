using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject cubeBulletPrefab;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] TextMeshProUGUI currentFiremode;
    [SerializeField] TextMeshProUGUI hpText; 

    [SerializeField] int currPlayerHP;
    [SerializeField] int maxMaxHP;

    [SerializeField] AudioSource mainFireSfx;
    [SerializeField] AudioSource altFireSfx;
    [SerializeField] AudioSource playerHealSfx;

    private int firingMode;

    void Start()
    {
        firingMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerShoot();
        SwitchFirePattern();
        UpdateFireModeText();
        UpdatePlayerHealth();
    }

    void PlayerMovement()
    {
        Vector3 position = this.transform.position;
        position.x = Mathf.Clamp(position.x, -4f, 4f);
        position.y = Mathf.Clamp(position.y, -1f, 12f);
        transform.position = position;

        if (Input.GetKey(KeyCode.W)) 
        {
            this.transform.Translate(Vector3.forward* moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    void PlayerShoot()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FiringMove();
            mainFireSfx.Play();
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            SpawnCubeBullet(spawnPoints[0]);
            altFireSfx.Play();
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

        if (Input.GetKey(KeyCode.Alpha2))
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
        currentFiremode.text = "Nozzle: " + firingMode;
    }

    void UpdatePlayerHealth()
    {
        hpText.text = currPlayerHP + "/" + maxMaxHP;
    }
    
    void PlayerTakeDmg()
    {
        currPlayerHP -= 5;
        UpdatePlayerHealth();
        if(currPlayerHP <= 0)
        {
            PlayerDestruction();
        }
    }

    void PlayerHeal()
    {
        if(currPlayerHP < maxMaxHP)
        {
            currPlayerHP += 5;
        }
    }

    public void PlayerDestruction()
    {
        SoundManager.Instance.PlayPlayerDeath();
        GameManger.Instance.ShowGameOver();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Enemy"))
        {
            Destroy(other.gameObject);
            PlayerTakeDmg();
        }
        else if(other.gameObject.name.Contains("PowerUp"))
        {
            Destroy(other.gameObject);
            PlayerHeal();
            playerHealSfx.Play();
        }
    }

    void SpawnBullet(Transform mspawnPoint)
    {
        GameObject bulletObj = Instantiate(bulletPrefab, mspawnPoint.transform.position, mspawnPoint.rotation) as GameObject;

        Destroy(bulletObj, 5);
    }

    void SpawnCubeBullet(Transform mspawnPoint)
    {
        GameObject cubeBulletObj = Instantiate(cubeBulletPrefab, mspawnPoint.transform.position, Quaternion.identity) as GameObject;

        Destroy(cubeBulletObj, 5);
    }

}
