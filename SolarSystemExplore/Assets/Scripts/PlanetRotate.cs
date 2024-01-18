using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform target;

    [SerializeField] int rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, rotateSpeed * Time.deltaTime);
    }
}
