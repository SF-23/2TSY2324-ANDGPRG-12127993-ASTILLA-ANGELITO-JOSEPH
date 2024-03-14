using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public SphereCollider sphereCollider;
    [SerializeField] float speed;
    [SerializeField] public float debuffTime;
    [SerializeField] public float damage;
    private float distanceThisFrame;

    private void Awake()
    {
       if(this.GetComponent<Collider>().GetType() == typeof(SphereCollider))
       {
            sphereCollider = (SphereCollider)this.GetComponent<Collider>();
       }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        distanceThisFrame = Time.deltaTime * speed;

        if (dir.magnitude <= distanceThisFrame)
        {
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

}
