using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labotatoryexercise : MonoBehaviour
{
    Vector3[] vertexArray = new []                  //array of vertices around which we want to make our B-splines
    {
        new Vector3(0f,0f,0f), new Vector3(0f,10f,5f), new Vector3(10f,10f,10f), new Vector3(10f,0f,15f), 
        new Vector3(0f,0f,20f), new Vector3(0f,10f,25f), new Vector3(10f,10f,30f), new Vector3(10f,0f,35f), 
        new Vector3(0f,0f,40f), new Vector3(0f,10f,45f), new Vector3(10f,10f,50f), new Vector3(10f,0f,55f)
    };
    private int segmentParts;                       //which of the curves are we one
    private float tParameter;                       //where on the current curve are we
    private Vector3 objectPosition;                 //position of our object
    private Vector3 objectRotation;                 //rotation of our object
    private float speedModifier;                    //how fast the object moves on a curve
    private bool coroutineAllowed;
    private Vector3 tangent;                        //tangent in a specific moment
    private Vector3 secondDer;                      //second derivative in a specific moment
    private Vector3 normal;                         //normal in a specific moment
    private Vector3 biNormal;                       //biNormal in a specific moment
    private float newAngleX;
    private float newAngleY;
    private float newAngleZ;
    
    // Start is called before the first frame update
    void Start()
    {
        segmentParts = 0;
        tParameter = 0f;
        speedModifier = 1f;
        coroutineAllowed = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
            StartCoroutine(BSplines(segmentParts));

    }

    private IEnumerator BSplines(int myVertexNumber)
    {
        coroutineAllowed = false;                       //so coroutine isn't called until it's ready

        Vector3 r0 = vertexArray[myVertexNumber];
        Vector3 r1 = vertexArray[myVertexNumber + 1];
        Vector3 r2 = vertexArray[myVertexNumber + 2];
        Vector3 r3 = vertexArray[myVertexNumber + 3];
        
        while (tParameter < 1)
        {
            tParameter += Time.deltaTime * speedModifier;

            objectPosition = (1 / 6f) * ((-r0 + 3 * r1 - 3 * r2 + r3) * Mathf.Pow(tParameter, 3) +                  //object position defined by a formula for B-spline
                                        (3 * r0 - 6 * r1 + 3 * r2) * Mathf.Pow(tParameter, 2) +
                                        (-3 * r0 + 3 * r2) * tParameter +
                                        (r0 + 4 * r1 + r2));

            tangent = (1 / 6f) * (3f * (-r0 + 3 * r1 - 3 * r2 + r3) * Mathf.Pow(tParameter, 2) +                    //first derivative aka tangent of the object
                                  2f * (3 * r0 - 6 * r1 + 3 * r2) * Mathf.Pow(tParameter, 1) +
                                  (-3 * r0 + 3 * r2));
            
            secondDer = (1 / 6f) * (6f * (-r0 + 3 * r1 - 3 * r2 + r3) * Mathf.Pow(tParameter, 1) +                  //second derivative
                                 2f * (3 * r0 - 6 * r1 + 3 * r2));

            normal = Vector3.Cross(tangent, secondDer);                                                          //normal calculations
            biNormal = Vector3.Cross(tangent, normal);                                                           //binormal calculations
            
            //objectRotation
            newAngleX = Vector3.Angle(Vector3.forward, tangent);
            newAngleY = Vector3.Angle(Vector3.right, normal);
            newAngleZ = Vector3.Angle(Vector3.up, biNormal);
            objectRotation = new Vector3(newAngleZ, newAngleY, newAngleX);
            
            transform.position = objectPosition;
            //transform.up();
            //transform.Rotate(objectRotation * 0.01f);
            transform.rotation = Quaternion.LookRotation(tangent, Vector3.up);                                        //rotation of the object along the spline using Quaternion
            
            var matrix = transform.localToWorldMatrix;
            // get position from the last column
            var position = new Vector3(matrix[0,3], matrix[1,3], matrix[2,3]);
            
            yield return new WaitForEndOfFrame();
        }

        tParameter = 0f;

        segmentParts += 1;

        if (segmentParts > 8)
            segmentParts = 0;

        coroutineAllowed = true;
    }
}
