using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ing_ghostwater : MonoBehaviour, IInteractable
{
    public int code => 0;
    public void Interact()
    {
        FindObjectOfType<ac_cauldron>().AddIngredient("ghostwater");
   
        Destroy(gameObject, 1.0f);
    }
}
