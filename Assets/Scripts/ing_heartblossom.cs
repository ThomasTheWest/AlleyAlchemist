using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_heartblossom : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().heartblossom += 1;
        Destroy(gameObject, 1.0f);
    }
}