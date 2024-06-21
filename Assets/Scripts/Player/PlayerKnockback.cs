using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKnockback : MonoBehaviour
{
    public float knockbackForce = 10f;  // Force of the knockback
    public float knockbackDuration = 0.2f;  // Duration of the knockback effect
    public float knockbackHeight = 1f;  // Height of the knockback (optional)

    private Rigidbody2D rb;
    private Vector2 knockbackDirection;
    private float knockbackStartTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if knockback duration has elapsed
        if (Time.time < knockbackStartTime + knockbackDuration)
        {
            // Apply knockback force in the opposite direction from the enemy
            rb.velocity = knockbackDirection * knockbackForce;
        }
        else
        {
            // Stop knockback effect
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Store the enemy's position to determine knockback direction
            Vector2 direction = (transform.position - collision.transform.position).normalized;

            // Start knockback effect
            knockbackDirection = direction;
            knockbackStartTime = Time.time;
        }
    }
}