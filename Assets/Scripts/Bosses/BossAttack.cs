using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [Header("Attack Components")]
    [SerializeField] private float enemyDamage;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform emitter;
    [SerializeField] private GameObject kShot;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Chase Components")]
    public bool chase = false;
    private GameObject player;
    [SerializeField] private Transform startingPoint;

    [Header("Enemy Components")]
    private Rigidbody2D bRb;
    private Animator bAnim;
    private SpriteRenderer bSprite;
    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bRb = GetComponent<Rigidbody2D>();
        bAnim = GetComponent<Animator>();
        bSprite = GetComponent<SpriteRenderer>();
        bAnim.SetBool("isChasing", false);
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
            bAnim.SetBool("isChasing", true);
        }
        else
        {
            ReturnStartPoint();
            bAnim.SetBool("isChasing", true);

        }

        Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);

        if(cooldownTimer >= attackCooldown)
        {
            Shoot();
            // sfx
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
    
    public void Shoot()
    {
        cooldownTimer = 0;
        Instantiate(kShot, emitter.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            col.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);   
        }
    }
}
