using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ac_cauldron : MonoBehaviour
{
    [Header("Ingredients")]
    public int moonwater = 0;
    public int moonlace = 0;
    public int mandrake = 0;
    public int heartblossom = 0;
    public int growsprout = 0;
    public int ivy = 0;
    public int carrot = 0;
    public int witchSalt = 0;

    private int ingredCount = 0;

    [Header("Material")]
    [SerializeField] Material green;
    [SerializeField] Material red;
    [SerializeField] Material grey;
    private Renderer renderLiquid;

    void Start()
    {
        renderLiquid = GetComponent<Renderer>();
    }
    void Update()
    {
        ingredCount = ivy + carrot;

        if (ingredCount >= 3)
        {
            if (ivy == 2 & carrot == 1)
            {
                renderLiquid.material = green;
            }
            else
            {
                renderLiquid.material = red;
            }
        }
        else
        {
            renderLiquid.material = grey;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null & interactable.code == 0)
        {
            //add sound code here wen we gots sounds
            interactable.Interact();
        }
        //need an elseif that makes the item bounce off if it isn't an ingredient
    }
}
