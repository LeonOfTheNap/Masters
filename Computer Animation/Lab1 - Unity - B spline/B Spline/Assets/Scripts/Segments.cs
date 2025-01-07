using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segments : MonoBehaviour
{

    [SerializeField] private Transform[] controlPoints;
    private Vector3 gizmosPosition;

    private void OnDrawGizmos()
    {
        Vector3 r0 = controlPoints[0].position;
        Vector3 r1 = controlPoints[1].position;
        Vector3 r2 = controlPoints[2].position;
        Vector3 r3 = controlPoints[3].position;
        
        //Gizmos.DrawSphere(r0 * 2, 0.5f);
        
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = (1f / 6f) * ((-r0 + 3f * r1 - 3f * r2 + r3) * Mathf.Pow(t, 3) +
                                        (3f * r0 - 6f * r1 + 3f * r2) * Mathf.Pow(t, 2) +
                                        (-3f * r0 + 3f * r2) * t +
                                        (r0 + 4f * r1 + r2));

            //Debug.Log(gizmosPosition);
            
            Gizmos.DrawSphere(gizmosPosition, 0.1f);
        }
        
        
    }
}
