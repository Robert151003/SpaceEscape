using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject otherPortal;
    public Transform robotTeleportPosition;
    public Transform boxTeleportPosition;
    private bool isTeleporting = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTeleporting)
        {
            if (other.CompareTag("Robot"))
        {
                isTeleporting = true;
                TeleportObject(other.transform, otherPortal.GetComponent<Portal>().robotTeleportPosition.transform);
            }
            else if (other.CompareTag("Block"))
            {
                isTeleporting = true;
                TeleportObject(other.transform, otherPortal.GetComponent<Portal>().boxTeleportPosition.transform);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Robot") || other.CompareTag("Block"))
        {
            isTeleporting = false;
        }
    }

    public void TeleportObject(Transform objTransform, Transform transformPos)
    {
        objTransform.transform.position = transformPos.position;
        isTeleporting = false;
    }
}
