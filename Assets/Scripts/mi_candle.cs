using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mi_candle : MonoBehaviour, IInteractable
{
    public int code => 1;
    public void Interact()
    {
        Destroy(gameObject);
    }
}