using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health Component")]
    [SerializeField] private float maxHealth;
    public float currHealth { get; private set; }
    private bool dead;

    [Header ("iFrames")]
    [SerializeField] private float invulDuration;
    [SerializeField] private int numofFlashes;

    [Header ("Player Component")]
    private Animator dAnim;
    private SpriteRenderer dSprite;

    private void Start()
    {
        currHealth = maxHealth;
        dAnim = GetComponent<Animator>();
        dSprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
    

    public void TakeDamage(float damage)
    {
        currHealth = Mathf.Clamp(currHealth - damage, 0, maxHealth);
        
        if (currHealth > 0)
        {
            dAnim.SetTrigger("Hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!dead)
            {
                StartCoroutine(GameEnd());
            }
        }
    }

    public void AddHealth(float value)
    {
        currHealth = Mathf.Clamp(currHealth + value, 0, maxHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numofFlashes; i++)
        {
            dSprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invulDuration / (numofFlashes * 2));
            dSprite.color = Color.white;
            yield return new WaitForSeconds(invulDuration / (numofFlashes * 2));
        }   
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private IEnumerator GameEnd()
    {
        dAnim.SetTrigger("Die");
        if(GetComponent<PlayerMovement>() != null)
            GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);
    }
}
