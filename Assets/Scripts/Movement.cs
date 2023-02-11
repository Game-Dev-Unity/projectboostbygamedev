using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Vector2 movement;
    Rigidbody body;
    AudioSource audioSource;
    float rotateSpeed = 200.0f;
    float thrustSpeed = 25000.0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem ThrustParticles;
    [SerializeField] ParticleSystem LeftThrustParticles;
    [SerializeField] ParticleSystem RightThrustParticles;
    
    // Start is called before the first frame update
    void Start()
    {
       body = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    } 
    void OnThrust(InputValue value){
        if(value.isPressed){
            ThrustControl(thrustSpeed); 
            
        }
        else{
            audioSource.Stop();
        }
    }
    void Thrust(){
        if(Input.GetKey(KeyCode.Space) == false){
            audioSource.Stop();
            ThrustParticles.Stop();
        }
    }
    void ThrustControl(float thrustSpeed){
        body.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            ThrustParticles.Play();
            audioSource.PlayOneShot(mainEngine);
        }
        else{
            audioSource.Stop();
        }
    }
    void OnMove(InputValue value){
        movement = value.Get<Vector2>();
    }
    void Rotate(){
        RotationControl(-rotateSpeed);
    }
   
    void RotationControl(float rotateSpeed)
    {
        body.freezeRotation = true;
        transform.Rotate(0, 0, movement.x * rotateSpeed * Time.deltaTime);
        ThrustParticlesControl();
        body.freezeRotation = false;
    }

    void ThrustParticlesControl()
    {
        if (movement.x > 0)
        {
            if (!LeftThrustParticles.isPlaying)
            {
                LeftThrustParticles.Play();
            }
        }
        else
        {
            LeftThrustParticles.Stop();
        }
        if (movement.x < 0)
        {
            if (!RightThrustParticles.isPlaying)
            {
                RightThrustParticles.Play();
            }
        }
        else
        {
            RightThrustParticles.Stop();
        }
    }


}
