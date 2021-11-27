using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) //il piu piccolo float che esiste!!!
        {
            return;
        }
        
        float cycles = Time.time / period; // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6,283
        float rawSignWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSignWave + 1f) / 2f; // recalculated to go from 0 to 1 so its clear

        Vector3 offSet = movementVector * movementFactor;
        transform.position = startingPosition + offSet;
           
    }
}
