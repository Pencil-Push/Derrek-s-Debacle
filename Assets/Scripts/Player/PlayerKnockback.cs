using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D sRb;
    [SerializeField] private float knockBack;
    [SerializeField] private float knockTime;
    public UnityEvent OnBegin, OnDone;

    private void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position-sender.transform.position).normalized;
        sRb.AddForce(direction * knockBack, ForceMode2D.Impulse);
        StartCoroutine(KnockCo());
    }

    private IEnumerator KnockCo()
    {
        yield return new WaitForSeconds(knockTime);
        sRb.velocity = Vector3.zero;
        OnDone?.Invoke();
    }
}
