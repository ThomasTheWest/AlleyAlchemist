using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelRaycaster : MonoBehaviour
{
    public float maxDistance = 10f; 
    private ObjectLabel currentLabel;

   

   
    void Update()
    {
        Transform cam =  Camera.main.transform;
        Ray ray = new Ray(cam.position, cam.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        { 
        ObjectLabel label = hit.collider.GetComponent<ObjectLabel>();
            if (label != null)
            {
                if (label != currentLabel)
                {
                    if (currentLabel != null) currentLabel.HideLabel();
                    currentLabel = label;
                    currentLabel.ShowLabel(cam);
                   
                
                }
                return;
            }
        }
        if (currentLabel != null)
        { 
        currentLabel.HideLabel();
            currentLabel = null;
        }
    }
}
