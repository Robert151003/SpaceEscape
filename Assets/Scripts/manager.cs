using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[System.Serializable]
public class manager : MonoBehaviour
{
    public List<GameObject>[] switches;

    public bool levelComplete;

    public GameObject player;

    public Animator fade;

    public GameObject[] playerIcons;

    public GameObject progressSaver;
    public float timer;

    public void Start()
    {
        switches = new List<GameObject>[1];
        switches[0] = new List<GameObject>(GameObject.FindGameObjectsWithTag("Switch"));
    }

    private void Update()
    {
        levelComplete = true; // Assume level is complete initially

        for (int i = 0; i < switches[0].Count; i++)
        {
            if (!switches[0][i].GetComponent<controllerSwitch>().switchTurnedOn)
            {
                levelComplete = false;
                break; // Exit the loop early if a switch is not pressed
            }
        }

        if (levelComplete)
        {
            player.GetComponent<controller>().levelComplete = true;
        }
        else
        {
            player.GetComponent<controller>().levelComplete = false;
        }

        //remove - is for testing
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            progressSaver.GetComponent<progressSaver>().SavePlayer();
            timer = 2f;
        }
    }

    public void fadeIcons(GameObject icon)
    {
        icon.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
    public void unfadeIcons(GameObject icon)
    {
        icon.GetComponent<Image>().color = new Color(1, 1, 1, 1);

    }


}
