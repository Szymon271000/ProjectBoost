using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketbody;
    [SerializeField] float mainThrust = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        rocketbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        
        if (Input.GetKey(KeyCode.Space)) 
        {
            rocketbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); //0,1,0 same thing == vector.up
        }
        
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotate left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotate right");
        }
    }
}
