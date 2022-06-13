using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    private Animator _animator;

    private float _attackCooldown = 0.5f;
    private float _attackTimer = 0f;

    [SerializeField] PlayerAttackTriggerController _attackTriggerController;
    private List<Rigidbody2D> _enemies;

    [SerializeField] PlayerHitAreaController _hitAreaController;
    private float _counterDuration = 1.0f;
    private float _counterTimer = 0.0f;

    private Vector2 _attackForce = new Vector2(1.0f, 1.0f);

    private float _dodgeCooldown = 0.0f;
    private float _dodgeTimer = 0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AttackHandler();
        DodgeHandler();
        CounterAttackHandler();
    }

    private void AttackHandler()
    {
        if (_attackTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (_counterTimer > 0)
                {
                    _animator.Play("CounterAttack");
                    _attackTimer = _attackCooldown;
                    _counterTimer = 0.0f;
                    _attackForce = new Vector2(1.5f, 1.5f);
                }
                else
                {
                    _animator.Play("SwordAttack");
                    _attackTimer = _attackCooldown;
                    _attackForce = new Vector2(1.0f, 1.0f);
                }

            }

        }
        else
        {
            _attackTimer -= Time.deltaTime;
            _enemies = _attackTriggerController.Enemies;
            if (_enemies.Count > 0)
            {
                foreach (Rigidbody2D enemy in _enemies)
                {
                    enemy.AddForce(new Vector2(_attackForce.x * transform.localScale.x, _attackForce.y));
                }
            }
        }
    }

    private void DodgeHandler()
    {
        if (_dodgeTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                _animator.Play("Dodge");
                _dodgeTimer = _dodgeCooldown;
            }

        }
        else
        {
            _dodgeTimer -= Time.deltaTime;
        }
    }

    private void CounterAttackHandler()
    {
        if (_hitAreaController.IsCountering)
        {
            _counterTimer = _counterDuration;
        }

        if (_counterTimer > 0)
        {
            _counterTimer -= Time.deltaTime;
        }
    }
}
