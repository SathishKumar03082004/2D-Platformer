using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    [SerializeField] private float detectionRadius = 1f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance < detectionRadius)
            {
                if (player.position.x < transform.position.x)
                {
                    cam.MoveToNewRoom(previousRoom);
                }
                else
                {
                    cam.MoveToNewRoom(nextRoom);
                }
            }
        }
    }
}