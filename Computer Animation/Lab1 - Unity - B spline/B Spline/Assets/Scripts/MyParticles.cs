using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Random;

public class MyParticles : MonoBehaviour
{
    
    [SerializeField] private float ParticleLifeTime = 5f;
    [SerializeField] public float ParticleSpeed = 1f;
    [SerializeField] private GameObject particle;
    [SerializeField] private int numberOfParticles = 10;
    [SerializeField] public bool Stop = false;

    private GameObject myNewParticle;
    private GameObject myParticle;
    public int counter = 0;
    
    // Start is called before the first frame update
    

    private void FixedUpdate()
    {
        if ((counter < numberOfParticles) && !Stop)
        {
            AddParticles();
            counter++;
        }
    }

    public void LowerCounter()
    {
        counter -= 1;
    }

    public void AddParticles()
    {
        float x = UnityEngine.Random.Range(-10f, 10f);
        float y = UnityEngine.Random.Range(0f, 10f);
        float z = UnityEngine.Random.Range(-10f, 10f);
        myNewParticle = Instantiate(particle, new Vector3(x + transform.position.x, y + transform.position.y, z + transform.position.z), Quaternion.identity);
        Destroy(myNewParticle, Range(0.9f * ParticleLifeTime, 1.1f * ParticleLifeTime));
        //Debug.Log("Stvorila se prašina " + listOfParticles.Count);
    }

}
