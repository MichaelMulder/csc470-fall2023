using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    float forwardSpeed = 60f;
    float xRotationSpeed = 80f;
    float zRotationSpeed = 240f;


    public GameObject cameraObject;

    public GameObject bulletObject;
    public GameObject casingObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GamePlayer.SharedInstance.isPlane){
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");

            float xRotation = vAxis * xRotationSpeed * Time.deltaTime;
            float zRotation = hAxis * -zRotationSpeed * Time.deltaTime;
            transform.Rotate(xRotation, 0, zRotation, Space.Self);


            gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * forwardSpeed;

            cameraObject.transform.position = transform.position + -transform.forward * 10 + Vector3.up * 5;
            cameraObject.transform.LookAt(transform);

            if(Input.GetKey(KeyCode.Space)){
                GameObject bulletObj = Instantiate(bulletObject, gameObject.transform.position, Quaternion.identity);
                bulletObj.GetComponent<Rigidbody>().AddForce(transform.forward * 15000);
                GameObject casingObj = Instantiate(casingObject, gameObject.transform.position, Quaternion.identity);
                casingObj.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ring"))
        {
            GamePlayer.SharedInstance.UpdateScore(1);
        }
    }
}
