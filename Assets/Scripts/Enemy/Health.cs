using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Enemy Health")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float currHealth;

    [Header ("Enemy Flashes")]
    [SerializeField] private float flashDur;
    [SerializeField] private int numofFlash;

    [Header ("Item Drops")]
    [SerializeField] private GameObject[] itemDrops;

    [Header("Enemy Components")]
    private Rigidbody2D sRb;
    //private Animator sAnim;
    private SpriteRenderer sSprite;

    private void Start()
    {
        currHealth = maxHealth;
        sRb = GetComponent<Rigidbody2D>();
        //sAnim = GetComponent<Animator>();
        sSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currHealth = Mathf.Clamp(currHealth - damage, 0, maxHealth);

        if(currHealth > 0)
        {
            StartCoroutine(damageFlash());
            // enemy hurt
        }
        else
        {
            ItemDrop();
            Destroy(gameObject);
        }
    }

    private IEnumerator damageFlash()
    {
        for (int i = 0; i < numofFlash; i++)
        {
            sSprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(flashDur);
            sSprite.color = Color.white;
            yield return new WaitForSeconds(flashDur);
        } 
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
