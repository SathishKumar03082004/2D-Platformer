using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentposX;
    private Vector3 velocity = Vector3.zero;


    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookahead;

    private void Update()
    {
        transform.position = new Vector3(player.position.x+ lookahead, transform.position.y,transform.position.z);
        lookahead=Mathf.Lerp(lookahead,(aheadDistance*player.localScale.x),Time.deltaTime*speed);
    }

    public void MoveToNewRoom(Transform newroom)
    {
        currentposX = newroom.position.x;
    }
}
