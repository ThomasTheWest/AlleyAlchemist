using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ui_tooltip : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private TextMeshProUGUI tooltip;
    [SerializeField] private RawImage bgSmear;
    public string tooltipText;

    [Header("Fade Settings")]
    [SerializeField] private float fadeStartDistance = 0.25f;
    [SerializeField] private float fadeEndDistance = 0.5f;

    private void Start()
    {
        mainCamera = Camera.main;

        tooltip.text = tooltipText;
    }
    void LateUpdate()
    {
        transform.LookAt(mainCamera.transform);
        transform.Rotate(0, 180, 0);

        //tooltip shouldn't be visible unless you're bringing the ingredient right up to your face and holding it
        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);

        float alpha = Mathf.InverseLerp(fadeEndDistance, fadeStartDistance, distance);
        Color currentColor = tooltip.color;
        currentColor.a = alpha;
        tooltip.color = currentColor;
        bgSmear.color = currentColor;
    }
}