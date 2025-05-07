using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_moonwater : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().AddIngredient("moonwater");
        //FindObjectOfType<ac_cauldron>().moonwater += 1;
        Destroy(gameObject, 1.0f);
    }
}