using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ac_ingSource : MonoBehaviour
{
    public GameObject ingredient;
    public Transform spawnLocation;
    public bool CustomOrientation = false;
    public bool SoundEnabled = false;
    private Vector3 spawnLocationPos;
    private Quaternion spawnLocationRot;
    private AudioSource audioSource;
    [HideInInspector] public bool ingredReady = true;

    private void Start()
    {
        spawnLocationPos = spawnLocation.position;
        spawnLocationRot = spawnLocation.rotation;

        if (CustomOrientation)
        {
            Instantiate(ingredient, spawnLocationPos, spawnLocationRot);
        }
        else
        {
            Instantiate(ingredient, spawnLocationPos, Quaternion.identity);
        }

        if (SoundEnabled)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private IEnumerator RespawnIngred()
    {
        yield return new WaitForSeconds(1);

        if (CustomOrientation)
        {
            Instantiate(ingredient, spawnLocationPos, spawnLocationRot);
        }
        else
        {
            Instantiate(ingredient, spawnLocationPos, Quaternion.identity);
        }

        ingredReady = true;
        yield return null;
    }
    void OnTriggerExit(Collider col)
    {
        //Debug.Log("Object removed!");

        if (SoundEnabled && audioSource != null)
        {
            audioSource.Play();
            //Debug.Log("playing sound!!!!!!");
        }

        if (ingredReady)
        {
            ingredReady = false;
            StartCoroutine(RespawnIngred());
        }
    }
}
