using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Side : MonoBehaviour
{
    [SerializeField] private float movementDisitance
    [SerializeField] private float damage;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
