using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_carrot : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().carrot += 1;
        Destroy(gameObject, 1.0f);
    }
}