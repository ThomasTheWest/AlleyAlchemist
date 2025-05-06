using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ac_moonwaterSource : MonoBehaviour
{
    public GameObject ingredient;
    public Transform spawnLocation;

    public void Start()
    {
        Vector3 spawnLocationPos = spawnLocation.position;

        Instantiate(ingredient, spawnLocationPos, Quaternion.identity);
    }
}
