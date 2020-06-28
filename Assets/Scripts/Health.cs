using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject attackerDeathVFX;

    Projectile projectile;

    private void Start()
    {
        projectile = FindObjectOfType<Projectile>();
    }


    public void DealDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!attackerDeathVFX) { return; }
        GameObject particleEffect = Instantiate(attackerDeathVFX, transform.position, transform.rotation);
        Destroy(particleEffect, 1f);
    }

}
