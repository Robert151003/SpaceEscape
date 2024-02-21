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
            this.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
    }
}
