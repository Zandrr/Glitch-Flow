using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCollider : MonoBehaviour
{
   // PlayerHealth health;
    int baseDamage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Attacker>())
        {
            FindObjectOfType<PlayerHealth>().ReducePlayerHealth(baseDamage);
        }

        Destroy(other.gameObject);
    }
}
