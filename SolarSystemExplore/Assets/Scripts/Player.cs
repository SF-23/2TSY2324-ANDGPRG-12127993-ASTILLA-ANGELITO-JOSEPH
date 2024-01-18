using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float moveSpeed = 5f;
	[SerializeField] Rigidbody rb;

    //called before start
	private void Awake()
	{
	
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }


	private void FixedUpdate()
	{
		
	}
	// Update is called once per frame
	void Update()
    {
		//this.transform.position += new Vector3(0, 0, 1);

		/*if(Input.GetKeyDown(KeyCode.W))
		{
			// on press but only once
		}
		if (Input.GetKey(KeyCode.W))
		{
			// while pressing the key
			//this.transform.position += new Vector3(0, 0, 1);
		}
		if(Input.GetKeyUp(KeyCode.W))
		{
			// on release but only once
		}*/
		MovementControl();
	}

	void MovementControl()
	{
		if (Input.GetKey(KeyCode.W))
		{
			this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			//this.rb.velocity += Vector3.right;
			this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
		}
	}
	private void LateUpdate()
	{
		
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
