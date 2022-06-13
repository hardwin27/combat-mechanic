using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDummyAttackController : DummyAttackController
{
    [SerializeField] private Gun _gun;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void AttackHandler()
    {
        base.AttackHandler();
        _gun.Shoot();
    }
}
