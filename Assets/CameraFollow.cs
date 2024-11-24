using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 3f;
    public float height = 3f;
    public Vector2 pitchLimits = new Vector2(-30f, 60f);

    private float yaw = 0f;
    private float pitch = 0f;

    void LateUpdate()
    {
        if (target == null)
            return;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = rotation * new Vector3(0, height, -distance);
        transform.position = target.position + offset;
        transform.LookAt(target.position + Vector3.up * height);
    }
}
