using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Animator keyAnimator;
    public Animator eKeyAnimator;
    public Animator robotAnimator;
    public Animator endLevel;

    public Animator blueSwitch;
    public Animator colouredSwitch;
    public Animator magnet;
    public float UITimer;

    public bool introLevel;
    public bool paused;

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
                if (start)
                {
                    keyAnimator.SetBool("In", true);
                }
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    keyAnimator.SetBool("Leave", true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Continue();
        }


        if(UITimer > 0)
        {
            UITimer -= Time.deltaTime;
        }
        
        if (blueSwitch && UITimer <= 0)
        {
            blueSwitch.SetBool("Out", true);
        }
        else if (colouredSwitch && UITimer <= 0)
        {
            colouredSwitch.SetBool("Out", true);
        }
        else if (magnet && UITimer <= 0)
        {
            magnet.SetBool("Out", true);
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        paused = false;
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
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
