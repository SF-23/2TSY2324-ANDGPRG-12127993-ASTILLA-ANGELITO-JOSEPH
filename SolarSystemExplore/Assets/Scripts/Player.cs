using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float moveSpeed = 5f;
	[SerializeField] Rigidbody rb;
	[SerializeField] float rotateSpeed = 30f;

	// Update is called once per frame
	void Update()
    {
		MovementControl();
	}

	void MovementControl()
	{
		if (Input.GetKey(KeyCode.W))
		{
			this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
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
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
		if (Input.GetKey(KeyCode.E))
		{
            this.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space)) 
		{
			this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftControl)) 
		{
			this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
		}
		
	}

	private void OnTriggerEnter(Collider other)
	{
		//both of the object must have a collider
		// one of them must have isTrigger Toggled
		//any of them must have at least one rigidbody
		if(other.gameObject.name.Contains("Enemy"))
		{
			Debug.Log("Im bumping to This object: " + other.gameObject.name);
		}

    }

	private void OnCollisionEnter(Collision other)
	{
		//both of the object must have a collider
		// none of them have isTrigger Toggled
		//any of them must have at least one rigidbody
		if (other.gameObject.name.Contains("Enemy"))
		{
			Debug.Log("Im bumping to This object: " + other.gameObject.name);
		}

	}
}
