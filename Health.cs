using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;

    private void Awake() {
        currentHealth=startHealth;
        anim=GetComponent<Animator>();
    }

    public void TakeDamage(float damage){
        currentHealth = Mathf.Clamp(currentHealth - damage,0,startHealth);
        //currentHealth-=damage;

        if(currentHealth>0){
            anim.SetTrigger("Hurt");
        }
        else{
            if(!dead){
                anim.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled=false;
                dead = true;
            }
        }
    }

}
