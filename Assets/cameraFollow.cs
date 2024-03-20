using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public GameObject doorblocker;
    public bool follow;


    private void Update()
    {
        if (follow)
        {
            camera.transform.position = new Vector3(player.transform.position.x, -0.18f, -10);
            doorblocker.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            follow = true;
        }
    }
}
