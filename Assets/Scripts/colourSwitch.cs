using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourSwitch : MonoBehaviour
{
    public string switchName;
    public string blockName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == switchName || other.gameObject.name == blockName)
        {
            this.GetComponent<controllerSwitch>().switchOn.Play();
            this.GetComponent<controllerSwitch>().timer = 0.3f;
            this.GetComponent<controllerSwitch>().startCounting = true;
            this.GetComponent<controllerSwitch>().switchPressed = true;
            this.GetComponent<controllerSwitch>().objectsOnSwitch++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == switchName || other.gameObject.name == blockName){
            this.GetComponent<controllerSwitch>().switchOn.Play();
            this.GetComponent<controllerSwitch>().timer = 0.3f;
            this.GetComponent<controllerSwitch>().startCounting = true;
            this.GetComponent<controllerSwitch>().switchPressed = false;
            this.GetComponent<controllerSwitch>().objectsOnSwitch--;
        }
        
    }
}
