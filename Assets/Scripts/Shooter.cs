using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;

    AttackerSpawner myLaneSpawner;
    Animator cactusAnimator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    // Start is called before the first frame update
    private void Start()
    {
        cactusAnimator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) { projectileParent = new GameObject(PROJECTILE_PARENT_NAME); }
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsAttackerInLane())
        {
            cactusAnimator.SetBool("IsAttacking", true);
            cactusAnimator.SetBool("IsAttacking", true);
        }
        else
        {
            cactusAnimator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void CreateProjectile()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
