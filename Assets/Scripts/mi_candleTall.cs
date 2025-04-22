using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mi_candleTall : MonoBehaviour, IInteractable
{
    public int code => 1;
    public void Interact()
    {
        FindObjectOfType<li_candle>().scaleInitial = 2;
        FindObjectOfType<li_candle>().durationMult = 2;
        Destroy(gameObject);
    }
}