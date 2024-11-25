using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5.0f;
    public float maxWalkingSpeed = 1000f;
    public float mouseSensitivity = 2.0f;

    private float verticalRotation = 0;
    public Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Gets player's rigidbody
    }

    void Update()
    {
        RotationInputM();
        WASD();
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = maxWalkingSpeed * 3;
        }
        else
        {
            movementSpeed = maxWalkingSpeed;
        }
        //Makes the player able to sprint. It makes its speed faster when Shift is pressed.
    }

    void RotationInputM()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        //Gets mouse input for X
        transform.Rotate(0, horizontalRotation, 0);
        //Rotates the player
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        //Gets mouse input for Y
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        //Makes vertical rotation restricted to only 180 degrees
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        //Rotates the camera
    }

    void WASD()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Gets the input from the keyboard(WASD)
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * movementSpeed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        //Gets the direction and speed of  the future movement
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        //Moves the player
    }
}
