using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    [SerializeField] protected float attackInterval;

    protected float attackTimer;
    
    protected virtual void Awake()
    {
        attackTimer = attackInterval;
    }

    protected virtual void Update() 
    {
        Attack();
    }

    protected virtual void Attack()
    {
        attackTimer -= Time.deltaTime;
    }
}
