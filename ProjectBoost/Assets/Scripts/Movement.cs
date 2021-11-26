using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketbody;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
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
            ApplyRotation(rotateThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateThrust);
        }

    }

    public void ApplyRotation(float rotationThisFrame)
    {
        rocketbody.freezeRotation = true; // freezing rotation se we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rocketbody.freezeRotation = false; // unfreezing rotation to the physics system can take over
    }
}
