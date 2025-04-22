using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class playerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float gravity = -9.81f;
    private float speedFalling;
    public LayerMask groundLayer;

    public XRNode inputSource;
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
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        //fallin...dreamin...talkin...
        bool isGrounded = CheckIfGrounded();

        if (isGrounded)
        {
            speedFalling = 0;
        }
        else
        {
            speedFalling += gravity * Time.fixedDeltaTime;
        }

        character.Move(Vector3.up * speedFalling * Time.fixedDeltaTime);
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}