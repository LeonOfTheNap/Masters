using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class MySpeck : MonoBehaviour
{
    [SerializeField] private GameObject ParticleSystem;
    private int localCounter = 0;
    private bool calledCourtine = false;
    

    private IEnumerator myMove()
    {
        var myPrSpeed = ParticleSystem.GetComponent<MyParticles>().ParticleSpeed;
        Vector3 thrust = new Vector3(Random.Range(-myPrSpeed, myPrSpeed), Random.Range(-myPrSpeed, myPrSpeed),
            Random.Range(-myPrSpeed, myPrSpeed));
        gameObject.GetComponent<Rigidbody>().velocity = thrust;
        yield return new WaitForSeconds(1f);
    }

    private void FixedUpdate()
    {
        if (!calledCourtine)
        {
            StartCoroutine(myMove());
            calledCourtine = true;
        }
    }

    void OnDestroy()
    {
        var myPr = ParticleSystem.GetComponent<MyParticles>();
        if(!myPr.Stop || (localCounter < 100))
        {
            localCounter++;
            ParticleSystem.GetComponent<MyParticles>().AddParticles();
        }
    }
}
