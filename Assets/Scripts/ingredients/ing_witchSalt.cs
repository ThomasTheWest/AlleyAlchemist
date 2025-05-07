using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_witchSalt : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().AddIngredient("witchSalt");
        //FindObjectOfType<ac_cauldron>().witchSalt += 1;
        Destroy(gameObject, 1.0f);
    }
}
