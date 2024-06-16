using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [Header("Attack Components")]
    [SerializeField] private float enemyDamage;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Chase Components")]
    public bool chase = false;
    private GameObject player;
    [SerializeField] private Transform startingPoint;

    [Header("Enemy Components")]
    private Rigidbody2D sRb;
    private Animator sAnim;
    private SpriteRenderer sSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sRb = GetComponent<Rigidbody2D>();
        sAnim = GetComponent<Animator>();
        sSprite = GetComponent<SpriteRenderer>();
        sAnim.SetBool("isChasing", false);
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(player == null)
        {
            return;
        }

        if(chase == true)
        {
            Chase();
            sAnim.SetBool("isChasing", true);
        }
        else
        {
            ReturnStartPoint();
            sAnim.SetBool("isChasing", true);
        }

        Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);

        if(cooldownTimer >= attackCooldown)
        {
            //attack method
            //audio
        }
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, enemySpeed * Time.deltaTime);
    }

    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
    }
    */
}
