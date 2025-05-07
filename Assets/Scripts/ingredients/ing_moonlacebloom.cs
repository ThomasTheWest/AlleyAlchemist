using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_moonlacebloom : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().AddIngredient("moonlace");
        //FindObjectOfType<ac_cauldron>().moonlacebloom += 1;
        Destroy(gameObject, 1.0f);
    }
}