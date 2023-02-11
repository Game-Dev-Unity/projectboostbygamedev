using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    float period = 8f;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveAutomatically();
    }
    void moveAutomatically(){
        if(period <= Mathf.Epsilon) return; //Mathf.Epsilon is the tiniest of the float value 
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float value = Mathf.Sin(cycles * tau);
        movementFactor = (value + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
