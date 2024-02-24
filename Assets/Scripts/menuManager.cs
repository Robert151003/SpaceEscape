using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject achievementsMenu;

    public TMP_Text levelNumber;
    public bool[] levels;

    public int levelNum;

    public void Start()
    {
        LoadPlayer();
        levelNumber.text = $"(Level {levelNum})";
    }
    public void start()
    {
        SceneManager.LoadScene(1);       
    }
    public void Continue()
    {
        SceneManager.LoadScene(levelNum);
    }
    public void levelSelector()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void achievements()
    {
        mainMenu.SetActive(false);
        achievementsMenu.SetActive(true);
    }
    public void settings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void loadLevel(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }
   
    public void back()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        achievementsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

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
