using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currHealth;

    private void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDamage(float damage)
    {
        currHealth -= damage;
        if(currHealth <= 0)
        {
            //Destroy(gameObject);
        }
    }
}
