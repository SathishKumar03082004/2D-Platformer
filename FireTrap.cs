using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float activtionDelay;
    [SerializeField] private float activateTime;
    [SerializeField] private float damage;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;
    private bool active;

    [Header("Sounds")]
    public Sound sound;
    public AudioClip firetrapSound;

    private void Awake() {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            if(!triggered){
                StartCoroutine(ActivateFiretrap());
            }
            if(active){
                other.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator ActivateFiretrap(){
        triggered=true;
        spriteRend.color=Color.red;
        yield return new WaitForSeconds(activtionDelay);
        sound.Play(firetrapSound);
        spriteRend.color=Color.white;
        active=true;
        anim.SetBool("Activated", true);

        yield return new WaitForSeconds(activateTime);
        active=false;
        triggered=false;
        anim.SetBool("Activated",false);
    }
}
