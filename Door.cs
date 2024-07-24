using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    [SerializeField] private float detectionRadius = 1f; // Radius within which the door will detect the player

    private Transform player;

    private void Start()
    {
        // Find the player object in the scene
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the distance between the player and the door
            float distance = Vector3.Distance(player.position, transform.position);

            // Check if the player is within the detection radius
            if (distance < detectionRadius)
            {
                // Move the camera based on player's position relative to the door
                if (player.position.x < transform.position.x)
                {
                    cam.MoveToNewRoom(previousRoom);
                }
                else
                {
                    cam.MoveToNewRoom(nextRoom);
                }

                // Optionally, disable the detection after moving the camera
                // enabled = false;
            }
        }
    }
}