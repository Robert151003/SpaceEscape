using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class blockController : MonoBehaviour
{
    public bool turnedOn;
    public GameObject attractor;
    public GameObject player;
    public GameObject UseText;
    public Animator buttonAnim;
    public AudioSource click;
    public bool pressed;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                buttonAnim.SetTrigger("pressed");
                timer = 0.5f;
                pressed = false;
            }

        }

        if (Vector2.Distance(this.transform.position, player.transform.position) < 2)
        {
            UseText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                click.Play();            
                
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
            UseText.SetActive(false);
        }
    }
}
