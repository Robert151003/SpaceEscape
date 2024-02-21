using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockAttractor : MonoBehaviour
{
    private List<GameObject> blockList = new List<GameObject>();
    public GameObject particleSystem;
    private bool shouldMoveBlocks = false;

    void Start()
    {
        FindAndAddBlocks();
    }

    void Update()
    {        
        if (shouldMoveBlocks)
        {
            MoveBlocksTowardsSelf();
        }
    }

    public void FindAndAddBlocks()
    {
        // Find all game objects with the "block" tag
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        // Add the found objects to the list
        foreach (GameObject block in blocks)
        {
            blockList.Add(block);
        }
    }

    public void MoveBlocksTowardsSelf()
    {
        // Get the position of the object this script is attached to
        Vector3 targetPosition = transform.position;

        // Move each block towards the target position
        foreach (GameObject block in blockList)
        {
            // Calculate the direction towards the target position
            Vector3 direction = (targetPosition - block.transform.position).normalized;

            // Set the speed at which the block moves
            float speed = 1f;

            // Move the block towards the target position
            block.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void moveBlocks()
    {
        shouldMoveBlocks = true;
        particleSystem.SetActive(true);
    }

    public void StopMovingBlocks()
    {
        shouldMoveBlocks = false;
        particleSystem.SetActive(false);
    }
}
