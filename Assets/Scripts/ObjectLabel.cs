using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ObjectLabel : MonoBehaviour
{
    public string labelText;
    public GameObject labelCanvasPrefab;

    private GameObject labelInstance;
    private TextMeshProUGUI labelTextUI; 
    void Start()
    {
        if (labelCanvasPrefab != null)
        {
            labelInstance = Instantiate(labelCanvasPrefab, transform.position, Quaternion.identity);
            labelTextUI = labelInstance.GetComponentInChildren<TextMeshProUGUI>();
            labelTextUI.text = labelText;
            labelInstance.SetActive(false);
        
        }
    }
    public void HideLabel()
    {
        if (labelInstance != null)
        { 

        labelInstance.SetActive(false);  

        }
    }

    public void ShowLabel(Transform cameraTransform)
    {
        if (labelInstance != null)
        {
            labelInstance.SetActive(true);
            labelInstance.transform.position = transform.position + Vector3.up * 0.2f;
            labelInstance.transform.LookAt(cameraTransform);
            labelInstance.transform.Rotate(0,180,0);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
