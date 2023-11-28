using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 cameraPosition;
    public float cameraSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            cameraPosition.x -= cameraSpeed/10;
        }
        if(Input.GetKey(KeyCode.S)){
            cameraPosition.x += cameraSpeed/10;
        }
        if(Input.GetKey(KeyCode.D)){
            cameraPosition.z += cameraSpeed/10;
        }
        if(Input.GetKey(KeyCode.A)){
            cameraPosition.z -= cameraSpeed/10;
        }
        this.transform.position = cameraPosition;
    }
}
