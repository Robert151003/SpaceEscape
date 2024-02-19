using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class blockController : MonoBehaviour
{
    public bool turnedOn;
    public GameObject attractor;
    public GameObject player;
    public Animator buttonAnim;
    public bool pressed;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < 2)
        {
            //instruction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                buttonAnim.SetTrigger("pressed");
                turnedOn = !turnedOn;
                
                pressed = true;
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
