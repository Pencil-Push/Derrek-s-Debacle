using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player Components")]
    private Rigidbody2D rb;
    //private Animator dAnim;

    [Header ("Move Components")]
    [SerializeField] private float moveSpeed;
    private Vector2 _movement;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = _movement * moveSpeed;
    }
}
