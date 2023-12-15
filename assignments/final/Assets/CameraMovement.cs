using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 cameraPosition;
    public float cameraSpeed = 1000000;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            cameraPosition.x -= cameraSpeed;
        }
        if(Input.GetKey(KeyCode.S)){
            cameraPosition.x += cameraSpeed;
        }
        if(Input.GetKey(KeyCode.D)){
            cameraPosition.z += cameraSpeed;
        }
        if(Input.GetKey(KeyCode.A)){
            cameraPosition.z -= cameraSpeed;
        }
        this.transform.position = cameraPosition;
    }
}
