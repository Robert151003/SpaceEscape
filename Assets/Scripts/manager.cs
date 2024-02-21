using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[System.Serializable]
public class manager : MonoBehaviour
{
    [Header("Game-Play")]
    public GameObject player;
    public List<GameObject>[] switches;    
    public bool levelComplete;

    [Header("UI")]
    public Animator fade;
    public GameObject[] playerIcons;

    [Header("Saving")]
    public GameObject progressSaver;
    public bool[] levels;

    public void Start()
    {
        switches = new List<GameObject>[1];
        switches[0] = new List<GameObject>(GameObject.FindGameObjectsWithTag("Switch"));

        LoadPlayer();
    }

    private void Update()
    {
        // Checking if all switches are active
        levelComplete = true;

        for (int i = 0; i < switches[0].Count; i++)
        {
            if (!switches[0][i].GetComponent<controllerSwitch>().switchTurnedOn)
            {
                levelComplete = false;
                break;
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

    // UI Control
    public void fadeIcons(GameObject icon)
    {
        icon.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
    public void unfadeIcons(GameObject icon)
    {
        icon.GetComponent<Image>().color = new Color(1, 1, 1, 1);

    }

    // Save System
    public void SavePlayer()
    {
        progressSaver.GetComponent<progressSaver>().level1 = levels[0];
        progressSaver.GetComponent<progressSaver>().level2 = levels[1];

        SaveSystem.SavePlayer(progressSaver.GetComponent<progressSaver>());
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        progressSaver.GetComponent<progressSaver>().level1 = data.level1;
        progressSaver.GetComponent<progressSaver>().level2 = data.level2;

        levels[0] = data.level1;
        levels[1] = data.level2;

    }

}
