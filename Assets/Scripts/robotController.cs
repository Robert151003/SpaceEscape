using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class robotController : MonoBehaviour
{
    public Tilemap waterTilemap;
    public CameraShake cameraShake;
    public Animator animator;
    public bool explosion;
    public float timer;

    void Start()
    {
        
    }

    void GetTilesInTilemap()
    {
        BoundsInt bounds = waterTilemap.cellBounds;

        for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
        {
            for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                // Get the world position of the tile
                Vector3 tileWorldPosition = waterTilemap.GetCellCenterWorld(tilePosition);

                TileBase tile = waterTilemap.GetTile(tilePosition);

                if (tile != null)
                {
                    // Calculate distance between tile position and object position in world space
                    float distance = Vector3.Distance(tileWorldPosition, transform.position);



                    if (distance < 2.5f)
                    {
                        StartCoroutine(cameraShake.shake(0.1f, 0.022f));
                    }
                    else if (distance < 3.5f)
                    {
                        StartCoroutine(cameraShake.shake(0.1f, 0.015f));
                    }
                    else if (distance < 4f)
                    {
                        StartCoroutine(cameraShake.shake(0.1f, 0.008f));
                    }
                }
            }
        }
    }
    public void Update()
    {
        if (explosion)
        {
            timer -= Time.deltaTime;   
            if(timer <= 0)
            {
                Destroy(this.gameObject);
            }

        }
        GetTilesInTilemap();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the one you want to destroy
        if (other.CompareTag("Water") || other.CompareTag("Robot"))
        {
            animator.SetBool("Explode", true);
            StartCoroutine(cameraShake.shake(0.5f, 0.3f));
            explosion = true;
        }
    }
}
