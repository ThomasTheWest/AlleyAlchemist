using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class li_candle : MonoBehaviour
{
    //this script should go on the scale point for the candle prefab. note the candle meshes that come w the asset pack need to be edited first
    [Header("Components")]
    [SerializeField] Light flame;
    [SerializeField] GameObject halo;

    [Header("Values")]
    public float duration = 10.0f;
    private float timer = 0f;
    public Color finalColor = new Color(1f, 0.52f, 0f);
    
    private Color initialColor;
    private float intensityInitial;
    private float scaleInitial;

    void Start()
    {
        intensityInitial = flame.intensity;
        scaleInitial = transform.localScale.y;
        initialColor = initialColor = flame.color;
    }

    void Update()
    {
        if (timer < duration)
        {
            //light gets dimmer and deeper, and candle gets shorter
            timer += Time.deltaTime;
            float t = timer / duration;
            flame.intensity = Mathf.Lerp(intensityInitial, 0f, t);
            flame.color = Color.Lerp(initialColor, finalColor, t);

            Vector3 scale = transform.localScale;
            scale.y = Mathf.Lerp(scaleInitial, 0.1f, t);
            transform.localScale = scale;
        }
        else
        {
            halo.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null & interactable.code == 1 & timer > duration)
        {
            //add sound code here wen we gots sounds
            timer = 0.0f;
            halo.SetActive(true);
            interactable.Interact();
        }
    }
}
