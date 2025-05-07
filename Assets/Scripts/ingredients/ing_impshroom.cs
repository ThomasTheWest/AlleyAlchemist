using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_impshroom : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().AddIngredient("impshroom");
        //FindObjectOfType<ac_cauldron>().impshroom += 1;
        Destroy(gameObject, 1.0f);
    }
}