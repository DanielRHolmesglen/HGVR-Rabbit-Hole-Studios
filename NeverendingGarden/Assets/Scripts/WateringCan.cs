using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! A script that controls the water particles and the intensity/speed that they emit from the watering can depending on the angle of the particle system.
public class WateringCan : MonoBehaviour
{
    [Header("Particle System")]
    public ParticleSystem waterParticles; //!< The water particle system.
    public AudioSource audioSource;
    public MeshCollider meshCollider;
    [Header("Water Pour Angle")]
    [Range(0f, 180f)] public float pourAngle = 90f; //!< The minimum angle needed for water particles to start emitting.

    [Header("Debug")]
    public bool debug = false; //!< A boolean that controls whether or not debugs are shown in runtime.

    private float originalParticleSpeed; //!< The original particle speed.
    public bool activeParticles; //!< A boolean that determines whether or not the particles are currently active.

    void Start()
    {
        originalParticleSpeed = waterParticles.main.startSpeedMultiplier;
        //Debug.Log("init");
    }

    void Update()
    {
       // Debug.Log("update");
        float currentAngle = Vector3.Angle(gameObject.transform.TransformDirection(Vector3.forward), Vector3.up);
        
        
        if (currentAngle >= pourAngle)
        {
           // Debug.Log("pour");
            if (!activeParticles)
            {
               // Debug.Log("make water");
                waterParticles.Play();
                audioSource.Play();
                meshCollider.gameObject.SetActive(true);
                
                activeParticles = true;
            }

            //disabled because the water was too slow
            //var main = waterParticles.main;
            //main.startSpeedMultiplier = (currentAngle - pourAngle) / (180f - pourAngle) * originalParticleSpeed;

            if (debug) Debug.DrawLine(waterParticles.transform.position, waterParticles.transform.TransformPoint(Vector3.forward), Color.green);
        }
        else
        {
            //Debug.Log("no pour");
            if (activeParticles)
            {
            //Debug.Log("stop water");
                waterParticles.Stop();
                audioSource.Stop();
                meshCollider.gameObject.SetActive(false);
                
                activeParticles = false;
            }

            if (debug) Debug.DrawLine(waterParticles.transform.position, waterParticles.transform.TransformPoint(Vector3.forward), Color.red);
        }
       
    }

    
    
}
