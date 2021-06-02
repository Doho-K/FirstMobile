using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public float speed = 10f;
    public float jump = 18f;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultiplier;

    public LayerMask ground;
    public LayerMask deathGround;

    public AudioSource jumpSound;

    public GameManager GameManager;

    private bool touch;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        mileStoneCount = mileStone;
    }


    void Update()
    {
        if(Input.touchCount>0&& Input.GetTouch(0).phase == TouchPhase.Began)//if player touch screen
        {
            touch = true;
        }
        bool dead = Physics2D.IsTouchingLayers(coll, deathGround);//check whether character is dead or not

        if (dead)
        {
            GameOver();
        }
        if (transform.position.x > mileStoneCount)//if player is over current milestonecount
        {
            mileStoneCount += mileStone;//increase milestonecount
            speed = speed * speedMultiplier;//increase speed
            mileStone += mileStone * speedMultiplier;//increase milestone

        }
        rb.velocity = new Vector2(speed, rb.velocity.y);//player move
        bool grounded = Physics2D.IsTouchingLayers(coll, ground);//if player touching ground
        if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space)||touch)//if player click,press space bar or touch
        {
            if (grounded)//if player is touching ground
            {
                touch = false;
                jumpSound.Play();
                rb.velocity = new Vector2(speed, jump);//jump
            }
        }
        anim.SetBool("Grounded", grounded);
    }

    void GameOver()
    {
        GameManager.GameOver();
    }
}
