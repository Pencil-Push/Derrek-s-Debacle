using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public BossAttack[] bossArray;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            foreach (BossAttack boss in bossArray)
            {
                boss.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            foreach (BossAttack boss in bossArray)
            {
                boss.chase = false;
            }
        }
    }
}
