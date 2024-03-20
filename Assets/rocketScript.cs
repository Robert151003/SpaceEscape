using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{
    public GameObject rocketDoor;
    public Sprite doorClosed;
    public Sprite doorOpen;

    public GameObject camera;

    public GameObject rocket;
    public bool moveRocket;

    public AudioSource rocketSound;

    private void Update()
    {
        if (moveRocket)
        {
            rocket.transform.Translate(Vector3.up * 5 * Time.deltaTime);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){

            StartCoroutine(startRocket(other.gameObject));
            
        }
    }

    void makePlayerChild(GameObject player)
    {
        player.transform.SetParent(rocket.transform);
        player.GetComponent<controller>().canMove = true;
    }

    IEnumerator startRocket(GameObject other)
    {
        rocketSound.Play();
        rocketDoor.GetComponent<SpriteRenderer>().sprite = doorClosed;
        makePlayerChild(other.gameObject);
        yield return new WaitForSeconds(1f);
        camera.GetComponent<CameraShake>().shake(5f, 2f);
        moveRocket = true;
        
    }
}
