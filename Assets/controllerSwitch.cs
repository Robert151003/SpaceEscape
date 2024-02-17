using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerSwitch : MonoBehaviour
{

    public Sprite pressed;
    public Sprite unPressed;

    public bool switchPressed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Robot") || other.CompareTag("Block"))
        {
            this.GetComponent<SpriteRenderer>().sprite = pressed;
            switchPressed = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<SpriteRenderer>().sprite = unPressed;
        switchPressed = false;
    }

}
