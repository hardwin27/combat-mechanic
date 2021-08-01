using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDummy : Dummy
{
    [SerializeField] private Gun gun;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update() 
    {
        base.Update();   
    }

    protected override void Attack()
    {
        base.Attack();
        if(attackTimer <= 0)
        {
            attackTimer = attackInterval;
            gun.Shoot();
        }
    }
}
