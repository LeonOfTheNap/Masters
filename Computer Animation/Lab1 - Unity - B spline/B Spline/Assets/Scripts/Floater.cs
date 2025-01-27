using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float depthBeforeSubmerged = 1f;
    [SerializeField]
    private float displacementAmount = 20f;
    [SerializeField]
    private float floaterCount = 4;

    [SerializeField]
    private float waterDrag = 0.99f;
    [SerializeField]
    private float waterAngularDrag = 0.5f;
    
    void FixedUpdate()
    {
        rigidbody.AddForceAtPosition(Physics.gravity / floaterCount , transform.position, ForceMode.Acceleration);
        
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rigidbody.AddForce(displacementMultiplier * -rigidbody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidbody.AddTorque(displacementMultiplier * -rigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
            
        
    }
}
