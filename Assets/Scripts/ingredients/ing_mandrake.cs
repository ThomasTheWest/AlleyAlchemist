using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_mandrake : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().AddIngredient("mandrake");
        //FindObjectOfType<ac_cauldron>().mandrake += 1;
        Destroy(gameObject, 1.0f);
    }
}