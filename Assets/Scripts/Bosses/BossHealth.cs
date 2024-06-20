using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header ("Boss Health")]
    [SerializeField] private float maxHealth;
    public float currHealth { get; private set; }

    [Header ("Boss Flashes")]
    [SerializeField] private float flashDur;
    [SerializeField] private int numofFlash;

    [Header ("Item Drops")]
    [SerializeField] private GameObject[] itemDrops;

    [Header("Boss Components")]
    private Rigidbody2D bRb;
    private Animator bAnim;
    private SpriteRenderer bSprite;

    private void Start()
    {
        currHealth = maxHealth;
        bRb = GetComponent<Rigidbody2D>();
        bAnim = GetComponent<Animator>();
        bSprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currHealth = Mathf.Clamp(currHealth - damage, 0, maxHealth);

        if(currHealth > 0)
        {
            StartCoroutine(damageFlash());
            bAnim.SetTrigger("Hurt");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator damageFlash()
    {
        for (int i = 0; i < numofFlash; i++)
        {
            bSprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(flashDur);
            bSprite.color = Color.white;
            yield return new WaitForSeconds(flashDur);
        } 
    }
}
