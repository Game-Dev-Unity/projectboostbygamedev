using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Vector2 movement;
    Rigidbody body;
    AudioSource audioSource;
    public InputAction PlayerControls;
    float rotateSpeed = 100.0f;
    float thrustSpeed = 10000.0f;
    
    void OnEnable(){
        PlayerControls.Enable();
    }
    void OnDisable(){
        PlayerControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
       body = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
       Debug.Log(GetComponent<PlayerInput>());
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
        else{
            audioSource.Stop();
        }
    }
    void RotationControl(float rotateSpeed){
        body.freezeRotation = true;
        transform.Rotate(0,0,movement.x * rotateSpeed * Time.deltaTime);
        body.freezeRotation = false;
    }
    void ThrustControl(float thrustSpeed){
        body.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        audioSource.Play();
    }

}
