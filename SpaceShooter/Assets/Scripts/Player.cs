using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
      
    }

    void PlayerMovement()
    {
        Vector3 position = this.transform.position;
        position.x = Mathf.Clamp(position.x, -4f, 4f);
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

    
}
