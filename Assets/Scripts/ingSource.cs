using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingSource : MonoBehaviour, IInteractable
{
    public int code => 2;
    public void Interact()
    {
        FindObjectOfType<ac_ingSource>().ingredReady = false;
    }
}