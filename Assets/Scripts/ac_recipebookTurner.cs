using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ac_recipebookTurner : MonoBehaviour
{
    public ac_recipebook bookScript;
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
    }
}
