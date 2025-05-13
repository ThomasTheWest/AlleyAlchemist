using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionPour : MonoBehaviour
{
    public GameObject ingredientPrefab;  // The ingredient prefab (a primitive sphere)
    public Transform pourPoint;  // A point to spawn the ingredient (e.g., the bottle's spout)
    public float pourForce = 5f;  // Force applied to the ingredient
    public float tiltThreshold = 70f;  // The tilt threshold (in degrees) at which the ingredient falls
    private bool hasPoured = false;  // Flag to ensure the ingredient is only poured once per tilt
    public AudioSource pourAudioSource;  // Reference to the AudioSource
    public AudioClip pourSound;  // The sound to play when pouring
    void Update()
    {
        // Check bottle's tilt
        float tiltAngle = Vector3.Angle(Vector3.up, transform.up); // Calculate the bottle's tilt angle

        // If the bottle's tilt is past the threshold and we haven't poured yet
        if (tiltAngle > tiltThreshold && !hasPoured)
        {
            PourPotion();
            PlayPourSound();
        }
    }
    private void PlayPourSound()
    {
        if (pourAudioSource != null && pourSound != null)
        {
            pourAudioSource.PlayOneShot(pourSound);  // Play the sound once
        }
    }

    // Function to pour the potion
    private void PourPotion()
    {
        
        GameObject ingredient = Instantiate(ingredientPrefab, pourPoint.position, pourPoint.rotation);

        // Make sure the ingredient has a Rigidbody
        Rigidbody rb = ingredient.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = ingredient.AddComponent<Rigidbody>();  // Add Rigidbody if missing
        }

        // Apply force in the direction the pour point is facing (bottle's rotation direction)
        rb.AddForce(pourPoint.forward * pourForce, ForceMode.Impulse);

       
        Destroy(ingredient, 5f);

        // Set hasPoured to true to avoid multiple pours
        hasPoured = true;
    }

    // Reset the pouring state if bottle is upright again
    void OnDrawGizmos()
    {
        // For debugging in editor, shows the tilt threshold (adjust this as needed)
        if (transform.up != Vector3.up)
        {
            float tiltAngle = Vector3.Angle(Vector3.up, transform.up);
            Gizmos.color = tiltAngle > tiltThreshold ? Color.green : Color.red;
            Gizmos.DrawWireSphere(transform.position, 0.1f);  // Show the tilt indication
        }
    }

    
}
