using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float attackerDamage = 20f;
    float currentSpeed;

    private void Start()
    {
        currentSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Move(currentSpeed);
        Debug.Log(currentSpeed);
    }

    private void Move(float speed)
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Defender defender = other.GetComponent<Defender>();
        if (defender != null)
        {
            currentSpeed = 0f;
        }

        //    var defender = other.GetComponent<Defender>();
        //    var defenderHealth = other.GetComponent<Health>();
        //    if (defender && defenderHealth)
        //    {

        //        defenderHealth.DealDamage(attackerDamage);
        //        Destroy(gameObject);
        //    }
        //}
    }


}
