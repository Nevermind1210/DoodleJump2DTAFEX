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
            collision.gameObject.GetComponent<PlayerController>().AnimDelay();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            UIScoreHandler.score += 1;
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
