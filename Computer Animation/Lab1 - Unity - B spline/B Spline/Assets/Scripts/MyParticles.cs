using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class MyParticles : MonoBehaviour
{
    
    [SerializeField] private float ParticleLifeTime = 3f;
    [SerializeField] private float ParticleSpeed = 1f;
    [SerializeField] private float ParticleSize = 1f;
    [SerializeField] private GameObject particle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
