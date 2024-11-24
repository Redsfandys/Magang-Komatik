using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private Vector3 movement;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        movement = forward * vertical + right * horizontal;
        if (movement.magnitude > 0f)
        {
            transform.Translate(movement.normalized * moveSpeed * Time.deltaTime, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
