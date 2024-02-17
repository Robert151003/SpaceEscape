using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class computerController : MonoBehaviour
{
    public GameObject robot;
    public GameObject player;
    public GameObject instruction;

    private void Update()
    {
        if(Vector2.Distance(this.transform.position, player.transform.position)<2)
        {
           instruction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<controller>().controllingRobot = robot;
                player.GetComponent<controller>().controlRobot = true;
            }
        }
        else
        {
            instruction.SetActive(false);
        }
    }
}
