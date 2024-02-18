using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject Manager;
    private bool uiInstructions;

    public bool canMove;

    public Animator playerAnimator;

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

        if (uiInstructions && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            uiInstructions = false;
        }

        movement.Normalize();

        
        if (!controlRobot)
        {
            if (canMove)
            {
                rb = GetComponent<Rigidbody2D>();
                MovePlayer(this.gameObject, movement);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
            
        }
        else
        {
            if (Manager.GetComponent<UIController>().introLevel)
            {
                Manager.GetComponent<UIController>().robotAnimator.SetBool("In", true);
                uiInstructions = true;
            }


            rb = controllingRobot.GetComponent<Rigidbody2D>();
            MovePlayer(controllingRobot, movement);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                controlRobot = false;
                canMove = true;
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

        if (levelComplete)
        {
            if (Manager.GetComponent<UIController>().introLevel)
            {
                Manager.GetComponent<UIController>().robotAnimator.SetBool("Out", true);
                Manager.GetComponent<UIController>().endLevel.SetBool("In", true);
            }
            
        }
        
    }

    void MovePlayer(GameObject controllingPlayer, Vector2 movement)
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        if (!controlRobot)
        {           
            playerAnimator.SetFloat("speed", Mathf.Abs(rb.velocity.magnitude));
            if (Mathf.Abs(rb.velocity.magnitude) == 0)
            {
                setBoolsFalse();
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                {
                    playerAnimator.SetBool("idleSide", true);
                }
                else if (Input.GetKeyUp(KeyCode.S))
                {
                    playerAnimator.SetBool("idleDown", true);
                }
                else if (Input.GetKeyUp(KeyCode.W))
                {
                    playerAnimator.SetBool("idleUp", true);
                }
            }
            else
            {
                setBoolsFalse();
                if (Input.GetKey(KeyCode.D))
                {
                    FlipPlayer(true);
                    playerAnimator.SetBool("runSide", true);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    FlipPlayer(false);
                    playerAnimator.SetBool("runSide", true);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    playerAnimator.SetBool("runDown", true);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    playerAnimator.SetBool("runUp", true);
                }
            }
        }       
    }

    void FlipPlayer(bool facingLeft)
    {
        transform.localScale = new Vector3(facingLeft ? -1 : 1, 1, 1);
    }


    public void setBoolsFalse()
    {
        playerAnimator.SetBool("idleDown", false);
        playerAnimator.SetBool("idleUp", false);
        playerAnimator.SetBool("idleSide", false);
        playerAnimator.SetBool("runSide", false);
        playerAnimator.SetBool("runDown", false);
        playerAnimator.SetBool("runUp", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("door"))
        {
            canMove = false;
            Manager.GetComponent<manager>().fade.SetTrigger("fade");
            Manager.GetComponent<progressSaver>().levels[SceneManager.GetActiveScene().buildIndex - 1] = true;
            StartCoroutine(changeLevel());
        }
    }

    IEnumerator changeLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
