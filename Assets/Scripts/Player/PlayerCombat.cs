using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header ("Attack Components")]
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRange;
    //[SerializeField] private float attackDistance;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;

    [Header ("Player Components")]
    private Rigidbody2D rb;
    private Animator dAnim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //attackPoint.transform.localPosition = transform.forward;

        if(Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        dAnim.SetBool("isAttacking", true);
        yield return null;
        dAnim.SetBool("isAttacking", false);
        yield return null;
    }

    void AttackComponents()
    {
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
