using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionManager : MonoBehaviour
{
    public GameObject instruction;
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public GameObject pressContinue;

    public GameObject player;
    public GameObject manager;

    public bool complete;
    public int step;
    public void Start()
    {
        instruction.SetActive(true);
    }
    public void Update()
    {
        player.GetComponent<controller>().canMove = false;
        manager.GetComponent<UIController>().start = false;
        instruction.SetActive(true);
        step1.SetActive(true);
        step2.SetActive(false);
        StartCoroutine("clicktoContinue");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StopCoroutine("clicktoContinue");
            step++;
            pressContinue.SetActive(false);
            StartCoroutine("clicktoContinue");
        }
        if(step == 1)
        {
            step1.SetActive(false);
            step2.SetActive(true);            
        }
        else if(step == 2)
        {
            step1.SetActive(false);
            step2.SetActive(false); 
            step3.SetActive(true);
        }
        else if( step == 3)
        {
            instruction.SetActive(false);
            player.GetComponent<controller>().canMove = true;
            manager.GetComponent<UIController>().start = true;
        }
    }

    IEnumerator clicktoContinue()
    {
        yield return new WaitForSeconds(2f);
        pressContinue.SetActive(true);
    }
}
