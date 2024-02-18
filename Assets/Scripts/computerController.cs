using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class computerController : MonoBehaviour
{
    public GameObject robot;
    public GameObject Manager;
    public GameObject player;
    public GameObject instruction;

    private void Update()
    {
        if(Vector2.Distance(this.transform.position, player.transform.position)<2)
        {
            if (Manager.GetComponent<UIController>().introLevel)
            {
                Manager.GetComponent<UIController>().eKeyAnimator.SetBool("In", true);
            }
            
            instruction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            { 
                if (Manager.GetComponent<UIController>().introLevel)
                {
                    Manager.GetComponent<UIController>().eKeyAnimator.SetBool("Out", true);
                }
                
                player.GetComponent<controller>().controllingRobot = robot;
                player.GetComponent<controller>().controlRobot = true;
                player.GetComponent<controller>().canMove = false;
            }
        }
        else
        {
            instruction.SetActive(false);
        }
    }
}
