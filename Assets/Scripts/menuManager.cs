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
        if(levelNum == 24)
        {
            levelNumber.text = "(Level 24)";
        }
        else
        {
            levelNumber.text = $"(Level {levelNum + 1})";
        }
        
    }
    public void start()
    {

        SceneManager.LoadScene(1);       
    }
    public void Continue()
    {
        if (levelNum == 24)
        {
            SceneManager.LoadScene(levelNum);
        }
        else
        {
            SceneManager.LoadScene(levelNum + 1);
        }
            
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
        levels[10] = data.level11;
        levels[11] = data.level12;
        levels[12] = data.level13;
        levels[13] = data.level14;
        levels[14] = data.level15;
        levels[15] = data.level16;
        levels[16] = data.level17;
        levels[17] = data.level18;
        levels[18] = data.level19;
        levels[19] = data.level20;
        levels[20] = data.level21;
        levels[21] = data.level22;
        levels[22] = data.level23;
        levels[23] = data.level24;

        levelNum = data.levelNum;
    }
}
