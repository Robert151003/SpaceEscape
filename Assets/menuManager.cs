using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public void start()
    {
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {
        SceneManager.LoadScene(1);
        //make it so that it loads up the players last level left off
        //grey button when the player has not completed level 1
    }
    public void levelSelector()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        //have levels grey out (unclickable) if the previous is not complete
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
}
