using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float duration;
    [SerializeField] private float power;

    public IEnumerator Knockback(float duration, float power, Transform obj) 
    { 
     float timer = 0; 
     while( timer <= duration ) 
        {   // personal preference: the fixed value we test against goes on the right
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction.normalized * power * Time.deltaTime);
            // wait for the next physics frame before incrementing the timer value
            yield return new WaitForFixedUpdate();
            timer += Time.deltaTime; 
        } 
    }
}