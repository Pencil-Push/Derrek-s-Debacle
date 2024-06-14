using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player Components")]
    private Rigidbody2D rb;
    private Animator dAnim;

    [Header ("Move Components")]
    [SerializeField] private float moveSpeed;
    private Vector2 _movement;
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dAnim = GetComponent<Animator>();
    }

    void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = _movement * moveSpeed;

        dAnim.SetFloat(_horizontal, _movement.x);
        dAnim.SetFloat(_vertical, _movement.y);

        if(_movement != Vector2.zero)
        {
            dAnim.SetFloat(_lastHorizontal, _movement.x);
            dAnim.SetFloat(_lastVertical, _movement.y);
        }
    }  
}
