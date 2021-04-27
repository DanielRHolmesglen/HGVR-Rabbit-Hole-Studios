using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! A script that controls the water particles and the intensity/speed that they emit from the watering can depending on the angle of the particle system.
public class WateringCan : MonoBehaviour
{
    [Header("Particle System")]
    public ParticleSystem waterParticles; //!< The water particle system.

    [Header("Water Pour Angle")]
    [Range(0f, 180f)] public float pourAngle = 90f; //!< The minimum angle needed for water particles to start emitting.

    [Header("Debug")]
    public bool debug = false; //!< A boolean that controls whether or not debugs are shown in runtime.

    private float originalParticleSpeed; //!< The original particle speed.
    private bool activeParticles = false; //!< A boolean that determines whether or not the particles are currently active.

    void Start()
    {
        originalParticleSpeed = waterParticles.main.startSpeedMultiplier;
    }

    void Update()
    {
        float currentAngle = Vector3.Angle(waterParticles.transform.TransformDirection(Vector3.forward), Vector3.up);
        Debug.Log((currentAngle - pourAngle) / (180f - pourAngle) * originalParticleSpeed);

        if (currentAngle >= pourAngle)
        {
            if (!activeParticles)
            {
                waterParticles.Play();
                activeParticles = true;
            }

            var main = waterParticles.main;
            main.startSpeedMultiplier = (currentAngle - pourAngle) / (180f - pourAngle) * originalParticleSpeed;

            if (debug) Debug.DrawLine(waterParticles.transform.position, waterParticles.transform.TransformPoint(Vector3.forward), Color.green);
        }
        else
        {
            if (activeParticles)
            {
                waterParticles.Stop();
                activeParticles = false;
            }

            if (debug) Debug.DrawLine(waterParticles.transform.position, waterParticles.transform.TransformPoint(Vector3.forward), Color.red);
        }
    }
}
