using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public void pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void settings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void back()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
