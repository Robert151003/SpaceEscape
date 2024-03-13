using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
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
    public int levelNum;

    [Header("AudioSettings")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioMixer masterMixer;

    public void Start()
    {
        switches = new List<GameObject>[1];
        switches[0] = new List<GameObject>(GameObject.FindGameObjectsWithTag("Switch"));
        LoadPlayer();

        masterMixer.SetFloat("MasterVolume", progressSaver.GetComponent<progressSaver>().masterVol);
        masterSlider.value = progressSaver.GetComponent<progressSaver>().masterVol;
        masterMixer.SetFloat("MusicVolume", progressSaver.GetComponent<progressSaver>().musicVol);
        musicSlider.value = progressSaver.GetComponent<progressSaver>().musicVol;
        masterMixer.SetFloat("SoundVolume", progressSaver.GetComponent<progressSaver>().soundVol);
        soundSlider.value = progressSaver.GetComponent<progressSaver>().soundVol;
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

        masterMixer.SetFloat("MasterVolume", masterSlider.value);
        progressSaver.GetComponent<progressSaver>().masterVol = (int)masterSlider.value;
        masterMixer.SetFloat("MusicVolume", musicSlider.value);
        progressSaver.GetComponent<progressSaver>().musicVol = (int)musicSlider.value;
        masterMixer.SetFloat("SoundVolume", soundSlider.value);
        progressSaver.GetComponent<progressSaver>().soundVol = (int)soundSlider.value;

        for (int i = 0; i < levels.Length; i++)
        {
            if (!levels[i])
            {
                levelNum = i + 1;
                return;
            }
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
        progressSaver.GetComponent<progressSaver>().level3 = levels[2];
        progressSaver.GetComponent<progressSaver>().level4 = levels[3];
        progressSaver.GetComponent<progressSaver>().level5 = levels[4];
        progressSaver.GetComponent<progressSaver>().level6 = levels[5];
        progressSaver.GetComponent<progressSaver>().level7 = levels[6];
        progressSaver.GetComponent<progressSaver>().level8 = levels[7];
        progressSaver.GetComponent<progressSaver>().level9 = levels[8];
        progressSaver.GetComponent<progressSaver>().level10 = levels[9];
        progressSaver.GetComponent<progressSaver>().level11 = levels[10];
        progressSaver.GetComponent<progressSaver>().level12 = levels[11];
        progressSaver.GetComponent<progressSaver>().level13 = levels[12];
        progressSaver.GetComponent<progressSaver>().level14 = levels[13];
        progressSaver.GetComponent<progressSaver>().level15 = levels[14];
        progressSaver.GetComponent<progressSaver>().level16 = levels[15];
        progressSaver.GetComponent<progressSaver>().level17 = levels[16];
        progressSaver.GetComponent<progressSaver>().level18 = levels[17];
        progressSaver.GetComponent<progressSaver>().level19 = levels[18];
        progressSaver.GetComponent<progressSaver>().level20 = levels[19];
        progressSaver.GetComponent<progressSaver>().level21 = levels[20];
        progressSaver.GetComponent<progressSaver>().level22 = levels[21];
        progressSaver.GetComponent<progressSaver>().level23 = levels[22];
        progressSaver.GetComponent<progressSaver>().level24 = levels[23];

        progressSaver.GetComponent<progressSaver>().levelNum = levelNum;

        SaveSystem.SavePlayer(progressSaver.GetComponent<progressSaver>());
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        progressSaver.GetComponent<progressSaver>().masterVol = data.masterVol;
        progressSaver.GetComponent<progressSaver>().musicVol = data.musicVol;
        progressSaver.GetComponent<progressSaver>().soundVol = data.soundVol;

        levels[0] = data.level1;
        levels[1] = data.level2;
        levels[2] = data.level3;
        levels[3] = data.level4;
        levels[4] = data.level5;
        levels[5] = data.level6;
        levels[6] = data.level7;
        levels[7] = data.level8;
        levels[8] = data.level9;
        levels[9] = data.level10;

        levelNum = data.levelNum;

    }

}
