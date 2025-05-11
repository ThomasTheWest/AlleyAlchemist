using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ac_ingSource : MonoBehaviour
{
    public GameObject ingredient;
    public Transform spawnLocation;
    public bool CustomOrientation = false;
    private Vector3 spawnLocationPos;
    private Quaternion spawnLocationRot;
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

        if (ingredReady)
        {
            ingredReady = false;
            StartCoroutine(RespawnIngred());
        }
    }
}
