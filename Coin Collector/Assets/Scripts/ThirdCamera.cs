using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float sensitivity = 2.0f;
    public float heightOffset = 1.5f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        //Makes cursor invisible and locks it so player can't move it.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraInput();
    }

    void HandleCameraInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        //Gets inout from the mouse.

        rotationY += mouseX;
        rotationX -= mouseY;
        //Gets the axes of rotation
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        //Makes the camera rotate only on 180 degrees
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        //Rotates the camera
    }

    void LateUpdate()
    {
        FollowTarget();
        //After the camera has rotated - it follows the player
    }

    void FollowTarget()
    {
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * heightOffset;
        //Gets the position where camera should be
        transform.position = targetPosition;
        //Moves the player
    }
}
