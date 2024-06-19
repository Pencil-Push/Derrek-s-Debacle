using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWaterGun : MonoBehaviour
{
    [SerializeField] private ParticleSystem upgradeEffect;
    [SerializeField] private Transform playerPosition;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Debug.Log("Upgrade Triggered");
            PlayerCombat.canShoot = true;
            Instantiate(upgradeEffect, playerPosition);
            Destroy(gameObject);
        }
    } 
}
