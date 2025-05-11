using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mi_candleShort : MonoBehaviour, IInteractable
{
    public int code => 1;
    public void Interact()
    {
        FindObjectOfType<li_candleBurn>().scaleInitial = 1;
        FindObjectOfType<li_candleBurn>().durationMult = 1;
        Destroy(gameObject);
    }
}