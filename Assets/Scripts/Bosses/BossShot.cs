using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float force;
    [SerializeField] private float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, direction.y).normalized * force; 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<PlayerHealth>().TakeDamage(damage);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
