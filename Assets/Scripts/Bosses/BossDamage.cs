using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    [Header("Attack Components")]
    [SerializeField] private float enemyDamage;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Chase Components")]
    public bool chase = false;
    private GameObject player;
    [SerializeField] private Transform startingPoint;

    [Header("Enemy Components")]
    private Rigidbody2D bRb;
    private Animator bAnim;
    private Animator pAnim;
    private SpriteRenderer bSprite;
    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bRb = GetComponent<Rigidbody2D>();
        bAnim = GetComponent<Animator>();
        pAnim = GetComponent<Animator>();
        bSprite = GetComponent<SpriteRenderer>();
        bAnim.SetBool("isChasing", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInSight())
        {   
            if(cooldownTimer >= attackCooldown)
            {
                Debug.Log("player in range");
                cooldownTimer = 0;
                bAnim.SetTrigger("kAttack");
                pAnim.SetTrigger("pAttack");
            }
        }
    }
    
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        
        if(hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();
        
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.TakeDamage(enemyDamage);
        }
    }
}

    
