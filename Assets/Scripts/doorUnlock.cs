using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorUnlock : MonoBehaviour
{
    public GameObject unlockSwitch;
    public GameObject light;

    public Sprite open;
    public Sprite close;

    public void Update()
    {
        if (unlockSwitch.GetComponent<controllerSwitch>().switchPressed)
        {
            this.GetComponent<SpriteRenderer>().sprite = open;
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            light.SetActive(false);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = close;
            this.GetComponent<BoxCollider2D>().isTrigger = false;
            light.SetActive(true);
        }
    }
}
