using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float bounceLvl;
    [SerializeField] Vector3 direction;
    [SerializeField] float ballSpd;

    [SerializeField] float velocityMulti;
    [SerializeField] float maxSpd;
    [SerializeField] float minSpd;
  
    
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*
    private void FixedUpdate()
    {
        rb.velocity = GetVelocity();
    }


    Vector3 GetVelocity()
    {
        Vector3 maxVelocity = new Vector3(
            Mathf.Clamp(rb.velocity.x * velocityMulti, minSpd, maxSpd), 
            Mathf.Clamp(rb.velocity.y * velocityMulti, minSpd, maxSpd), 
            0);

        Debug.Log(maxVelocity);
        return maxVelocity;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        this.direction = this.rb.position + direction * ballSpd * Time.deltaTime;

       
    }
    */
    

    
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.name.Contains("Player"))
        //{
            ContactPoint contact = collision.GetContact(0);

            Vector3 collisionPoint = contact.point;
            Vector3 collisionNormal = contact.normal;

            Vector3 newDirection = Vector3.Reflect(rb.velocity.normalized, collisionNormal);

            rb.velocity = newDirection * bounceLvl;
        //}
    }
    
}
