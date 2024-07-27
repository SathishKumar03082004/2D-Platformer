using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iframeDuration;
    [SerializeField] private int numberoffFlashes;
    private SpriteRenderer spriteRend;

    [Header("Sounds")]
    public AudioClip deathsound;
    public AudioClip hurtsound;
    public Sound sound;

    private void Awake() {
        currentHealth=startHealth;
        anim=GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage){
        currentHealth = Mathf.Clamp(currentHealth - damage,0,startHealth);

        if(currentHealth>0){
            anim.SetTrigger("Hurt");
            StartCoroutine(Invunerability());
            sound.Play(hurtsound);
        }
        else{
            if(!dead){
                anim.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled=false;
                dead = true;
                sound.Play(deathsound);
                StartCoroutine(Deadback());
            }
        }
    }

    public void AddHealth(float value){
        currentHealth = Mathf.Clamp(currentHealth + value,0,startHealth);
    }

    private IEnumerator Invunerability(){
        Physics2D.IgnoreLayerCollision(10,11,true);

        for(int i=0;i<numberoffFlashes;i++){
            spriteRend.color=new Color(1,0,0,0.5f);
            //yield return new WaitForSeconds(iframeDuration / (numberoffFlashes*2));// 2 sec/3*2 == 0.66sec
            yield return new WaitForSeconds(0.3f);
            spriteRend.color= Color.white;
            yield return new WaitForSeconds(0.3f);
            //yield return new WaitForSeconds(iframeDuration / (numberoffFlashes*2));
        }
        Physics2D.IgnoreLayerCollision(10,11,false);
    }

    private IEnumerator Deadback(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Lose");
    }

}
