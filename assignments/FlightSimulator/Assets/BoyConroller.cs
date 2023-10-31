using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyConroller : MonoBehaviour
{
    public GameObject cameraObject;

    float forwardSpeed = 10;
    float rotateSpeed = 40;
    float jumpForce = 20;
    float yVelocity = 0;
    float gravityModifier = 4.5f;

    int jumpCount = 0;

    CharacterController  cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!(GamePlayer.SharedInstance.isPlane)){
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

        if(!cc.isGrounded){
            yVelocity += Physics.gravity.y * gravityModifier * Time.deltaTime;
        } else {
            yVelocity = -1;
            jumpCount = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2){
            yVelocity = jumpForce;
            jumpCount++;
        }


        Vector3 amountToMove = vAxis * transform.forward * forwardSpeed;
        amountToMove.y = yVelocity;

        cc.Move(amountToMove * Time.deltaTime);

        cameraObject.transform.position = transform.position + -transform.forward * 10 + Vector3.up * 5;
        cameraObject.transform.LookAt(transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");
            GamePlayer.SharedInstance.UpdateScore(1);
            yVelocity = 50;
            Vector3 amountToMove = vAxis * transform.forward * forwardSpeed;
            amountToMove.y = yVelocity;

            cc.Move(amountToMove * Time.deltaTime);

            cameraObject.transform.position = transform.position + -transform.forward * 10 + Vector3.up * 5;
            cameraObject.transform.LookAt(transform);
        }
    }
}
