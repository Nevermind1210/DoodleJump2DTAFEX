using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    public Vector2 vel; // the velocity of player
    public float moveSpeed = 10;
    public Rigidbody2D rb;
    private float moveX;
    private Animator anim;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
    }

    //Triggers on impact with platform
    public void AnimDelay()
    {
        anim.SetTrigger("Landing");
        Invoke("Bounce", 0.1f);
    }

    void Bounce()
    {
        anim.SetTrigger("Jumping");

        Invoke("FallDelay", 0.75f);

    }
    
    void FallDelay()
    {
        anim.SetTrigger("Falling");
    }
    

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
}
