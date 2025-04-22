using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class playerCamera : MonoBehaviour
{
    public XRNode inputSource;
    public float speedRotate = 50.0f;
    private XROrigin rig;
    private Vector2 inputAxis;
    private CharacterController character;
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        float rotation = inputAxis.x * speedRotate * Time.deltaTime;

        transform.Rotate(0, rotation, 0);

        if (inputAxis.x < 0)
        {
            //Debug.Log(inputSource + " stick X axis is " + inputAxis.x);
        }
    }
}
