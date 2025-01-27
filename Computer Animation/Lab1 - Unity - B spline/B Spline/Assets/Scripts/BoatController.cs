using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private float acceleration = 0f;
    [SerializeField] private float maxAcceleration = 10f;
    [SerializeField] private float rotationalAcceleration = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && acceleration < maxAcceleration)
        {
            acceleration += 0.01f;
        }
        else if (acceleration > 0)
        {
            acceleration -= 0.01f;
        }

        if (Input.GetKey(KeyCode.D) && rotationalAcceleration < maxAcceleration)
        {
            rotationalAcceleration += 0.01f;
        } else if (Input.GetKey(KeyCode.A) && rotationalAcceleration > -maxAcceleration)
        {
            rotationalAcceleration -= 0.01f;
        }
        else if (rotationalAcceleration != 0)
        {
            if (rotationalAcceleration > 0)
            {
                rotationalAcceleration -= 0.01f;
            }
            else if (rotationalAcceleration < 0)
            {
                rotationalAcceleration += 0.01f;
            }
        }
        
        
        Vector3 movement = Vector3.forward * acceleration;
        transform.Translate(movement * Time.deltaTime);
        transform.rotation *= Quaternion.AngleAxis(rotationalAcceleration * Time.deltaTime, Vector3.up);
        //transform.Rotate(Vector3.left, rotationalAcceleration * Time.deltaTime);
    }
}
