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

    public AudioSource deathSound;
    public AudioSource jumpSound;

    public GameManager GameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        mileStoneCount = mileStone;
    }


    void Update()
    {
        bool dead = Physics2D.IsTouchingLayers(coll, deathGround);

        if (dead)
        {
            GameOver();
        }
        if (transform.position.x > mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplier;
            mileStone += mileStone * speedMultiplier;

        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
        bool grounded = Physics2D.IsTouchingLayers(coll, ground);
        if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                jumpSound.Play();
                rb.velocity = new Vector2(speed, jump);
            }
        }
        anim.SetBool("Grounded", grounded);
    }

    void GameOver()
    {
        GameManager.GameOver();
    }
}
