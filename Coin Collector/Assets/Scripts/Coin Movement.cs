using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float amplitude = 1.0f;
    private Vector3 startPos;

    public float rotationSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        //It stores the starting location of the coin. Also rotates it on 90 degrees, so it rotates by verical axis and not horizontal(because I want to)
        startPos = transform.position;
        transform.Rotate(0, -90, -90);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {
        float verticalMovement = Mathf.Sin(Time.time * moveSpeed) * amplitude;
        //Makes the trajectory form movement(which is sinusoid) which is controlled by moveSpeed and amplitude
        Vector3 newPosition = startPos + Vector3.up * verticalMovement;
        //Updates the next position of the coin
        transform.position = newPosition;
        //Moves the coin
    }

    void Rotation()
    {
        //Constantly rotates the coin
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerStay(Collider boom)
    {
        //Checks if the coin collides with the player
        if(boom.gameObject.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if(gameManager != null)
            {
                gameManager.AddCollectedCoin(1);
            }
            Destroy(gameObject);
            //It refers to the Game Manager and adds 1 to the score. Then destroys the coin.
        }
    }
}
