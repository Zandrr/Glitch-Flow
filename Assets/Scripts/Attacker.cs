using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float attackerDamage = 20f;
    float currentSpeed = 1f;


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{

        //SetMovementSpeed(0);
        //var defender = other.GetComponent<Defender>();
        //var defenderHealth = other.GetComponent<Health>();
        //if (defender && defenderHealth)
        //{

        //    defenderHealth.DealDamage(attackerDamage);
        //    Destroy(gameObject);
        //}
    //}

}
