using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttackController : MonoBehaviour
{
    [SerializeField] protected float _attackInterval;

    protected float _attackTimer;

    protected virtual void Awake()
    {
        _attackTimer = _attackInterval;
    }

    protected virtual void Update()
    {
        AttackTimerHandler();
    }

    protected virtual void AttackTimerHandler()
    {
        _attackTimer -= Time.deltaTime;
        if (_attackTimer <= 0)
        {
            _attackTimer = _attackInterval;
            AttackHandler();
        }
    }

    protected virtual void AttackHandler() { }
}
