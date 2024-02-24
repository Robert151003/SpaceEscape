using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class computerController : MonoBehaviour
{
    [Header("Player Objects")]
    public GameObject player;
    public GameObject Manager;
    public GameObject robot;
    public GameObject robotLights;
   
    [Header("Game-Play")]
    public int robotNum;

    [Header("UI")]
    public GameObject instruction;

    [Header("Audio")]
    public AudioSource robotStartingUp;

    private void Update()
    {
        if (robot)
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) < 2)
            {
                if (Manager.GetComponent<UIController>().introLevel)
                {
                    Manager.GetComponent<UIController>().eKeyAnimator.SetBool("In", true);
                }

                instruction.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Changes Icon for whose controlling
                    for (int i = 0; i < Manager.GetComponent<manager>().playerIcons.Length; i++)
                    {
                        Manager.GetComponent<manager>().fadeIcons(Manager.GetComponent<manager>().playerIcons[i]);
                    }
                    Manager.GetComponent<manager>().unfadeIcons(Manager.GetComponent<manager>().playerIcons[robotNum]);


                    if (Manager.GetComponent<UIController>().introLevel)
                    {
                        Manager.GetComponent<UIController>().eKeyAnimator.SetBool("Out", true);
                    }

                    robotStartingUp.Play();

                    player.GetComponent<controller>().rb.velocity = new Vector2(0, 0);
                    player.GetComponent<controller>().setBoolsFalse();
                    player.GetComponent<controller>().playerAnimator.SetBool("idleUp", true);

                    player.GetComponent<controller>().controllingRobot = robot;
                    player.GetComponent<controller>().robotLights = robotLights;
                    robotLights.SetActive(true);

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
}
