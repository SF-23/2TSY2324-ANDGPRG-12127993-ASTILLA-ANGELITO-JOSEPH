using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] float powerUpSpeed;

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }

    void Movement()
    {
        this.transform.Translate(Vector3.down * powerUpSpeed * Time.deltaTime);
    }

    void PowerUpDelete()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("DeleteWall"))
        {
            PowerUpDelete();
        }
    }
}
