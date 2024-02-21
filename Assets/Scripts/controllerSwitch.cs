using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerSwitch : MonoBehaviour
{

    public Sprite pressed;
    public Sprite unPressed;
    public AudioSource leavingSwitch;
    public AudioSource switchOn;
    public bool switchPressed;
    public bool startCounting;
    public bool switchTurnedOn;
    public float timer;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Robot") || other.CompareTag("Block"))
        {
            
            switchOn.Play();
            timer = 0.3f;
            startCounting = true;
            switchPressed = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switchOn.Play();
        timer = 0.3f;
        switchPressed = false;
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
