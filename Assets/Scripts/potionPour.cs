using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionPour : MonoBehaviour
{
    [Header("Liquid Settings")]
    [SerializeField] private Material liquidMaterial;    // Liquid material with fill control
    [SerializeField] private string liquidFillProperty = "_Fill"; // Shader property name for liquid fill
    [SerializeField] private float pourRate = 0.01f;     // Rate at which the liquid empties
    [SerializeField] private float minFillLevel = 0.0f;  // Minimum fill level

    [Header("Pouring Settings")]
    [SerializeField] private ParticleSystem pourParticles; // Particle system for pouring
    [SerializeField] private float pourThreshold = 45f;    // Tilt angle to start pouring

    [Header("Ingredient Settings")]
    [SerializeField] private string ingredientName;        // The ingredient this bottle represents

    private bool isPouring = false; // Tracks if the bottle is currently pouring

    void Update()
    {
        var emission = pourParticles.emission;
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to manually play the particle system
        {
            pourParticles.Play();
            Debug.Log("Test particle system started!");
        }
        // Check bottle tilt (rotation of the bottle's transform)
        float tiltAngle = Vector3.Angle(transform.up, Vector3.up); // Angle between bottle's up direction and world up
        Debug.Log("Tilt Angle: " + tiltAngle);

        // If bottle is tilted beyond the threshold, start pouring
        if (tiltAngle > pourThreshold)
        {
            if (!isPouring)
            {
                StartPouring();
                emission.enabled = true;
            }
        }
        else
        {
            if (isPouring)
            {
                StopPouring();
                emission.enabled = false; 
            }
        }

        // Update the particle system's position and rotation to match the bottle's
        if (pourParticles != null && isPouring)
        {
            pourParticles.transform.position = transform.position; // Follow bottle's position
            pourParticles.transform.rotation = transform.rotation; // Follow bottle's rotation
        }

        // Handle liquid fill level
        if (isPouring && liquidMaterial != null)
        {
            float currentFill = liquidMaterial.GetFloat(liquidFillProperty);
            float newFill = Mathf.Max(minFillLevel, currentFill - pourRate * Time.deltaTime);
            liquidMaterial.SetFloat(liquidFillProperty, newFill);

            if (newFill <= minFillLevel)
            {
                StopPouring();
            }
        }
    }

    private void StartPouring()
    {
        if (!isPouring)
        {
            isPouring = true;
            if (pourParticles != null)
            {
                pourParticles.gameObject.SetActive(true);
                pourParticles.Play();
                
                Debug.Log("Particle system started!");
                Debug.Log($"Particle system isPlaying: {pourParticles.isPlaying}");
            }
            Debug.Log($"Pouring {ingredientName}!");
        }
    }

    private void StopPouring()
    {
        if (isPouring)
        {
            isPouring = false;
            if (pourParticles != null)
            {
                pourParticles.Stop();
                Debug.Log("Particle system stopped!");
                Debug.Log($"Particle system isPlaying: {pourParticles.isPlaying}");
            }
            Debug.Log($"Stopped pouring {ingredientName}.");
        }
    }

    public bool IsPouring()
    {
        return isPouring;
    }

    public string GetIngredientName()
    {
        return ingredientName;
    }
}
