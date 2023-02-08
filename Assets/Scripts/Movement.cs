using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Vector2 movement;
    Rigidbody body;
    float rotateSpeed = 100.0f;
    float thrustSpeed = 10000.0f;
    
    // Start is called before the first frame update
    void Start()
    {
       body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    void OnMove(InputValue value){
        movement = value.Get<Vector2>();
    }
    void Rotate(){
        RotationControl(-rotateSpeed);
    }
    void OnThrust(InputValue value){
        if(value.isPressed){
            ThrustControl(thrustSpeed);
        } 
    }
    void RotationControl(float rotateSpeed){
        body.freezeRotation = true;
        transform.Rotate(0,0,movement.x * rotateSpeed * Time.deltaTime);
        body.freezeRotation = false;
    }
    void ThrustControl(float thrustSpeed){
        body.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
    }

}
