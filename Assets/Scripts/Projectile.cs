using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float rotationSpeed = 90f;
    [SerializeField] float projectileDamage = 50f;

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void Move()
    {

        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();
        if (health && attacker)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        } 
    }
}
