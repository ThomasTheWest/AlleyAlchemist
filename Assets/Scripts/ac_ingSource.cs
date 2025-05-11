using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ac_ingSource : MonoBehaviour
{
    public GameObject ingredient;
    public Transform spawnLocation;
    private Vector3 spawnLocationPos;
    [HideInInspector] public bool ingredReady = true;

    private void Start()
    {
        spawnLocationPos = spawnLocation.position;

        Instantiate(ingredient, spawnLocationPos, Quaternion.identity);
    }

    private IEnumerator RespawnIngred()
    {
        yield return new WaitForSeconds(1);
        Instantiate(ingredient, spawnLocationPos, Quaternion.identity);
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
