using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumppower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float walljumpcooldown;
    private float horizontalInput;

    [Header("Sounds")]
    public Sound sound;

    public AudioClip jumpsound;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {

        horizontalInput=Input.GetAxis("Horizontal");


        if(horizontalInput>0.01f){
            transform.localScale=Vector3.one;
        }
        else if(horizontalInput<-0.01f){
            transform.localScale= new Vector3(-1,1,1);
        }


        anim.SetBool("Run",horizontalInput!=0);
        anim.SetBool("Grounded",isGrounded());

        if(walljumpcooldown>0.2f){

            body.velocity = new Vector2(horizontalInput*speed,body.velocity.y);

            if(onWall() && !isGrounded()){
                body.gravityScale=0;
                body.velocity=Vector2.zero;
            }
            else{
                body.gravityScale=3;
            }

            if(Input.GetKey(KeyCode.Space)){
                Jump();

                if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){
                    sound.Play(jumpsound);
                }
            }
        }
        else{
            walljumpcooldown+=Time.deltaTime;
        }
    }

    private void Jump(){
        if(isGrounded()){
            anim.SetTrigger("Jump");
            body.velocity=new Vector2(body.velocity.x,jumppower);
        }

        else if(onWall() && !isGrounded()){
            if(horizontalInput==0){
                transform.localScale=new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y,transform.localScale.z);
            }
            else{
                body.velocity=new Vector2(-Mathf.Sign(transform.localScale.x)*3, 6);
            }
            walljumpcooldown=0;
        }
    }


    private bool isGrounded(){
        RaycastHit2D raycastHit= Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider!=null;
    }


    private bool onWall(){
        RaycastHit2D raycastHit= Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,new Vector2(transform.localScale.x,0),0.1f,wallLayer);
        return raycastHit.collider!=null;
    }

    public bool canAttack(){
        return horizontalInput==0 && isGrounded() && !onWall();
    }
}
