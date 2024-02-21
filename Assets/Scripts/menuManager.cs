using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;

    public bool[] levels;

    public void Start()
    {
        LoadPlayer();
    }
    public void start()
    {
        SceneManager.LoadScene(1);       
    }
    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
    public void levelSelector()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void loadLevel(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }
    public void back()
    {
        pauseMenu.SetActive(false);
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

    }
}
