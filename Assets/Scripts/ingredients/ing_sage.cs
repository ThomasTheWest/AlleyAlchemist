using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_sage : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().AddIngredient("sage");
        //FindObjectOfType<ac_cauldron>().growsprout += 1;
        Destroy(gameObject, 1.0f);
    }
}
