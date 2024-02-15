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
        switches[0] = new List<GameObject>(GameObject.FindGameObjectsWithTag("Switch"));
    }
    private void Update()
    {
        for (int i = 0; i < switches[0].Count; i++)
        {
            if (!switches[i][0].GetComponent<controllerSwitch>().switchPressed)
            {
                levelComplete = false;
                return;
            }
            else
            {
                levelComplete = true;
            }
        }
        if (levelComplete)
        {
            player.GetComponent<controller>().levelComplete = true;
        }
    }

}
