using System;
using System.Collections;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;
using UnityEngine;

public class FixedSegments : MonoBehaviour
{

    
    Vector3[] vertexArray = new []
    {
        new Vector3(0f,0f,0f), new Vector3(0f,10f,5f), new Vector3(10f,10f,10f), new Vector3(10f,0f,15f), 
        new Vector3(0f,0f,20f), new Vector3(0f,10f,25f), new Vector3(10f,10f,30f), new Vector3(10f,0f,35f), 
        new Vector3(0f,0f,40f), new Vector3(0f,10f,45f), new Vector3(10f,10f,50f), new Vector3(10f,0f,55f)
    };
    private Vector3 gizmosPosition;
    private Vector3 tangent;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < 9; i++)
        {
            Vector3 r0 = vertexArray[i];
            Vector3 r1 = vertexArray[i + 1];
            Vector3 r2 = vertexArray[i + 2];
            Vector3 r3 = vertexArray[i + 3];
        
            //Gizmos.DrawSphere(r0 * 2, 0.5f);
        
            for (float t = 0; t <= 1; t += 0.05f)
            {
                gizmosPosition = (1f / 6f) * ((-r0 + 3f * r1 - 3f * r2 + r3) * Mathf.Pow(t, 3) +
                                              (3f * r0 - 6f * r1 + 3f * r2) * Mathf.Pow(t, 2) +
                                              (-3f * r0 + 3f * r2) * t +
                                              (r0 + 4f * r1 + r2));
                
                tangent = (1 / 6f) * (3f * (-r0 + 3 * r1 - 3 * r2 + r3) * Mathf.Pow(t, 2) +                    //first derivative aka tangent of the object
                                      2f * (3 * r0 - 6 * r1 + 3 * r2) * Mathf.Pow(t, 1) +
                                      (-3 * r0 + 3 * r2));
                
                //Debug.Log(gizmosPosition);

                //Vector3 temp = gizmosPosition + new Vector3(1,1,1);
                
                Gizmos.DrawLine(gizmosPosition, gizmosPosition + tangent);
            
                Gizmos.DrawSphere(gizmosPosition, 0.1f);
            }
            
        }
        
    }
}
