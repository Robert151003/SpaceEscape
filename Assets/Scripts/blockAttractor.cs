using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockAttractor : MonoBehaviour
{
    // Create a list to store game objects with the "block" tag
    private List<GameObject> blockList = new List<GameObject>();

    public GameObject particleSystem;

    // Variable to check if the blocks should move
    private bool shouldMoveBlocks = false;

    void Start()
    {
        // Call a method to find and add objects with the "block" tag
        FindAndAddBlocks();
        //particleSystem.Stop();
    }

    void Update()
    {        
        // Check for user input or any other condition to trigger the movement or stop movement
        // For example, you can call MoveBlocksTowardsSelf on one button press and StopMovingBlocks on another
       

        // Optionally, you can continuously move the blocks as long as shouldMoveBlocks is true
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

            // Set the speed at which the block moves (you can adjust this value)
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
        // You can add any additional logic here if needed
        // For now, we'll simply stop the movement by setting shouldMoveBlocks to false
        shouldMoveBlocks = false;
        particleSystem.SetActive(false);
    }
}
