using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float attackerDamage = 20f;
    float currentSpeed;
    Animator attackerAnim;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().CountAttackers();
    }

    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();

        if (levelController != null) { levelController.DecrementAttackers(); }
    }
    private void Start()
    {
        attackerAnim = GetComponent<Animator>();
        currentSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
       
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        attackerAnim.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void DealDamageToDefender(float amount)
    {
        if(!currentTarget) { return; }
        currentTarget.GetComponent<Health>().DealDamage(amount);
    }

    public void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            attackerAnim.SetBool("isAttacking", false);
        }
    }

}
