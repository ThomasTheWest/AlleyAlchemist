using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_ivy : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().ivy += 1;
        Destroy(gameObject, 1.0f);
    }
}