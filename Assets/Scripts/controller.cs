using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    public GameObject controllingRobot;
    public bool controlRobot;

    public GameObject door;
    public Sprite openDoor;
    public Sprite closeDoor;

    public bool levelComplete;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        movement.Normalize();
        if (!controlRobot)
        {
            rb = GetComponent<Rigidbody2D>();
            MovePlayer(this.gameObject, movement);
        }
        else
        {
            rb = controllingRobot.GetComponent<Rigidbody2D>();
            MovePlayer(controllingRobot, movement);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                controlRobot = false;
            }
            
        }

        if (levelComplete)
        {
            door.GetComponent<SpriteRenderer>().sprite = openDoor;
        }
        else
        {
            door.GetComponent<SpriteRenderer>().sprite = closeDoor;
        }
        
    }

    void MovePlayer(GameObject controllingPlayer, Vector2 movement)
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
