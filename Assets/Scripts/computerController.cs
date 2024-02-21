using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class computerController : MonoBehaviour
{
    public GameObject robot;
    public GameObject robotLights;
    public GameObject Manager;
    public GameObject player;
    public GameObject instruction;
    public AudioSource robotStartingUp;

    public int robotNum;

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
                robotLights.SetActive(true);
                player.GetComponent<controller>().robotLights = robotLights;
                player.GetComponent<controller>().setBoolsFalse();
                player.GetComponent<controller>().controllingRobot = robot;
                player.GetComponent<controller>().controlRobot = true;
                player.GetComponent<controller>().canMove = false;
                player.GetComponent<controller>().rb.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            instruction.SetActive(false);
        }
    }
}
