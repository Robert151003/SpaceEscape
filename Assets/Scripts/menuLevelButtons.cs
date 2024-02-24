using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuLevelButtons : MonoBehaviour
{
    public int levelNum;
    public GameObject menuManager;

    private void Update()
    {
        if (menuManager.GetComponent<menuManager>().levels[levelNum - 2])
        {
            this.GetComponent<Button>().interactable = true;
            this.GetComponent<Image>().color = new Color(0.6650944f, 1, 0.8071122f, 1);
        }
        else
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<Image>().color = new Color(0.6650944f, 1, 0.8071122f, 0.8f);
        }
    }
}
