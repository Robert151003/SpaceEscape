using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Animator keyAnimator;
    public Animator eKeyAnimator;
    public Animator robotAnimator;
    public Animator endLevel;

    public bool introLevel;

    public GameObject pauseMenu;
    public GameObject player;

    public bool start;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            introLevel = true;
        }
    }
    void Update()
    {
        if (start)
        {
            if (introLevel)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    keyAnimator.SetBool("Leave", true);
                }
            }
        }        
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
