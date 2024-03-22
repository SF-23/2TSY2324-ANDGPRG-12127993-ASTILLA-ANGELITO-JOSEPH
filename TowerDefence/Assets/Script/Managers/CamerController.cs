using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    [SerializeField] float panSpeed;
    [SerializeField] float panBorderThickness;

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        Vector3 position = this.transform.position;
        position.x = Mathf.Clamp(position.x, 5f, 50f);
        position.z = Mathf.Clamp(position.z, 0f, 40f);
        transform.position = position;


        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            this.transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            this.transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            this.transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            this.transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
