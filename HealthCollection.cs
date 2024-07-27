using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollection : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [Header ("Sounds")]
    public Sound sound;
    public AudioClip pickupsound;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            sound.Play(pickupsound);
            other.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
