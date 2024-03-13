using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class doorUnlock : MonoBehaviour
{
    public GameObject[] unlockSwitch;
    public GameObject light;

    public Sprite open;
    public Sprite close;

    public void Update()
    {
        int switchesPressed = 0;

        for (int i = 0; i < unlockSwitch.Count(); i++)
        {
            if (unlockSwitch[i].GetComponent<controllerSwitch>().switchPressed)
            {
                switchesPressed++;
            }
        }

        if (switchesPressed == unlockSwitch.Count())
        {
            // All switches are pressed, open the door
            this.GetComponent<SpriteRenderer>().sprite = open;
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            light.SetActive(false);
        }
        else
        {
            // At least one switch is not pressed, keep the door closed
            this.GetComponent<SpriteRenderer>().sprite = close;
            this.GetComponent<BoxCollider2D>().isTrigger = false;
            light.SetActive(true);
        }

    }
}
