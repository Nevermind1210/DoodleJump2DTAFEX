using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            //collision.gameObject.GetComponent<Animator>().SetTrigger("Landing");
            collision.gameObject.GetComponent<PlayerController>().AnimDelay();
            UIHandler.score += 1;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
              //  gameObject.GetComponent<Animator>().SetTrigger("Jumping");
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
