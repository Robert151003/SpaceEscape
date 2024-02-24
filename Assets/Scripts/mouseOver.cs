using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouseOver : MonoBehaviour
{
    public void OnPointerEnter()
    {
        Debug.Log("Mouse is over the UI element");
        transform.localScale = new Vector3(2.5f, 2.5f, 2f);
    }

    public void OnPointerExit()
    {
        Debug.Log("Mouse has exited the UI element");
        transform.localScale = new Vector3(1.852114f, 1.852114f, 1.852114f);
    }
}
