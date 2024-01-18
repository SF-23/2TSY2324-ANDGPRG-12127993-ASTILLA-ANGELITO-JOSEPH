using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float distance = 10;

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.position);
        if(Vector3.Distance(this.transform.position, target.position) > distance )
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
