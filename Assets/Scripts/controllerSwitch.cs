using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerSwitch : MonoBehaviour
{
    [Header("Switch Sprites")]
    public Sprite pressed;
    public Sprite unPressed;

    [Header("Audio")]
    public AudioSource leavingSwitch;
    public AudioSource switchOn;

    [Header("Game-Play")]
    public bool switchPressed;
    public bool startCounting;
    public bool switchTurnedOn;
    public bool colourRobotSwitch;
    public float timer;


    private int objectsOnSwitch = 0; // Track the number of objects on the switch

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Robot") || other.CompareTag("Block"))
        {
            objectsOnSwitch++;
            if (!colourRobotSwitch)
            {
                switchOn.Play();
                timer = 0.3f;
                startCounting = true;
                switchPressed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Robot") || other.CompareTag("Block"))
        {
            objectsOnSwitch--;
            if (objectsOnSwitch == 0 && !colourRobotSwitch)
            {
                switchOn.Play();
                timer = 0.3f;
                startCounting = true;
                switchPressed = false;
            }
        }
    }

    private void Update()
    {
        

        if (startCounting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (switchPressed)
                {
                    this.GetComponent<SpriteRenderer>().sprite = pressed;
                    switchTurnedOn = true;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().sprite = unPressed;
                    switchTurnedOn = false;
                }
                startCounting = false;
            }
        }
    }
}
