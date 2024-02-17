using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class manager : MonoBehaviour
{
    public List<GameObject>[] switches;

    public bool levelComplete;

    public GameObject player;

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
            if (!switches[0][i].GetComponent<controllerSwitch>().switchPressed)
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
    }


}
