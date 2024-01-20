using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerFire();
    }

    void PlayerMovement()
    {
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

    void PlayerFire()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletObj = Instantiate(bulletPrefab) as GameObject;
            bulletObj.transform.position = this.transform.position;

            Destroy(bulletObj, 4);
        }
    }
}
