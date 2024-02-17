using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour
{
    public bool turnedOn;
    public GameObject attractor;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < 2)
        {
            //instruction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                turnedOn = !turnedOn; 
            }

            if (turnedOn)
            {
                attractor.GetComponent<blockAttractor>().moveBlocks();
            }
            else
            {
                attractor.GetComponent<blockAttractor>().StopMovingBlocks();
            }
        }
        else
        {
            //instruction.SetActive(false);
        }
    }
}
