using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        LevelController level = FindObjectOfType<LevelController>();
        health -= damage;

        if(health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return health;
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject particleEffect = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(particleEffect, 1f);
    }

}
